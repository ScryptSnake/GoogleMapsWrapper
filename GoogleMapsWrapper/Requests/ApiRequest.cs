using GoogleMapsWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Requests;
///<Summary>Defines a request to be sent to the engine for HTTP sending.</Summary>
///<Remarks>Note: This object's Uri property should never contain the user's API key.</Remarks>
internal class ApiRequest : IRequest
{
    public string? Id { get; }
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
