using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Types;
namespace GoogleMapsWrapper.JavascriptApi.Html
{


    using System.Text.Json;
    using Microsoft.Extensions.Configuration;

    public class GoogleMapsHtmlTemplate
    {
        // The template source html
        private string templateHtml = string.Empty;
        public string TemplateHtml { get => templateHtml; }

        //the modified html:
        private string html;
        public string Html { get => html; }


        public GoogleMapsHtmlTemplate(string templateHtml, string apiKey, string objectBindingScript, Map? loadMap = null)
        {
            if (string.IsNullOrEmpty(apiKey)) throw new ArgumentNullException(nameof(apiKey));
            if (string.IsNullOrEmpty(templateHtml)) throw new ArgumentNullException(nameof(templateHtml));
            if (string.IsNullOrEmpty(objectBindingScript)) throw new ArgumentNullException(nameof(objectBindingScript));
            this.templateHtml = templateHtml ?? string.Empty;    
            html = ModifyTemplate(this.templateHtml, apiKey, objectBindingScript, loadMap);
        }

        private string ModifyTemplate(string templateHtml, string apiKey, string objectBindingScript, Map? loadMap)
        {
            //alter the html passed and output modified html 

            //If user doesn't pass map, no center can be obtained. Default to NYC arbitrarily.
            var defaultMapCenter = GpsCoordinate.Parse("40.7128,-74.0060");

            //use var map to set params, establish default map obj if null
            var map = loadMap ?? new Map()
            {
                MapType = MapTypes.Hybrid,
                Zoom = 8,
                Center = defaultMapCenter,
            };



            //check if loadMap.Center has a value, otherwise can't access properties of nullable struct
            var centerCoord = map.Center ?? defaultMapCenter;

            //alter html template
            var html = templateHtml;
            html = InsertParam(html, "__APIKEY__", apiKey);
            html = InsertParam(html, "__LATITUDE__", centerCoord.Latitude.ToString());
            html = InsertParam(html, "__LONGITUDE__", centerCoord.Longitude.ToString());
            html = InsertParam(html, "__ZOOM__", map.Zoom.ToString());
            html = InsertParam(html, "__MAPTYPE__", map.MapType.ToString().ToLower());

            //inject script 
            if (objectBindingScript != null) html = InsertParam(html, "__INJECT_BINDING_SCRIPT__", objectBindingScript);

            return html;
        }


        private string InsertParam(string text, string placeholder, string value)
        {
            if (text.Contains(placeholder))
            {
                return text.Replace(placeholder, value);
            }
            else
            {
                throw new IOException($"Unable to insert template parameter:{placeholder} - Not found in file.");
            }
        }
    }
}




