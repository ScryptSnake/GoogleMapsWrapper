using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Elements;
using GoogleMapsWrapper.JavascriptApi;
using GoogleMapsWrapper.JavascriptApi.Browser;
using GoogleMapsWrapper.JavascriptApi.Elements;
using GoogleMapsWrapper.JavascriptApi.Html;
using GoogleMapsWrapper.JavascriptApi.Listener;
using GoogleMapsWrapper.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Web.WebView2.WinForms;

namespace WinFormsApp1
{
    internal class WebViewBrowser : IBrowser
    {
        archit
        public string Html => throw new NotImplementedException();


        private WebView2 webView;
        public WebViewBrowser(WebView2 webViewCtl)
        {
            this.webView = webViewCtl;
            webView.EnsureCoreWebView2Async();
        }

        public void BindObject(string name, object sourceObject)
        {
            webView.CoreWebView2.AddHostObjectToScript(name, sourceObject);
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public async Task ExecuteScriptAsync(string script)
        {
            await webView.ExecuteScriptAsync(script);
        }

        public void Navigate(string html)
        {
            webView.NavigateToString(html);
        }
        public void Navigate(Uri source)
        {
            webView.Source = source;    
        }


        public object SourceObject()
        {
            throw new NotImplementedException();
        }
    }


}
