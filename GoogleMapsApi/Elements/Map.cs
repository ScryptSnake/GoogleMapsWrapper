using GoogleMapsWrapper.Api;
using GoogleMapsWrapper.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Elements;
/// <summary>
/// Defines a 'map' object and it's characteristics. 
/// In the context of this application, it is primarily used as a parameter for methods within the StaticMapsApi. 
/// </summary>
public class Map : GoogleMapElement
{
    private MapTypes mapType;
    
     ///<summary>The type or style of map to be rendered by the API.///</summary>
    public MapTypes MapType { get => mapType; set => mapType=value; }


    private MapScaleTypes scale;
    ///<summary>Scale type of the map./// </summary>
    public MapScaleTypes Scale { get => scale; set => scale = value; } 


    private MapImageFormats imageFormat;
    ///<summary>Desired file format for an image of the map./// </summary>
    public MapImageFormats ImageFormat { get => imageFormat; set => imageFormat = value; }

    private int zoom = 0;
    ///<summary>A zoom value for which the map should be displayed. 
    /// Accepts values: 0 to 21, where zero (default) is considered 'ommitted'. 
    /// If ommitted from a StaticMapsApi request, the Google API determines a zoom that best fits the map. 
    ///</summary>
    public int Zoom
    {
        get => zoom;
        set
        {
            if (value>=0 && value <= 21)
            {
                zoom = value;
            }
            else { throw new ArgumentOutOfRangeException("Invalid zoom value."); }
        }
    }

    private string dimensions = string.Empty;

    ///<summary>A string describing the size dimensions of the map. Format is:  {Height}x{Width}</summary>
    public string Dimensions
    {
        get => $"{Height}x{Width}";
        set
        {
            try
            {
                value = value.ToLower();
                this.Height = int.Parse(value.Split('x')[0]);
                this.Width = int.Parse(value.Split('x')[1]);
                dimensions = value;
            }
            catch
            {
                throw new ArgumentException("Failed to parse dimension string.");
            }
        }
    }

    private GpsCoordinate? center;
     ///<summary>The type or style of map to be rendered by the API.///</summary>
    public GpsCoordinate? Center { get => center; set => center=value; }
    
    public Map(MapTypes MapType, MapScaleTypes Scale = MapScaleTypes.HighRes, 
        GpsCoordinate? Center = null, string? Id = null, string? Name = null)
    {
        //note: map styles not supported in this API.
        this.MapType = MapType;
        this.Scale = Scale;
        this.Center = Center;
        this.Id = Id;
    this.Name = Name;
        //defaults:
        this.Scale = MapScaleTypes.HighRes;
        this.Dimensions = "640x640";
        this.ImageFormat = MapImageFormats.Jpg;
    }

}
