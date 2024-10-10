using GoogleMapsWrapper.Elements;
using GoogleMapsWrapper.Responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapsWrapper;
internal static class UsageExamples
{
    public static void Example_CreateStaticMap(string outputFile)
    {
        //Demonstrates how to create a static map with the wrapper:
        var client = new HttpClient();

        //Point to the config file. The engine needs a config source that contains: "{AppSettings": {"ApiKey": "INSERT KEY HERE"}}
        var configJson = "C:\\Users\\WIN11PC\\source\\repos\\GoogleMapsWrapper\\GoogleMapsApi\\Configuration\\appSettings.json";

        //Create an IConfiguration to be passed to the api.
        var config = new ConfigurationBuilder()
        .AddJsonFile(configJson)
        .Build();

        //Create an API object.
        var wrapper = new GoogleMapsApi(client, config);

        //Declare a new map object.
        var map = new Map(MapTypes.Hybrid);
        map.ImageFormat = MapImageFormats.Jpg;

        //Create a list to hold some markers - you can do the same with polylines (paths)
        var markers = new List<Marker>();
        //Declare two new markers, add to list
        var marker1 = new Marker(GpsCoordinate.Parse("43.8791,-103.4591"));
        var marker2 = new Marker(GpsCoordinate.Parse("43.9791,-103.8891"));
        markers.Add(marker1);
        markers.Add(marker2);

        //manipulate marker colors
        marker1.Color = Color.Purple;

        //Get the map from the endpoint - this is a non-async context because awaiting task NEVER returns to main(). 
        var byteResponse = Task.Run(async () => await wrapper.StaticMapsApi.GetMapBytesAsync(map, markers)).Result;

        if (byteResponse == null) { throw new System.Exception("Response contains no data."); };
        //Save map to disk
        File.WriteAllBytes(outputFile, byteResponse);
    }

    public static void Example_ReverseGeocode()
    {
        //prints the output to the console of a reverse geocoded coordinate.

        //create an http client
        var client = new HttpClient();
        //Point to the config file. The engine needs a config json file that contains: "{AppSettings": {"ApiKey": "INSERT KEY HERE"}}
        var configJson = "C:\\Users\\WIN11PC\\source\\repos\\GoogleMapsWrapper\\GoogleMapsApi\\Configuration\\appSettings.json";

        //Create the IConfiguration to be passed to the api.
        var config = new ConfigurationBuilder()
        .AddJsonFile(configJson)
        .Build();

        //Create an API object
        var wrapper = new GoogleMapsApi(client, config);
        //create a coordiante
        var coord = GpsCoordinate.Parse("43.8791,-103.4591");
        //geocode the coordinate, returns an IContainer with a concrete type of GeocodeContainer
        var container = Task.Run(async () => await wrapper.GeocodeApi.GeocodeParseAsync(coord)).Result;
        //print the IContainer (GeocodeContainer) properties
        Console.WriteLine(container.ToString());    
    }




}
