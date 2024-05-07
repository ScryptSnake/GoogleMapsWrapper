using GoogleMapsWrapper.JavascriptApi.Elements;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi;

public interface IGoogleMapsBrowser {

    public object GetBrowserObject();

    public string Html { get; }

    public IGoogleMapsJavascriptRepository Repository { get; }

    public GoogleMapsHtmlTemplate HtmlTemplate { get; }

    public Task LoadAsync();

    public void Close();

    public void AddMarker(BoundMarker marker);

    public void UpdateMarker(BoundMarker marker);



    public void _OnMapClicked(string? json);

    public event EventHandler<MapClickedEventArgs> OnMapClicked;

    public void _OnError(string? error);

    public event EventHandler<EventArgs> OnError;

    public void _OnMarkerClicked(string? json);

    public void _OnMarkerDblClicked(string? json);

    public void _On






}
