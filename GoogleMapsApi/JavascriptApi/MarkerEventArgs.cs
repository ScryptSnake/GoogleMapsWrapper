using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi
{
    public class MarkerEventArgs : EventArgs
    {
        public string Id { get; }

        public MarkerEventArgs(string id)
        {
            this.Id = id;
            
        }
    }

}
