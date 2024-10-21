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
///<Summary>A response from the Api Engine that contains content in JsonDocument form.</Summary>
public class JsonResponse : IResponse<JsonDocument>
{
    private IRequest sentRequest;
    public IRequest SentRequest { get=> sentRequest;}

    private HttpResponseMessage responseMessage;
    public HttpResponseMessage ResponseMessage => responseMessage;

    private JsonDocument content;
    public JsonDocument Content { get=>content; }

    ///<Summary>Constructs a new instance of this object.</Summary>
    ///<param>name=SentRequest>The attached request associated with the response.</param>
    ///<param>name=Content>The raw http response returned from the endpoint.</param>
    ///<param>name=ResponseMessage> The response message from the HttpClient used to send the request.</param>
    public JsonResponse(IRequest SentRequest, JsonDocument Content, HttpResponseMessage ResponseMessage)
    {
        content = Content;
        sentRequest = SentRequest;
        responseMessage = ResponseMessage;
    }
    public T Parse<T>(IParser<T,JsonDocument> parser)
    {
        return parser.Parse(this.content);
    }
}


















//public class ElevationParser: IParser<ElevationContainer, JsonDocument>
