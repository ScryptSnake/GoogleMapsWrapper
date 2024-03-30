using GoogleMapsWrapper.Parsers;
using GoogleMapsWrapper.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Responses
{

    public class ByteResponse : IResponse<byte[]>
    {
        private IRequest sentRequest;
        public IRequest SentRequest { get => sentRequest; }

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

        public T Parse<T>(IParser<T, byte[]> parser)
        {
            return parser.Parse(this.content);
        }
    }
}
