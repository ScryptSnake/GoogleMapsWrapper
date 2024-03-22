//using GoogleMapsWrapper.Types;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Design;
//using System.Diagnostics;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Text;
//using System.Text.Json;
//using System.Text.Json.Nodes;
//using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace GoogleMapsWrapper
//{
//    public class GeocodeRequest : IGoogleMapsApiRequest<JsonDocument, GeocodeContainer>
//    {
//        private HttpClient httpClient;
//        private Uri? requestUri;
//        private HttpResponseMessage? responseMessage;
//        private JsonDocument? jsonResult;
//        private GeocodeContainer? result;

//        public bool IsSuccess
//        {
//            get
//            {
//                if (this.responseMessage != null)
//                {
//                    return responseMessage.IsSuccessStatusCode;
//                }
//                return false;
//            }
//        }

//        public int StatusCode
//        {
//            get
//            {
//                if (this.responseMessage != null)
//                {
//                    return (int)responseMessage.StatusCode;
//                }
//                return 0;
//            }
//        }

//        public Uri? RequestUri => requestUri;

//        public HttpResponseMessage? ResponseMessage => responseMessage;

//        public GeocodeRequest(HttpClient httpClient, Uri requestUri)
//        {
//            this.requestUri = requestUri;
//            this.httpClient = httpClient;
//        }

//        public async Task<JsonDocument> SendAsync()
//        {
//            HttpResponseMessage response = await httpClient.GetAsync(requestUri);
//            var result = await response.Content.ReadAsStringAsync();
//            this.responseMessage = response;
//            jsonResult = JsonDocument.Parse(result);
//            return jsonResult;
//        }


//        public GeocodeContainer? Result => this.result; //this is set only after Parse has been executed.


//        private Dictionary<string, string?> ParseAddressComponents(JsonElement jsonElement)
//        {
//            //assembles a KVP of address related properties from the 'address_components' JSON array.
//            //The array contains 3 properties:  long_name, short_name, types[].
//            //We are interested in the long_name property (= key) and the first element in the types[] array ( = value)
//            var output = new Dictionary<string, string?>();
//            {
//                //loop through address_components array
//                foreach (var arrayElement in jsonElement.EnumerateArray())
//                {
//                    //First item in "types" is 'property name' or key.
//                    string? typeName = arrayElement.GetProperty("types")[0].GetString();
//                    if (string.IsNullOrEmpty(typeName))
//                        throw new System.Text.Json.JsonException($"Type name for address component is empty.");
//                    //long_name property is the 'property value'
//                    var typeValue = arrayElement.GetProperty("long_name").GetString();
//                    //append address component to dictionary
//                    output.Add(typeName, typeValue);
//                }
//                return output;
//            }
//            //output.ToList().ForEach(kvp => Debug.Print($"{kvp.Key}: {kvp.Value}"));
//        }


//        private GpsCoordinate FindGpsCoordinate(JsonElement jsonElement)
//        {
//            //find gps Coordinate in Json result. 
//            // Used by the Parse routine.
//            try
//            {
//                decimal latitude = 0;
//                decimal longitude = 0;
//                if (jsonElement.TryGetProperty("lat", out var latElement) &&
//                    (jsonElement.TryGetProperty("lng", out var lngElement)))
//                {
//                    latElement.TryGetDecimal(out latitude);
//                    lngElement.TryGetDecimal(out longitude);
//                }
//                var output = new GpsCoordinate(latitude, longitude);
//                return output;
//            }
//            catch { throw new System.Text.Json.JsonException("Failed to parse coordinates."); }
//        }


//        public bool TryParse(out GeocodeContainer? output)
//        {
//            try
//            {
//                output = Parse();
//                return true;
//            }
//            catch
//            {
//                output = null;
//                return false;
//            }
//        }



//        public async Task<GeocodeContainer> ParseAsync()
//        {
//            var result = await Task.Run(this.Parse);
//            return result;
//        }


//        public GeocodeContainer Parse()
//        {
//            //create a dictionary to hold retrieved data
//            if (jsonResult == null) throw new NullReferenceException("A JSON Response was not found.");

//            //Grab 'results' array from response
//            JsonElement results = jsonResult.RootElement.GetProperty("results");

//            // Get second item in result, ignore first and others
//            if (results.GetArrayLength() >= 2)
//            {
//                // Access the second result - it is unclear what the other results are expressing. Partial info.
//                JsonElement secondResult = results[1];

//                // find address_components array item in second result, the array contains the bulk of info needed.

//                var data = ParseAddressComponents(secondResult.GetProperty("address_components"));

//                //grab formatted_address property and add to dict.
//                var address = secondResult.GetProperty("formatted_address").GetString();
//                data.Add("formatted_address", address ?? string.Empty);

//                //Serialize back to Json...
//                var json = JsonConvert.SerializeObject(data, Formatting.Indented);

//                //Deserialize into result object
//                var container = JsonConvert.DeserializeObject<GeocodeContainer>(json);

//                if (container == null) throw new System.Text.Json.JsonException("Failed to derserialize geocode response");

//                // Find coordinates and create new container with coords added...
//                var containerWithCoordinates = container with
//                { Coordinates = FindGpsCoordinate(secondResult.GetProperty("geometry").GetProperty("location")),
//                    AssociatedData = this.responseMessage
//                };

//                return containerWithCoordinates ?? throw new JsonSerializationException("Failed to parse.");
//            }
//            else
//            {
//                throw new System.Text.Json.JsonException("Expected 2 results in address components.");
//            }
//        }

//    }
//}








