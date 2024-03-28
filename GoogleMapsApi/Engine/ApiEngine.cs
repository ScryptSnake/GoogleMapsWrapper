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
using GoogleMapsWrapper.Responses;
using GoogleMapsWrapper.Exceptions;
using System.Runtime.InteropServices;
namespace GoogleMapsWrapper.Engine
{

    public class ApiEngine
    {
        private readonly string key;
        private readonly HttpClient httpClient;
        private readonly ApiEngineOptions? options;

        //AIzaSyDHaNIVpQ-Iy02FTY4x2NfpI2zOag_Xwuk

        private const string defaultBaseUri = "https://maps.googleapis.com/maps/api/";
        private Uri baseUri;

        //Constructor
        public ApiEngine(string key, HttpClient httpClient, ApiEngineOptions? options=null) //IHttpClientFactory httpClientFactory)
        {
            this.options = options;
            if (options is not null)
                this.baseUri = options.BaseUri;
            else
                this.baseUri = new Uri(defaultBaseUri);
            
            this.key = key;
            this.httpClient = httpClient;
        }

        public IRequest RequestFactory()
        {

        }






        private async Task<HttpResponseMessage> sendGetRequestAsync(IRequest request)
        // Sends an http request
        {
            var responseMessage = await httpClient.GetAsync(request.Url);
            if (responseMessage.IsSuccessStatusCode == false)
            {
                var message = await responseMessage.Content.ReadAsStringAsync();
                throw new GoogleMapsApiException($"API request returned an invalid response. " +
                $"Status Code: '{responseMessage.StatusCode}' ; Message='{message}'");
            }
            return responseMessage;
        }

        public async Task<IResponse<JsonDocument>> GetJsonAsync(IRequest request)
        {
            var response = await sendGetRequestAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            return new JsonResponse(request, JsonDocument.Parse(result), response);
        }

        public async Task<IResponse<byte[]>> GetBytesAsync(IRequest request)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(request.Url);
            var result = await responseMessage.Content.ReadAsByteArrayAsync();
            return new ByteResponse(request, result, responseMessage);
        }




    }
}

