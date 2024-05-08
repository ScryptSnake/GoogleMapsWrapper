using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi
{
    public class BrowserErrorEventArgs : EventArgs
    {
        public string Message { get; }
        public BrowserErrorEventArgs(string message)
        {
            this.Message = message;
        }
    }

}
