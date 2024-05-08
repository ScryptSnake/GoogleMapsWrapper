using GoogleMapsWrapper.JavascriptApi.Elements;
using GoogleMapsWrapper.JavascriptApi.Html;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.JavascriptApi.Listener;

namespace GoogleMapsWrapper.JavascriptApi.Browser;

public interface IGoogleMapsBrowser
{

    public object GetBrowserObject();

    public string Html { get; }

    public IGoogleMapsJavascriptRepository Repository { get; }

    public IGoogleMapsJavascriptListener Listener { get; }

    public GoogleMapsHtmlTemplate HtmlTemplate { get; }

    public Task LoadAsync();

    public void Close();

    public void AddMarker(BoundMarker marker);

    public void UpdateMarker(BoundMarker marker);

    public void BindListener(IGoogleMapsJavascriptListener listener)
    {

    }









}
