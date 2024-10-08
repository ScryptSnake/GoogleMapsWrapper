﻿using GoogleMapsWrapper.Types;
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
public record ElevationContainer(
    [JsonProperty("elevation")]
    double ElevationMeters,

    [JsonProperty("resolution")]
    double Resolution,

    //this property is manually converted
    double ElevationFeet,

    //this property is not de-serialized.but manually added in GeocodeResponse, the reponse returns a list
    GpsCoordinate? Coordinates,

   object? AssociatedData

    ) : IContainer
{
    object? IContainer.AssociatedData => AssociatedData;
}
