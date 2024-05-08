using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Types;
using GoogleMapsWrapper.JavascriptApi.Elements;

namespace GoogleMapsWrapper.JavascriptApi.Listener
{
    public interface IGoogleMapsJavascriptListener
    {

        //Raised by the JS handlers after parsing
        event EventHandler<BrowserErrorEventArgs> OnError;

        event EventHandler<MapClickEventArgs> OnMapClick;
        event EventHandler<MapClickEventArgs> OnMapDblClick;
        event EventHandler<MapClickEventArgs> OnMapRightClick;

        event EventHandler<MarkerClickEventArgs> OnMarkerClick;
        event EventHandler<MarkerClickEventArgs> OnMarkerDblClick;
        event EventHandler<MarkerClickEventArgs> OnMarkerRightClick;

        event EventHandler<MarkerDragEventArgs> OnMarkerDrag;

        event EventHandler<MarkerMouseEventArgs> OnMarkerMouseOver;
        event EventHandler<MarkerDragEventArgs> OnMarkerMouseOut;


        //JS handlers, called by JS directly
        public void _OnMapClick(string? coord, string? clickType);
        public void _OnMarkerClick(string? id, string? clickType);
        public void _OnMarkerDrag(string? id, string? coord);
        public void _OnMarkerMouseOver(string? id);
        public void _OnMarkerMouseOut(string? id);




    }
}
