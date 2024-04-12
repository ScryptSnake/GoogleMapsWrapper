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


    public async Task<IResponse<byte[]>> GetMap(Map mapSettings, IEnumerable<Marker>? markers=null, IEnumerable<GoogleMapsWrapper.Elements.Path>? paths=null)
    {
        var url = BuildUrl(mapSettings, markers, paths);
        //build request
        var request = new ApiRequest(url, apiType, RequestType.StaticMaps, mapSettings.Id);

        //send request
        var response = await this.apiEngine.GetBytesAsync(request);
        return response;
    }

    public async Task<byte[]> GetMapBytes(Map mapSettings, IEnumerable<Marker>? markers = null, IEnumerable<GoogleMapsWrapper.Elements.Path>? paths = null)
    {
        //shortcut method
        var response = await GetMap(mapSettings, markers, paths);
        return response.Content;
    }



    private Uri BuildUrl(Map mapSettings, IEnumerable<Marker>? markers = null, IEnumerable<GoogleMapsWrapper.Elements.Path>? paths = null)
    {
        //format: staticmap?center=Berkeley,CA&zoom=14&size=400x400

        //Grab the main API Url...
        var builder = new Flurl.Url(apiEngine.Options.BaseUri + "staticmap?");

        //convert map type to string:
        var mapType = Enum.GetName(typeof(MapTypes), mapSettings.MapType);
        mapType = mapType?.ToLower() ?? "roadmap";

        //convert image format to string:
        var mapFormat = Enum.GetName(typeof(MapImageFormats), mapSettings.ImageFormat);
        mapFormat = mapFormat?.ToLower() ?? "jpg";

        //check if caller provided a centering coordinate:
        if (mapSettings.Center != null) builder.SetQueryParam("center", mapSettings.Center.ToString());
        if (mapSettings.Zoom != 0) builder.SetQueryParam("zoom", mapSettings.Zoom);

        builder.SetQueryParam("maptype", mapType);
        builder.SetQueryParam("format", mapFormat);
        //builder.SetQueryParam("scale", mapSettings.Scale); //TODO: FIX TO CONVERT TO INT.
        builder.SetQueryParam("size", mapSettings.Dimensions);


        Debug.Print("DEBUG === " + builder.ToString());


        //grab markers:
        if (markers != null)
        {
            builder.SetQueryParam("markers",buildMarkers(markers));
        }
        return builder.ToUri();
    }




    private List<string> buildMarkers(IEnumerable<Marker> markers)
        //generates the url query string for a list of markers.
    {
        //Filter out null markers, group by custom icon / no custom icon.
        var groupedMarkers = markers.Where(m => m != null).GroupBy(m => m.CustomIcon == null);

        var output = new List<string>();

        foreach (var group in groupedMarkers)
        {
            if (group.Key)
            //markers without custom icon
            {
                foreach (var marker in group)
                {
                    //convert size enum value to string representation:
                    var markerSize = Enum.GetName(typeof(MarkerSizes), marker.Size);
                    markerSize = markerSize?.ToLower() ?? "mid";

                    //grab marker color, check if has value, convert to hex
                    var markerColor = marker.Color;
                    if (marker.Color == Color.Empty) markerColor = Color.Green;
                    var markerColorHex = ColorToHex(markerColor);

                    //check if marker label supplied, if not, provide one
                    var markerLabel = marker.Label;
                    if (markerLabel == '\0') markerLabel = 'a';


                    //url format: markers=size:mid|color:0xFFFF00|label:C|address_or_coordinates
                    output.Add($"size:{markerSize}" +
                        $"|color:{markerColorHex}" +
                        $"|label:{markerLabel}" +
                        $"|{marker.Coordinate.ToString()}");
                }
            }
            else //custom icons
            {
                //url format:  markers = icon:http://tinyurl.com/jrhlvu6|coordinates
                foreach (var customMarker in group)
                {
                    //note: using null forgiving operator, as LINQ filtered by nulls.
                    output.Add($"icon:{customMarker.CustomIcon!.Url.AbsoluteUri}" +
                        $"|{customMarker.Coordinate.ToString()}");
                }
            }
        }
        return output;

    }

    static string ColorToHex(Color color)
        //convert a color object to a 24bit hex string representation
    {
        return $"0x{color.R:X2}{color.G:X2}{color.B:X2}";

    }

}
