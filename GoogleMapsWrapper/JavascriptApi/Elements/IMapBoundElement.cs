using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi
{
    public interface IMapBoundElement
    {

        string? Id { get; }

        string Serialize();

    }
}
