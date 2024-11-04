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
using GoogleMapsWrapper.Elements;
using GoogleMapsWrapper.Api;


namespace GoogleMapsWrapper.Elements;
/// <summary>
/// Defines a marker (placemark) object and it's characteristics.
/// <remarks>It is primarily used as parameter to methods within the StaticMapsApi.</remarks>
/// </summary>
public record Marker : GoogleMapElement
{
    private char label = '\0'; // Initialize to null character.

    ///<summary> A label applied to the marker.</summary>
    ///<remarks>Accepts values that are alpha-numerical, uppercase only. Single character.</remarks>
    public char Label
    {
        get => label;
        init
        {
            bool isUppercaseAlphanumeric =
                value == '\0' ||                    //allow null
                (value >= 'A' && value <= 'Z') ||   // Check if it's uppercase letter
                (value >= '0' && value <= '9');     // Check if it's digit
            if (!isUppercaseAlphanumeric) 
                throw new FormatException("Invalid character provided for label.");
            label = value;
        }
    }

    ///<summary>Affects the scale of the marker graphic rendered on a static map.</summary>
    public MarkerScaleTypes Scale { get; init; } = MarkerScaleTypes.Normal;

    ///<summary>Affects the scale of the marker graphic rendered on a static map.</summary>
    public MarkerSizes Size { get; init; } = MarkerSizes.Mid;

    ///<summary>A custom icon to represent the marker. </summary>
    public StaticMapCustomIcon? CustomIcon { get; init; }

    ///<summary> The location of the marker. </summary>
    public GpsCoordinate Coordinate { get; init; }
    
    ///<summary> Constructs a new marker instance. </summary>
    
    public Marker(GpsCoordinate Coordinate)
    {
        this.Coordinate = Coordinate;

        // Set default inherited properties.
        Color = Color.Red;
    }
}
