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
namespace CoreUI.Gfx {
/// <summary>CoreUI Gfx Color mixin class</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Gfx.ColorConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IColor : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>The general/main color of the given Evas object.
    /// 
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
    /// <since_tizen> 6 </since_tizen>
    void GetColor(out int r, out int g, out int b, out int a);

    /// <summary>The general/main color of the given Evas object.
    /// 
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
    /// <since_tizen> 6 </since_tizen>
    void SetColor(int r, int g, int b, int a);

    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
    /// <returns>the hex color code.</returns>
    /// <since_tizen> 6 </since_tizen>
    System.String GetColorCode();

    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
    /// <param name="colorcode">the hex color code.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetColorCode(System.String colorcode);

    /// <summary>The general/main color of the given Evas object.
    /// 
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
    /// <since_tizen> 6 </since_tizen>
    (int, int, int, int) Color {
        get;
        set;
    }

    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
    /// <value>the hex color code.</value>
    /// <since_tizen> 6 </since_tizen>
    System.String ColorCode {
        get;
        set;
    }

}

/// <summary>CoreUI Gfx Color mixin class</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ColorConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IColor
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ColorConcrete))
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
    private ColorConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_color_mixin_get();

    /// <summary>Initializes a new instance of the <see cref="IColor"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ColorConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>The general/main color of the given Evas object.
    /// 
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
    /// <since_tizen> 6 </since_tizen>
    public void GetColor(out int r, out int g, out int b, out int a) {
        CoreUI.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_get_ptr.Value.Delegate(this.NativeHandle, out r, out g, out b, out a);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The general/main color of the given Evas object.
    /// 
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
    /// <since_tizen> 6 </since_tizen>
    public void SetColor(int r, int g, int b, int a) {
        CoreUI.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_set_ptr.Value.Delegate(this.NativeHandle, r, g, b, a);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
    /// <returns>the hex color code.</returns>
    /// <since_tizen> 6 </since_tizen>
    public System.String GetColorCode() {
        var _ret_var = CoreUI.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_code_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
    /// <param name="colorcode">the hex color code.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetColorCode(System.String colorcode) {
        CoreUI.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_code_set_ptr.Value.Delegate(this.NativeHandle, colorcode);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The general/main color of the given Evas object.
    /// 
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
    /// <since_tizen> 6 </since_tizen>
    public (int, int, int, int) Color {
        get {
            int _out_r = default(int);
            int _out_g = default(int);
            int _out_b = default(int);
            int _out_a = default(int);
            GetColor(out _out_r, out _out_g, out _out_b, out _out_a);
            return (_out_r, _out_g, _out_b, _out_a);
        }
        set { SetColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }

    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
    /// <value>the hex color code.</value>
    /// <since_tizen> 6 </since_tizen>
    public System.String ColorCode {
        get { return GetColorCode(); }
        set { SetColorCode(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.Gfx.ColorConcrete.efl_gfx_color_mixin_get();
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

            if (efl_gfx_color_get_static_delegate == null)
            {
                efl_gfx_color_get_static_delegate = new efl_gfx_color_get_delegate(color_get);
            }

            if (methods.Contains("GetColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_get_static_delegate) });
            }

            if (efl_gfx_color_set_static_delegate == null)
            {
                efl_gfx_color_set_static_delegate = new efl_gfx_color_set_delegate(color_set);
            }

            if (methods.Contains("SetColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_set_static_delegate) });
            }

            if (efl_gfx_color_code_get_static_delegate == null)
            {
                efl_gfx_color_code_get_static_delegate = new efl_gfx_color_code_get_delegate(color_code_get);
            }

            if (methods.Contains("GetColorCode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_get_static_delegate) });
            }

            if (efl_gfx_color_code_set_static_delegate == null)
            {
                efl_gfx_color_code_set_static_delegate = new efl_gfx_color_code_set_delegate(color_code_set);
            }

            if (methods.Contains("SetColorCode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_set_static_delegate) });
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
            return CoreUI.Gfx.ColorConcrete.efl_gfx_color_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int r,  out int g,  out int b,  out int a);

        
        internal delegate void efl_gfx_color_get_api_delegate(System.IntPtr obj,  out int r,  out int g,  out int b,  out int a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_get_api_delegate> efl_gfx_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_get_api_delegate>(Module, "efl_gfx_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void color_get(System.IntPtr obj, System.IntPtr pd, out int r, out int g, out int b, out int a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(int);g = default(int);b = default(int);a = default(int);
                try
                {
                    ((IColor)ws.Target).GetColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_gfx_color_get_delegate efl_gfx_color_get_static_delegate;

        
        private delegate void efl_gfx_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  int r,  int g,  int b,  int a);

        
        internal delegate void efl_gfx_color_set_api_delegate(System.IntPtr obj,  int r,  int g,  int b,  int a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_set_api_delegate> efl_gfx_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_set_api_delegate>(Module, "efl_gfx_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void color_set(System.IntPtr obj, System.IntPtr pd, int r, int g, int b, int a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IColor)ws.Target).SetColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), r, g, b, a);
            }
        }

        private static efl_gfx_color_set_delegate efl_gfx_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_gfx_color_code_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
        internal delegate System.String efl_gfx_color_code_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_code_get_api_delegate> efl_gfx_color_code_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_code_get_api_delegate>(Module, "efl_gfx_color_code_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.String color_code_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_color_code_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IColor)ws.Target).GetColorCode();
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
                return efl_gfx_color_code_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_color_code_get_delegate efl_gfx_color_code_get_static_delegate;

        
        private delegate void efl_gfx_color_code_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String colorcode);

        
        internal delegate void efl_gfx_color_code_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String colorcode);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_code_set_api_delegate> efl_gfx_color_code_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_color_code_set_api_delegate>(Module, "efl_gfx_color_code_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void color_code_set(System.IntPtr obj, System.IntPtr pd, System.String colorcode)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_color_code_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IColor)ws.Target).SetColorCode(colorcode);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_color_code_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), colorcode);
            }
        }

        private static efl_gfx_color_code_set_delegate efl_gfx_color_code_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.Gfx {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class ColorConcreteExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<System.String> ColorCode<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IColor, T>magic = null) where T : CoreUI.Gfx.IColor {
        return new CoreUI.BindableProperty<System.String>("color_code", fac);
    }

}
#pragma warning restore CS1591
}

