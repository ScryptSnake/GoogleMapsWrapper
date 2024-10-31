using GoogleMapsWrapper.Parsers;
using GoogleMapsWrapper.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapsWrapper.Responses;
///<Summary>A response from the Api Engine that contains content in <see cref="byte"/>[] form.</Summary>
public class ByteResponse : IResponse<byte[]>
{
    public IRequest SentRequest { get; }

    public HttpResponseMessage ResponseMessage { get; }

    public byte[]? Content { get; }

    ///<Summary>Constructs a new instance of this object.</Summary>
    ///<param>name=sentRequest>The attached request associated with the response.</param>
    ///<param>name=content>The raw byte response returned from the endpoint.</param>
    ///<param>name=responseMessage> The response message from the HttpClient used to send the request.</param>
    public ByteResponse(IRequest sentRequest, byte[] content, HttpResponseMessage responseMessage)
    {
        SentRequest = sentRequest;
        Content = content;
        ResponseMessage = responseMessage;
    }
    public T Parse<T>(IParser<T, byte[]> parser)
    {
        if(this.Content==null)
        { throw new NullReferenceException("Content of response is null."); }
        return parser.Parse(this.Content);
    }
}
