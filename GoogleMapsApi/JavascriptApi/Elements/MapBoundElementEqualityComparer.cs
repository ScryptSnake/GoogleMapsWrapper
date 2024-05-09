using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Elements
{

    /// <summary>
    /// An equality comparer for IMapBoundElement type, to check if two IMapBoundElements are
    /// have equal ID values.
    /// </summary>
    public class MapBoundElementEqualityComparer : IEqualityComparer<IMapBoundElement>
    {
        public bool Equals(IMapBoundElement? x, IMapBoundElement? y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x is null && y is null)
                return true;
            if (x is null || y is null)
                return false;
            //Compare by id - we are only concerned with the id comparison. 
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] IMapBoundElement obj)
        {
            if (obj.Id != null)
                return obj.Id.GetHashCode();
            else
                return 0;
        }
    }

}
