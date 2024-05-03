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
namespace GoogleMapsWrapper.Elements
{
    public record BoundMarker(
        string? id,
        GpsCoordinate? coordinates, 
        Color color = default, 
        string? info = null, 
        bool draggable = false)
    {
        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }


    }


}
