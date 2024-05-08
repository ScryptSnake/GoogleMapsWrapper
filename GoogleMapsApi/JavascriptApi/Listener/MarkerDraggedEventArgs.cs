using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Listener
{
    public class MarkerDragEventArgs : EventArgs
    {
        public string Id { get; }
        public GpsCoordinate Coordinates { get; }
        public MarkerDragEventArgs(string id, GpsCoordinate coordinates)
        {
            Id = id;
            Coordinates = coordinates;
        }
    }

}
