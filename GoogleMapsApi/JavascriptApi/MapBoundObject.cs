using GoogleMapsWrapper.Elements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class MapBoundObject : IMapBoundObject
    {
        public event EventHandler<MarkerEventArgs> OnMarkerAdded;
        public event EventHandler<MarkerEventArgs> OnMarkerRemoved;
        public event EventHandler<MarkerEventArgs> OnMarkerUpdated;



        private IGoogleMapsBrowser browser;

        public MapBoundObject(IGoogleMapsBrowser browser)
        {
            this.browser = browser; 
        }





        public async Task AddMarkerAsync(Marker marker)
        {
            var script = $"addMarker('{marker.Id}', {marker.Coordinate.Latitude}, {marker.Coordinate.Longitude});";
            await browser.ExecuteScriptAsync(script);
        }

        public Task AddPoylineAsync(Polyline polyline)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMarkerAsync(Marker marker)
        {
            throw new NotImplementedException();
        }

        public Task RemovePolylineAsync(Polyline polyline)
        {
            throw new NotImplementedException();
        }

        public Task SetMapAsync(Map map)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMarkerAsync(Marker marker)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePolylineAsync(Polyline polyline)
        {
            throw new NotImplementedException();
        }

        public void _OnDebug(string message)
        {
            throw new NotImplementedException();
        }

        public void _OnMarkerAdded(string latitude, string longitude)
        {
            Debug.Print("Added marker:" + latitude);
            //OnMarkerAdded.Invoke(this,new MarkerEventArgs(id));
        }

        public void _OnMarkerRemoved(string id)
        {
            throw new NotImplementedException();
        }

        public void _OnMarkerUpdated(string id)
        {
            throw new NotImplementedException();
        }
    }

}
