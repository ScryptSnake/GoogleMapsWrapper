using GoogleMapsWrapper.Parsers;
using GoogleMapsWrapper.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapsWrapper.Responses;
public interface IResponse<TResponse> //TResponse: the type of content that the response returns/represents.
{
    public IRequest SentRequest { get; }
    public HttpResponseMessage ResponseMessage { get; }
    public TResponse? Content { get; }

    public T Parse<T>(IParser<T,TResponse> parser);
}
