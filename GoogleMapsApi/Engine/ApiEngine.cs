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
using GoogleMapsWrapper.Requests;
using System.Net.WebSockets;
namespace GoogleMapsWrapper.Engine
{

    public class ApiEngine : IApiEngine
    {
        private readonly string key;
        private readonly HttpClient httpClient;

        //API_KEY_REDACTED_4-22-24

        private const string defaultBaseUrl = "https://maps.googleapis.com/maps/api/";

        //Constructor
        public ApiEngine(string key, HttpClient httpClient, ApiEngineOptions? options = null)
        {
            this.key = key;
            this.httpClient = httpClient;

            if (options is not null)
            {
                this.Options = options;
            }
        }

        private ApiEngineOptions options = new ApiEngineOptions(new Uri(defaultBaseUrl));
        public ApiEngineOptions Options { set => this.options = value; get => this.options; }





        private KeyedRequest CreateKeyedRequest(IRequest request)
        {
            //appends the API key to the request for sending *within* the engine. 
            var builder = new UriBuilder(request.Url);
            builder.Query = builder.Query + $"&key={this.key}";

            return new KeyedRequest(builder.Uri, request.Api, request.Category,request.Id);
        }

        private async Task<HttpResponseMessage> sendGetRequestAsync(KeyedRequest request)
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
            var response = await sendGetRequestAsync(CreateKeyedRequest(request));
            var result = await response.Content.ReadAsStringAsync();
            return new JsonResponse(request, JsonDocument.Parse(result), response);
        }

        public async Task<IResponse<byte[]>> GetBytesAsync(IRequest request)
        {
            var response = await sendGetRequestAsync(CreateKeyedRequest(request));
            var result = await response.Content.ReadAsByteArrayAsync();
            return new ByteResponse(request, result, response);
        }





    }
}

