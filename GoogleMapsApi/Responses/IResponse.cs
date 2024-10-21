using GoogleMapsWrapper.Parsers;
using GoogleMapsWrapper.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapsWrapper.Responses;
///<Summary>A type that describes a response from an API request.</Summary>
///<Param>name=TResponse>The type of content the response represents.</Param>
public interface IResponse<TResponse>
{
    public IRequest SentRequest { get; }
    public HttpResponseMessage ResponseMessage { get; }
    public TResponse? Content { get; }

    public T Parse<T>(IParser<T,TResponse> parser);
}
