﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Engine
{
    internal class KeyedRequest : IRequest 
        //A typical IRequest is converted to a KeyedRequest in the API Engine, by appending the API Key. 
        //It is never exposed outside the engine. 
    {
        public string? Id { get; }
        
        public Uri Url { get; }

        public string Query { get => Url.Query; }
        public ApiType Api { get; }
        public RequestType Category { get; }

        public KeyedRequest(Uri Url, ApiType Api, RequestType Category, string? Id = null)
        {
            this.Url = Url;
            this.Api = Api;
            this.Category = Category;
            this.Id = Id;
        }
        public KeyedRequest(string Url, ApiType Api, RequestType Category, string? Id = null)
        {
            this.Url = new Uri(Url);
            this.Api = Api;
            this.Category = Category;
            this.Id = Id;
        }
    }
}
