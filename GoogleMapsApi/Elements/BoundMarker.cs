using GoogleMapsWrapper.JavascriptApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Elements
{
    public class BoundMarker : Marker, INotifyPropertyChanged
    {

        event EventHandler<MarkerEventArgs> OnMarkerUpdated;



        public BoundMarker(GpsCoordinate Coordinate, string? Id = null, string? Name = null) : base(Coordinate, Id, Name)
        {
            

        }

        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public bool IsBound { get; }

        
        public IMapBoundObject MapBoundObject { get; }





    }

}
