
using GoogleMapsWrapper.Types;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Elements;

public record Polyline : GoogleMapElement
{
    /// <summary> The weight of the line when rendered. In pixels.</summary>
    public int Weight { get; init; } = 5;

    /// <summary> Allows the line to follow the earth's contour.</summary>
    public bool Geodesic { get; init; } = false;

    /// <summary> Label displayed with the marker.</summary>
    public char? Label { get; init; } = '\0';

    /// <summary>
    /// Gets the coordinates contained in the Polyline.
    /// </summary>
    public IReadOnlyCollection<GpsCoordinate> Coordinates
    {
        get => coordinates.AsReadOnly();
    }

    private readonly List<GpsCoordinate> coordinates;

    /// <summary>
    /// Initializes a new Polyline from a set of coordinate objects.
    /// </summary>
    public Polyline(IEnumerable<GpsCoordinate> Coordinates)
    {
        this.coordinates = new List<GpsCoordinate>(Coordinates);

        // Inherited property defaults:
        this.Color = Color.Yellow;
    }

    /// <summary>
    /// Returns true if the Polyline contains zero coordinates.
    /// </summary>
    public bool IsEmpty()
    {
        if (this.coordinates.Count == 0) return true;
        return false;
    }

    /// <summary>
    /// Returns true if the Polyline contains more than 1 coordinate.
    /// </summary>
    public bool IsValid()
    {
        if (this.coordinates.Count > 1) return true;
        return false;
    }

    /// <summary>
    /// Returns a semicolon separated string of coordinates.
    /// </summary>
    public override string ToString()
    {
        return string.Join(';', this.Coordinates);
    }
}
