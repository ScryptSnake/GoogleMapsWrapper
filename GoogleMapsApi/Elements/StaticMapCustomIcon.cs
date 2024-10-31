using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Types;


namespace GoogleMapsWrapper.Api;
///<summary>An object that represents a custom icon for a marker. The source must be a Uri of an image.</summary>
public record StaticMapCustomIcon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StaticMapCustomIcon"/> class.
    /// </summary>
    /// <param name="Uri">The image source.</param>
    /// <param name="anchorType">How the icon is anchored.</param>
    /// <Remarks>Acceptable formats are:  .PNG, .GIF, .JPG/.JPEG. PNG is preferred.</Remarks>
    /// <exception cref="ArgumentException">Uri provided contains invalid image format.</exception>
    ///
    ///
    ///
    ///
    ///
    

    public Uri Uri { get; init }
    public MarkerIconAnchorTypes

    public StaticMapCustomIcon(string Uri, MarkerIconAnchorTypes anchorType=MarkerIconAnchorTypes.Center)
    {
        // Validate the uri is an acceptable format: JPEG, PNG, or GIF (PNG preferred).
        var uriFormat = Path.GetExtension(Uri);
        // Allowable extensions.
        var formatsAllowed = new string[]{ ".PNG", ".GIF", ".JPG", ".JPEG" };
        // Check extension.
        if (formatsAllowed.Contains(uriFormat, StringComparer.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Uri provided contains invalid image format.");
        }
    }
}
