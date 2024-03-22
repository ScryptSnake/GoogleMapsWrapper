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

        //API_KEY_REDACTED_4-22-24

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

        public async Task<IResponse<TResponse>>SendRequestAsync<TResponse>(IRequest request)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(request.Url);
            TResponse response = new TResponse();





            this.responseMessage = response;
            jsonResult = JsonDocument.Parse(result);
            return jsonResult;
        }






    }
}
