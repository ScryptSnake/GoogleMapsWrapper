using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Elements
{
    public class BoundMarkerJsonConverter : JsonConverter<BoundMarker>
    {
        public override BoundMarker Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException(); // Implement if needed
        }

        public override void Write(Utf8JsonWriter writer, BoundMarker value, JsonSerializerOptions options)
        {
            string iconSerialized = value.Icon.Serialize();

            writer.WriteStartObject();

            // Get all properties of the Parent class
            var properties = typeof(BoundMarker).GetProperties();

            // Loop through each property
            foreach (var property in properties)
            {
                // Skip MapIcon property
                if (property.Name == "Icon")
                    continue;

                // Serialize property
                writer.WritePropertyName(property.Name);
                JsonSerializer.Serialize(writer, property.GetValue(value), options);
            }

            // Serialize MapIcon property using its Serialize method
            writer.WritePropertyName("Icon");
            writer.WriteRawValue(value.Icon.Serialize());

            writer.WriteEndObject();


        

        }
    }

}
