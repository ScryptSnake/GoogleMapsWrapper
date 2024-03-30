using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Api
{
    public abstract class GoogleMapsApi
    {
        public ApiType ApiType { get; }
        public IApiEngine Engine { get; }



    }
}
