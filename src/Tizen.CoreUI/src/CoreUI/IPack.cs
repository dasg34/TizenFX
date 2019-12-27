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
/// <summary>Common interface for objects (containers) with multiple contents (sub-objects) which can be added and removed at runtime.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.PackConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IPack : 
    CoreUI.IContainer,
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Removes all packed sub-objects and unreferences them.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    bool ClearPack();

    /// <summary>Removes all packed sub-objects without unreferencing them.
    /// 
    /// Use with caution.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    bool UnpackAll();

    /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="subobj">The sub-object to unpack.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
    bool Unpack(CoreUI.Gfx.IEntity subobj);

    /// <summary>Adds a sub-object to this container.
    /// 
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="subobj">The object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    bool Pack(CoreUI.Gfx.IEntity subobj);

}

/// <summary>Common interface for objects (containers) with multiple contents (sub-objects) which can be added and removed at runtime.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class PackConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IPack,
    CoreUI.IContainer
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(PackConcrete))
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
    private PackConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_pack_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IPack"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private PackConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
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
    /// <summary>Removes all packed sub-objects and unreferences them.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public bool ClearPack() {
        var _ret_var = CoreUI.PackConcrete.NativeMethods.efl_pack_clear_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Removes all packed sub-objects without unreferencing them.
    /// 
    /// Use with caution.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public bool UnpackAll() {
        var _ret_var = CoreUI.PackConcrete.NativeMethods.efl_pack_unpack_all_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="subobj">The sub-object to unpack.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
    public bool Unpack(CoreUI.Gfx.IEntity subobj) {
        var _ret_var = CoreUI.PackConcrete.NativeMethods.efl_pack_unpack_ptr.Value.Delegate(this.NativeHandle, subobj);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Adds a sub-object to this container.
    /// 
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="subobj">The object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    public bool Pack(CoreUI.Gfx.IEntity subobj) {
        var _ret_var = CoreUI.PackConcrete.NativeMethods.efl_pack_ptr.Value.Delegate(this.NativeHandle, subobj);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

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
        return CoreUI.PackConcrete.efl_pack_interface_get();
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

            if (efl_pack_clear_static_delegate == null)
            {
                efl_pack_clear_static_delegate = new efl_pack_clear_delegate(pack_clear);
            }

            if (methods.Contains("ClearPack"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_clear_static_delegate) });
            }

            if (efl_pack_unpack_all_static_delegate == null)
            {
                efl_pack_unpack_all_static_delegate = new efl_pack_unpack_all_delegate(unpack_all);
            }

            if (methods.Contains("UnpackAll"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack_all"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_all_static_delegate) });
            }

            if (efl_pack_unpack_static_delegate == null)
            {
                efl_pack_unpack_static_delegate = new efl_pack_unpack_delegate(unpack);
            }

            if (methods.Contains("Unpack"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_static_delegate) });
            }

            if (efl_pack_static_delegate == null)
            {
                efl_pack_static_delegate = new efl_pack_delegate(pack);
            }

            if (methods.Contains("Pack"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_static_delegate) });
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
            return CoreUI.PackConcrete.efl_pack_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_clear_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_clear_api_delegate> efl_pack_clear_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_clear_api_delegate>(Module, "efl_pack_clear");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool pack_clear(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_clear was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPack)ws.Target).ClearPack();
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
                return efl_pack_clear_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_pack_clear_delegate efl_pack_clear_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_unpack_all_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_unpack_all_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_unpack_all_api_delegate> efl_pack_unpack_all_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_unpack_all_api_delegate>(Module, "efl_pack_unpack_all");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool unpack_all(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_unpack_all was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPack)ws.Target).UnpackAll();
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
                return efl_pack_unpack_all_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_pack_unpack_all_delegate efl_pack_unpack_all_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_unpack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_unpack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_unpack_api_delegate> efl_pack_unpack_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_unpack_api_delegate>(Module, "efl_pack_unpack");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool unpack(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_unpack was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPack)ws.Target).Unpack(subobj);
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
                return efl_pack_unpack_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj);
            }
        }

        private static efl_pack_unpack_delegate efl_pack_unpack_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_api_delegate> efl_pack_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_api_delegate>(Module, "efl_pack");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool pack(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPack)ws.Target).Pack(subobj);
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
                return efl_pack_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj);
            }
        }

        private static efl_pack_delegate efl_pack_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

