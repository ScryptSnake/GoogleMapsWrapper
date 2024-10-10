using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Containers;
public interface IContainer
{
    public object? AssociatedData { get; }
}
