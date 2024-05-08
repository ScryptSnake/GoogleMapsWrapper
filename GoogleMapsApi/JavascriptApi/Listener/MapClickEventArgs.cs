using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Types;

namespace GoogleMapsWrapper.JavascriptApi.Listener
{
    public class MapClickEventArgs : EventArgs
    {
        GpsCoordinate Coordinates { get; }
        public MapClickEventArgs(GpsCoordinate coordinates)
        {
            Coordinates = coordinates;
        }
    }

}
