using GoogleMapsWrapper.Containers;
using GoogleMapsWrapper.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Parsers
{
    public class ElevationParser : IParser<ElevationContainer, JsonDocument>
    {

        public bool TryParse(JsonDocument input, out ElevationContainer? output)
        {
            try
            {
                output = Parse(input);
                return true;
            }
            catch
            {
                output = null;
                return false;
            }
        }



        public ElevationContainer Parse(JsonDocument input)
        {
            //create a dictionary to hold retrieved data
            if (input == null) throw new NullReferenceException("A JSON Response was not found.");

            //Grab 'results' array from response
            JsonElement results = input.RootElement.GetProperty("results");

            if (results.GetArrayLength() != 2) //should result an array, then a 'status' of 'OK'
            {
                // Access the first array element in result (the data)
                JsonElement firstResult = results[0]; //contains another array of the data we need.

                //Deserialize into result object
                var container = JsonConvert.DeserializeObject<ElevationContainer>(firstResult.ToString());

                if (container == null) throw new System.Text.Json.JsonException("Failed to derserialize elevation response");


                // Find coordinates and create new container with coords added...
                var containerCopied = container with
                {
                    Coordinates = findGpsCoordinate(firstResult.GetProperty("location")),
                    AssociatedData = input.ToString(),
                    ElevationFeet = container.ElevationMeters * 3.28084d
                };
                return containerCopied ?? throw new JsonSerializationException("Failed to parse elevation.");
            }
            else
            {
                throw new System.Text.Json.JsonException("Expected 2 results in elevation request array: data and status code.");
            }
        }

        private GpsCoordinate findGpsCoordinate(JsonElement jsonElement)
        {
            //find gps Coordinate in Json result. 
            // Used by the Parse routine.
            try
            {
                decimal latitude = 0;
                decimal longitude = 0;
                if (jsonElement.TryGetProperty("lat", out var latElement) &&
                    (jsonElement.TryGetProperty("lng", out var lngElement)))
                {
                    latElement.TryGetDecimal(out latitude);
                    lngElement.TryGetDecimal(out longitude);
                }
                var output = new GpsCoordinate(latitude, longitude);
                return output;
            }
            catch { throw new System.Text.Json.JsonException("Failed to parse coordinates."); }
        }
    }
}
