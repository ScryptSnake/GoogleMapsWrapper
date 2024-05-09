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
    //public record BoundMarker(
    //    string? Id,
    //    GpsCoordinate? coordinates,
    //    Color color = default,
    //    string? info = null,
    //    bool draggable = false) : IMapBoundElement
    //{
    //    public string Serialize()
    //    {
    //        return JsonSerializer.Serialize(this);
            
    //    }

    //    public static BoundMarker FromJson(string json)
    //    {
    //        var result = JsonSerializer.Deserialize<BoundMarker>(json)
    //            ?? throw new NullReferenceException("Failed to serialize");
    //        return result;
    //    }


    //}


    public record BoundMarker(
        string? Id,
        GpsCoordinate? Coordinates,
        Color Color = default,
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
        public BoundMarker(GpsCoordinate? coordinates, Color color = default, string? info = null, bool draggable = false)
            : this(Guid.NewGuid().ToString(), coordinates, color, info, draggable) { }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
        
        public static BoundMarker CopyAssignNewId(string? id, BoundMarker source)
        {
            //use primary constructor
            var newMarker = new BoundMarker(
                source.Id,
                source.Coordinates,
                source.Color,
                source.Info,
                source.Draggable);
            return newMarker;
        }
        public static BoundMarker CopyAssignNewId(BoundMarker source)
        {
            //use constructor that generate new GUID.
            var newMarker = new BoundMarker(
                source.Coordinates,
                source.Color,
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
