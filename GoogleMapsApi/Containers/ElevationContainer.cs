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
/// <param name="ElevationMeters">The elevation in unit meters.</param>
/// <param name="Resolution">The elevation in meters.</param>
public record ElevationContainer(
    [JsonProperty("elevation")]
    double ElevationMeters,

    [JsonProperty("resolution")]
    double Resolution,

    // Note: This property is mathematically converted by the caller/setter and is not instrinsic to the API.
    double ElevationFeet,

    // Note: This property is not de-serialized. Rather, It is manually provided by the caller/setter.
    GpsCoordinate? Coordinates,
    
    // A property to append any relevant information to the object.
   object? AssociatedData

    ) : IContainer
{
    object? IContainer.AssociatedData => AssociatedData;
}
