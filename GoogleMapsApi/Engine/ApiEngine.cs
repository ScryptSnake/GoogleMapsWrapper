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

/// <summary>
/// An implementation of <see cref="IApiEngine"/> to send <see cref="IRequest"/>s
/// and return data in form of <see cref="IResponse{TResponse}"/>s.
/// </summary>
/// <remarks>This layer of the application operates closest to the endpoint
/// by using <see cref="HttpClient"/> to send HTTPGet requests.</remarks>
public class ApiEngine : IApiEngine
{
    private readonly string key;
    private readonly HttpClient httpClient;

    public string BaseUrl { get; } = "https://maps.googleapis.com/maps/api/";

    private IConfiguration configuration;
    public ApiEngine(HttpClient httpClient, IConfiguration config)
    {
        this.configuration = config;
        this.key = config["AppSettings:ApiKey"] ?? 
            throw new Exception("Configuration invalid. Failed to find key.");
        this.httpClient = httpClient;
    }

    /// <summary>
    /// Converts a request object to a keyed request by appending the key to the request's URI to send to the endpoint.
    /// </summary>
    private KeyedRequest CreateKeyedRequest(IRequest request)
    {
        // Appends the API key to the request for sending *within* the engine. 
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

