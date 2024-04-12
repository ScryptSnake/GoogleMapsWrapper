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
using Flurl;
namespace GoogleMapsWrapper.Engine
{

    public class ApiEngine : IApiEngine
    {
        private readonly string key;
        private readonly HttpClient httpClient;

        //API_KEY_REDACTED_4-22-24

        private const string defaultBaseUrl = "https://maps.googleapis.com/maps/api/";

        private ApiEngineOptions options = new ApiEngineOptions(new Uri(defaultBaseUrl));
        public ApiEngineOptions Options { set => this.options = value; get => this.options; }


        public ApiEngine(string key, HttpClient httpClient, ApiEngineOptions? options = null)
        {
            this.key = key;
            this.httpClient = httpClient;

            if (options is not null)
            {
                this.Options = options;
            }
        }
        private KeyedRequest CreateKeyedRequest(IRequest request)
        {
            //appends the API key to the request for sending *within* the engine. 


            Debug.Print("inotu====" + request.Url.ToString());


            //var uri = new Flurl.Url(request.Url); //create a new uri
            //uri.SetQueryParam("key", this.key); //note: this will not work because of multiple markers parameters, must manually string-append key

            string url = request.Url.AbsoluteUri + $"&key={this.key}";


            Debug.Print("OUTPUT====" + url.ToString());
            return new KeyedRequest(url, request.Api, request.Category,request.Id); //create keyed req.


        }


        private async Task<HttpResponseMessage> sendGetRequestAsync(KeyedRequest request)
        // Sends an http request
        {
            var responseMessage = await httpClient.GetAsync(request.Url.AbsoluteUri);
            if (responseMessage.IsSuccessStatusCode == false)
            {
                var message = await responseMessage.Content.ReadAsStringAsync();
                Debug.Print(message);
                Debug.Print(request.Url.ToString());    
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

