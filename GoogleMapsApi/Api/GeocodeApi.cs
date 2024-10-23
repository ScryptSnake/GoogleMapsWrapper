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
    public ApiTypes ApiType { get; private set; } = ApiTypes.Maps;


    /// <summary>
    /// Initializes a new instance of the <see cref="GeocodeApi"/> class.
    /// </summary>
    /// <param name="engine">An instance of the API engine.</param>
    public GeocodeApi(IApiEngine engine)
    {
        apiEngine = engine;
    }


    /// <summary>
    /// Makes a request to the API endpoint for geocoding a lat/lng coordinate./>
    /// </summary>
    /// <param name="latitude">Decimal degrees gps latitude. </param>
    /// <param name="longitude">Decimal degrees gps longitude.</param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref="IResponse{JsonDocument}"/> containing the raw JSON response from the Google API.</returns>
    public async Task<IResponse<JsonDocument>> GeocodeAsync(string latitude, string longitude, string? identifier = default)
    {
        var coordinate = GpsCoordinate.Parse($"{latitude},{longitude}");
        return await this.GeocodeAsync(coordinate,identifier);
    }


    /// <summary>
    /// <inheritdoc cref="GeocodeAsync(string, string, string?)"/>
    /// </summary>
    /// <param name="coordinate">GpsCoordinate to target the request. </param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref="IResponse{JsonDocument}"/> containing the raw JSON response from the Google API.</returns>
    public async Task<IResponse<JsonDocument>> GeocodeAsync(GpsCoordinate coordinate, string? identifier = default)
    {
        // Grab the main API Url.
        var builder = new UriBuilder(apiEngine.BaseUrl + "geocode/json");
        // Build query.
        builder.Query = $"?latlng={coordinate.ToString()}";
        // Build a request.
        var request = new ApiRequest(builder.Uri,ApiType, RequestTypes.Geocoding, identifier);
        // Send the request.
        var response = await this.apiEngine.GetJsonAsync(request);
        return response;
    }


    /// <summary>
    /// <inheritdoc cref="GeocodeAsync(string, string, string?)"/>
    /// </summary>
    /// <param name="latitude">Decimal degrees gps latitude. </param>
    /// <param name="longitude">Decimal degrees gps longitude.</param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>A <see cref="GeocodeContainer"/> holding data parsed from <see cref="GeocodeParser"/>.</returns>
    public async Task<GeocodeContainer> GeocodeParseAsync(string latitude, string longitude, string? identifier = default)
    {
        var response =await GeocodeAsync(latitude, longitude,identifier);
        return response.Parse<GeocodeContainer>(new GeocodeParser());
    }


    /// <summary>
    /// <inheritdoc cref="GeocodeAsync(string, string, string?)"/>
    /// </summary>
    /// <param name="coordinate">GpsCoordinate to target the request. </param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>A <see cref="GeocodeContainer"/> holding data parsed from <see cref="GeocodeParser"/>.</returns>
    public async Task<GeocodeContainer> GeocodeParseAsync(GpsCoordinate coordinate, string? identifier = default)
    {
        var response = await GeocodeAsync(coordinate,identifier);
        return response.Parse<GeocodeContainer>(new GeocodeParser());
    }


    /// <summary>
    /// Makes a request to the API endpoint for acquiring elevation data about a lat/lng coordinate./>
    /// </summary>
    /// <param name="latitude">Decimal degrees gps latitude. </param>
    /// <param name="longitude">Decimal degrees gps longitude.</param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref="IResponse{JsonDocument}"/> containing the raw JSON response from the Google API.</returns>
    public async Task<IResponse<JsonDocument>>GetElevationAsync(string latitude, string longitude, string? identifier = default)
    {
        var coordinate = GpsCoordinate.Parse($"{latitude},{longitude}");
        return await GetElevationAsync(coordinate, identifier);
    }


    /// <summary>
    /// <inheritdoc cref="GetElevationAsync(string, string, string?)"/>
    /// </summary>
    /// <param name="coordinate">GpsCoordinate to target the request about. </param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref="IResponse{JsonDocument}"/> containing the raw JSON response from the Google API.</returns>
    public async Task<IResponse<JsonDocument>> GetElevationAsync(GpsCoordinate coordinate, string? identifier = default)
    {
        var builder = new UriBuilder(apiEngine.BaseUrl + "elevation/json");
        builder.Query = $"?locations={coordinate.Latitude},{coordinate.Longitude}";
        var request = new ApiRequest(builder.Uri, ApiType, RequestTypes.Elevation, identifier);
        return await this.apiEngine.GetJsonAsync(request);
    }


    /// <summary>
    /// <inheritdoc cref="GetElevationAsync(string, string, string?)"/>
    /// </summary>
    /// <param name="latitude">Decimal degrees gps latitude. </param>
    /// <param name="longitude">Decimal degrees gps longitude.</param>
    /// <param name="identifier">A string appended to the request for tracking or identification.</param>
    /// <returns>An <see cref="ElevationContainer"/> holding data parsed from <see cref="ElevationParser"/>.</returns>
    public async Task<ElevationContainer>GetElevationParsedAsync(string latitude, string longitude, string? identifier = default)
    {
        var coordinate = GpsCoordinate.Parse($"{latitude},{longitude}");
        return await GetElevationParsedAsync(coordinate,identifier);
    }


    /// <summary>
    /// <inheritdoc cref="GetElevationAsync(string, string, string?)"/>
    /// </summary>
    /// <param name="coordinate">GpsCoordinate to target the request about. </param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref="ElevationContainer"/> holding data parsed from <see cref="ElevationParser"/>.</returns>
    public async Task<ElevationContainer> GetElevationParsedAsync(GpsCoordinate coordinate, string? identifier = default)
    {
        var response = await GetElevationAsync(coordinate, identifier);
        return response.Parse<ElevationContainer>(new ElevationParser());
    }
}
