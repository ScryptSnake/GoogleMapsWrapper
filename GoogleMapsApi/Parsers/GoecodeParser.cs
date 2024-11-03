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
public class GeocodeParser : IParser<GeocodeContainer, JsonDocument>
{
    ///<Summary>Attempts to parse a JsonDocument.</Summary>
    public bool TryParse(JsonDocument input, out GeocodeContainer? output)
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
    ///<Summary>Parses a JsonDocument from a GeocodeResponse to a container.</Summary>
    public GeocodeContainer Parse(JsonDocument input)
    {
        // Validate input.
        if (input == null)
            throw new NullReferenceException("A JSON Response was not found.");

        // Grab 'results' array from the response.
        JsonElement results = input.RootElement.GetProperty("results");

        // Validate length of 'results' array.
        if (results.GetArrayLength() >= 2)
        {
            // Access the second result from 'results' - It is unclear from the web API what the other results are describing. Partial info?
            JsonElement secondResult = results[1];

            // Find 'address_components' array item in second result, the array contains the bulk of info needed.
            // Then, pass to method to parse the array to a dict.
            var data = ParseAddressComponents(secondResult.GetProperty("address_components"));
            
            // Grab formatted_address property and add to dict.
            var address = secondResult.GetProperty("formatted_address").GetString();
            data.Add("formatted_address", address ?? string.Empty);

            // Serialize dict back to Json.
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);

            // Deserialize into result object.
            var container = JsonConvert.DeserializeObject<GeocodeContainer>(json);
            if (container == null) 
                throw new System.Text.Json.JsonException("Failed to derserialize geocode response");

            // Find coordinates and create a copy of container with coordinates added.
            var containerWithCoordinates = container with
            {
                Coordinates = FindGpsCoordinate(secondResult.GetProperty("geometry").GetProperty("location")),
                AssociatedData = input.ToString()
            };
            return containerWithCoordinates ?? throw new JsonSerializationException("Failed to parse.");
        }
        else
        {
            throw new System.Text.Json.JsonException("Expected 2 results in address components.");
        }
    }


    ///<Summary>Parses the 'address_components' JSON array to a Dictionary.
    ///<para>Each value in the argument contains 3 properties: 'long_name', 'short_name', 'types[]'.</para>
    ///<para>This method acquires the 'long_name' (=value), and the first element in the 'types' array (=key).</para>
    ///</Summary>
    private Dictionary<string, string?> ParseAddressComponents(JsonElement jsonElement)
    {
        // Establish a new Dict for output.
        var output = new Dictionary<string, string?>();
        {
            // Loop through the JsonElement.
            foreach (var arrayElement in jsonElement.EnumerateArray())
            {
                // First item in "types[]" is 'property name' or key.
                string? typeName = arrayElement.GetProperty("types")[0].GetString();

                if (string.IsNullOrEmpty(typeName))
                    throw new System.Text.Json.JsonException($"Type name for address component is empty.");

                // 'long_name' property is the value of interest.
                var typeValue = arrayElement.GetProperty("long_name").GetString();

                // Append the KVP to dictionary.
                output.Add(typeName, typeValue);
            }
            return output;
        }
        //output.ToList().ForEach(kvp => Debug.Print($"{kvp.Key}: {kvp.Value}"));
    }


    ///<Summary>Extracts the GpsCoordinate from a JsonElement. 
    ///<Remarks>This method supplements the containerization operation in Parse() because the serializer cannot deserialize to this type.</Remarks>
    ///</Summary>
    private GpsCoordinate FindGpsCoordinate(JsonElement jsonElement)
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
