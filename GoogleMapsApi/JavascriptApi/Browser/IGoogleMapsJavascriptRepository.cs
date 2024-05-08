using GoogleMapsWrapper.JavascriptApi.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Browser
{
    public interface IGoogleMapsJavascriptRepository
    {

        public void AddMarker(BoundMarker marker);

        public void RemoveMarker(BoundMarker marker);

        public void UpdateMarker(BoundMarker marker);

        public IReadOnlyList<BoundMarker> Markers { get; }




    }
}
