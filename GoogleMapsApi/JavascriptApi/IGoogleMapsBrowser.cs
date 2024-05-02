using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi;

public interface IGoogleMapsBrowser {

    public object GetBrowserObject();

    public string Html { get; }

    public IMapBoundObject BoundObject { get; } 

    public GoogleMapsHtmlTemplate HtmlTemplate { get; }

    public Task LoadAsync();

    public void BindObject(IMapBoundObject boundObject);

    public Task ExecuteScriptAsync(string script);

    public void Close();





}
