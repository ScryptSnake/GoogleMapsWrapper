using GoogleMapsWrapper.JavascriptApi.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Browser
{
    public class GoogleMapsReadonlyRepository : IGoogleMapsJsReadonlyRepository
    {

        private IReadOnlyList<BoundMarker> markers;
        public IReadOnlyList<BoundMarker> Markers { get => markers; }

        public GoogleMapsReadonlyRepository(IReadOnlyList<BoundMarker> markers)
        {
            this.markers = markers;
        }

    }
}
