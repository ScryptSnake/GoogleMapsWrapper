using GoogleMapsWrapper.JavascriptApi.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Browser
{
    public class GoogleMapsRepository : IGoogleMapsJsRepository
    {

        private IGoogleMapsBrowser? source;
        public IGoogleMapsBrowser? Source { get => source;}

        public IGoogleMapsJsReadonlyRepository AsReadonly()
            //Convenience method - Expose a readonly version of the repo
        {
            var readonlyRepo = new GoogleMapsReadonlyRepository(this.Markers);
            return readonlyRepo;
        }


        private LockSafeHashSet<BoundMarker> hashSet;

        public GoogleMapsRepository()
        {
            this.hashSet =
            new LockSafeHashSet<BoundMarker>(new MapBoundElementEqualityComparer(), false);
        }

        public IReadOnlyList<BoundMarker> Markers { get => hashSet.Items; }

        public void AddMarker(BoundMarker marker)
        {
            hashSet.Add(marker);
        }

        public void RemoveMarker(BoundMarker marker)
        {
            hashSet.Remove(marker);
        }

        public void UpdateMarker(BoundMarker marker)
        {
            hashSet.Replace(marker);
        }

        public bool ContainsMarker(BoundMarker marker)
        {
           return hashSet.Contains(marker);
        }
    }
}
