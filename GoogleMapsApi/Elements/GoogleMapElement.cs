using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Elements
{


    public abstract class GoogleMapElement
    {
        public string? Name { get; set; }
        public string? Id { get; set; }
        public object? AssociatedData { get; set; }
        public virtual string? Color { get; set; }
        public virtual string? FillColor {  get; set; }

        public virtual bool Visible { get; set; }
    
    }

}