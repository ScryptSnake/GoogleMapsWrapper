using GoogleMapsWrapper.JavascriptApi.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Browser
{
    /// <summary>
    /// A repository for storing map state. Data is sent from the IGoogleMapsBrowser to this object.
    /// </summary>
    internal interface IGoogleMapsJsRepository
    {
        IGoogleMapsBrowser? Source { get; }

        void AddMarker(BoundMarker marker); 

        void RemoveMarker(BoundMarker marker); 

        void UpdateMarker(BoundMarker marker);

        bool ContainsMarker(BoundMarker marker);

        public IReadOnlyList<BoundMarker> Markers { get; }

        public IGoogleMapsJsReadonlyRepository AsReadonly();

    }
}
