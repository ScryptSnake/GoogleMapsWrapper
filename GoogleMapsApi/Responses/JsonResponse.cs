using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Dynamic;
using GoogleMapsWrapper.Containers;
using GoogleMapsWrapper.Parsers;
using GoogleMapsWrapper.Requests;


namespace GoogleMapsWrapper.Responses;
///<Summary>A response from the Api Engine that contains content in <see cref="JsonDocument"/> form.</Summary>
public class JsonResponse : IResponse<JsonDocument>
{
    public IRequest SentRequest { get;}

    public HttpResponseMessage ResponseMessage { get; }

    public JsonDocument Content { get; }

    ///<Summary>Constructs a new instance of this object.</Summary>
    ///<param>name=sentRequest>The attached request associated with the response.</param>
    ///<param>name=content>The raw http response returned from the endpoint.</param>
    ///<param>name=responseMessage> The response message from the HttpClient used to send the request.</param>
    public JsonResponse(IRequest sentRequest, JsonDocument content, HttpResponseMessage responseMessage)
    {
        Content = content;
        SentRequest = sentRequest;
        ResponseMessage = responseMessage;
    }

    public T Parse<T>(IParser<T,JsonDocument> parser)
    {
        return parser.Parse(Content);
    }
}


















//public class ElevationParser: IParser<ElevationContainer, JsonDocument>
