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
namespace CoreUI {
/// <summary>CoreUI text interface</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.TextConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IText : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>The text string to be displayed by the given text object.
    /// 
    /// Do not release (free) the returned value.</summary>
    /// <returns>Text string to display.</returns>
    /// <since_tizen> 6 </since_tizen>
    System.String GetText();

    /// <summary>The text string to be displayed by the given text object.
    /// 
    /// Do not release (free) the returned value.</summary>
    /// <param name="text">Text string to display.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetText(System.String text);

    /// <summary>The text string to be displayed by the given text object.
    /// 
    /// Do not release (free) the returned value.</summary>
    /// <value>Text string to display.</value>
    /// <since_tizen> 6 </since_tizen>
    System.String Text {
        get;
        set;
    }

}

/// <summary>CoreUI text interface</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class TextConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IText
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TextConcrete))
            {
                return GetCoreUIClassStatic();
            }
            else
            {
                return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private TextConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_text_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IText"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private TextConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>The text string to be displayed by the given text object.
    /// 
    /// Do not release (free) the returned value.</summary>
    /// <returns>Text string to display.</returns>
    /// <since_tizen> 6 </since_tizen>
    public System.String GetText() {
        var _ret_var = CoreUI.TextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The text string to be displayed by the given text object.
    /// 
    /// Do not release (free) the returned value.</summary>
    /// <param name="text">Text string to display.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetText(System.String text) {
        CoreUI.TextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate(this.NativeHandle, text);
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

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.TextConcrete.efl_text_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal new class NativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_text_get_static_delegate == null)
            {
                efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
            }

            if (methods.Contains("GetText"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate) });
            }

            if (efl_text_set_static_delegate == null)
            {
                efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
            }

            if (methods.Contains("SetText"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate) });
            }

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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return CoreUI.TextConcrete.efl_text_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_text_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_get_api_delegate> efl_text_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_get_api_delegate>(Module, "efl_text_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String text_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IText)ws.Target).GetText();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_text_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_text_get_delegate efl_text_get_static_delegate;

        
        private delegate void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String text);

        
        internal delegate void efl_text_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String text);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_text_set_api_delegate> efl_text_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_text_set_api_delegate>(Module, "efl_text_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void text_set(System.IntPtr obj, System.IntPtr pd, System.String text)
        {
            CoreUI.DataTypes.Log.Debug("function efl_text_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IText)ws.Target).SetText(text);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_text_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), text);
            }
        }

        private static efl_text_set_delegate efl_text_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class TextConcreteExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<System.String> Text<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IText, T>magic = null) where T : CoreUI.IText {
        return new CoreUI.BindableProperty<System.String>("text", fac);
    }

}
#pragma warning restore CS1591
}

