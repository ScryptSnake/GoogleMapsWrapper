// See https://aka.ms/new-console-template for more information
using GoogleMapsWrapper;
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


            var api = new GMapsApi("API_KEY_REDACTED_4-22-24",testClient);
            var coord = new GpsCoordinate(40.803143m, -79.507266m);
            var result = await api.Geocode(coord);

            Console.WriteLine(result.ResponseMessage.Content.ToString());

            var container = result.Parse();
            PrintProperties(container);

            var result2 = await api.GetElevation(coord);
            PrintProperties(result2.Parse());



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
