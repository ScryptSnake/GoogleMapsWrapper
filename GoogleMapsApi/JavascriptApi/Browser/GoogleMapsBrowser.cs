using GoogleMapsWrapper.JavascriptApi.Elements;
using GoogleMapsWrapper.JavascriptApi.Html;
using GoogleMapsWrapper.JavascriptApi.Listener;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Browser
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class GoogleMapsBrowser : IGoogleMapsBrowser
    {

        private IBrowser browser;
        public IBrowser Browser{ get => browser; }

        private IGoogleMapsJsRepository repository; //Writeable version private
        public IGoogleMapsJsReadonlyRepository Repository { get => repository.AsReadonly(); }

        //private GoogleMapsHtmlTemplate htmlTemplate;
        //public GoogleMapsHtmlTemplate HtmlTemplate { get=> htmlTemplate; }  

        //public event EventHandler<BrowserErrorEventArgs>? OnError;
        public event EventHandler<MapClickEventArgs>? OnMapClick;
        public event EventHandler<MapClickEventArgs>? OnMapDblClick;
        public event EventHandler<MapClickEventArgs>? OnMapRightClick;
        public event EventHandler<MarkerClickEventArgs>? OnMarkerClick;
        public event EventHandler<MarkerClickEventArgs>? OnMarkerDblClick;
        public event EventHandler<MarkerClickEventArgs>? OnMarkerRightClick;
        public event EventHandler<MarkerDragEventArgs>? OnMarkerDrag;
        public event EventHandler<MarkerMouseEventArgs>? OnMarkerMouseOver;
        public event EventHandler<MarkerMouseEventArgs>? OnMarkerMouseOut;


        public GoogleMapsBrowser(IBrowser browser)
        {
            this.browser = browser;
            this.repository = new GoogleMapsRepository();
            browser.BindObject("boundObject", this);
        }

        public void Navigate(GoogleMapsHtmlTemplate template)
        {
            this.browser.Navigate(template.Html);   
        }

        public async Task AddMarkerAsync(BoundMarker boundMarker)
        {
            var marker = boundMarker;
            if (!repository.ContainsMarker(marker))
            {
                if (string.IsNullOrEmpty(boundMarker.Id))
                {
                    //copy the passed marker with a new GUID id. 
                    marker = BoundMarker.CopyAssignNewId(boundMarker);
                }
                //execute in browser
                var result = await browser.ExecuteScriptAsync($"addMarker('{boundMarker.Serialize()}')");

                if (result.IsSuccess)
                {
                    Debug.Print("success AddMarkerAsync???");
                    repository.AddMarker(marker);
                }
                else
                {
                    throw new System.Exception("Script Error returned from browser: " + result.ExceptionMessage);
                }
            }
        }


        public async Task RemoveMarkerAsync(BoundMarker boundMarker)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMarkerAsync(BoundMarker boundMarker)
        {
            throw new NotImplementedException();
        }



        public void Close()
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }


        public void _OnError(string message)
        {
            throw new GoogleMapsJavascriptException(message);
        }

        public void _OnMapClick(string coordinate)
        {
            var coord = GpsCoordinate.Parse(coordinate); //validate
            this.OnMapClick?.Invoke(this, new MapClickEventArgs(coord));
        }

        public void _OnMapDblClick(string coordinate)
        {
            Debug.Print("Adding........");

            var coord = GpsCoordinate.Parse(coordinate); //validate
            var newMarker = new BoundMarker(coord);
            Task.Run(async () =>
            {
                await AddMarkerAsync(newMarker);
            }).GetAwaiter().GetResult();

            this.OnMapDblClick?.Invoke(this, new MapClickEventArgs(coord));
        }

        public void _OnMapRightClick(string coordinate)
        {
            
            var coord = GpsCoordinate.Parse(coordinate); //validate
            this.OnMapRightClick?.Invoke(this, new MapClickEventArgs(coord));
        }

        public void _OnMarkerClick(string id)
        {
            throw new NotImplementedException();
        }

        public void _OnMarkerDblClick(string id)
        {
            throw new NotImplementedException();
        }

        public void _OnMarkerDrag(string id, string coordinate)
        {
            throw new NotImplementedException();
        }

        public void _OnMarkerMouseOut(string id)
        {
            throw new NotImplementedException();
        }

        public void _OnMarkerMouseOver(string id)
        {
            throw new NotImplementedException();
        }

        public void _OnMarkerRightClick(string id)
        {
            throw new NotImplementedException();
        }
    }
}
