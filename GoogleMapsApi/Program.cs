// See https://aka.ms/new-console-template for more information
using GoogleMapsWrapper;
using GoogleMapsWrapper.Utilities;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GoogleMapsWrapper
{
    class Program
    {
        static async Task Main()

        {
            Console.WriteLine("Starting application.........");


            var testClient = new HttpClient();

            var configpath = "C:/GoogleMapsApi/GoogleMapsApi/Configuration/appSettings.json";

            var api = new ApiEngine("AIzaSyDHaNIVpQ-Iy02FTY4x2NfpI2zOag_Xwuk",testClient);
            var coord = new GpsCoordinate(40.803143m, -79.507266m);


            var map = new Map(MapTypes.Hybrid);
            map.Dimensions = "200X200";

            var markers = new List<Marker>();
            var marker = new Marker(GpsCoordinate.Parse("41.40484,-77.02829"));
            var marker2 = new Marker(GpsCoordinate.Parse("41.42484,-77.04829"));
            var marker3 = new Marker(GpsCoordinate.Parse("41.43484,-77.07829"));

            marker.Color = Color.Purple;
            markers.Add(marker);
            markers.Add(marker2);
            markers.Add(marker3);

            var coords = new List<GpsCoordinate>();
            foreach (var m in markers)
            {
                coords.Add(m.Coordinate);
            }

            var path = new Polyline(coords);
            path.Color = Color.BlanchedAlmond;

            //Debug.Print("ENCODED =========== " + path.Encode());


            string encodedPolyline = PolylineEncoder.Encode(coords);
            Console.WriteLine("Encoded Polyline: " + encodedPolyline);

            var img = await wrapper.StaticMapsApi.GetMap(map, markers, new List<GoogleMapsWrapper.Elements.Polyline> { path });

        }

        static void PrintProperties(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(obj);
                Console.WriteLine($"{property.Name}: {value}");
            }
        }

    }

}
