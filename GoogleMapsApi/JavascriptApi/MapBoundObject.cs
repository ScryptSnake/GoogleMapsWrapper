using System.Runtime.InteropServices;
using GoogleMapsWrapper.JavascriptApi.Elements;

namespace GoogleMapsWrapper.JavascriptApi
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class MapBoundObject
    {
        public event EventHandler<MarkerEventArgs> OnMarkerAdded;
        public event EventHandler<MarkerEventArgs> OnMarkerRemoved;
        public event EventHandler<MarkerEventArgs> OnMarkerUpdated;


        private LockSafeHashSet<BoundMarker> markers = new LockSafeHashSet<BoundMarker>(new MapBoundElementEqualityComparer());

        public IReadOnlyList<BoundMarker> MarkersCollection { get => markers.AsReadOnly(); }

        private IGoogleMapsBrowser browser;

        public MapBoundObject(IGoogleMapsBrowser browser)
        {
            this.browser = browser;
        }

        public async Task<BoundMarker> AddUpdateMarker(BoundMarker marker)
        {
            var json = string.Empty;
            if (marker.id == null)
                //Marker will be added....
            {
                var guid = Guid.NewGuid().ToString();
                var markerCopy = new BoundMarker(
                    guid,
                    marker.coordinates,
                    marker.color,
                    marker.info,
                    marker.draggable);
                json = $"AddMarker({marker.Serialize()})";
            }
            else if (markerExists(marker))
            {
                json = $"UpdateMarker({marker.Serialize()}")
            }
            else
            {

            }
            browser.ExecuteScriptAsync(json);
            AppendMarker


        }
    }
}