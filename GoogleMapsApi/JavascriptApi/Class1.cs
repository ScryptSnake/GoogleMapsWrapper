using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Types;
using GoogleMapsWrapper.JavascriptApi;
using GoogleMapsWrapper.JavascriptApi.Elements;

namespace GoogleMapsWrapper.JavascriptApi
{
    public interface GoogleMapsJavascriptListener
    {

        



        event EventHandler<MarkerEventArgs> OnError;



        public void _OnMapClick(string? coord, string? eventType);
        public void _OnMarkerClick(string? id, string? eventType);
        public void _OnMarkerDragged(string? id, string? coord);
        public void _OnMarkerMouseOver(string? id);
        public void _OnMarkerMouseOut(string? id);   



        //public void _OnMapDblClicked(string? json);  //returns gps coordinate
        //public void _OnMapRightClicked(string? json); //returns gps cordinate

        //public void _OnMarkerClicked(string? json); //returns marker id
        //public void _OnMarkerDblClicked(string? json); //returns marker id
        //public void _OnMarkerRightClicked(string? json); //returns marker id

        //public void _OnMarkerDragged(string? json); // returns marker id, gps coordinate

        //public void _OnMarkerMouseOver(string? json); // returns marker id

        //public void _OnMarkerMouseOut(string? json);  //  returns marker id 





    }
}
