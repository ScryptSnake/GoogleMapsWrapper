using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Types;
using GoogleMapsWrapper.Elements;


namespace ExampleProject;

//A container to hold some default input data for the demo app.
internal class ProgramDefaults
{
    public static IList<GpsCoordinate> StaticMapCoordinates()
    {
        var output = new List<GpsCoordinate>();
        output.Add(GpsCoordinate.Parse("43.8807, -103.4595"));
        output.Add(GpsCoordinate.Parse("43.8788, -103.4612"));
        output.Add(GpsCoordinate.Parse("43.8766, -103.4643"));
        output.Add(GpsCoordinate.Parse("43.8753, -103.4681"));
        output.Add(GpsCoordinate.Parse("43.8770, -103.4745"));
        output.Add(GpsCoordinate.Parse("43.8801, -103.4732"));
        output.Add(GpsCoordinate.Parse("43.8823, -103.4654"));

        return output;
    }

    public static readonly GpsCoordinate MountRushmoreCoordinate = GpsCoordinate.Parse("43.8753, -103.4681");

    public static readonly MapTypes StaticMapType = MapTypes.Hybrid;

}