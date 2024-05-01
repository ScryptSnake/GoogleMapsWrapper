using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi
{
    internal class HtmlTemplateHelper
    {

        private string templateContent;
        public string TemplateContent { get => this.templateContent; }

        private string content;
        public string Content { get => this.content; }

        public HtmlTemplateHelper(string filename)
        {
            this.templateContent = File.ReadAllText(filename);
            this.content = string.Empty;

        }
        public string LoadParameters(string apiKey, GpsCoordinate center, string mapType = "hybrid", int zoom = 10)
        {
            var html = this.templateContent;
            html = html.Replace("*APIKEY*", apiKey);
            html = html.Replace("*LATITUDE*", center.Latitude.ToString());
            html = html.Replace("*LONGITUDE*", center.Longitude.ToString());
            html = html.Replace("*ZOOM*", zoom.ToString());
            html = html.Replace("*MAPTYPE*", mapType);

            this.content = html;
            return html;
        }

        




    }
}
