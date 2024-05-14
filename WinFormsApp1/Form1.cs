

using Microsoft.Extensions.Configuration;
using GoogleMapsWrapper.Types;
using GoogleMapsWrapper.JavascriptApi.Browser;
using GoogleMapsWrapper.JavascriptApi.Elements;
using GoogleMapsWrapper.JavascriptApi.Html;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private string htmlContent;
        private GoogleMapsHtmlTemplate template;    
        public Form1()
        {
            {


                //Point to the config file. The engine needs a config source that contains: "{AppSettings": {"ApiKey": "INSERT KEY HERE"}}
                var configJson = "C:/GoogleMapsApi/GoogleMapsApi/Configuration/appSettings.json";

                //Create an IConfiguration to be passed to the api.
                var config = new ConfigurationBuilder()
                .AddJsonFile(configJson)
                .Build();

                var templatePath = "C:\\GoogleMapsApi\\GoogleMapsApi\\JavascriptApi\\Html\\GoogleMapsJavascriptTemplate.html";

                var key = config["AppSettings:ApiKey"];

                var html = new GoogleMapsHtmlTemplate(File.ReadAllText(templatePath), 
                    key, "var boundObject = window.chrome.webview.hostObjects.boundObject;");


                template = html;

                InitializeComponent();
            }
        }

        private GoogleMapsBrowser browser;

        async void Form1_Load(object sender, EventArgs e)
        {
            //Point to the config file. The engine needs a config source that contains: "{AppSettings": {"ApiKey": "INSERT KEY HERE"}}
            var configJson = "C:/GoogleMapsApi/GoogleMapsApi/Configuration/appSettings.json";

            //Create an IConfiguration to be passed to the api.
            var config = new ConfigurationBuilder()
            .AddJsonFile(configJson)
            .Build();


            await this.webView.EnsureCoreWebView2Async();



            browser = new GoogleMapsBrowser(new WebViewBrowser(this.webView));

            browser.Navigate(template);


            File.WriteAllText(@"\\Mac\\Home\\Desktop\\outputtt.html", template.Html);

            
        }



        private async void button1_Click(object sender, EventArgs e)
        {


            var marker = new BoundMarker(GpsCoordinate.Parse("41.038930,-77.03839"), "1", Color.Red, "1", true);
            var marker2 = new BoundMarker(GpsCoordinate.Parse("41.138930,-77.93839"), "2!", Color.Red, "2", true);
            var marker3 = new BoundMarker(GpsCoordinate.Parse("41.088930,-77.08839"), "3!", Color.Red, "3", true);

            await browser.AddMarkerAsync(marker);
            //await browser.AddMarkerAsync(marker2);
            //await browser.AddMarkerAsync(marker3);
        }
    }
}
