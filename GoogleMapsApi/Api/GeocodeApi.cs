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
namespace GoogleMapsWrapper.Api;

public class GeocodeApi
{
    private IApiEngine apiEngine;

    private ApiType apiType = ApiType.Maps;


    public GeocodeApi(IApiEngine engine)
    {
        this.apiEngine = engine;
    }

    public async Task<IResponse<JsonDocument>> Geocode(string latitude, string longitude)
    {
        var coordinate = new GpsCoordinate();
        GpsCoordinate.TryParse($"{latitude},{longitude}", out coordinate);
        return await this.Geocode(coordinate);
    }

    public async Task<IResponse<JsonDocument>> Geocode(GpsCoordinate coordinate, string? identifier = default)
    {
        //Grab the main API Url...
        var builder = new UriBuilder(apiEngine.Options.BaseUri + "geocode/json");

        //build query
        builder.Query = $"?latlng={coordinate.ToString()}";

        //build request
        var request = new ApiRequest(builder.Uri, apiType, RequestType.Geocoding, identifier);

        //send request
        var response = await this.apiEngine.GetJsonAsync(request);
        return response;
    }

    public async Task<GeocodeContainer> GeocodeParse(string latitude, string longitude)
    {
        var response =await Geocode(latitude, longitude);
        return response.Parse<GeocodeContainer>(new GeocodeParser());
    }
    public async Task<GeocodeContainer> GeocodeParse(GpsCoordinate coordinate)
    {
        var response = await Geocode(coordinate);
        return response.Parse<GeocodeContainer>(new GeocodeParser());
    }

}
