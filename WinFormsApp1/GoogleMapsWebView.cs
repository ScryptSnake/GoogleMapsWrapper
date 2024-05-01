using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Elements;
using GoogleMapsWrapper.JavascriptApi;
using GoogleMapsWrapper.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Web.WebView2.WinForms;

namespace WinFormsApp1
{
    internal class GoogleMapsWebView : IGoogleMapsBrowser
    {

        private const string htmlTemplatePath = "C:\\GoogleMapsApi\\GoogleMapsApi\\JavascriptApi\\GoogleMapsJavascriptTemplate.html";


        private IMapBoundObject boundObject;
        public IMapBoundObject BoundObject { get => boundObject; }


        private WebView2 webView;


        private string html = string.Empty;
        public string Html { get => html; }


        private IConfiguration configuration;

        public GoogleMapsWebView(WebView2 webViewControl, IConfiguration config)
        {
            this.webView = webViewControl;
            this.configuration = config;

            var doc = new HtmlTemplateHelper(htmlTemplatePath);
            var key = config["AppSettings:ApiKey"] ??
                throw new Exception("Configuration invalid. Failed to find key.");
            doc.LoadParameters(key, GpsCoordinate.Parse("41.03930,-77.038393"));
            doc.SetBindingScript("var boundObject = chrome.webview.hostObjects.boundObject;");
            this.html = doc.Content;
        }

 
        public object GetBrowserObject()
        {
            return webView;
        }

        public void BindObject(IMapBoundObject boundObject)
        {
            this.webView.CoreWebView2.AddHostObjectToScript("boundObject", boundObject);
        }


        public void Close()
        {
            throw new NotImplementedException();
        }


        public async Task InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async();
        }

        public void Load()
        {
            webView.CoreWebView2.NavigateToString(this.html);
        }

        public async Task ExecuteScriptAsync(string script)
        {
            await webView.ExecuteScriptAsync(script); 
        }

    }
}
