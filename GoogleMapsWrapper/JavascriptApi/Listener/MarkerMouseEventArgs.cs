using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi
{
    public class MarkerMouseEventArgs : EventArgs
    {
        public string Id { get; }
        public MarkerMouseEventArgs(string id)
        {
            this.Id = id;
        }
    }

}
