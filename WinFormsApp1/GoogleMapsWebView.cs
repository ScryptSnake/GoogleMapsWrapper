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

        private GoogleMapsHtmlTemplate htmlTemplate;
        public GoogleMapsHtmlTemplate HtmlTemplate { get=> htmlTemplate; }


        private WebView2 webView;

        private string html = string.Empty;
        public string Html { get => html; }

        public GoogleMapsWebView(WebView2 webViewControl, GoogleMapsHtmlTemplate template, IMapBoundObject boundObject)
        {
            this.webView = webViewControl;
            this.htmlTemplate = template;
            this.boundObject = boundObject;
        }


        public object GetBrowserObject()
        {
            return webView;
        }

        public void BindObject(IMapBoundObject boundObject)
        {
            if (this.boundObject != null) {

                this.webView.CoreWebView2.AddHostObjectToScript("boundObject", boundObject);
            }
            else
            {
                throw new System.Exception("Browser bound object is already set.");
            }
        }


        public void Close()
        {
            throw new NotImplementedException();
        }


        public async Task LoadAsync()
        {
            await webView.EnsureCoreWebView2Async(); //may need to be called earlier in form_open, for example
            await Task.Run(() =>webView.CoreWebView2.NavigateToString(this.html));
        }

        public async Task ExecuteScriptAsync(string script)
        {
            await webView.ExecuteScriptAsync(script); 
        }


    }
}
