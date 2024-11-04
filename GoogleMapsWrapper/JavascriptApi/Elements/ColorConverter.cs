using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Elements
{
    class JsonColorToHexConverter : JsonConverter<Color>
    //Allows a C# Color type to be translated to web format (hex) when passed to a serializer
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Dummy implementation for deserialization
            throw new NotSupportedException("Deserialization not supported.");
        }
        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            // Convert to hex notation.
            string hexColor = $"#{value.R:X2}{value.G:X2}{value.B:X2}";

            // write to json output
            writer.WriteStringValue(hexColor);
        }
    }
}
