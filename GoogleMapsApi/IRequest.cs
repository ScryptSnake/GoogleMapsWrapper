using GoogleMapsWrapper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper
{

    public interface IRequest
    {
        public string? Id { get; }
        public Uri Url { get; }
        public string Query { get; }
        public ApiType Api { get; }
        public RequestType Category { get; }

    }
}
