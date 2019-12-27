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
/// <summary>Wearable Title Item Class.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wearable.TitleItem.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public class TitleItem : CoreUI.Wearable.Item, CoreUI.IText
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TitleItem))
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
        efl_wearable_title_item_class_get();

    /// <summary>Initializes a new instance of the <see cref="TitleItem"/> class.
    /// </summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
/// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
    public TitleItem(CoreUI.Object parent, System.String style = null) : base(efl_wearable_title_item_class_get(), parent)
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
    protected TitleItem(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TitleItem"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
    /// </summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    internal TitleItem(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TitleItem"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
    /// </summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The CoreUI.Object parent of this instance.</param>
    protected TitleItem(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>The text part for default items. This is the caption of the items.</summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.LayoutPartText TextPart
    {
        get
        {
            return GetPart("text") as CoreUI.UI.LayoutPartText;
        }
    }
    /// <summary>The text string to be displayed by the given text object.
    /// 
    /// Do not release (free) the returned value.</summary>
    /// <returns>Text string to display.</returns>
    /// <since_tizen> 6 </since_tizen>
    public virtual System.String GetText() {
        var _ret_var = CoreUI.TextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The text string to be displayed by the given text object.
    /// 
    /// Do not release (free) the returned value.</summary>
    /// <param name="text">Text string to display.</param>
    /// <since_tizen> 6 </since_tizen>
    public virtual void SetText(System.String text) {
        CoreUI.TextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), text);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The text string to be displayed by the given text object.
    /// 
    /// Do not release (free) the returned value.</summary>
    /// <value>Text string to display.</value>
    /// <since_tizen> 6 </since_tizen>
    public System.String Text {
        get { return GetText(); }
        set { SetText(value); }
    }

    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.Wearable.TitleItem.efl_wearable_title_item_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal new class NativeMethods : CoreUI.Wearable.Item.NativeMethods
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
            return CoreUI.Wearable.TitleItem.efl_wearable_title_item_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.Wearable {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class TitleItemExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<System.String> Text<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Wearable.TitleItem, T>magic = null) where T : CoreUI.Wearable.TitleItem {
        return new CoreUI.BindableProperty<System.String>("text", fac);
    }

    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindablePart<CoreUI.UI.LayoutPartText> TextPart<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Wearable.TitleItem, T> x=null) where T : CoreUI.Wearable.TitleItem
    {
        return new CoreUI.BindablePart<CoreUI.UI.LayoutPartText>("text", fac);
    }

}
#pragma warning restore CS1591
}

