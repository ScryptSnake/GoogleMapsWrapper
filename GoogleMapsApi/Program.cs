// See https://aka.ms/new-console-template for more information
using GoogleMapsWrapper;
using GoogleMapsWrapper.Api;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GoogleMapsWrapper
{
    class Program
    {
        static async Task Main()

        {
            Console.WriteLine("Starting application.........");


            var testClient = new HttpClient();


            var api = new ApiEngine("AIzaSyDHaNIVpQ-Iy02FTY4x2NfpI2zOag_Xwuk",testClient);
            var coord = new GpsCoordinate(40.803143m, -79.507266m);

            var googapi = new StaticMapsApi(api);

            var map = new Map(MapTypes.Hybrid);
            
            var markers = new List<Marker>();
            var marker = new Marker(GpsCoordinate.Parse("41.40484,-71.02829"));
            var marker2 = new Marker(GpsCoordinate.Parse("41.42484,-71.04829"));
            var marker3 = new Marker(GpsCoordinate.Parse("41.43484,-71.07829"));
            marker.Color = Color.Purple;
            markers.Add(marker);
            markers.Add(marker2);
            markers.Add(marker3);




            var img = await googapi.GetMap(map, markers);



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
