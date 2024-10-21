using GoogleMapsWrapper.Parsers;
using GoogleMapsWrapper.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapsWrapper.Responses;
///<Summary>A response from the Api Engine that contains content in byte[] form.</Summary>
public class ByteResponse : IResponse<byte[]>
{
    private IRequest sentRequest;
    public IRequest SentRequest { get => sentRequest; }

    private HttpResponseMessage responseMessage;
    public HttpResponseMessage ResponseMessage { get => responseMessage; }

    public byte[]? content;
    public byte[]? Content { get=>content; }


    ///<Summary>Constructs a new instance of this object.</Summary>
    ///<param>name=SentRequest>The attached request associated with the response.</param>
    ///<param>name=Content>The raw http response returned from the endpoint.</param>
    ///<param>name=ResponseMessage> The response message from the HttpClient used to send the request.</param>
    public ByteResponse(IRequest SentRequest, byte[] Content, HttpResponseMessage ResponseMessage)
    {
        this.sentRequest = SentRequest;
        this.content = Content;
        this.responseMessage = ResponseMessage;
    }
    public T Parse<T>(IParser<T, byte[]> parser)
    {
        if(this.Content==null)
        { throw new NullReferenceException("Content of response is null."); }
        return parser.Parse(this.Content);
    }
}
