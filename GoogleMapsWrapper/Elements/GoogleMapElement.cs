using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Elements;
/// <summary>
/// An abstract base class that contains properties from which map elements derive.
/// A GoogleMapElement can be defined as a geo-locational data type, such as a map, marker (placemark), or polyline (path) that is leveraged by the wrapper. 
/// </summary>
public abstract record GoogleMapElement
{
    public string? Name { get; init; }
    public string? Id { get; init; }
    public object? AssociatedData { get; init; }
    public Color Color { get; init; }
    public Color SecondaryColor { get; init; }
    public bool Visible { get; init; }
    public int Height { get; init; }
    public int Width { get; init; }

}
