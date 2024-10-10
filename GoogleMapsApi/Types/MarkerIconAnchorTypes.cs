using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Types;
/// <summary> Anchor type when using a custom static map icon.</summary>
public enum MarkerIconAnchorTypes
//member names should match exact string inputs for the API!
{
    Top, Bottom, Left, Right, Center, TopLeft, TopRight, BottomLeft, BottomRight
}
