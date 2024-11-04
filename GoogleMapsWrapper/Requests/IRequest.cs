using GoogleMapsWrapper.Requests;
using GoogleMapsWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapsWrapper.Requests;
///<Summary>A type that represents a request to be sent to the engine for HTTP sending.</Summary>
public interface IRequest
{
    public string? Id { get; }
    public Uri Url { get; }
    public string Query { get; }
    public ApiTypes Api { get; }
    public RequestTypes Category { get; }
}

