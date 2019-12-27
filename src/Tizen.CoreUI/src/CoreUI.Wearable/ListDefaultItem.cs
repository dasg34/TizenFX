/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
namespace CoreUI.Wearable {
/// <summary>Wearable Default Item class to be used inside <see cref="CoreUI.UI.List"/> containers. It displays the three parts in horizontal order: <c>icon</c>, <c>text</c> and <c>extra</c>. Theming can change this arrangement.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wearable.ListDefaultItem.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public class ListDefaultItem : CoreUI.Wearable.DefaultItem
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ListDefaultItem))
            {
                return GetCoreUIClassStatic();
            }
            else
            {
                return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
        efl_wearable_list_default_item_class_get();

    /// <summary>Initializes a new instance of the <see cref="ListDefaultItem"/> class.
    /// </summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
/// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
    public ListDefaultItem(CoreUI.Object parent, System.String style = null) : base(efl_wearable_list_default_item_class_get(), parent)
    {
        if (CoreUI.Wrapper.Globals.ParamHelperCheck(style))
        {
            SetStyle(CoreUI.Wrapper.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.
    /// </summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    /// <since_tizen> 6 </since_tizen>
    protected ListDefaultItem(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ListDefaultItem"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
    /// </summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    internal ListDefaultItem(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ListDefaultItem"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
    /// </summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The CoreUI.Object parent of this instance.</param>
    protected ListDefaultItem(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
    {
    }


    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.Wearable.ListDefaultItem.efl_wearable_list_default_item_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal new class NativeMethods : CoreUI.Wearable.DefaultItem.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return CoreUI.Wearable.ListDefaultItem.efl_wearable_list_default_item_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

