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
///<summary>A object to hold parsed JSON data from Elevation API responses.</summary>
///<param name="ElevationMeters"> The elevation in meters. </param>
///<param name="Resolution"> Indicates the maximum distance between data points 
///     from which the elevation was interpolated, in meters. 
///     This property is acquired from the JSON response's 'administrative_area_level_1' property.</param>
///<param name="ElevationFeet">The elevation in feet. This property is mathematically converted and not instrinsic to the API. </param>
///<param name="Coordinates"> The GPS coordinate for the request.</param>
///<param name="AssociatedData">Associated information about the data or it's source. This contains the IResponse.</param>
///</Summary>
public record ElevationContainer(
    [JsonProperty("elevation")]
    double ElevationMeters,
    
    [JsonProperty("resolution")]
    double Resolution,
    
    double ElevationFeet,

    GpsCoordinate? Coordinates,
    
   object? AssociatedData

    ) : IContainer
{
    object? IContainer.AssociatedData => AssociatedData;
}
