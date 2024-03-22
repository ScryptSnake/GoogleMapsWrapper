using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Dynamic;
using GoogleMapsWrapper.Containers;
using GoogleMapsWrapper.Parsers;
namespace GoogleMapsWrapper
{




    public interface IResponse<TResponse> //TResponse: the type of content returned 
    {
        public IRequest SentRequest { get; }
        public HttpResponseMessage ResponseMessage { get; }
        public TResponse Content { get; }

        public T Parse<T>(IParser<T> parser);
    }




    public class JsonResponse : IResponse<JsonDocument>
    {
        private IRequest sentRequest;
        public IRequest SentRequest => throw new NotImplementedException();

        private HttpResponseMessage responseMessage;
        public HttpResponseMessage ResponseMessage => responseMessage;

        private JsonDocument content;
        public JsonDocument Content { get; }


        public JsonResponse(IRequest SentRequest, JsonDocument Content, HttpResponseMessage ResponseMessage)
        {
            this.content = Content;
            this.sentRequest = SentRequest;
            this.responseMessage = ResponseMessage;

        }

        public T Parse<T>(IParser<T> parser)
        {
            throw new NotImplementedException();
        }
    }







    public class ByteResponse : IResponse<byte[]>
    {
        private IRequest sentRequest;
        public IRequest SentRequest => throw new NotImplementedException();

        private HttpResponseMessage responseMessage;
        public HttpResponseMessage ResponseMessage => responseMessage;

        private byte[] content;
        public byte[] Content { get; }


        public ByteResponse(IRequest SentRequest, byte[] Content, HttpResponseMessage ResponseMessage)
        {
            this.content = Content;
            this.sentRequest = SentRequest;
            this.responseMessage = ResponseMessage;

        }

        public T Parse<T>(IParser<T> parser)
        {
            parser.Parse()
        }
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
