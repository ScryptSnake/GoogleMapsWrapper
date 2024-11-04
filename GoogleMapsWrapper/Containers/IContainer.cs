using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Containers;
/// <summary>Describes a container object used to hold parsed data from an API response.</summary>
public interface IContainer
{
    /// <summary>A property to append data to the container.</summary>
    public object? AssociatedData { get; }
}
