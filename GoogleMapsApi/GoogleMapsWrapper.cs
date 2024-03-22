using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.ComponentModel.Design;
using GoogleMapsWrapper.Types;

namespace GoogleMapsWrapper
{

    public class GoogleMapsWrapper
    {
        private readonly string key;
        private readonly HttpClient httpClient;

        //AIzaSyDHaNIVpQ-Iy02FTY4x2NfpI2zOag_Xwuk

        private const string baseUri = "https://maps.googleapis.com/maps/api/";


        //Constructor
        public GoogleMapsWrapper(string key, HttpClient httpClient) //IHttpClientFactory httpClientFactory)
        {
            this.key = key;
            this.httpClient = httpClient;
        }


        //public async Task<GeocodeRequest>Geocode(GpsCoordinate coordinates)
        //{
        //    var builder = new UriBuilder(baseUri + "geocode/json");
        //    builder.Query = $"latlng={coordinates.Latitude},{coordinates.Longitude}&key={key}";
        //    var response = new GeocodeRequest(this.httpClient, builder.Uri);
        //    await response.SendAsync();
        //    return response;
        //}


        //public async Task<ElevationRequest> GetElevation(GpsCoordinate coordinates)
        //{
        //    //note: the Elevation API supports multiple coordinates along a path, this wrapper supports only a single coordinate. 
        //    var builder = new UriBuilder(baseUri + "elevation/json");
        //    builder.Query = $"locations={coordinates.Latitude},{coordinates.Longitude}&key={key}";
        //    var response = new ElevationRequest(this.httpClient, builder.Uri);
        //    await response.SendAsync();
        //    return response;
        //}






        public async Task<IResponse<JsonDocument>>GetJsonAsync(IRequest request)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(request.Url);
            var result = await responseMessage.Content.ReadAsStringAsync();
            return new JsonResponse(request, JsonDocument.Parse(result), responseMessage);
        }

        public async Task<IResponse<byte[]>> GetBytesAsync(IRequest request)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(request.Url);
            var result = await responseMessage.Content.ReadAsByteArrayAsync();
            return new ByteResponse(request, result, responseMessage);
        }




    }
}
