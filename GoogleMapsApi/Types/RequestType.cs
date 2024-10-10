using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Types;
///<summary> Type of request. For categorization purposes.</summary>
public enum RequestType
{
    StaticMaps, Elevation, Geocoding //there are others, but these are supported. 
}
