using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using GoogleMapsWrapper.StaticMaps;


namespace GoogleMapsWrapper.Containers
{
    public record StaticMapContainer(
       byte[] image,

       StaticMapRequestParameter MapParameters,

       object? AssociatedData

        ) : IContainer
    {
        object? IContainer.AssociatedData => AssociatedData;
    }

}
