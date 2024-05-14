using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Elements;
using GoogleMapsWrapper.Exceptions;
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
        private bool isBound=false;
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
            isBound = true;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public async Task<ScriptResult> ExecuteScriptAsyncInvoke(string script)
        {
            //this is called from outside UI thread
            Debug.Print("Executing invoke....");
            return await webView.Invoke(async () => await ExecuteScriptAsync(script));
        }

        public async Task<ScriptResult> ExecuteScriptAsync(string script)
        {
            var output = string.Empty;

            Debug.Print("Executing script async...");

            await webView.ExecuteScriptAsync(script);
            var execution = await webView.CoreWebView2.ExecuteScriptWithResultAsync(script);

            Debug.Print("Received result");

            var exception = string.Empty;
            if (execution.Succeeded == false) //Must! check for succeeded first to access Exception.Message;
            {
                exception = execution.Exception.Message;
            }

            //return a script result from the execution
            var result = new ScriptResult(execution.ResultAsJson, execution.Succeeded, exception);
            Debug.Print("ScriptResult=" + result.ToString());
            return result;

            //return new ScriptResult(output, true, "");

        }

        public void Navigate(string html)
        {
            if (!isBound) { throw new InvalidOperationException("No object bound."); };
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
