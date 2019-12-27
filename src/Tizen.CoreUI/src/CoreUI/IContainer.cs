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
/// <summary>Common interface for objects (containers) that can have multiple contents (sub-objects).
/// 
/// APIs in this interface deal with containers of multiple sub-objects, not with individual parts.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.ContainerConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IContainer : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Begin iterating over this object&apos;s contents.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Iterator on object&apos;s content.</returns>
    IEnumerable<CoreUI.Gfx.IEntity> IterateContent();

    /// <summary>Returns the number of contained sub-objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Number of sub-objects.</returns>
    int ContentCount();

    /// <summary>Sent after a new sub-object was added.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ContainerContentAddedEventArgs"/></value>
    event EventHandler<CoreUI.ContainerContentAddedEventArgs> ContentAddedEvent;
    /// <summary>Sent after a sub-object was removed, before unref.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ContainerContentRemovedEventArgs"/></value>
    event EventHandler<CoreUI.ContainerContentRemovedEventArgs> ContentRemovedEvent;
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.IContainer.ContentAddedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ContainerContentAddedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Sent after a new sub-object was added.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.IContainer.ContentRemovedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ContainerContentRemovedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Sent after a sub-object was removed, before unref.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity arg { get; set; }
}

/// <summary>Common interface for objects (containers) that can have multiple contents (sub-objects).
/// 
/// APIs in this interface deal with containers of multiple sub-objects, not with individual parts.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ContainerConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IContainer
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ContainerConcrete))
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
    private ContainerConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_container_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IContainer"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ContainerConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Sent after a new sub-object was added.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ContainerContentAddedEventArgs"/></value>
    public event EventHandler<CoreUI.ContainerContentAddedEventArgs> ContentAddedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContainerContentAddedEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.EntityConcrete) });
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ContentAddedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnContentAddedEvent(CoreUI.ContainerContentAddedEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_CONTAINER_EVENT_CONTENT_ADDED", info, null);
    }

    /// <summary>Sent after a sub-object was removed, before unref.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ContainerContentRemovedEventArgs"/></value>
    public event EventHandler<CoreUI.ContainerContentRemovedEventArgs> ContentRemovedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContainerContentRemovedEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.EntityConcrete) });
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ContentRemovedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnContentRemovedEvent(CoreUI.ContainerContentRemovedEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_CONTAINER_EVENT_CONTENT_REMOVED", info, null);
    }


#pragma warning disable CS0628
    /// <summary>Begin iterating over this object&apos;s contents.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Iterator on object&apos;s content.</returns>
    public IEnumerable<CoreUI.Gfx.IEntity> IterateContent() {
        var _ret_var = CoreUI.ContainerConcrete.NativeMethods.efl_content_iterate_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.IEntity>(_ret_var);
    }

    /// <summary>Returns the number of contained sub-objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Number of sub-objects.</returns>
    public int ContentCount() {
        var _ret_var = CoreUI.ContainerConcrete.NativeMethods.efl_content_count_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.ContainerConcrete.efl_container_interface_get();
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

            if (efl_content_iterate_static_delegate == null)
            {
                efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
            }

            if (methods.Contains("IterateContent"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate) });
            }

            if (efl_content_count_static_delegate == null)
            {
                efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
            }

            if (methods.Contains("ContentCount"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate) });
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
            return CoreUI.ContainerConcrete.efl_container_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate System.IntPtr efl_content_iterate_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_content_iterate_api_delegate> efl_content_iterate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_content_iterate_api_delegate>(Module, "efl_content_iterate");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_content_iterate was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<CoreUI.Gfx.IEntity> _ret_var = null;
                try
                {
                    _ret_var = ((IContainer)ws.Target).IterateContent();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
            }
            else
            {
                return efl_content_iterate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_content_iterate_delegate efl_content_iterate_static_delegate;

        
        private delegate int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_content_count_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_content_count_api_delegate> efl_content_count_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_content_count_api_delegate>(Module, "efl_content_count");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int content_count(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_content_count was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IContainer)ws.Target).ContentCount();
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
                return efl_content_count_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_content_count_delegate efl_content_count_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

