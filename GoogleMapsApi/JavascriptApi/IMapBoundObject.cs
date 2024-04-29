using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsJavascriptApi
{
    public interface IMapBoundObject
    {
        public Task SetMapBorderAsync(Color Color, int Weight = 5, int Radius = 0);

        public Task FitMapAsync();





        public Task AddMarkerAsync(string markerId, string latitude, string longitude);

        public Task AddPolylineAsync(string id, string coordinates, string color, decimal opacity, int weight);








    }
}
