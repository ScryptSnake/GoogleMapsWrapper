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
        GpsCoordinate? coordinates,
        Color color = default,
        string? info = null,
        bool draggable = false) : IMapBoundElement
    {
        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
            
        }

        public static BoundMarker FromJson(string json)
        {
            var result = JsonSerializer.Deserialize<BoundMarker>(json)
                ?? throw new NullReferenceException("Failed to serialize");
            return result;
        }


    }


}
