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
using GoogleMapsWrapper.StaticMaps;

namespace GoogleMapsWrapper.Elements
{

    public class Marker : GoogleMapElement
    {
        public char Label { get; set; }
        public MarkerScaleTypes Scale;
        public MarkerSizes Size;
        public StaticMapCustomIcon? CustomIcon { get; set; }

        public readonly GpsCoordinate Coordinate;

        public override string FillColor => throw new NotSupportedException();  

        public Marker(GpsCoordinate Coordinates, string? Id = null, string? Name = null)
        {
            Coordinate = Coordinates;

            //defaults:
            Color = "red";
            Scale = MarkerScaleTypes.normal;
            Size = MarkerSizes.mid;
        }
    }














}