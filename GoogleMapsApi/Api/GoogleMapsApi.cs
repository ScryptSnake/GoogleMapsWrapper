using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Api;
/// <summary>
/// The entry point of the wrapper. Sub-API's are exposed:
/// <para><see cref="GeocodeApi"/></para>
/// <para><see cref="StaticMapsApi"/></para>
/// </summary>
public class GoogleMapsApi
{
    private ApiEngine engine;
    public GeocodeApi GeocodeApi { get; private set; }
    public StaticMapsApi StaticMapsApi { get; private set; }

    /// <summary>
    /// Initializes a new instance of the class, using the provided <see cref="HttpClient"/> 
    /// and configuration settings.
    /// </summary>
    /// <param name="httpClient"> An <see cref="HttpClient"/> to be used to process web requests. </param>
    /// <param name="config"> An <see cref="IConfiguration"/> which contains the API key.</param>
    /// 
    public GoogleMapsApi(HttpClient httpClient, IConfiguration config)
    {
        //Instantiate a new API engine, provide client and config.
        engine = new ApiEngine(httpClient,config);

        //Construct sub-APIs.
        this.GeocodeApi = new GeocodeApi(engine);
        this.StaticMapsApi = new StaticMapsApi(engine);
    }
}