using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapsWrapper.Exceptions;
public class GoogleMapsApiException : Exception
{
    public GoogleMapsApiException()
    {
    }
    public GoogleMapsApiException(string message)
        : base(message)
    {
    }
    public GoogleMapsApiException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
