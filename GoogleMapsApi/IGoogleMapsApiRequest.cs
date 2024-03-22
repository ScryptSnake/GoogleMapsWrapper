using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace GoogleMapsWrapper
{


    public interface IResponse<TResponse> //TResponse: the type of content returned 
    {
        public IRequest SentRequest { get; }
        public HttpResponseMessage ResponseMessage { get; }
        public HttpContent Content { get; }
        public TResponse Value { get; }

        //public IContainer Parse(IParser)
    }


    public class JsonResponse : IResponse<JsonDocument>
    {
        private IRequest sentRequest;
        public IRequest SentRequest => throw new NotImplementedException();

        private HttpResponseMessage responseMessage;
        public HttpResponseMessage ResponseMessage => responseMessage;

        private HttpContent content;
        public HttpContent Content => Content;


        private JsonDocument value;
        public JsonDocument Value { get =>  throw new NotImplementedException(); }



        public JsonResponse(HttpContent Content, IRequest SentRequest, HttpResponseMessage ResponseMessage)
        {
            this.content = Content;
            this.sentRequest = SentRequest;
            this.responseMessage = ResponseMessage;

            Task<string> task = Task.Run(async () =>
            {
                return await Content.ReadAsStringAsync();
            });

            var result = task.GetAwaiter().GetResult();
            this.value = JsonDocument.Parse(result);
        }


        public T Parse<T>(IParser<T> parser)
        {
            throw new NotImplementedException();
        }



    }



    public interface IParser<TResult>
    {

        TResult Parse();




    }

    public class ElevationParser : IParser<ElevationContainer>
    {
        public ElevationContainer Parse()
        {
            throw new NotImplementedException();
        }
    }

    //public class ElevationParser: IParser<ElevationContainer, JsonDocument>
}
