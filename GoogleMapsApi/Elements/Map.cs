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
        public MapTypes MapType { get => mapType; set => mapType=value; }


        private MapScaleTypes scale;
        public MapScaleTypes Scale { get => scale; set => scale = value; } 


        private MapImageFormats imageFormat;
        public MapImageFormats ImageFormat { get => imageFormat; set => imageFormat = value; }


        private int zoom = 0;
        public int Zoom //not required for static maps if adding markers/paths.
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

        private string dimensions = string.Empty;
        public string Dimensions
        {
            get => $"{Height}x{Width}";
            set
            {
                try
                {
                    value = value.ToLower();
                    this.Height = int.Parse(value.Split('x')[0]);
                    this.Width = int.Parse(value.Split('x')[1]);
                    dimensions = value;
                }
                catch
                {
                    throw new ArgumentException("Failed to parse dimension string.");
                }
            }
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
