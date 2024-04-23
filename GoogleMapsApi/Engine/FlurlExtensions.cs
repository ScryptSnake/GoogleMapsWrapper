using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Markup;
using Flurl;

namespace GoogleMapsWrapper.Engine
{
    public static class FlurlExtensions
    {

        /// <summary>
        /// An extension method to flur url to SetQueryParam with a default value.
        /// If the value passed is null or an empty string, the default value is used.
        /// If the default value is null, Flurl.NullValueHandling.Remove is enacted.
        /// </summary>
        public static Flurl.Url SetQueryParamWithDefault(this Flurl.Url url, string name,
            Object? value, object? defaultValue, bool isEncoded = false)
        {
            //initialize null string
            string? stringValue = null;
            //check if value is not null;
            if(value is not null)
            {
                //convert to string
                stringValue = value.ToString();
                if (string.IsNullOrWhiteSpace(stringValue))
                {
                    //Set as null so SetQueryParam() removes/doesn't add.
                    stringValue = null;
                }
            }

            if(defaultValue is not null && stringValue is null)
            {
                stringValue = defaultValue.ToString(); //set the default
            }
            url.SetQueryParam(name, stringValue, false);
            return url;
        }



    }
}
