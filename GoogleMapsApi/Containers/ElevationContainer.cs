using GoogleMapsWrapper.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace GoogleMapsWrapper.Containers;
/// <summary>A object to hold parsed JSON data from Elevation API responses.</summary>
public record ElevationContainer(
    ///<Summary>The elevation in meters.</summary>
    [JsonProperty("elevation")]
    double ElevationMeters,
    
    ///<Summary>Indicates the maximum distance between data points from which the elevation was interpolated, in meters.
    ///<para>This property is acquired from the JSON response's 'administrative_area_level_1' property.</para>
    ///</summary>
    [JsonProperty("resolution")]
    double Resolution,
    
    ///<Summary>The elevation in feet. 
    ///<para>Note: This property is mathematically converted by the caller/setter and is not instrinsic to the API.</para>
    </summary>
    double ElevationFeet,

    ///<Summary>Location of the request.</summary>
    GpsCoordinate? Coordinates,
    
    ///<Summary>Associated data related to the request. This contains the IRequest object.</summary>.</summary>
   object? AssociatedData

    ) : IContainer
{
    object? IContainer.AssociatedData => AssociatedData;
}
