using GoogleMapsWrapper.JavascriptApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace GoogleMapsWrapper.JavascriptApi.Elements
{
    public record BoundMarker(
        string? Id,
        GpsCoordinate? Coordinates,
        MapSvgIcon Icon,
        MapLabel Label,
        string? Info = null,
        bool Draggable = false) : IMapBoundElement
    {

        // Overloaded constructor with random ID
        /// <summary>
        /// Overload constructor, Id property is produced internally as a GUID.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="color"></param>
        /// <param name="info"></param>
        /// <param name="draggable"></param>
        /// 

        //Constructor for auto generating guid id. 
        public BoundMarker(GpsCoordinate? coordinates, MapSvgIcon icon, MapLabel label, string? info = null, bool draggable = false)
            : this(Guid.NewGuid().ToString(), coordinates, icon, label, info, draggable) { }


        //Overload for auto-icon.
        public BoundMarker(GpsCoordinate? coordinates, MapLabel label, string? info = null, bool draggable = false)
            : this(Guid.NewGuid().ToString(),coordinates, MapSvgIcon.PinIcon(Color.Red), label, info, draggable) { }

        public string Serialize()
        {
            //set up the serializer converter for this object:
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters = { new BoundMarkerJsonConverter() }
            };
            var dblquote = (char)34;
            var result = JsonSerializer.Serialize(this, options);
            var result2 = result.Replace("\\u0022", dblquote.ToString()); //Nested serialization problem with Icon proerty - see converter.
            
            return result2;
        }

        public static BoundMarker CopyAssignNewId(string? id, BoundMarker source)
        {
            //use primary constructor
            var newMarker = new BoundMarker(
                source.Id,
                source.Coordinates,
                source.Icon,
                source.Label,
                source.Info,
                source.Draggable);
            return newMarker;
        }
        public static BoundMarker CopyAssignNewId(BoundMarker source)
        {
            //use constructor that generate new GUID.
            var newMarker = new BoundMarker(
                source.Coordinates,
                source.Icon,
                source.Label,
                source.Info,
                source.Draggable);
            return newMarker;
        }

        public static BoundMarker FromJson(string json)
        {
            var result = JsonSerializer.Deserialize<BoundMarker>(json)
                ?? throw new NullReferenceException("Failed to serialize");
            return result;
        }
    }


}
