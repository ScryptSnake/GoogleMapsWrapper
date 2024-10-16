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
public interface IRequest
{
    public string? Id { get; }
    public Uri Url { get; } //note:  Url should not ever contain the API Key!, this is done in the engine and never exposed in a returned reponse.
    public string Query { get; }
    public ApiTypes Api { get; }
    public RequestTypes Category { get; }
}

