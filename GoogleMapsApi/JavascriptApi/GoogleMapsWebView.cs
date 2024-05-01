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
    internal class GoogleMapsWebView : IGoogleMapsBrowser<WebView2>
    {

        private const string htmlTemplatePath = "C:\\GoogleMapsApi\\GoogleMapsApi\\JavascriptApi\\GoogleMapsJavascriptTemplate.html";


        private IMapBoundObject boundObject;
        public IMapBoundObject BoundObject { get => boundObject; }


        private WebView2 browserObject;
        public WebView2 BrowserObject { get=>browserObject; }


        private string html = string.Empty;
        public string Html { get => html; }


        private IConfiguration configuration;

        public GoogleMapsWebView(WebView2 browserObject, IConfiguration config)
        {
            this.browserObject = browserObject;
            this.configuration = config;
        }

 


        public void BindObject(IMapBoundObject boundObject)
        {
            throw new NotImplementedException();
        }

        public async Task BindObjectAsync(IMapBoundObject boundObject)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }


        public async Task InitializeAsync()
        {
            await browserObject.EnsureCoreWebView2Async();
        }

        public async Task LoadAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddMarkerAsync(Marker marker)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveMarkerAsync(Marker marker)
        {
            throw new NotImplementedException();
        }

        public async Task SetMarkerAsync(Marker marker)
        {
            throw new NotImplementedException();
        }

        public async Task AddPoylineAsync(Polyline polyline)
        {
            throw new NotImplementedException();
        }

        public async Task RemovePolylineAsync(Polyline polyline)
        {
            throw new NotImplementedException();
        }

        public async Task SetPolylineAsync(Polyline polyline)
        {
            throw new NotImplementedException();
        }

        public async Task SetMapAsync(Map map)
        {
            throw new NotImplementedException();
        }
    }
}
