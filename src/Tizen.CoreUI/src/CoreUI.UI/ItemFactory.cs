using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CoreUI.UI
{

/// <summary>Helper factory class. Makes use of C# extension methods for easier property binding.
///
/// <code>
/// var factory = CoreUI.UI.Factory&lt;CoreUI.UI.Button&gt;();
/// factory.Style().Bind("Name"); // The factory Style property is bound to the Name property for the given model.
/// </code>
/// </summary>
/// <since_tizen> 6 </since_tizen>
public class ItemFactory<T> : CoreUI.UI.LayoutFactory
{
    /// <summary>Creates a new factory.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="parent">The parent of the factory.</param>
    public ItemFactory(CoreUI.Object parent = null)
        : base (parent, typeof(T))
    {
    }
}

}
