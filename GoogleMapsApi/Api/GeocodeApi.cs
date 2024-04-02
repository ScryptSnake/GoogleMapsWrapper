﻿using System;
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

public class GeocodeApi
{
    private IApiEngine apiEngine;

    private ApiType apiType = ApiType.Maps;


    public GeocodeApi(IApiEngine engine)
    {
        this.apiEngine = engine;
    }

    public async Task<IResponse<JsonDocument>> Geocode(string latitude, string longitude, string? identifier = default)
    {
        var coordinate = GpsCoordinate.Parse($"{latitude},{longitude}");
        return await this.Geocode(coordinate,identifier);
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


    public async Task<IResponse<JsonDocument>>GetElevation(string latitude, string longitude, string? Identifier = default)
    {
        var coordinate = GpsCoordinate.Parse($"{latitude},{longitude}");
        return await GetElevation(coordinate, Identifier);
    }
    public async Task<IResponse<JsonDocument>> GetElevation(GpsCoordinate coordinate, string? Identifier = default)
    {
        var builder = new UriBuilder(apiEngine.Options.BaseUri + "elevation/json");
        builder.Query = $"?locations={coordinate.Latitude},{coordinate.Longitude}";
        var request = new ApiRequest(builder.Uri, this.apiType, RequestType.Elevation, Identifier);
        return await this.apiEngine.GetJsonAsync(request);
    }

    public async Task<ElevationContainer>GetElevationParsed(string latitude, string longitude)
    {
        var coordinate = GpsCoordinate.Parse($"{latitude},{longitude}");
        return await GetElevationParsed(coordinate);
    }
    public async Task<ElevationContainer> GetElevationParsed(GpsCoordinate coordinate)
    {
        var response = await GetElevation(coordinate);
        return response.Parse<ElevationContainer>(new ElevationParser());
    }



}
