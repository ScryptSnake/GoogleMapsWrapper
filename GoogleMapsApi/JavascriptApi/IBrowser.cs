using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsJavascriptApi
{
    internal interface IBrowser { 

        Task ConnectAsync(Uri url);

        Task ExecuteScriptAsync(string script, object[]? args = null);

        Task ReceiveScriptAsync(out object result);


    }
}
