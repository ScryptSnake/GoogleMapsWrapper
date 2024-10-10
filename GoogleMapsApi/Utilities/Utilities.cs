using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace GoogleMapsWrapper.Utilities;

/// <summary>
/// A static class for generic utility functions that may be used in this application.
/// </summary>
public static class Utilities
{
    /// <summary>
    /// Convert a .NET Color object to a hexadecimal notation. If transparency (alpha) is provided
    /// in the color parameter, outputs 32 bit hex, else 24. 
    /// </summary>
    public static string ColorToHex(Color color)
    //convert a color object to hexedcimal notati
    {
        bool includeAlpha = color.A != 255;
        string hex;
        if (includeAlpha)
        {
            hex = $"0x{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }
        else
        {
            hex = $"0x{color.R:X2}{color.G:X2}{color.B:X2}";
        }
        return hex;
    }
    /// <summary>
    /// Convert a char to a URL encoded string representation.
    /// </summary>
    public static string UrlEncodeChar(char c)
    {
        // Convert the character to its hexadecimal representation for URL
        string hexValue = ((int)c).ToString("X2");
        return "%" + hexValue;
    }
}



    


