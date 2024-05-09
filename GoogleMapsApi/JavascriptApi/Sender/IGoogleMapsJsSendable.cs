using GoogleMapsWrapper.JavascriptApi.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Sender
{
    public interface IGoogleMapsJsSendable
    {
        public Task AddMarkerAsync(BoundMarker boundMarker);
        public Task RemoveMarkerAsync(BoundMarker boundMarker);
        public Task UpdateMarkerAsync(BoundMarker boundMarker);  
    }
}
