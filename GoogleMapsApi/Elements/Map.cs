using GoogleMapsWrapper.StaticMaps;
using GoogleMapsWrapper.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Elements
{
    public class Map : GoogleMapElement
    {
        public MapTypes MapType { get; set; }
        public MapScaleTypes Scale { get; set; }
        public MapImageFormats ImageFormat { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }


        private int zoom = 0;
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


        private string dimensions;
        public string Dimensions
        {
            get => $"{Height}X{Width}";
            set
            {
                this.Height = int.Parse(value.Split('X')[0]);
                this.Width = int.Parse(value.Split('X')[1]);
            }
        }
        public override string? Color
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        public override string? FillColor
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public Map(MapTypes MapType, MapScaleTypes Scale = MapScaleTypes.Normal, 
            GpsCoordinate Center = default, string? Id = null, string? Name = null)
        {
            //note: map styles not supported in this API.

            //defaults:
            Scale = MapScaleTypes.HighRes;
            this.Dimensions = "640x640";
            this.ImageFormat = MapImageFormats.Jpg;
        }





    }
}
