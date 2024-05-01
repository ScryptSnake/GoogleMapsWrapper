

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


        async void Form1_Load(object sender, EventArgs e)
        {
            Debug.Print("Loading.............");
            await webView.EnsureCoreWebView2Async();

            // Bind a .NET object to JavaScript
            webView.CoreWebView2.AddHostObjectToScript("testBoundObject", new TestBoundObject());

            webView.CoreWebView2.NavigateToString(engine.GetHtml());


        }

        private void webView_Click(object sender, EventArgs e)
        {

        }
    }
}
