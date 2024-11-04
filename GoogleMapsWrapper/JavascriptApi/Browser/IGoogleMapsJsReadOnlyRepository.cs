using GoogleMapsWrapper.JavascriptApi.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Browser
{
    /// <summary>
    /// A repository for storing map state. Data is loaded into this object by IGoogleMapsJsRepository
    /// </summary>
    public interface IGoogleMapsJsReadonlyRepository
    {
        public IReadOnlyList<BoundMarker> Markers { get; }

    }
}
