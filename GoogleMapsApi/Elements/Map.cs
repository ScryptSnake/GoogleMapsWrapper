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
/// <Remarks>It is primarily used as a parameter for methods within the StaticMapsApi. </Remarks>
/// </summary>
public record Map : GoogleMapElement
{
    ///<summary>The type or style of map to be rendered by the API.///</summary>
    public MapTypes MapType { get; init; } = MapTypes.Hybrid;

    ///<summary>Scale type of the map./// </summary>
    public MapScaleTypes Scale { get; init; }

    ///<summary>Desired file format for an image of the map./// </summary>
    public MapImageFormats ImageFormat { get; init; } = MapImageFormats.Jpg;

    /// <summary>
    /// Sets the center of the map when rendered on the StaticMapsAPI. 
    /// </summary>
    public GpsCoordinate? Center { get; init; }

    private readonly int zoom = 1;
    ///<summary>A zoom value for which the map should be displayed. 
    /// Accepts values: 0 to 21, where zero (default) is considered 'omitted'. 
    /// If omitted from a StaticMapsApi request, the Google API determines a zoom that best fits the map. 
    ///</summary>
    public int Zoom
    {
        get => zoom;
        init
        {
            if (value<0 || value > 21) 
                throw new ArgumentOutOfRangeException("Invalid zoom value.");
            zoom = value;
        }
    }

    ///<summary>A string describing the size dimensions of the map. Format is:  {Height}x{Width}</summary>
    public string Dimensions
    {
        get => $"{Height}x{Width}";
        init
        {
            try
            {
                this.Height = int.Parse(value.Split('x')[0]);
                this.Width = int.Parse(value.Split('x')[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse dimension string.");
            }
        }
    }
    
    /// <summary>
    /// Constructs a new instance of a map.
    /// </summary>
    public Map()
    {
        // Set default 'Dimensions' property.
        Dimensions = "640x640";
    }
}
