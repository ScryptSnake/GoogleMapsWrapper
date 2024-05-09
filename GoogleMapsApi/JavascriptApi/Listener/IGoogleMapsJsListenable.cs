using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Types;
using GoogleMapsWrapper.JavascriptApi.Elements;

namespace GoogleMapsWrapper.JavascriptApi.Listener
{

    public interface IGoogleMapsJsListenable
    {

        //Published by JS subscriber methods
        //event EventHandler<BrowserErrorEventArgs>? OnError;

        event EventHandler<MapClickEventArgs>? OnMapClick;
        event EventHandler<MapClickEventArgs>? OnMapDblClick;
        event EventHandler<MapClickEventArgs>? OnMapRightClick;

        event EventHandler<MarkerClickEventArgs>? OnMarkerClick;
        event EventHandler<MarkerClickEventArgs>? OnMarkerDblClick;
        event EventHandler<MarkerClickEventArgs>? OnMarkerRightClick;

        event EventHandler<MarkerDragEventArgs>? OnMarkerDrag;

        event EventHandler<MarkerMouseEventArgs>? OnMarkerMouseOver;
        event EventHandler<MarkerMouseEventArgs>? OnMarkerMouseOut;


        //published by JS subscribers, called by JS directly

        public void _OnError(string message);   

        public void _OnMapClick(string coordinate);
        public void _OnMapDblClick(string coordinate);  
        public void _OnMapRightClick(string coordinate);


        public void _OnMarkerClick(string id);
        public void _OnMarkerDblClick(string id);
        public void _OnMarkerRightClick(string id);


        public void _OnMarkerDrag(string id, string coordinate);
        public void _OnMarkerMouseOver(string id);
        public void _OnMarkerMouseOut(string id);




    }
}
