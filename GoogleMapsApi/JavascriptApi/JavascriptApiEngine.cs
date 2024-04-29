using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi
{
    public class JavascriptApiEngine
    {


        private IConfiguration configuration;
        private GpsCoordinate center;
        private string key;

        private const string htmlTemplatePath = "C:\\GoogleMapsApi\\GoogleMapsApi\\JavascriptApi\\GoogleMapsJavascriptTemplate.html";


        public JavascriptApiEngine(IConfiguration config, GpsCoordinate center)
        {
            this.configuration = config;
            this.key = config["AppSettings:ApiKey"] ??
                throw new Exception("Configuration invalid. Failed to find key.");
            this.center = center;

        }


        public string GetHtml()
        {
            var template = File.ReadAllText(htmlTemplatePath);
            template = template.Replace("*APIKEY*", this.key);
            template = template.Replace("*LATITUDE*",this.center.Latitude.ToString());
            template = template.Replace("*LONGITUDE*", this.center.Longitude.ToString());

            return template;
        }



    }
}
