using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Api
{
    public class GoogleMapsApi
    {

        private ApiEngine engine;
        private IConfiguration configuration;

        private GeocodeApi geocodeApi;
        public GeocodeApi GeocodeApi { get => geocodeApi; set => geocodeApi = value; }


        private StaticMapsApi staticMapsApi;
        public StaticMapsApi StaticMapsApi { get => staticMapsApi; set => staticMapsApi = value; }


        public GoogleMapsApi(HttpClient httpClient, IConfiguration config)
        {
            this.engine = new ApiEngine(httpClient,config);
            this.configuration = config;

            //instance properties...
            this.geocodeApi = new GeocodeApi(engine);
            this.staticMapsApi = new StaticMapsApi(engine);


        }




    }
}
