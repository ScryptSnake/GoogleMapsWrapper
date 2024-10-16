
using Microsoft.Extensions.Configuration;
using System.Text;
using GoogleMapsWrapper.Api;
using GoogleMapsWrapper.Types;
using GoogleMapsWrapper.Parsers;
using System.Configuration;
using GoogleMapsWrapper.Containers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using GoogleMapsWrapper.Elements;
using GoogleMapsWrapper.Utilities;


namespace ExampleProject;
public partial class MainForm : Form
{
    private IConfiguration config;
    private GoogleMapsApi api { get; set; }

    public MainForm()
    {
        InitializeComponent();
    }


    private void Form1_Load(object sender, EventArgs e)
    {
        LoadFormDefaults();

        //prompt for key, store in class property.
        var apiKey = Microsoft.VisualBasic.Interaction.InputBox("Enter Google Maps API key:");

        //ensure key
        if (string.IsNullOrEmpty(apiKey))
        {
            MessageBox.Show("This application requires a valid API key. Exiting...");
            this.Close();
        }

        //Assemble a json configuration for the backend with the key.
        var jsonConfig = $"{{ \"AppSettings\": {{ \"ApiKey\": \"{apiKey}\" }} }}";

        //Build a quick IConfig for the key to pass to the backend. 
        config = new ConfigurationBuilder().AddJsonStream(new MemoryStream(Encoding.ASCII.GetBytes(jsonConfig))).Build();

        //Create an API wrapper object, pass http client singleton, store in class property.
        api = new GoogleMapsApi(HttpClientSingleton.Instance, config);

    }

    private void LoadFormDefaults()
    {
        //Setup some controls / fill with defaults
        //hide error msg.
        DisplayError(null);

        //default inputs
        tbGeocode.Text = ProgramDefaults.MountRushmoreCoordinate.ToString();
        IList<GpsCoordinate> defaultCoordinates = ProgramDefaults.StaticMapCoordinates();
        lbMarkers.DataSource = defaultCoordinates.Select(c => c.ToString()).ToList();
        panColor.BackColor = Color.YellowGreen;
        //Load map types into combobox
        cbMapType.DataSource = Enum.GetValues(typeof(GoogleMapsWrapper.Types.MapTypes));
        cbMapType.Text = ProgramDefaults.StaticMapType.ToString();

        //Load zoom levels into combobox
        var zoomSource = new List<string>();
        zoomSource.Add("Automatic");
        for (int i = 0; i <= 21; i++)
        {
            zoomSource.Add(i.ToString());
        }
        cbZoom.DataSource = zoomSource;
        cbZoom.SelectedIndex = 0;
    }


    private async void bGeocodeExecute_Click(object sender, EventArgs e)
    {
        try
        {
            ClearGeocodeTab();
            //start progress
            progBar.Visible = true;
            //parse to coordinate type:
            var coordinate = GpsCoordinate.Parse(tbGeocode.Text);
            //Process geocode request:
            var geoResponse = await api.GeocodeApi.GeocodeAsync(coordinate);
            //Store JSON from response:
            var geoJson = geoResponse.Content;
            //Parse response to a geocode container:
            var geoContainer = geoResponse.Parse<GeocodeContainer>(new GeocodeParser());
            //Loop through geocode container, add to listbox:
            foreach (var prop in geoContainer.GetType().GetProperties())
            {
                object propertyValue = prop.GetValue(geoContainer) ?? "[EMPTY]";
                // Add property name and value to the ListBox
                lbGeocodeResults.Items.Add($"{prop.Name}: {propertyValue}");
            }

            //Process elevation request:
            var elevationResponse = await api.GeocodeApi.GetElevationAsync(coordinate);
            //Store JSON from response:
            var elevationJson = elevationResponse.Content;
            //Parse response to a elevation container:
            var elevationContainer = elevationResponse.Parse<ElevationContainer>(new ElevationParser());

            //Loop through elevation container, add to listbox:
            foreach (var prop in elevationContainer.GetType().GetProperties())
            {
                object propertyValue = prop.GetValue(elevationContainer) ?? "[EMPTY]";
                // Add property name and value to the ListBox
                lbGeocodeResults.Items.Add($"{prop.Name}: {propertyValue}");
            }
            //Add JSON from each response to textbox:
            tbGeocodeResponse.Text = $"{geoJson?.RootElement.GetRawText()} /n {elevationJson?.RootElement.GetRawText()}";
            progBar.Visible = false;

            //Add request URLs from each request to textbox:
            lbGeocodeRequests.Items.Add(geoResponse.SentRequest.Url.ToString());
            lbGeocodeRequests.Items.Add(elevationResponse.SentRequest.Url.ToString());
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    private void ClearGeocodeTab()
    {
        //Clears the geocode tab controls
        DisplayError(null);
        lbGeocodeResults.Items.Clear();
        tbGeocodeResponse.Clear();
        lbGeocodeRequests.Items.Clear();
    }

    private void ClearStaticMapsTab()
    {
        //Clears static maps tab controls
        pictureBox1.Image = null; //clear
        lbStaticRequest.Items.Clear();
    }

    private void DisplayError(string? message)
    {
        //display error msg in label at top of form
        if (string.IsNullOrEmpty(message))
        {
            lbError.Visible = false;
        }
        else
        {
            lbError.Visible = true;
            lbError.Text = $"Exception Thrown: {message}";
            progBar.Visible = false;
        }
    }

    private void panColor_DoubleClick(object sender, EventArgs e)
    {
        //color selection control for markers
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            Color selectedColor = colorDialog1.Color;
            panColor.BackColor = selectedColor;
        }
    }

    private void bAddMarker_Click(object sender, EventArgs e)
    {
        //store user entered markers in listbox for static maps
        var newMarker = Microsoft.VisualBasic.Interaction.InputBox("Enter coordinates (decimal degrees)");
        var tryCoord = GpsCoordinate.TryParse(newMarker, out var coord);
        if (tryCoord == true)
        {
            lbMarkers.Items.Add(newMarker);
        }
        else
        {
            MessageBox.Show("Invalid coordinate input.");
        }
    }

    private async void bGenerateMap_Click(object sender, EventArgs e)
    {
        progBar.Visible = true;
        ClearStaticMapsTab();
        //grab the map type from combo box:
        var mapType = (MapTypes)Enum.Parse(typeof(MapTypes), cbMapType.Text);

        //grab marker list from listbox, convert to list of marker elements:
        var markers = new List<Marker>();
        var coordinates = new List<GpsCoordinate>();
        var polylines = new List<Polyline>();

        foreach (var coord in lbMarkers.Items)
        {
            var coordinate = GpsCoordinate.Parse(coord.ToString() ?? "");
            var marker = new Marker(coordinate) { Color = panColor.BackColor };//set the color from control.
            markers.Add(marker);
            coordinates.Add(coordinate);
        }

        if (cbConvertPolyline.Checked)
        {
            polylines.Add(new Polyline(coordinates) { Color = Color.OrangeRed });
        }

        //assemble a Map element to pass to the wrapper:
        var map = new GoogleMapsWrapper.Elements.Map(mapType);
        //check if zoom provided by user:
        var zoomValue = cbZoom.Text;
        if (zoomValue != "Automatic") { map.Zoom = Convert.ToInt32(zoomValue); }
        map.ImageFormat = MapImageFormats.Jpg;

        //process the request:
        var response = await api.StaticMapsApi.GetMapAsync(map, markers, polylines);

        //byte array of image
        var image = response.Content;

        //set to control
        if (image != null)
        {
            MemoryStream ms = new MemoryStream(image);
            pictureBox1.Image = Image.FromStream(ms);
        }

        //display request Uri:
        lbStaticRequest.Items.Add(response.SentRequest.Url.ToString());

        progBar.Visible = false;
    }

    private void bClearMarkers_Click(object sender, EventArgs e)
    {
        lbMarkers.DataSource = null;
    }
}
