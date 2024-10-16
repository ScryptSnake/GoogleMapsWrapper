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

namespace GoogleMapsWrapper.Api;
public record StaticMapCustomIcon(Uri Uri, 
    MarkerIconAnchorTypes AnchorType=MarkerIconAnchorTypes.Center)
{
    public StaticMapCustomIcon(string uri, 
        MarkerIconAnchorTypes anchorType=MarkerIconAnchorTypes.Center) : this(new Uri(uri), anchorType)
    {
    }
}