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
/// <summary>This interface provides methods for manipulating how contents are arranged within a container, providing more granularity for content positioning.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Gfx.ArrangementConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IArrangement : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <param name="align_horiz">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
    /// <param name="align_vert">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    void GetContentAlign(out CoreUI.Gfx.Align align_horiz, out CoreUI.Gfx.Align align_vert);

    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <param name="align_horiz">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
    /// <param name="align_vert">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetContentAlign(CoreUI.Gfx.Align align_horiz, CoreUI.Gfx.Align align_vert);

    /// <summary>This property determines the space between a container&apos;s content items.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
    /// <param name="pad_horiz">Horizontal padding.<br/>The default value is <c>0U</c>.</param>
    /// <param name="pad_vert">Vertical padding.<br/>The default value is <c>0U</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    void GetContentPadding(out uint pad_horiz, out uint pad_vert);

    /// <summary>This property determines the space between a container&apos;s content items.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
    /// <param name="pad_horiz">Horizontal padding.<br/>The default value is <c>0U</c>.</param>
    /// <param name="pad_vert">Vertical padding.<br/>The default value is <c>0U</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetContentPadding(uint pad_horiz, uint pad_vert);

    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <value>Controls the horizontal alignment.</value>
    /// <since_tizen> 6 </since_tizen>
    (CoreUI.Gfx.Align, CoreUI.Gfx.Align) ContentAlign {
        get;
        set;
    }

    /// <summary>This property determines the space between a container&apos;s content items.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
    /// <value>Horizontal padding.</value>
    /// <since_tizen> 6 </since_tizen>
    (uint, uint) ContentPadding {
        get;
        set;
    }

}

/// <summary>This interface provides methods for manipulating how contents are arranged within a container, providing more granularity for content positioning.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ArrangementConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IArrangement
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ArrangementConcrete))
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
    private ArrangementConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_arrangement_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IArrangement"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ArrangementConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <param name="align_horiz">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
    /// <param name="align_vert">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    public void GetContentAlign(out CoreUI.Gfx.Align align_horiz, out CoreUI.Gfx.Align align_vert) {
        CoreUI.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_get_ptr.Value.Delegate(this.NativeHandle, out align_horiz, out align_vert);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <param name="align_horiz">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
    /// <param name="align_vert">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetContentAlign(CoreUI.Gfx.Align align_horiz, CoreUI.Gfx.Align align_vert) {
        CoreUI.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_set_ptr.Value.Delegate(this.NativeHandle, align_horiz, align_vert);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This property determines the space between a container&apos;s content items.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
    /// <param name="pad_horiz">Horizontal padding.<br/>The default value is <c>0U</c>.</param>
    /// <param name="pad_vert">Vertical padding.<br/>The default value is <c>0U</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    public void GetContentPadding(out uint pad_horiz, out uint pad_vert) {
        CoreUI.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate(this.NativeHandle, out pad_horiz, out pad_vert);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This property determines the space between a container&apos;s content items.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
    /// <param name="pad_horiz">Horizontal padding.<br/>The default value is <c>0U</c>.</param>
    /// <param name="pad_vert">Vertical padding.<br/>The default value is <c>0U</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetContentPadding(uint pad_horiz, uint pad_vert) {
        CoreUI.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate(this.NativeHandle, pad_horiz, pad_vert);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <value>Controls the horizontal alignment.</value>
    /// <since_tizen> 6 </since_tizen>
    public (CoreUI.Gfx.Align, CoreUI.Gfx.Align) ContentAlign {
        get {
            CoreUI.Gfx.Align _out_align_horiz = default(CoreUI.Gfx.Align);
            CoreUI.Gfx.Align _out_align_vert = default(CoreUI.Gfx.Align);
            GetContentAlign(out _out_align_horiz, out _out_align_vert);
            return (_out_align_horiz, _out_align_vert);
        }
        set { SetContentAlign( value.Item1,  value.Item2); }
    }

    /// <summary>This property determines the space between a container&apos;s content items.
    /// 
    /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
    /// <value>Horizontal padding.</value>
    /// <since_tizen> 6 </since_tizen>
    public (uint, uint) ContentPadding {
        get {
            uint _out_pad_horiz = default(uint);
            uint _out_pad_vert = default(uint);
            GetContentPadding(out _out_pad_horiz, out _out_pad_vert);
            return (_out_pad_horiz, _out_pad_vert);
        }
        set { SetContentPadding( value.Item1,  value.Item2); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.Gfx.ArrangementConcrete.efl_gfx_arrangement_interface_get();
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

            if (efl_gfx_arrangement_content_align_get_static_delegate == null)
            {
                efl_gfx_arrangement_content_align_get_static_delegate = new efl_gfx_arrangement_content_align_get_delegate(content_align_get);
            }

            if (methods.Contains("GetContentAlign"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_align_get_static_delegate) });
            }

            if (efl_gfx_arrangement_content_align_set_static_delegate == null)
            {
                efl_gfx_arrangement_content_align_set_static_delegate = new efl_gfx_arrangement_content_align_set_delegate(content_align_set);
            }

            if (methods.Contains("SetContentAlign"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_align_set_static_delegate) });
            }

            if (efl_gfx_arrangement_content_padding_get_static_delegate == null)
            {
                efl_gfx_arrangement_content_padding_get_static_delegate = new efl_gfx_arrangement_content_padding_get_delegate(content_padding_get);
            }

            if (methods.Contains("GetContentPadding"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_padding_get_static_delegate) });
            }

            if (efl_gfx_arrangement_content_padding_set_static_delegate == null)
            {
                efl_gfx_arrangement_content_padding_set_static_delegate = new efl_gfx_arrangement_content_padding_set_delegate(content_padding_set);
            }

            if (methods.Contains("SetContentPadding"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_padding_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_padding_set_static_delegate) });
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
            return CoreUI.Gfx.ArrangementConcrete.efl_gfx_arrangement_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_arrangement_content_align_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.Gfx.Align align_horiz,  out CoreUI.Gfx.Align align_vert);

        
        internal delegate void efl_gfx_arrangement_content_align_get_api_delegate(System.IntPtr obj,  out CoreUI.Gfx.Align align_horiz,  out CoreUI.Gfx.Align align_vert);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_arrangement_content_align_get_api_delegate> efl_gfx_arrangement_content_align_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_arrangement_content_align_get_api_delegate>(Module, "efl_gfx_arrangement_content_align_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void content_align_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.Gfx.Align align_horiz, out CoreUI.Gfx.Align align_vert)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_arrangement_content_align_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                align_horiz = default(CoreUI.Gfx.Align);align_vert = default(CoreUI.Gfx.Align);
                try
                {
                    ((IArrangement)ws.Target).GetContentAlign(out align_horiz, out align_vert);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_arrangement_content_align_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out align_horiz, out align_vert);
            }
        }

        private static efl_gfx_arrangement_content_align_get_delegate efl_gfx_arrangement_content_align_get_static_delegate;

        
        private delegate void efl_gfx_arrangement_content_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Gfx.Align align_horiz,  CoreUI.Gfx.Align align_vert);

        
        internal delegate void efl_gfx_arrangement_content_align_set_api_delegate(System.IntPtr obj,  CoreUI.Gfx.Align align_horiz,  CoreUI.Gfx.Align align_vert);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_arrangement_content_align_set_api_delegate> efl_gfx_arrangement_content_align_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_arrangement_content_align_set_api_delegate>(Module, "efl_gfx_arrangement_content_align_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void content_align_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.Align align_horiz, CoreUI.Gfx.Align align_vert)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_arrangement_content_align_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IArrangement)ws.Target).SetContentAlign(align_horiz, align_vert);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_arrangement_content_align_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), align_horiz, align_vert);
            }
        }

        private static efl_gfx_arrangement_content_align_set_delegate efl_gfx_arrangement_content_align_set_static_delegate;

        
        private delegate void efl_gfx_arrangement_content_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,  out uint pad_horiz,  out uint pad_vert);

        
        internal delegate void efl_gfx_arrangement_content_padding_get_api_delegate(System.IntPtr obj,  out uint pad_horiz,  out uint pad_vert);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_arrangement_content_padding_get_api_delegate> efl_gfx_arrangement_content_padding_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_arrangement_content_padding_get_api_delegate>(Module, "efl_gfx_arrangement_content_padding_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void content_padding_get(System.IntPtr obj, System.IntPtr pd, out uint pad_horiz, out uint pad_vert)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_arrangement_content_padding_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                pad_horiz = default(uint);pad_vert = default(uint);
                try
                {
                    ((IArrangement)ws.Target).GetContentPadding(out pad_horiz, out pad_vert);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out pad_horiz, out pad_vert);
            }
        }

        private static efl_gfx_arrangement_content_padding_get_delegate efl_gfx_arrangement_content_padding_get_static_delegate;

        
        private delegate void efl_gfx_arrangement_content_padding_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint pad_horiz,  uint pad_vert);

        
        internal delegate void efl_gfx_arrangement_content_padding_set_api_delegate(System.IntPtr obj,  uint pad_horiz,  uint pad_vert);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_arrangement_content_padding_set_api_delegate> efl_gfx_arrangement_content_padding_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_arrangement_content_padding_set_api_delegate>(Module, "efl_gfx_arrangement_content_padding_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void content_padding_set(System.IntPtr obj, System.IntPtr pd, uint pad_horiz, uint pad_vert)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_arrangement_content_padding_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IArrangement)ws.Target).SetContentPadding(pad_horiz, pad_vert);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pad_horiz, pad_vert);
            }
        }

        private static efl_gfx_arrangement_content_padding_set_delegate efl_gfx_arrangement_content_padding_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

