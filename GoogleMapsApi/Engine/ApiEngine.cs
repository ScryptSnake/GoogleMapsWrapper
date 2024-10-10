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
using Microsoft.Extensions.Configuration;


namespace GoogleMapsWrapper.Engine;
public class ApiEngine : IApiEngine
    //The API engine is responsible for receiving IRequests and sending via http GET.
    //The methods in the engine return an IResponse to the caller for processing.
{
    private readonly string key;
    private readonly HttpClient httpClient;

    private string baseUrl = "https://maps.googleapis.com/maps/api/";
    public string BaseUrl { get => baseUrl; }

    private IConfiguration configuration;
    public ApiEngine(HttpClient httpClient, IConfiguration config)
    {
        this.configuration = config;
        this.key = config["AppSettings:ApiKey"] ?? 
            throw new Exception("Configuration invalid. Failed to find key.");
        this.httpClient = httpClient;
    }
    private KeyedRequest CreateKeyedRequest(IRequest request)
    {
        //appends the API key to the request for sending *within* the engine. 
        var uri = new Flurl.Url(request.Url); //create a new uri
        uri.AppendQueryParam("key",this.key);
        Debug.Print("OUTPUT==" + uri.ToString());
        return new KeyedRequest(uri, request.Api, request.Category,request.Id); //create keyed req.
    }
    private async Task<HttpResponseMessage> sendGetRequestAsync(KeyedRequest request)
    // Sends an http request
    {
        var responseMessage = await httpClient.GetAsync(request.Url.AbsoluteUri);
        if (responseMessage.IsSuccessStatusCode == false)
        {
            var message = await responseMessage.Content.ReadAsStringAsync();  
            throw new GoogleMapsApiException($"API request returned an invalid response. " +
            $"Status Code: '{responseMessage.StatusCode}' ; Message='{message}'");
        }
        return responseMessage;
    }

    /// <summary>
    /// Make a GET request to the API endpoint and return a JSON response.
    /// </summary>
    public async Task<IResponse<JsonDocument>> GetJsonAsync(IRequest request)
    {
        var response = await sendGetRequestAsync(CreateKeyedRequest(request));
        var result = await response.Content.ReadAsStringAsync();
        return new JsonResponse(request, JsonDocument.Parse(result), response);
    }
    /// <summary>
    /// Make a GET request to the API endpoint and return a byte array response.
    /// </summary>
    public async Task<IResponse<byte[]>> GetBytesAsync(IRequest request)
    {
        var response = await sendGetRequestAsync(CreateKeyedRequest(request));
        var result = await response.Content.ReadAsByteArrayAsync();
        return new ByteResponse(request, result, response);
    }

}

