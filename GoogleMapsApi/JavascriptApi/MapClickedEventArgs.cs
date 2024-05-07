using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Types;

namespace GoogleMapsWrapper.JavascriptApi
{
    public class MapClickedEventArgs : EventArgs
    {
        GpsCoordinate Coordinates  { get; }

        public MapClickedEventArgs(GpsCoordinate coordinates)
        {
            this.Coordinates = coordinates;
            
        }
    }

}
