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
/// <summary>A container to hold parsed JSON information from a GoecodeAPI response.</summary>
public record GeocodeContainer(
    /// <summary>The 'Country' parsed from the response. This property is set from the API's 'country' JSON property</summary>
    [JsonProperty("country")]
    string Country,
    /// <summary>The 'State' parsed from the response. This property is set from the API's 'administrative_area_level_1' JSON property.</summary>
    [JsonProperty("administrative_area_level_1")]
    string State,
    /// <summary>The 'County' parsed from the response. This property is set from the API's 'administrative_area_level_2' JSON property.</summary>
    [JsonProperty("administrative_area_level_2")]
    string County,
    /// <summary>The 'City' parsed from the response. This property is set from the API's 'locality' JSON property.</summary>
    [JsonProperty("locality")]
    string City,
    /// <summary>The 'Municipality' parsed from the response. This property is set from the API's 'administrative_area_level_2' JSON property.</summary>
    [JsonProperty("administrative_area_level_3")]
    string Municipality,
    /// <summary>The 'ZipCode' parsed from the response. This property is set from the API's 'postal_code' JSON property.</summary>
    [JsonProperty("postal_code")]
    int ZipCode,
    /// <summary>The 'Address' parsed from the response. This property is set from the API's 'formatted_address' JSON property.</summary>
    [JsonProperty("formatted_address")]
    string Address,

    /// <summary>The Gps Coordinate the request targets.</summary>
    GpsCoordinate? Coordinates,
    /// <summary>Associated data related to the request. This contains the IRequest object.</summary>
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
