using GoogleMapsWrapper.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoogleMapsWrapper
{
    public class ElevationRequest : IGoogleMapsApiRequest<JsonDocument, ElevationContainer>
    {
        private HttpClient httpClient;
        private Uri? requestUri;
        private HttpResponseMessage? responseMessage;
        private JsonDocument? jsonResult;
        private GeocodeContainer? result;

        public bool IsSuccess
        {
            get
            {
                if (this.responseMessage != null)
                {
                    return responseMessage.IsSuccessStatusCode;
                }
                return false;
            }
        }

        public int StatusCode
        {
            get
            {
                if (this.responseMessage != null)
                {
                    return (int)responseMessage.StatusCode;
                }
                return 0;
            }
        }

        public Uri? RequestUri => requestUri;

        public HttpResponseMessage? ResponseMessage => responseMessage;

        public ElevationRequest(HttpClient httpClient, Uri requestUri)
        {
            this.requestUri = requestUri;
            this.httpClient = httpClient;
        }

        public async Task<JsonDocument> SendAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            var result = await response.Content.ReadAsStringAsync();
            this.responseMessage = response;
            jsonResult = JsonDocument.Parse(result);
            return jsonResult;
        }


        public GeocodeContainer? Result => this.result; //this is set only after Parse has been executed.



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


        public bool TryParse(out ElevationContainer? output)
        {
            try
            {
                output = Parse();
                return true;
            }
            catch
            {
                output = null;
                return false;
            }
        }



        public async Task<ElevationContainer> ParseAsync()
        {
            var result = await Task.Run(this.Parse);
            return result;
        }


        public ElevationContainer Parse()
        {
            //create a dictionary to hold retrieved data
            if (jsonResult == null) throw new NullReferenceException("A JSON Response was not found.");

            //Grab 'results' array from response
            JsonElement results = jsonResult.RootElement.GetProperty("results");

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
                    AssociatedData = this.responseMessage,
                    ElevationFeet = container.ElevationMeters * 3.28084m
                };

                return containerCopied ?? throw new JsonSerializationException("Failed to parse.");
            }
            else
            {
                throw new System.Text.Json.JsonException("Expected 2 results in elevation request array: data and status code.");
            }
        }

    }
}








