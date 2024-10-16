using GoogleMapsWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Requests;
internal class ApiRequest : IRequest
{
    public string? Id { get; }
    //note:  Url should not every contain the API Key!, this is done in the engine and never exposed in a returned reponse.
    public Uri Url { get; } 
    public string Query { get => Url.Query; }
    public ApiTypes Api { get; }
    public RequestTypes Category { get; }
    public ApiRequest(Uri Url, ApiTypes Api, RequestTypes Category, string? Id = null)
    {
        this.Url = Url;
        this.Api = Api;
        this.Category = Category;
        this.Id = Id;
    }
    public ApiRequest(string Url, ApiTypes Api, RequestTypes Category, string? Id = null)
    {
        this.Url = new Uri(Url);
        this.Api = Api;
        this.Category = Category;
        this.Id = Id;
    }
}
