using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Api;
/// <summary>
/// The entry point of the wrapper. Exposes API objects to interact with the endpoint:
/// <para><see cref="GeocodeApi"/></para>
/// <para><see cref="StaticMapsApi"/></para>
/// </summary>
///<Remarks>This object instantiates a new  <see cref="ApiEngine"/> 
/// to send <see cref="IRequest"/>s and return data in form of <see cref="IResponse{TResponse}"/>s.</Remarks>
public class GoogleMapsApi
{
    private ApiEngine engine;

    ///<summary>An instance of the GeocodeApi.// </summary>
    public GeocodeApi GeocodeApi { get; private set; }

    ///<summary>An instance of the StaticMapsApi./// </summary>
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
        // Instantiate a new API engine, provide client and config.
        engine = new ApiEngine(httpClient,config);

        // Construct sub-APIs.
        this.GeocodeApi = new GeocodeApi(engine);
        this.StaticMapsApi = new StaticMapsApi(engine);
    }
}