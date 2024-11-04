using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GoogleMapsWrapper.Utilities;
using static System.Formats.Asn1.AsnWriter;

namespace GoogleMapsWrapper.JavascriptApi.Elements
{

    public record MapSvgIcon(
        string SvgPath,
        Color Color,
        double Scale = 1.0,
        Color OutlineColor = default,
        double OutlineWeight = 1.0,
        double Opacity = 1.0
        )
    {

        public string Serialize()
        {
            //force serializer to output hex color, instead of default serailization for Color.
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters = { new JsonColorToHexConverter() }
            };
            return JsonSerializer.Serialize(this,options);
        }


        public static MapSvgIcon PinIcon(Color color, double scale = 1.0)
        {
            const string path = "M16 0C7.16 0 0 6.94 0 15.5 0 25.39 16 48 16 48s16-22.61 16-32.5C32 6.94 24.84 0 16 0zm0 22c-2.76 0-5-2.24-5-5s2.24-5 5-5 5 2.24 5 5-2.24 5-5 5z";
            return new MapSvgIcon(path, color, scale);
        }

        public static MapSvgIcon CircleHollowIcon(Color color, double scale = 1.0)
        {
            const string path = "M50,10A40,40 0 1,1 50,90A40,40 0 1,1 50,10M50,18A32,32 0 1,0 50,82A32,32 0 1,0 50,18Z";
            return new MapSvgIcon(path, color,scale);
        }

        public static MapSvgIcon CircleIcon(Color color, double scale = 1.0)
        {
            const string path = "M50,10A40,40 0 1,1 50,90A40,40 0 1,1 50,10Z";
            return new MapSvgIcon(path, color,scale);
        }


    }


}
