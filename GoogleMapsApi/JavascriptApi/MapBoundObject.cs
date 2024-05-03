using System.Runtime.InteropServices;

namespace GoogleMapsWrapper.JavascriptApi
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class MapBoundObject
    {
        public event EventHandler<MarkerEventArgs> OnMarkerAdded;
        public event EventHandler<MarkerEventArgs> OnMarkerRemoved;
        public event EventHandler<MarkerEventArgs> OnMarkerUpdated;

        private HashSet<string> MarkerUniqueIds = new HashSet<string>();


        private IList<BoundMarker> markers = new List<BoundMarker>();
        public IReadOnlyList<BoundMarker> MarkersCollection { get => markers.AsReadOnly(); }

        private IGoogleMapsBrowser browser;

        public MapBoundObject(IGoogleMapsBrowser browser)
        {
            this.browser = browser;
        }

        private readonly object locker = new();
        private void AppendMarkerListItem(BoundMarker marker)
        {
            lock (locker)
            {
                MarkerUniqueIds.Add
                this.markers.Add(marker);
            }
        }
        private void RemoveMarkerListItem(BoundMarker marker)
        {
            lock (locker)
            {
                markers.Remove(marker);
            }
        }
        
        private void

        private bool markerExists(BoundMarker marker) => 
            markers.Any(m => m.id == marker.id);

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