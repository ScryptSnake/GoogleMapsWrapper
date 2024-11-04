using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Types;

/// <summary> Type of scale that a map is displayed at. 1 = normal, 2 = high resolution. </summary>
public enum MapScaleTypes
//numeric values should match the API (1 or 2)
{
    Normal = 1,
    HighRes = 2
}
