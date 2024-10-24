﻿using System;
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
/// An abstract base class that contains properties from which map elements derrive.
/// A GoogleMapElement can be defined as a geolocational data type, such as a Map, Marker, or Polyline that is leveraged by the wrapper. 
/// </summary>
public abstract class GoogleMapElement
{
    public string? Name { get; set; }
    public string? Id { get; set; }
    public object? AssociatedData { get; set; }
    public Color Color { get; set; }
    public Color SecondaryColor {  get; set; }
    public bool Visible { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

}
