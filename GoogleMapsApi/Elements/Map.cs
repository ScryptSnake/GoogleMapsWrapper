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

        private MapTypes mapType;
        public MapTypes MapType { get => mapType; set => value=mapType; }

        private MapScaleTypes scale;
        public MapScaleTypes Scale { get => scale; set => value = scale; } 

        private MapImageFormats imageFormat;
        public MapImageFormats ImageFormat { get => imageFormat; set => value = imageFormat; }

        private int height;
        public int Height { get => height; set => value = height; }

        private int width;
        public int Width { get => width; set => value = width; }

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
                try
                {
                    this.Height = int.Parse(value.Split('X')[0]);
                    this.Width = int.Parse(value.Split('X')[1]);
                }
                catch
                {
                    throw new ArgumentException("Failed to parse dimension string.");
                }
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

        private GpsCoordinate? center;
        public GpsCoordinate? Center { get => center; set => value = center; }


        public Map(MapTypes MapType, MapScaleTypes Scale = MapScaleTypes.HighRes, 
            GpsCoordinate? Center = null, string? Id = null, string? Name = null)
        {
            //note: map styles not supported in this API.

            this.MapType = MapType;
            this.Scale = Scale;
            this.Center = Center;
            this.Id = Id;
            this.Name = Name;


            //defaults:
            this.Scale = MapScaleTypes.HighRes;
            this.Dimensions = "640x640";
            this.ImageFormat = MapImageFormats.Jpg;
        }





    }
}
