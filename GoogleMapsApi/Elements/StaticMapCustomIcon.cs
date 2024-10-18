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

// TODO: Validate file format?

namespace GoogleMapsWrapper.Api;
///<summary>An object that represents a custom icon for a marker. The source must be a Uri of an image.</summary>
public record StaticMapCustomIcon(Uri Uri, 
    MarkerIconAnchorTypes AnchorType=MarkerIconAnchorTypes.Center)
{
    public StaticMapCustomIcon(string uri, 
        MarkerIconAnchorTypes anchorType=MarkerIconAnchorTypes.Center) : this(new Uri(uri), anchorType)
    {
    }
}
