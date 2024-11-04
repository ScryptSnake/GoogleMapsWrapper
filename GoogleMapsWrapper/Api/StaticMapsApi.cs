using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GoogleMapsWrapper.Containers;
using GoogleMapsWrapper.Parsers;
using System.Data.Common;
using System.Drawing;
using GoogleMapsWrapper.Elements;
using System.Diagnostics;
using Flurl;
using System.Collections.ObjectModel;

namespace GoogleMapsWrapper.Api;
/// <summary>
/// Provides methods for retrieving a static image of a map from Google's Static API.
/// <Remarks>This object leverages an <see cref="IApiEngine"/> 
/// to send <see cref="IRequest"/>s and return data in form of <see cref="IResponse{TResponse}"/>s.</Remarks>
/// </summary>
public class StaticMapsApi
{
    // Maximum length of a URL per Google API documentation.
    private const int MAX_URL_LENGTH = 16384;

    private IApiEngine apiEngine { get; set; }

    private ApiTypes apiType = ApiTypes.Maps;

    /// <summary>
    /// Initializes a new instance of the StaticMapsAPI.
    /// </summary>
    /// <param name="engine"> An <see cref="IApiEngine"></see> to process API requests and responses./></param>
    public StaticMapsApi(IApiEngine engine)
    {
        this.apiEngine = engine;
    }


    /// <summary>
    /// Makes a request to the API endpoint for a static map image.
    /// </summary>
    /// <param name="mapSettings">A <see cref="Map"/> element that defines key features about the map.></param>
    /// <param name="markers"> Optional. <see cref="Marker"/>s to be included in the map.</param>
    /// <param name="paths">Optional. <see cref="Polyline"/>s to be included in the map.</param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>An <see cref="IResponse{JsonDocument}"/> containing the raw byte[] response from the Google API.</returns>
    public async Task<IResponse<byte[]>> GetMapAsync(
        Map mapSettings, 
        IEnumerable<Marker>? markers = null, 
        IEnumerable<Polyline>? paths = null, 
        string? identifier = default)
    {
        // Assemble a URL for the API.
        var url = BuildUrl(mapSettings, markers, paths);
        // Build a request object.
        var request = new ApiRequest(url, apiType, RequestTypes.StaticMaps, mapSettings.Id);
        // Send a request. 
        var response = await this.apiEngine.GetBytesAsync(request);
        return response;
    }


    /// <inheritdoc cref="GetMapAsync(Map, IEnumerable{Marker}?, IEnumerable{Polyline}?, string?)"/>
    /// <param name="mapSettings">A <see cref="Map"/> element that defines key features about the map.></param>
    /// <param name="markers"> Optional. <see cref="Marker"/>s to be included in the map.</param>
    /// <param name="paths">Optional. <see cref="Polyline"/>s to be included in the map.</param>
    /// <param name="identifier">A string appended to the request object for tracking or identification.</param>
    /// <returns>A <see cref="byte"/> array containing the raw byte[] data of the image.</returns>
    public async Task<byte[]?> GetMapBytesAsync(
        Map mapSettings,
        IEnumerable<Marker>? markers = null,
        IEnumerable<Polyline>? paths = null,
        string? identifier = default)
        {
            // Shortcut reference.
            var response = await GetMapAsync(mapSettings, markers, paths);
            return response.Content;
        }


    ///<summary>Assembles the URL to be provided to the engine for http processing.</summary>
    ///<returns>A URI object for Google's API.</returns>
    private Uri BuildUrl(Map mapSettings, IEnumerable<Marker>? markers = null, IEnumerable<Polyline>? paths = null)
    {
        // Assemble a URL builder object from the engine's base URL.  
        var builder = new Flurl.Url(apiEngine.BaseUrl + "staticmap?");
        
        // Check if caller provided centering or zoom parameters, if null ignored.
        builder.SetQueryParam("center", mapSettings.Center); 
        if (mapSettings.Zoom != 0) builder.SetQueryParam("zoom", mapSettings.Zoom);

        // Set parameters with default values.
        builder.SetQueryParamWithDefault("maptype", mapSettings.MapType.ToString().ToLower(),"hybrid");
        builder.SetQueryParamWithDefault("format", mapSettings.ImageFormat.ToString().ToLower(), "png");
        builder.SetQueryParamWithDefault("scale", (int)mapSettings.Scale, 2);
        builder.SetQueryParamWithDefault("size", mapSettings.Dimensions, "640x640");
        
        // Build a list of marker parameters, append to the URL builder.
        if (markers != null)
        {
            foreach (var marker in BuildMarkers(markers))
            {
                builder.AppendQueryParam("markers", marker, true);
            }
        }

        // Build a list of path parameters, append to the URL builder.
        if (paths!= null)
        {
            foreach (var path in BuildPaths(paths))
            {
                builder.AppendQueryParam("path", path,false);
            }
        }

        // Perform a check against URL maximum size.
        if (builder.ToString().Length > MAX_URL_LENGTH) { 
            throw new GoogleMapsApiException("Resultant static map URL exceeds allowable size: Max = " + MAX_URL_LENGTH);
        }
        
        return builder.ToUri();
    }


    ///<summary>Converts a list of marker objects into a list of string, 
    /// representing a URL query for the marker(s).
    ///</summary>
    ///<remarks>This method url encodes each query value in the resultant list before output.</remarks>
    ///<returns>A list of string, where each value in the list represents a URL query for a marker.</returns>
   private List<string> BuildMarkers(IEnumerable<Marker> markers)
    {
        // Filter out null markers, group by custom icon / no custom icon.
        var groupedMarkers = markers.Where(m => m != null).GroupBy(m => m.CustomIcon == null);
        
        // Establish some URL encoded characters.
        const string COLON_ENCODED = "%3A";
        const string PIPE_ENCODED = "%7C";
        
        // Instantiate an output list.
        var output = new List<string>();

        // Loop through grouped markers.
        foreach (var group in groupedMarkers)
        {
            // Markers WITHOUT a custom icon.
            if (group.Key)
            {
                foreach (var marker in group)
                {
                    // Convert size enum value to string representation.
                    var markerSize = marker.Size.ToString().ToLower();

                    // Grab marker color, check has value, convert to hex.
                    var markerColor = marker.Color;
                    if (marker.Color == Color.Empty) markerColor = Color.Green;
                    var markerColorHex = Utilities.Utilities.ColorToHex(markerColor);

                    // Check if marker label supplied, if not, provide one.
                    var markerLabel = marker.Label;
                    if (markerLabel == '\0') markerLabel = 'A'; 

                    // URL format: markers=size:mid|color:0xFFFF00|label:C|address_or_coordinates.
                    var outputString = $"size{COLON_ENCODED}{markerSize}" +
                        $"{PIPE_ENCODED}color{COLON_ENCODED}{markerColorHex}" +
                        $"{PIPE_ENCODED}";

                    if (marker.Label != '\0')
                    {
                        // UrlEncodeChar is required to use certain characters that conflict with the %3A colon encoding.
                        // For example:  label%3AB => label:Z works fine, But label%3AA => label:A expected,
                        // But the API does not process it properly because 'A' conflicts with %3A
                        // Using a regular colon decoded in the URL works fine, but its poor practice to not encode it.
                        var markerLabelEncoded = Utilities.Utilities.UrlEncodeChar(markerLabel);
                        outputString = outputString + $"label{COLON_ENCODED}{markerLabelEncoded}";
                    }
                    output.Add(outputString + $"{PIPE_ENCODED}{marker.Coordinate.ToString()}");
                }
            }
            else // Markers WITH Custom icons.
            {
                // Url format:  markers = icon:http://tinyurl.com/jrhlvu6|coordinates
                foreach (var customMarker in group)
                {
                    // Note: using null forgiving operator, as LINQ filtered by nulls.
                    output.Add($"icon:{customMarker.CustomIcon!.Uri.AbsoluteUri}" +
                        $"|{customMarker.Coordinate.ToString()}");
                }
            }
        }
        return output;
    }


    ///<summary>Converts a list of <see cref="Polyline"/> into a list of string, 
    /// representing a URL query for the polylines(s).
    ///</summary>
    ///<remarks>This method uses an implementation of Google's Polyline encoding algorithm.
    /// Each value in the resultant list contains an encoded parameter with the algorithm.</remarks>
    ///<returns>A list of string, where each value in the list represents a URL query for a Poyline.</returns>
    private List<string> BuildPaths(IEnumerable<Polyline> paths)
    {
        // Establish a constant for the pipe delimeter.
        // Note: This is not URL encoded.
        const string PIPE_ENCODED = "|";

        // Instantiate a list for output.
        var output = new List<string>();

        // Loop through the Polylines provided.
        foreach (var path in paths)
        {
            if (path.IsEmpty()) { continue;}
            // Convert the Polyline's color property to a hex string for the API.
            var hexColor = Utilities.Utilities.ColorToHex(path.Color);
            // Create a write-able list from the Polyline's coordinate list.
            IList<GpsCoordinate> pathCoords = new List<GpsCoordinate>(path.Coordinates);
            // Encode the coordinates with the Poyline encoding algorithm (space saver).
            var encodedCoords = Utilities.PolylineEncoder.Encode(pathCoords);
            // Example format: path=color:0xff0000ff|weight:5|40.737102,-73.990318|40.749825,-73.987963|40.752946,-73.987384|40.755823,-73.986397
            output.Add($"color:{hexColor}{PIPE_ENCODED}" +
                $"weight:{path.Weight}{PIPE_ENCODED}enc:{encodedCoords}");
        }
        return output;
    }
}
