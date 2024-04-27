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

            //Usage example 1....
            //Creates a static map, downloads as filename provided:
            //See method definition below for info on config file - API key must be provided in appSettings.json
            UsageExamples.Example_CreateStaticMap("C:/GoogleMapsApi/GoogleMapsApi/Configuration/outputExample.jpg");


            //Usage example 2....
            //Reverse geocodes coordinate for mount rushmore. Prints to console.
            UsageExamples.Example_ReverseGeocode(); 
        }


    }

}
