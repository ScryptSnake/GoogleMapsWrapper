using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Elements;

namespace GoogleMapsJavascriptApi
{
    public interface IGoogleJavascriptMap
    {
        public IReadOnlyList<Marker> Markers { get; }

        public IReadOnlyList<Polyline> Polylines { get; }

        public Task<Marker> AddMarkerAsync(Marker marker);

        public Task<Marker> RemoveMarkerAsync(Marker marker);

        public Task<Polyline> AddPolylineAsync(Polyline polyline);

        public Task<Polyline> RemovePolyline(Polyline polyline);

        public Task<Map> SetMapAsync(Map map);





    }
}
