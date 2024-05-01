using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi
{
    public class HtmlTemplateHelper
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
        public void LoadParameters(string apiKey, GpsCoordinate center, string mapType = "hybrid", int zoom = 10)
        {
            var html = this.templateContent;
            html = html.Replace("__APIKEY__", apiKey);
            html = html.Replace("__LATITUDE__", center.Latitude.ToString());
            html = html.Replace("__LONGITUDE__", center.Longitude.ToString());
            html = html.Replace("__ZOOM__", zoom.ToString());
            html = html.Replace("__MAPTYPE__", mapType);

            this.content = html;
        }

        public void SetBindingScript(string script)
        {
            //script must not include script tags
            if (string.IsNullOrEmpty(this.content)){
                throw new System.Exception("Parameters must be set.");
            }
            this.content = this.content.Replace("__INJECT_BINDING_SCRIPT__", script);


        }
        




    }
}
