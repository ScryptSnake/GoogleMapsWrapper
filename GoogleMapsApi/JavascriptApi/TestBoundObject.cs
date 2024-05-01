using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class TestBoundObject
    {
        // Sample property.
        public async Task<string> OnMapClick()
        {

            Debug.Print("FOOOO BAR");
            return string.Empty;
        }
    }
}

