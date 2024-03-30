// See https://aka.ms/new-console-template for more information
using GoogleMapsWrapper;
using GoogleMapsWrapper.Api;
using System.Diagnostics;
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


            var api = new ApiEngine("API_KEY_REDACTED_4-22-24",testClient);
            var coord = new GpsCoordinate(40.803143m, -79.507266m);

            var googapi = new GeocodeApi(api);

           var container =  await googapi.GeocodeParse(coord);
            
            Console.WriteLine(container.ToString());    



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
