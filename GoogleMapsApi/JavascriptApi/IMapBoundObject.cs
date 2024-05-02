using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi;

public interface IMapBoundObject //NOTE: THIS TYPE SHOULD BE COM-VISIBLE
{



    event EventHandler<MarkerEventArgs> OnMarkerAdded;

    event EventHandler<MarkerEventArgs> OnMarkerRemoved;

    event EventHandler<MarkerEventArgs> OnMarkerUpdated;

    //----- event marshal methods called from JS
    public void _OnDebug(string message);
    public void _OnMarkerAdded(string latitude, string longitude);
    public void _OnMarkerRemoved(string id);
    public void _OnMarkerUpdated(string id);

    public void _OnMapException(string message);
    //----------------------------------------------



    public Task AddMarkerAsync(Marker marker);
    public Task RemoveMarkerAsync(Marker marker);
    public Task UpdateMarkerAsync(Marker marker);


    public Task AddPoylineAsync(Polyline polyline);
    public Task RemovePolylineAsync(Polyline polyline);
    public Task UpdatePolylineAsync(Polyline polyline);


    public Task SetMapAsync(Map map);






}
