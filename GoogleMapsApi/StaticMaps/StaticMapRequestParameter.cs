using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Types;

namespace GoogleMapsWrapper.StaticMaps
{
    public record StaticMapRequestParameter(
               MapTypes MapType = MapTypes.Hybrid,
               MapScaleTypes MapScaleType = MapScaleTypes.HighRes,
               int MapWidth = 640,
               int MapHeight = 640,
               int MapZoom = 0,
               GpsCoordinate MapCenter = default
        )
    { }
}
