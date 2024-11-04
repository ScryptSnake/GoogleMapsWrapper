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
/// <summary>A container to hold parsed JSON information from a <see cref="GeocodeApi"/> response.</summary>
///<param name="Country">This property is acquired from the JSON response's 'country' property.</param>
///<param name="State">This property is acquired from the JSON response's 'administrative_area_level_1' property.</param>
///<param name="County">This property is acquired from the JSON response's 'administrative_area_level_2' property.</param>
///<param name="City">This property is acquired from the JSON response's 'locality' property.</param>
///<param name="Municipality">This property is acquired from the JSON response's 'administrative_area_level_3' property.</param>
///<param name="ZipCode">This property is acquired from the JSON response's 'postal_code' property.</param>
///<param name="Address">This property is acquired from the JSON response's 'formatted_address' property.</param>
///<param name="Coordinates"> The GPS coordinate for the request.</param>
///<param name="AssociatedData">Associated information about the data or it's source. This contains the IResponse.</param>
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
   
    GpsCoordinate? Coordinates,
   
   object? AssociatedData

    ) : IContainer
{
    object? IContainer.AssociatedData => AssociatedData;

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String" /> that represents this instance.
    /// </returns>
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
