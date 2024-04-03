using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Types
{

    ///<summary> Type of API per google. For categorization purposes.</summary>
    public enum ApiType
    {
        //the type of goog
        Maps, Routes, Places, Environment //environment, routes APIs not supported in this wrapper. 
    }


    ///<summary> Type of request. For categorization purposes.</summary>
    public enum RequestType
    {
        StaticMaps, Elevation, Geocoding //there are others, but these are supported. 
    }


    ///<summary> Type of map. 
    public enum MapTypes
    //member names should match string inputs for the API!
    {
        RoadMap, Satellite, Terrain, Hybrid
    }

    ///<summary> Static map image formats.</summary>
    public enum MapImageFormats
    //member names should match string inputs for the API!
    {
        Png, Png32, Gif, Jpg
    }


    /// <summary> Type of scale that a map is displayed at. 1 = normal, 2 = high resolution. </summary>
    public enum MapScaleTypes
    //numeric values should match the API (1 or 2)
    {
        Normal = 1,
        HighRes = 2
    }
 

    /// <summary>
    /// Type of scale that a map is displayed at. 1 = normal, 2 = high resolution.
    ///</summary>
    public enum MarkerSizes
    {
        Tiny, Mid, Small
    }

    /// <summary> Scale type of a marker. </summary>
    public enum MarkerScaleTypes
    {
        Normal = 1,
        Medium = 2,
        Large = 4,
    }


    /// <summary> Anchor type when using a custom static map icon.</summary>
    public enum MarkerIconAnchorTypes
    //member names should match exact string inputs for the API!
    {
        Top, Bottom, Left, Right, Center, TopLeft, TopRight, BottomLeft, BottomRight
    }
}
