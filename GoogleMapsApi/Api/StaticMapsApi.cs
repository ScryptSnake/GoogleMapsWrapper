using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Api;
using System.Text.Json;
using GoogleMapsWrapper.Containers;
using GoogleMapsWrapper.Parsers;
using System.Data.Common;
namespace GoogleMapsWrapper.Api;

public class StaticMapsApi
{
    private IApiEngine apiEngine;

    private ApiType apiType = ApiType.Maps;


    public StaticMapsApi(IApiEngine engine)
    {
        this.apiEngine = engine;
    }


    public async Task<IResponse<byte[]>> GetMap(Map mapSettings, IEnumerable<Marker>? markers=null, IEnumerable<GoogleMapsWrapper.Elements.Path>? paths=null)
    {
        var url = BuildUrl(mapSettings, markers, paths);

        //build request
        var request = new ApiRequest(url, apiType, RequestType.Geocoding, mapSettings.Id);

        //send request
        var response = await this.apiEngine.GetBytesAsync(request);
        return response;
    }




    private Uri BuildUrl(Map mapSettings, IEnumerable<Marker>? markers = null, IEnumerable<GoogleMapsWrapper.Elements.Path>? paths = null)
    {
        ////Grab the main API Url...
        //var builder = new UriBuilder(apiEngine.Options.BaseUri + "geocode/json");

        ////build query
        //builder.Query = $"?latlng={coordinate.ToString()}";

        return null;
    }



}
