using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Listener
{
    public class MarkerClickEventArgs : EventArgs
    {
        public string Id { get; }
        public MarkerClickEventArgs(string id)
        {
            Id = id;
        }
    }

}
