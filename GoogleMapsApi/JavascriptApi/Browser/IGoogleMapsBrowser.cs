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
using GoogleMapsWrapper.JavascriptApi.Sender;

namespace GoogleMapsWrapper.JavascriptApi.Browser;

/// <summary>
/// Defines a browser that interacts directly with the Google Maps Javascript file,
/// via HTML template file. Implements I..Sendable and I...Listenable to send/receive data to and from browser.
/// Recommended usage:  constructor takes params IBrowser and IGoogleMapsJsReadonlyRepository
public interface IGoogleMapsBrowser : IGoogleMapsJsSendable, IGoogleMapsJsListenable
{
    public IBrowser Browser { get; }

    public IGoogleMapsJsReadonlyRepository Repository { get; }

    //public GoogleMapsHtmlTemplate HtmlTemplate { get; }

    public void Navigate(GoogleMapsHtmlTemplate template);

    public void Close();

    



}
