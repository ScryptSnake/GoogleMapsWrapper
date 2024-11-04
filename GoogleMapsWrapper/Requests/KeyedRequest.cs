using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Engine;
/// <summary>
/// An <see cref="IRequest"/> which contains the user's API key. This specific request object is used internally by the <see cref="ApiEngine"/>./>
/// </summary>
/// <seealso cref="GoogleMapsWrapper.Requests.IRequest" />
internal class KeyedRequest : IRequest
{
    public string? Id { get; }
    public Uri Url { get; }
    public string Query { get => Url.Query; }
    public ApiTypes Api { get; }
    public RequestTypes Category { get; }
    public KeyedRequest(Uri Url, ApiTypes Api, RequestTypes Category, string? Id = null)
    {
        this.Url = Url;
        this.Api = Api;
        this.Category = Category;
        this.Id = Id;
    }
    public KeyedRequest(string Url, ApiTypes Api, RequestTypes Category, string? Id = null)
    {
        this.Url = new Uri(Url);
        this.Api = Api;
        this.Category = Category;
        this.Id = Id;
    }
}
