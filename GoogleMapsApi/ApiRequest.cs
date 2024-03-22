using GoogleMapsWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper
{
    internal class ApiRequest : IRequest
    {
        public string? Id { get; }

        public Uri Url { get; }

        public string Query { get => Url.Query; }
        public ApiType Api { get; }
        public RequestType Category { get; }

        public ApiRequest(Uri Url, ApiType Api, RequestType Category, string? Id = null)
        {
            this.Url = Url;
            this.Api = Api;
            this.Category = Category;
            this.Id = Id;
        }
        public ApiRequest(string Url, ApiType Api, RequestType Category, string? Id = null)
        {
            this.Url = new Uri(Url);
            this.Api = Api;
            this.Category = Category;
            this.Id = Id;
        }

    }
}
