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

public class StaticMapsApi
{
    private const int MaxUrlLength = 16384; //maximum allowed Url length per API documentation. 

    private IApiEngine apiEngine;

    private ApiType apiType = ApiType.Maps;


    public StaticMapsApi(IApiEngine engine)
    {
        this.apiEngine = engine;
    }

    /// <summary>
    /// Make a request to the API for a static map and return a Byte Response. Markers are optional. Paths are also optional. 
    /// </summary>
    public async Task<IResponse<byte[]>> GetMapAsync(Map mapSettings, IEnumerable<Marker>? markers=null, IEnumerable<Polyline>? paths=null)
    {
        var url = BuildUrl(mapSettings, markers, paths);
        //build request
        var request = new ApiRequest(url, apiType, RequestType.StaticMaps, mapSettings.Id);

        //send request
        var response = await this.apiEngine.GetBytesAsync(request);
        return response;
    }


    /// <summary>
    /// Make a request to the API for a static map and return a byte array of the resultant image. Markers are optional. Paths are also optional. 
    /// </summary>
    public async Task<byte[]?> GetMapBytesAsync(Map mapSettings, IEnumerable<Marker>? markers = null, IEnumerable<Polyline>? paths = null)
    {
        //shortcut method
        var response = await GetMapAsync(mapSettings, markers, paths);
        return response.Content;
    }


    private Uri BuildUrl(Map mapSettings, IEnumerable<Marker>? markers = null, IEnumerable<Polyline>? paths = null)
    {
        //format: staticmap?center=Berkeley,CA&zoom=14&size=400x400

        //Grab the main API Url:
        var builder = new Flurl.Url(apiEngine.BaseUrl + "staticmap?");

        //check if caller provided a centering or zoom parameters, if null ignored.
        builder.SetQueryParam("center", mapSettings.Center); 
        if (mapSettings.Zoom != 0) builder.SetQueryParam("zoom", mapSettings.Zoom);

        //set parameters with defaults:
        builder.SetQueryParamWithDefault("maptype", mapSettings.MapType.ToString().ToLower(),"hybrid");
        builder.SetQueryParamWithDefault("format", mapSettings.ImageFormat.ToString().ToLower(), "png");
        builder.SetQueryParamWithDefault("scale", (int)mapSettings.Scale, 2);
        builder.SetQueryParamWithDefault("size", mapSettings.Dimensions, "640x640");

        //build list of markers parameters, add to URL
        if (markers != null)
        {
            foreach (var marker in buildMarkers(markers))
            {
                builder.AppendQueryParam("markers", marker, true);
            }
        }

        //build list of paths parameters, add to URL
        if (paths!= null)
        {
            foreach (var path in buildPaths(paths))
            {
                builder.AppendQueryParam("path", path,false);
            }
        }

        //perform check for max URL size:
        if (builder.ToString().Length > MaxUrlLength) { 
            throw new GoogleMapsApiException("Resultant static map URL exceeds allowable size: Max = " + MaxUrlLength);
        }

        return builder.ToUri();
    }



    private List<string> buildPaths(IEnumerable<Polyline> paths)
    {
        //format: path=color:0xff0000ff|weight:5|40.737102,-73.990318|40.749825,-73.987963|40.752946,-73.987384|40.755823,-73.986397
        const string pipeEncoded = "|";

        var output = new List<string>();

        foreach (var path in paths)
        {
            if (!path.IsEmpty())
            {
                var hexColor = Utilities.Utilities.ColorToHex(path.Color);

                var encodedCoords = Utilities.PolylineEncoder.Encode(path.Coordinates);

                output.Add($"color:{hexColor}{pipeEncoded}" +
                    $"weight:{path.Weight}{pipeEncoded}enc:{encodedCoords}");
            }
        }
        return output;



    }


    private List<string> buildMarkers(IEnumerable<Marker> markers)
        //generates a collection of markers queries
        //this is passed as same-named parameters using Flurl.AppendQueryParam
        //The value of each collection item is an ALREADY url encoded value.
    {
        //Filter out null markers, group by custom icon / no custom icon.
        var groupedMarkers = markers.Where(m => m != null).GroupBy(m => m.CustomIcon == null);

        const string colonEncoded = "%3A";
        const string pipeEncoded = "%7C";
        
        var output = new List<string>();

        foreach (var group in groupedMarkers)
        {
            if (group.Key)
            //markers without custom icon
            {
                foreach (var marker in group)
                {
                    //convert size enum value to string representation:
                    var markerSize = marker.Size.ToString().ToLower();

                    //grab marker color, check if has value, convert to hex
                    var markerColor = marker.Color;
                    if (marker.Color == Color.Empty) markerColor = Color.Green;
                    var markerColorHex = Utilities.Utilities.ColorToHex(markerColor);
                    
                    //check if marker label supplied, if not, provide one
                    var markerLabel = marker.Label;
                    if (markerLabel == '\0') markerLabel = 'A'; 

                    //url format: markers=size:mid|color:0xFFFF00|label:C|address_or_coordinates

                    var outputString = $"size{colonEncoded}{markerSize}" +
                        $"{pipeEncoded}color{colonEncoded}{markerColorHex}" +
                        $"{pipeEncoded}";

                    if (marker.Label != '\0')
                    {
                        //UrlEncodeChar is required to use certain characters that conflict with the %3A colon encoding.
                        //for example:  label%3AB => label:Z works fine, But label%3AA => label:A expected,
                        //but the API does not process it properly because 'A' conflicts with %3A
                        //using a regular colon decoded in the URL works fine, but its poor practice to not encode it.
                        var markerLabelEncoded = Utilities.Utilities.UrlEncodeChar(markerLabel);
                        outputString = outputString + $"label{colonEncoded}{markerLabelEncoded}";
                    }

                    output.Add(outputString + $"{pipeEncoded}{marker.Coordinate.ToString()}");

                }
            }
            else //custom icons
            {
                //url format:  markers = icon:http://tinyurl.com/jrhlvu6|coordinates
                foreach (var customMarker in group)
                {
                    //note: using null forgiving operator, as LINQ filtered by nulls.
                    output.Add($"icon:{customMarker.CustomIcon!.Uri.AbsoluteUri}" +
                        $"|{customMarker.Coordinate.ToString()}");
                }
            }
        }
        return output;

    }



}
