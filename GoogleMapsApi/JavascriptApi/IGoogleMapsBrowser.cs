using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi;

public interface IGoogleMapsBrowser<T> {


    public T BrowserObject { get; }

    public string Html { get; }

    public IMapBoundObject BoundObject { get; } 

    public Task InitializeAsync();

    public Task LoadAsync();

    public Task BindObjectAsync(IMapBoundObject boundObject);

    public void BindObject(IMapBoundObject boundObject);


    public Task AddMarkerAsync(Marker marker);
    public Task RemoveMarkerAsync(Marker marker);
    public Task SetMarkerAsync(Marker marker);


    public Task AddPoylineAsync(Polyline polyline);
    public Task RemovePolylineAsync(Polyline polyline);
    public Task SetPolylineAsync(Polyline polyline);


    public Task SetMapAsync(Map map);


    public void Close();





}
