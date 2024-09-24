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

    //FontWeight: 100 to 900 per API docs
    
    public record MapLabel(
        string Text,
        Color Color,
        double Scale = 1.0,
        int FontWeight = 400,
        Color BackgroundColor = default
        )
    {


        //Constructor for text only, with defaults
        public MapLabel(string Text)
            : this(Text, Color.White) { }


        public string Serialize()
        {
            //force serializer to output hex color, instead of default serailization for Color.
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters = { new JsonColorToHexConverter() }
            };
            return JsonSerializer.Serialize(this,options);
        }




    }


}
