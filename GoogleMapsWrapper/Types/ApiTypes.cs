using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Types;

///<summary> Type of API per google. For categorization purposes.</summary>
public enum ApiTypes
{
    Maps, Routes, Places, Environment //environment, routes APIs not supported in this wrapper. 
}
