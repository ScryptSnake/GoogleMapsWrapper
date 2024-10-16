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

public record GeocodeContainer(
    [JsonProperty("country")]
    string Country,

    [JsonProperty("administrative_area_level_1")]
    string State,

    [JsonProperty("administrative_area_level_2")]
    string County,

    [JsonProperty("locality")]
    string City,

    [JsonProperty("administrative_area_level_3")]
    string Municipality,

    [JsonProperty("postal_code")]
    int ZipCode,

    [JsonProperty("formatted_address")]
    string Address,

    //this property is not de-serialized.but manually added in GeocodeResponse.
    GpsCoordinate? Coordinates,

   object? AssociatedData

    ) : IContainer
{
    object? IContainer.AssociatedData => AssociatedData;

    public override string ToString()
    {
        // Use string interpolation and handle null values
        return $"Country: {Country}, " +
               $"State: {State}, " +
               $"City: {City}, " +
               $"Municipality: {Municipality}, " +
               $"ZipCode: (ZipCode.ToString(), " +
               $"Address: {Address}, " +
               $"Coordinates: (Coordinates.ToString(), " +
               $"AssociatedData: {AssociatedData?.ToString() ?? "EMPTY"}";
    }


}
