

using Microsoft.Extensions.Configuration;
using GoogleMapsWrapper.Types;
using GoogleMapsWrapper.JavascriptApi;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private JavascriptApiEngine engine;

        public Form1()
        {
            {


                //Point to the config file. The engine needs a config source that contains: "{AppSettings": {"ApiKey": "INSERT KEY HERE"}}
                var configJson = "C:/GoogleMapsApi/GoogleMapsApi/Configuration/appSettings.json";

                //Create an IConfiguration to be passed to the api.
                var config = new ConfigurationBuilder()
                .AddJsonFile(configJson)
                .Build();


                engine = new JavascriptApiEngine(config, new GpsCoordinate(41.0389390m, -77.39383m));
                engine.DownloadHtml(@"\\Mac\Home\Desktop\TestFile.html");


                InitializeComponent();
            }
        }


        private MapBoundObject bound;


        async void Form1_Load(object sender, EventArgs e)
        {
            //Point to the config file. The engine needs a config source that contains: "{AppSettings": {"ApiKey": "INSERT KEY HERE"}}
            var configJson = "C:/GoogleMapsApi/GoogleMapsApi/Configuration/appSettings.json";

            //Create an IConfiguration to be passed to the api.
            var config = new ConfigurationBuilder()
            .AddJsonFile(configJson)
            .Build();


            await this.webView.EnsureCoreWebView2Async();

            var browser = new GoogleMapsWebView(this.webView, config);
            bound = new MapBoundObject(browser);
            browser.BindObject(bound);  


            await browser.InitializeAsync();

            browser.Load();


            File.WriteAllText(@"\\Mac\\Home\\Desktop\\outputtt.html", browser.Html);


        }

        private void webView_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bound.AddMarkerAsync(new GoogleMapsWrapper.Elements.Marker(GpsCoordinate.Parse("41.04940,-77.03839"), "poop")).Wait();
            Debug.Print("Adding marker from script?");
        }
    }
}
