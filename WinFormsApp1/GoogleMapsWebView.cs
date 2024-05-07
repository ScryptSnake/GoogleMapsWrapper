using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Elements;
using GoogleMapsWrapper.JavascriptApi;
using GoogleMapsWrapper.JavascriptApi.Elements;
using GoogleMapsWrapper.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Web.WebView2.WinForms;

namespace WinFormsApp1
{
    internal class GoogleMapsWebView : IGoogleMapsBrowser
    {

        private const string htmlTemplatePath = "C:\\GoogleMapsApi\\GoogleMapsApi\\JavascriptApi\\GoogleMapsJavascriptTemplate.html";


        private IGoogleMapsJavascriptRepository repository;
        public IGoogleMapsJavascriptRepository Repository { get => repository; }

        private GoogleMapsHtmlTemplate htmlTemplate;
        public GoogleMapsHtmlTemplate HtmlTemplate { get=> htmlTemplate; }


        private WebView2 webView;


        public event EventHandler<MapClickedEventArgs> OnMapClicked = delegate { };
        public event EventHandler<EventArgs> OnError = delegate { };

        public string Html { get => HtmlTemplate.Html; }

        public GoogleMapsWebView(WebView2 webViewControl, GoogleMapsHtmlTemplate template, IGoogleMapsJavascriptRepository repository)
        {
            this.webView = webViewControl;
            this.htmlTemplate = template;
            this.repository = repository;
        }


        public object GetBrowserObject()
        {
            return webView;
        }


        public void Close()
        {
            throw new NotImplementedException();
        }

        public async Task LoadAsync()
        {
            await webView.EnsureCoreWebView2Async(); //may need to be called earlier in form_open, for example
            webView.CoreWebView2.NavigateToString(this.HtmlTemplate.Html);
        }






        public void AddMarker(BoundMarker marker)
        {
            webView.ExecuteScriptAsync($"addMarker({marker.Serialize()})");
            repository.AddMarker(marker);   
        }

        public void UpdateMarker(BoundMarker marker)
        {
            throw new NotImplementedException();
        }




        public void _OnMapClicked(string? json)
        {
            throw new NotImplementedException();
        }
        public void _OnError(string? error)
        {
            throw new NotImplementedException();
        }
        public void _OnM(string error)
        {
            throw new NotImplementedException();
        }



    }
}
