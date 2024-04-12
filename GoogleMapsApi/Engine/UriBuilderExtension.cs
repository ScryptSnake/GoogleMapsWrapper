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
    public static class UriExtension
    {

        ///<summary> An extension method to add a URL query parameter to a UriBuilder. 
        ///If overwrite = true, will overwrite existing parameter, otherwise, appends duplicate. 
        public static UriBuilder AddParameter(this UriBuilder uriBuilder, string name, 
            Object? value, string? defaultValue=null, bool overwrite = true)

        {
            
            //forget HttpUtility for this - maybe use Flurl for a better solution? Heres a roll-your-own:
            if(value == null)
            {
                if (string.IsNullOrWhiteSpace(defaultValue))
                {
                    return uriBuilder;
                }
                else { value = defaultValue; }
            }
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[name] = Convert.ToString(value);
            uriBuilder.Query = query.ToString();
            return uriBuilder;
        }



    }
}
