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
/// <summary>Low-level APIs for objects that can lay their children out.
/// 
/// Used for containers like <see cref="CoreUI.UI.Box"/> and <see cref="CoreUI.UI.Table"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.PackLayoutConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IPackLayout : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Requests EFL to recalculate the layout of this object.
    /// 
    /// Internal layout methods might be called asynchronously.</summary>
    /// <since_tizen> 6 </since_tizen>
    void LayoutRequest();

    /// <summary>Sent after the layout was updated.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler LayoutUpdatedEvent;
}

/// <summary>Low-level APIs for objects that can lay their children out.
/// 
/// Used for containers like <see cref="CoreUI.UI.Box"/> and <see cref="CoreUI.UI.Table"/>.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class PackLayoutConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IPackLayout
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(PackLayoutConcrete))
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
    private PackLayoutConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_pack_layout_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IPackLayout"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private PackLayoutConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Sent after the layout was updated.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler LayoutUpdatedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event LayoutUpdatedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnLayoutUpdatedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_PACK_EVENT_LAYOUT_UPDATED", IntPtr.Zero, null);
    }


#pragma warning disable CS0628
    /// <summary>Requests EFL to recalculate the layout of this object.
    /// 
    /// Internal layout methods might be called asynchronously.</summary>
    /// <since_tizen> 6 </since_tizen>
    public void LayoutRequest() {
        CoreUI.PackLayoutConcrete.NativeMethods.efl_pack_layout_request_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Implementation of this container&apos;s layout algorithm.
    /// 
    /// EFL will call this function whenever the contents of this container need to be re-laid out on the canvas.
    /// 
    /// This can be overridden to implement custom layout behaviors.</summary>
    /// <since_tizen> 6 </since_tizen>
    protected void UpdateLayout() {
        CoreUI.PackLayoutConcrete.NativeMethods.efl_pack_layout_update_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.PackLayoutConcrete.efl_pack_layout_interface_get();
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

            if (efl_pack_layout_request_static_delegate == null)
            {
                efl_pack_layout_request_static_delegate = new efl_pack_layout_request_delegate(layout_request);
            }

            if (methods.Contains("LayoutRequest"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_request"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_request_static_delegate) });
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
            return CoreUI.PackLayoutConcrete.efl_pack_layout_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_pack_layout_request_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_pack_layout_request_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_layout_request_api_delegate> efl_pack_layout_request_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_layout_request_api_delegate>(Module, "efl_pack_layout_request");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void layout_request(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_layout_request was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPackLayout)ws.Target).LayoutRequest();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_pack_layout_request_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_pack_layout_request_delegate efl_pack_layout_request_static_delegate;

        
        private delegate void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_pack_layout_update_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_layout_update_api_delegate> efl_pack_layout_update_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_layout_update_api_delegate>(Module, "efl_pack_layout_update");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

