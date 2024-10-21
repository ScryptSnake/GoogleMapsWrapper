using GoogleMapsWrapper.Containers;
using GoogleMapsWrapper.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace GoogleMapsWrapper.Parsers;
///<Summary>A parser for an Elevation API JSON response. Parses data and outputs an ElevationContainer.</Summary>
public class ElevationParser : IParser<ElevationContainer, JsonDocument>
{

    ///<Summary>Attempts to parse a JSON document.</Summary>
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
    ///<Summary>Parses a JSON document, stores output in an ElevationContainer.</Summary>
    public ElevationContainer Parse(JsonDocument input)
    {
        // Validate input.
        if (input == null) throw new NullReferenceException("A JSON Response was not found.");

        // Grab 'results' array from JsonDocument.
        JsonElement results = input.RootElement.GetProperty("results");

        // 'results' array should contain 2 values:  the data of interest; a status value of 'OK'
        if (results.GetArrayLength() != 2)
        {
            // Access the first array element in result (the data).
            JsonElement firstResult = results[0];

            // Deserialize to the container.
            var container = JsonConvert.DeserializeObject<ElevationContainer>(firstResult.ToString());
            if (container == null) throw new System.Text.Json.JsonException("Failed to derserialize elevation response");

            // Find coordinates in JSON document. Manually add to a new copy of the container.
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


    ///<Summary>Extracts the GpsCoordinate from a JsonElement. 
    ///<para>Note:This method supplements the containerization operation in Parse() because the serializer cannot deserialize to this type. </para>
    ///</Summary>
    private GpsCoordinate findGpsCoordinate(JsonElement jsonElement)
    {
        try
        {
            // Initialize decimals.
            decimal latitude = 0;
            decimal longitude = 0;
            // Attempt to grab 'lat'/'lng' properties. 
            if (jsonElement.TryGetProperty("lat", out var latProperty) &&
                (jsonElement.TryGetProperty("lng", out var lngProperty)))
            {
                // Attempt to parse prop values to decimal.
                latProperty.TryGetDecimal(out latitude);
                lngProperty.TryGetDecimal(out longitude);
            }
            // Attempt to parse decimal to GpsCoordinate.
            var output = new GpsCoordinate(latitude, longitude);
            return output;
        }
        catch { throw new System.Text.Json.JsonException("Failed to parse coordinates."); }
    }
}
