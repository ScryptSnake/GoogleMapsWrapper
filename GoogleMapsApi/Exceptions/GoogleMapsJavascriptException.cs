using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Exceptions
{
    public class GoogleMapsJavascriptException : Exception
    {
        public GoogleMapsJavascriptException()
        {
        }

        public GoogleMapsJavascriptException(string message)
            : base(message)
        {
        }

        public GoogleMapsJavascriptException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
