using GoogleMapsWrapper.JavascriptApi.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Browser
{
    /// <summary>
    /// Defines the minimum requirements needed for a 
    /// browser-like object to interact with an IGoogleMapsBrowser.
    /// </summary>
    public interface IBrowser
    {
        public object SourceObject();

        public string Html { get; }

        public void BindObject(string name, object sourceObject);

        public void Navigate(string html);

        public void Navigate(Uri source);

        public Task<ScriptResult> ExecuteScriptAsync(string script);

        public Task<ScriptResult> ExecuteScriptAsyncInvoke(string script);

        public void Close();

    }
}
