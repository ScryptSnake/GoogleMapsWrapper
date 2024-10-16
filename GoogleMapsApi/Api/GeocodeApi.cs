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

/// <summary>
/// Provides methods for retrieiving data from Google's Geocoding API.
/// </summary>
public class GeocodeApi
{
    private IApiEngine apiEngine { get; set; }
    public ApiTypes apiType { get; private set; } = ApiTypes.Maps;

    public GeocodeApi(IApiEngine engine)
    {
        this.apiEngine = engine;
    }

    /// <summary>
    /// Makes a request to the API endpoint for geocoding a lat/lng coordinate. A reponse is returned.
    /// </summary>
    /// <param name="latitude">Decimal degrees gps latitude. </param>
    /// <param name="longitude">Decimal degrees gps longitude.</param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref=>"IResponse{JsonDocument}"/> containing the raw JSON response from the Google API.</returns>
    public async Task<IResponse<JsonDocument>> GeocodeAsync(string latitude, string longitude, string? identifier = default)
    {
        var coordinate = GpsCoordinate.Parse($"{latitude},{longitude}");
        return await this.GeocodeAsync(coordinate,identifier);
    }

    /// <summary>
    /// Makes a request to the API endpoint for geocoding a lat/lng coordinate. A reponse is returned.
    /// </summary>
    /// <param name="coordinate">GpsCoordinate to target the request about. </param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref=>"IResponse{JsonDocument}"/> containing the raw JSON response from the Google API.</returns>
    public async Task<IResponse<JsonDocument>> GeocodeAsync(GpsCoordinate coordinate, string? identifier = default)
    {
        //Grab the main API Url...
        var builder = new UriBuilder(apiEngine.BaseUrl + "geocode/json");
        //build query
        builder.Query = $"?latlng={coordinate.ToString()}";
        //build request
        var request = new ApiRequest(builder.Uri, apiType, RequestTypes.Geocoding, identifier);
        //send request
        var response = await this.apiEngine.GetJsonAsync(request);
        return response;
    }

    /// <summary>
    /// Makes a request to the API endpoint for geocoding a lat/lng coordinate. 
    /// The response is parsed into a <see cref=">GeocodeContainer"/>
    /// </summary>
    /// <param name="latitude">Decimal degrees gps latitude. </param>
    /// <param name="longitude">Decimal degrees gps longitude.</param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>A <see cref=">GeocodeContainer"/> holding parsed results.</returns>
    public async Task<GeocodeContainer> GeocodeParseAsync(string latitude, string longitude, string? identifier = default)
    {
        var response =await GeocodeAsync(latitude, longitude,identifier);
        return response.Parse<GeocodeContainer>(new GeocodeParser());
    }

    /// <summary>
    /// Makes a request to the API endpoint for geocoding a lat/lng coordinate. 
    /// The response is parsed into a <see cref=">GeocodeContainer"/>
    /// </summary>
    /// <param name="coordinate">GpsCoordinate to target the request about. </param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>A <see cref=">GeocodeContainer"/> holding parsed results.</returns>
    public async Task<GeocodeContainer> GeocodeParseAsync(GpsCoordinate coordinate)
    {
        var response = await GeocodeAsync(coordinate);
        return response.Parse<GeocodeContainer>(new GeocodeParser());
    }
    
    /// <summary>
    /// Makes a request to the API endpoint for receiving elevation data about a coordinate.  A response is returned.
    /// </summary>
    /// <param name="latitude">Decimal degrees gps latitude. </param>
    /// <param name="longitude">Decimal degrees gps longitude.</param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref=>"IResponse{JsonDocument}"/> containing the raw JSON response from the Google API.</returns>
    public async Task<IResponse<JsonDocument>>GetElevationAsync(string latitude, string longitude, string? identifier = default)
    {
        var coordinate = GpsCoordinate.Parse($"{latitude},{longitude}");
        return await GetElevationAsync(coordinate, identifier);
    }

    /// <summary>
    /// Makes a request to the API endpoint for receiving elevation data about a coordinate.  A response is returned.
    /// </summary>
    /// <param name="coordinate">GpsCoordinate to target the request about. </param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref=>"IResponse{JsonDocument}"/> containing the raw JSON response from the Google API.</returns>
    public async Task<IResponse<JsonDocument>> GetElevationAsync(GpsCoordinate coordinate, string? identifier = default)
    {
        var builder = new UriBuilder(apiEngine.BaseUrl + "elevation/json");
        builder.Query = $"?locations={coordinate.Latitude},{coordinate.Longitude}";
        var request = new ApiRequest(builder.Uri, this.apiType, RequestTypes.Elevation, identifier);
        return await this.apiEngine.GetJsonAsync(request);
    }
    
        /// <summary>
    /// Makes a request to the API endpoint for receiving elevation data about a coordinate.  A container of parsed data is returned.
    /// </summary>
    /// <param name="latitude">Decimal degrees gps latitude. </param>
    /// <param name="longitude">Decimal degrees gps longitude.</param>
    /// <param name="identifier">A string appended to the request for tracking or identification.</param>
    /// <returns>An <see cref=">ElevationContainer"/> holding parsed results.</returns>
    public async Task<ElevationContainer>GetElevationParsedAsync(string latitude, string longitude, string? identifier = default)
    {
        var coordinate = GpsCoordinate.Parse($"{latitude},{longitude}");
        return await GetElevationParsedAsync(coordinate,identifier);
    }
    
        /// <summary>
    /// Makes a request to the API endpoint for receiving elevation data about a coordinate.  A container of parsed data is returned.
    /// </summary>
    /// <param name="coordinate">GpsCoordinate to target the request about. </param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref=">ElevationContainer"/> holding parsed results.</returns>
    public async Task<ElevationContainer> GetElevationParsedAsync(GpsCoordinate coordinate, string? identifier = default)
    {
        var response = await GetElevationAsync(coordinate, identifier);
        return response.Parse<ElevationContainer>(new ElevationParser());
    }
}
