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
namespace CoreUI.UI.PositionManager {
/// <param name="range">The range of items to fill into @.memory. The length of memory must be bigger or equal to the requested items</param>
/// <param name="memory">The slice to fill the information in, the full slice will be filled if there are enough items.</param>
/// <returns>The returned stats of this function call.</returns>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public delegate CoreUI.UI.PositionManager.ObjectBatchResult ObjectBatchCallback(CoreUI.UI.PositionManager.RequestRange range,  CoreUI.DataTypes.RwSlice memory);
internal delegate CoreUI.UI.PositionManager.ObjectBatchResult.NativeStruct ObjectBatchCallbackInternal(IntPtr data,  CoreUI.UI.PositionManager.RequestRange.NativeStruct range,   CoreUI.DataTypes.RwSlice memory);
internal class ObjectBatchCallbackWrapper
{

    private ObjectBatchCallbackInternal _cb;
    private IntPtr _cb_data;
    private CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb;

    internal ObjectBatchCallbackWrapper (ObjectBatchCallbackInternal _cb, IntPtr _cb_data, CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~ObjectBatchCallbackWrapper()
    {
        if (this._cb_free_cb != null)
        {
            CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
        }
    }

    internal CoreUI.UI.PositionManager.ObjectBatchResult ManagedCb(CoreUI.UI.PositionManager.RequestRange range,  CoreUI.DataTypes.RwSlice memory)
    {
CoreUI.UI.PositionManager.RequestRange.NativeStruct _in_range = range;
var _ret_var = _cb(_cb_data, _in_range, memory);
CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

        internal static CoreUI.UI.PositionManager.ObjectBatchResult.NativeStruct Cb(IntPtr cb_data,  CoreUI.UI.PositionManager.RequestRange.NativeStruct range,   CoreUI.DataTypes.RwSlice memory)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        ObjectBatchCallback cb = (ObjectBatchCallback)handle.Target;
CoreUI.UI.PositionManager.RequestRange _in_range = range;
CoreUI.UI.PositionManager.ObjectBatchResult _ret_var = default(CoreUI.UI.PositionManager.ObjectBatchResult);        try {
            _ret_var = cb(_in_range, memory);
        } catch (Exception e) {
            CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
            CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
        }
        return _ret_var;    }
}
}

namespace CoreUI.UI.PositionManager {
/// <param name="conf">The configuration for this call.</param>
/// <param name="memory">The slice to fill the information in, the full slice will be filled if there are enough items.</param>
/// <returns>The returned stats of this function call</returns>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public delegate CoreUI.UI.PositionManager.SizeBatchResult SizeBatchCallback(CoreUI.UI.PositionManager.SizeCallConfig conf,  CoreUI.DataTypes.RwSlice memory);
internal delegate CoreUI.UI.PositionManager.SizeBatchResult.NativeStruct SizeBatchCallbackInternal(IntPtr data,  CoreUI.UI.PositionManager.SizeCallConfig.NativeStruct conf,   CoreUI.DataTypes.RwSlice memory);
internal class SizeBatchCallbackWrapper
{

    private SizeBatchCallbackInternal _cb;
    private IntPtr _cb_data;
    private CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb;

    internal SizeBatchCallbackWrapper (SizeBatchCallbackInternal _cb, IntPtr _cb_data, CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~SizeBatchCallbackWrapper()
    {
        if (this._cb_free_cb != null)
        {
            CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
        }
    }

    internal CoreUI.UI.PositionManager.SizeBatchResult ManagedCb(CoreUI.UI.PositionManager.SizeCallConfig conf,  CoreUI.DataTypes.RwSlice memory)
    {
CoreUI.UI.PositionManager.SizeCallConfig.NativeStruct _in_conf = conf;
var _ret_var = _cb(_cb_data, _in_conf, memory);
CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

        internal static CoreUI.UI.PositionManager.SizeBatchResult.NativeStruct Cb(IntPtr cb_data,  CoreUI.UI.PositionManager.SizeCallConfig.NativeStruct conf,   CoreUI.DataTypes.RwSlice memory)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        SizeBatchCallback cb = (SizeBatchCallback)handle.Target;
CoreUI.UI.PositionManager.SizeCallConfig _in_conf = conf;
CoreUI.UI.PositionManager.SizeBatchResult _ret_var = default(CoreUI.UI.PositionManager.SizeBatchResult);        try {
            _ret_var = cb(_in_conf, memory);
        } catch (Exception e) {
            CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
            CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
        }
        return _ret_var;    }
}
}

namespace CoreUI.UI.PositionManager {
/// <summary>Interface for abstracting the data access of the position managers.
/// 
/// The idea here is that a data-provider calls <see cref="CoreUI.UI.PositionManager.IDataAccessV1.SetDataAccess"/> on the position manager object and passes the functions that are defined here. Later, the position manager can call these function callbacks to get sizes or objects. A data-provider should always fill all requested items. If an item is not available <c>null</c> should be inserted. If a size is not available, an as-close-as-possible approximation should be inserted. The Size callback is equipped with a parameter to specify caching requests. This flag can be used to differentiate between two use cases: When the size is being requested to build up a cache over all items, and when the size is being requested to apply it to the object. Since the data-provider might need to do expensive operations to find the exact size, the as-close-as-possible approximation is usually enough when building caches. If real object placement is happening, then real sizes must be requested. If a size changes after it was returned due to batching, this change still should be announced with the <see cref="CoreUI.UI.PositionManager.IEntity.ItemSizeChanged"/> function.
/// 
/// The depth of the items is used to express a hierarchical structure on the items themselves. Any given depth might or might not have a <c>depth_leader</c>. A group is ended when there is either a lower depth, or another <c>depth_leader</c>.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.UI.PositionManager.DataAccessV1Concrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IDataAccessV1 : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
    /// 
    /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="CoreUI.UI.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <param name="canvas">Will use this object to freeze/thaw canvas events.</param>
    /// <param name="obj_access">Function callback for canvas objects, even if the start_id is valid, the returned objects may be <c>NULL</c>.</param>
    /// <param name="size_access">Function callback for the size, returned values are always valid, but might be changed later on.</param>
    /// <param name="size">valid size for start_id, 0 &lt;= i &lt; size</param>
    /// <since_tizen> 6 </since_tizen>
    void SetDataAccess(CoreUI.UI.Win canvas, CoreUI.UI.PositionManager.ObjectBatchCallback obj_access, CoreUI.UI.PositionManager.SizeBatchCallback size_access, int size);

    /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
    /// 
    /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="CoreUI.UI.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <value>Will use this object to freeze/thaw canvas events.</value>
    /// <since_tizen> 6 </since_tizen>
    (CoreUI.UI.Win, CoreUI.UI.PositionManager.ObjectBatchCallback, CoreUI.UI.PositionManager.SizeBatchCallback, int) DataAccess {
        set;
    }

}

/// <summary>Interface for abstracting the data access of the position managers.
/// 
/// The idea here is that a data-provider calls <see cref="CoreUI.UI.PositionManager.IDataAccessV1.SetDataAccess"/> on the position manager object and passes the functions that are defined here. Later, the position manager can call these function callbacks to get sizes or objects. A data-provider should always fill all requested items. If an item is not available <c>null</c> should be inserted. If a size is not available, an as-close-as-possible approximation should be inserted. The Size callback is equipped with a parameter to specify caching requests. This flag can be used to differentiate between two use cases: When the size is being requested to build up a cache over all items, and when the size is being requested to apply it to the object. Since the data-provider might need to do expensive operations to find the exact size, the as-close-as-possible approximation is usually enough when building caches. If real object placement is happening, then real sizes must be requested. If a size changes after it was returned due to batching, this change still should be announced with the <see cref="CoreUI.UI.PositionManager.IEntity.ItemSizeChanged"/> function.
/// 
/// The depth of the items is used to express a hierarchical structure on the items themselves. Any given depth might or might not have a <c>depth_leader</c>. A group is ended when there is either a lower depth, or another <c>depth_leader</c>.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class DataAccessV1Concrete :
    CoreUI.Wrapper.ObjectWrapper,
    IDataAccessV1
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(DataAccessV1Concrete))
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
    private DataAccessV1Concrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_position_manager_data_access_v1_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IDataAccessV1"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private DataAccessV1Concrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
    /// 
    /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="CoreUI.UI.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <param name="canvas">Will use this object to freeze/thaw canvas events.</param>
    /// <param name="obj_access">Function callback for canvas objects, even if the start_id is valid, the returned objects may be <c>NULL</c>.</param>
    /// <param name="size_access">Function callback for the size, returned values are always valid, but might be changed later on.</param>
    /// <param name="size">valid size for start_id, 0 &lt;= i &lt; size</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetDataAccess(CoreUI.UI.Win canvas, CoreUI.UI.PositionManager.ObjectBatchCallback obj_access, CoreUI.UI.PositionManager.SizeBatchCallback size_access, int size) {
        GCHandle obj_access_handle = GCHandle.Alloc(obj_access);
GCHandle size_access_handle = GCHandle.Alloc(size_access);
CoreUI.UI.PositionManager.DataAccessV1Concrete.NativeMethods.efl_ui_position_manager_data_access_v1_data_access_set_ptr.Value.Delegate(this.NativeHandle, canvas, GCHandle.ToIntPtr(obj_access_handle), CoreUI.UI.PositionManager.ObjectBatchCallbackWrapper.Cb, CoreUI.Wrapper.Globals.free_gchandle, GCHandle.ToIntPtr(size_access_handle), CoreUI.UI.PositionManager.SizeBatchCallbackWrapper.Cb, CoreUI.Wrapper.Globals.free_gchandle, size);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
    /// 
    /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="CoreUI.UI.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <value>Will use this object to freeze/thaw canvas events.</value>
    /// <since_tizen> 6 </since_tizen>
    public (CoreUI.UI.Win, CoreUI.UI.PositionManager.ObjectBatchCallback, CoreUI.UI.PositionManager.SizeBatchCallback, int) DataAccess {
        set { SetDataAccess( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.UI.PositionManager.DataAccessV1Concrete.efl_ui_position_manager_data_access_v1_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal new class NativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_position_manager_data_access_v1_data_access_set_static_delegate == null)
            {
                efl_ui_position_manager_data_access_v1_data_access_set_static_delegate = new efl_ui_position_manager_data_access_v1_data_access_set_delegate(data_access_set);
            }

            if (methods.Contains("SetDataAccess"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_data_access_v1_data_access_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_data_access_v1_data_access_set_static_delegate) });
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
            return CoreUI.UI.PositionManager.DataAccessV1Concrete.efl_ui_position_manager_data_access_v1_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_position_manager_data_access_v1_data_access_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Win canvas,  IntPtr obj_access_data, CoreUI.UI.PositionManager.ObjectBatchCallbackInternal obj_access, CoreUI.DataTypes.Callbacks.EinaFreeCb obj_access_free_cb,  IntPtr size_access_data, CoreUI.UI.PositionManager.SizeBatchCallbackInternal size_access, CoreUI.DataTypes.Callbacks.EinaFreeCb size_access_free_cb,  int size);

        
        internal delegate void efl_ui_position_manager_data_access_v1_data_access_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Win canvas,  IntPtr obj_access_data, CoreUI.UI.PositionManager.ObjectBatchCallbackInternal obj_access, CoreUI.DataTypes.Callbacks.EinaFreeCb obj_access_free_cb,  IntPtr size_access_data, CoreUI.UI.PositionManager.SizeBatchCallbackInternal size_access, CoreUI.DataTypes.Callbacks.EinaFreeCb size_access_free_cb,  int size);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_data_access_v1_data_access_set_api_delegate> efl_ui_position_manager_data_access_v1_data_access_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_data_access_v1_data_access_set_api_delegate>(Module, "efl_ui_position_manager_data_access_v1_data_access_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void data_access_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Win canvas, IntPtr obj_access_data, CoreUI.UI.PositionManager.ObjectBatchCallbackInternal obj_access, CoreUI.DataTypes.Callbacks.EinaFreeCb obj_access_free_cb, IntPtr size_access_data, CoreUI.UI.PositionManager.SizeBatchCallbackInternal size_access, CoreUI.DataTypes.Callbacks.EinaFreeCb size_access_free_cb, int size)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_data_access_v1_data_access_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                    CoreUI.UI.PositionManager.ObjectBatchCallbackWrapper obj_access_wrapper = new CoreUI.UI.PositionManager.ObjectBatchCallbackWrapper(obj_access, obj_access_data, obj_access_free_cb);
    CoreUI.UI.PositionManager.SizeBatchCallbackWrapper size_access_wrapper = new CoreUI.UI.PositionManager.SizeBatchCallbackWrapper(size_access, size_access_data, size_access_free_cb);

                try
                {
                    ((IDataAccessV1)ws.Target).SetDataAccess(canvas, obj_access_wrapper.ManagedCb, size_access_wrapper.ManagedCb, size);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_position_manager_data_access_v1_data_access_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), canvas, obj_access_data, obj_access, obj_access_free_cb, size_access_data, size_access, size_access_free_cb, size);
            }
        }

        private static efl_ui_position_manager_data_access_v1_data_access_set_delegate efl_ui_position_manager_data_access_v1_data_access_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.UI.PositionManager {
/// <summary>Representing the range of a request.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct RequestRange : IEquatable<RequestRange>
{
    /// <summary>The first item that must be filled into the passed slice.</summary>
    /// <since_tizen> 6 </since_tizen>
    public uint Start_id;
    /// <summary>The last item that must be filled into the passed slice.</summary>
    /// <since_tizen> 6 </since_tizen>
    public uint End_id;
    /// <summary>Constructor for RequestRange.
    /// </summary>
    /// <param name="Start_id">The first item that must be filled into the passed slice.</param>
    /// <param name="End_id">The last item that must be filled into the passed slice.</param>
    /// <since_tizen> 6 </since_tizen>
    public RequestRange(
        uint Start_id = default(uint),
        uint End_id = default(uint)    )
    {
        this.Start_id = Start_id;
        this.End_id = End_id;
    }

    /// <summary>Packs tuple into RequestRange object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator RequestRange(
        (
         uint Start_id,
         uint End_id
        ) tuple)
    {
        return new RequestRange{
            Start_id = tuple.Start_id,
            End_id = tuple.End_id,
        };
    }
    /// <summary>Unpacks RequestRange into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out uint Start_id,
        out uint End_id
    )
    {
        Start_id = this.Start_id;
        End_id = this.End_id;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Start_id.GetHashCode();
        hash = hash * 23 + End_id.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(RequestRange other)
    {
        return Start_id == other.Start_id && End_id == other.End_id        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is RequestRange) ? Equals((RequestRange)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(RequestRange lhs, RequestRange rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(RequestRange lhs, RequestRange rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator RequestRange(IntPtr ptr)
    {
        var tmp = (RequestRange.NativeStruct)Marshal.PtrToStructure(ptr, typeof(RequestRange.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static RequestRange FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct RequestRange.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public uint Start_id;
        
        public uint End_id;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator RequestRange.NativeStruct(RequestRange _external_struct)
        {
            var _internal_struct = new RequestRange.NativeStruct();
            _internal_struct.Start_id = _external_struct.Start_id;
            _internal_struct.End_id = _external_struct.End_id;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator RequestRange(RequestRange.NativeStruct _internal_struct)
        {
            var _external_struct = new RequestRange();
            _external_struct.Start_id = _internal_struct.Start_id;
            _external_struct.End_id = _internal_struct.End_id;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.UI.PositionManager {
/// <summary>Struct that is getting filled by the object function callback.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct ObjectBatchEntity : IEquatable<ObjectBatchEntity>
{
    /// <summary>The canvas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity Entity;
    /// <summary>The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</summary>
    /// <since_tizen> 6 </since_tizen>
    public byte Element_depth;
    /// <summary><c>true</c> if this is the leader of a group</summary>
    /// <since_tizen> 6 </since_tizen>
    public bool Depth_leader;
    /// <summary>Constructor for ObjectBatchEntity.
    /// </summary>
    /// <param name="Entity">The canvas object.</param>
    /// <param name="Element_depth">The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</param>
    /// <param name="Depth_leader"><c>true</c> if this is the leader of a group</param>
    /// <since_tizen> 6 </since_tizen>
    public ObjectBatchEntity(
        CoreUI.Gfx.IEntity Entity = default(CoreUI.Gfx.IEntity),
        byte Element_depth = default(byte),
        bool Depth_leader = default(bool)    )
    {
        this.Entity = Entity;
        this.Element_depth = Element_depth;
        this.Depth_leader = Depth_leader;
    }

    /// <summary>Packs tuple into ObjectBatchEntity object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator ObjectBatchEntity(
        (
         CoreUI.Gfx.IEntity Entity,
         byte Element_depth,
         bool Depth_leader
        ) tuple)
    {
        return new ObjectBatchEntity{
            Entity = tuple.Entity,
            Element_depth = tuple.Element_depth,
            Depth_leader = tuple.Depth_leader,
        };
    }
    /// <summary>Unpacks ObjectBatchEntity into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out CoreUI.Gfx.IEntity Entity,
        out byte Element_depth,
        out bool Depth_leader
    )
    {
        Entity = this.Entity;
        Element_depth = this.Element_depth;
        Depth_leader = this.Depth_leader;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Entity.GetHashCode();
        hash = hash * 23 + Element_depth.GetHashCode();
        hash = hash * 23 + Depth_leader.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(ObjectBatchEntity other)
    {
        return Entity == other.Entity && Element_depth == other.Element_depth && Depth_leader == other.Depth_leader        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is ObjectBatchEntity) ? Equals((ObjectBatchEntity)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(ObjectBatchEntity lhs, ObjectBatchEntity rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(ObjectBatchEntity lhs, ObjectBatchEntity rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ObjectBatchEntity(IntPtr ptr)
    {
        var tmp = (ObjectBatchEntity.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ObjectBatchEntity.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static ObjectBatchEntity FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ObjectBatchEntity.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        /// <summary>Internal wrapper for field Entity</summary>
        public System.IntPtr Entity;
        
        public byte Element_depth;
        /// <summary>Internal wrapper for field Depth_leader</summary>
        public System.Byte Depth_leader;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ObjectBatchEntity.NativeStruct(ObjectBatchEntity _external_struct)
        {
            var _internal_struct = new ObjectBatchEntity.NativeStruct();
            _internal_struct.Entity = _external_struct.Entity?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Element_depth = _external_struct.Element_depth;
            _internal_struct.Depth_leader = _external_struct.Depth_leader ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ObjectBatchEntity(ObjectBatchEntity.NativeStruct _internal_struct)
        {
            var _external_struct = new ObjectBatchEntity();

            _external_struct.Entity = (CoreUI.Gfx.EntityConcrete) CoreUI.Wrapper.Globals.CreateWrapperFor(_internal_struct.Entity);
            _external_struct.Element_depth = _internal_struct.Element_depth;
            _external_struct.Depth_leader = _internal_struct.Depth_leader != 0;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.UI.PositionManager {
/// <summary>Struct that is getting filled by the size function callback.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct SizeBatchEntity : IEquatable<SizeBatchEntity>
{
    /// <summary>The size of the element.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A 2D size in pixels.</value>
    public CoreUI.DataTypes.Size2D Size;
    /// <summary>The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</summary>
    /// <since_tizen> 6 </since_tizen>
    public byte Element_depth;
    /// <summary><c>true</c> if this is the leader of a group</summary>
    /// <since_tizen> 6 </since_tizen>
    public bool Depth_leader;
    /// <summary>Constructor for SizeBatchEntity.
    /// </summary>
    /// <param name="Size">The size of the element.</param>
    /// <param name="Element_depth">The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</param>
    /// <param name="Depth_leader"><c>true</c> if this is the leader of a group</param>
    /// <since_tizen> 6 </since_tizen>
    public SizeBatchEntity(
        CoreUI.DataTypes.Size2D Size = default(CoreUI.DataTypes.Size2D),
        byte Element_depth = default(byte),
        bool Depth_leader = default(bool)    )
    {
        this.Size = Size;
        this.Element_depth = Element_depth;
        this.Depth_leader = Depth_leader;
    }

    /// <summary>Packs tuple into SizeBatchEntity object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator SizeBatchEntity(
        (
         CoreUI.DataTypes.Size2D Size,
         byte Element_depth,
         bool Depth_leader
        ) tuple)
    {
        return new SizeBatchEntity{
            Size = tuple.Size,
            Element_depth = tuple.Element_depth,
            Depth_leader = tuple.Depth_leader,
        };
    }
    /// <summary>Unpacks SizeBatchEntity into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out CoreUI.DataTypes.Size2D Size,
        out byte Element_depth,
        out bool Depth_leader
    )
    {
        Size = this.Size;
        Element_depth = this.Element_depth;
        Depth_leader = this.Depth_leader;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Size.GetHashCode();
        hash = hash * 23 + Element_depth.GetHashCode();
        hash = hash * 23 + Depth_leader.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(SizeBatchEntity other)
    {
        return Size == other.Size && Element_depth == other.Element_depth && Depth_leader == other.Depth_leader        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is SizeBatchEntity) ? Equals((SizeBatchEntity)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(SizeBatchEntity lhs, SizeBatchEntity rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(SizeBatchEntity lhs, SizeBatchEntity rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator SizeBatchEntity(IntPtr ptr)
    {
        var tmp = (SizeBatchEntity.NativeStruct)Marshal.PtrToStructure(ptr, typeof(SizeBatchEntity.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static SizeBatchEntity FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct SizeBatchEntity.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public CoreUI.DataTypes.Size2D.NativeStruct Size;
        
        public byte Element_depth;
        /// <summary>Internal wrapper for field Depth_leader</summary>
        public System.Byte Depth_leader;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator SizeBatchEntity.NativeStruct(SizeBatchEntity _external_struct)
        {
            var _internal_struct = new SizeBatchEntity.NativeStruct();
            _internal_struct.Size = _external_struct.Size;
            _internal_struct.Element_depth = _external_struct.Element_depth;
            _internal_struct.Depth_leader = _external_struct.Depth_leader ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator SizeBatchEntity(SizeBatchEntity.NativeStruct _internal_struct)
        {
            var _external_struct = new SizeBatchEntity();
            _external_struct.Size = _internal_struct.Size;
            _external_struct.Element_depth = _internal_struct.Element_depth;
            _external_struct.Depth_leader = _internal_struct.Depth_leader != 0;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.UI.PositionManager {
/// <summary>Struct returned by the size access callback.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct SizeBatchResult : IEquatable<SizeBatchResult>
{
    /// <summary>The group size of the group where the first item is part of.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A 2D size in pixels.</value>
    public CoreUI.DataTypes.Size2D Parent_size;
    /// <summary>The depth of the parent</summary>
    /// <since_tizen> 6 </since_tizen>
    public byte Parent_depth;
    /// <summary>The number of items that are filled into the slice.</summary>
    /// <since_tizen> 6 </since_tizen>
    public uint Filled_items;
    /// <summary>Constructor for SizeBatchResult.
    /// </summary>
    /// <param name="Parent_size">The group size of the group where the first item is part of.</param>
    /// <param name="Parent_depth">The depth of the parent</param>
    /// <param name="Filled_items">The number of items that are filled into the slice.</param>
    /// <since_tizen> 6 </since_tizen>
    public SizeBatchResult(
        CoreUI.DataTypes.Size2D Parent_size = default(CoreUI.DataTypes.Size2D),
        byte Parent_depth = default(byte),
        uint Filled_items = default(uint)    )
    {
        this.Parent_size = Parent_size;
        this.Parent_depth = Parent_depth;
        this.Filled_items = Filled_items;
    }

    /// <summary>Packs tuple into SizeBatchResult object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator SizeBatchResult(
        (
         CoreUI.DataTypes.Size2D Parent_size,
         byte Parent_depth,
         uint Filled_items
        ) tuple)
    {
        return new SizeBatchResult{
            Parent_size = tuple.Parent_size,
            Parent_depth = tuple.Parent_depth,
            Filled_items = tuple.Filled_items,
        };
    }
    /// <summary>Unpacks SizeBatchResult into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out CoreUI.DataTypes.Size2D Parent_size,
        out byte Parent_depth,
        out uint Filled_items
    )
    {
        Parent_size = this.Parent_size;
        Parent_depth = this.Parent_depth;
        Filled_items = this.Filled_items;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Parent_size.GetHashCode();
        hash = hash * 23 + Parent_depth.GetHashCode();
        hash = hash * 23 + Filled_items.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(SizeBatchResult other)
    {
        return Parent_size == other.Parent_size && Parent_depth == other.Parent_depth && Filled_items == other.Filled_items        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is SizeBatchResult) ? Equals((SizeBatchResult)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(SizeBatchResult lhs, SizeBatchResult rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(SizeBatchResult lhs, SizeBatchResult rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator SizeBatchResult(IntPtr ptr)
    {
        var tmp = (SizeBatchResult.NativeStruct)Marshal.PtrToStructure(ptr, typeof(SizeBatchResult.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static SizeBatchResult FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct SizeBatchResult.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public CoreUI.DataTypes.Size2D.NativeStruct Parent_size;
        
        public byte Parent_depth;
        
        public uint Filled_items;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator SizeBatchResult.NativeStruct(SizeBatchResult _external_struct)
        {
            var _internal_struct = new SizeBatchResult.NativeStruct();
            _internal_struct.Parent_size = _external_struct.Parent_size;
            _internal_struct.Parent_depth = _external_struct.Parent_depth;
            _internal_struct.Filled_items = _external_struct.Filled_items;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator SizeBatchResult(SizeBatchResult.NativeStruct _internal_struct)
        {
            var _external_struct = new SizeBatchResult();
            _external_struct.Parent_size = _internal_struct.Parent_size;
            _external_struct.Parent_depth = _internal_struct.Parent_depth;
            _external_struct.Filled_items = _internal_struct.Filled_items;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.UI.PositionManager {
/// <summary>Struct that is returned by the function callbacks.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct SizeCallConfig : IEquatable<SizeCallConfig>
{
    /// <summary>The range of items to fill into @.memory. The length of memory must be bigger or equal to the requested items</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Representing the range of a request.</value>
    public CoreUI.UI.PositionManager.RequestRange Range;
    /// <summary>Indicate if this request is made for caching or displaying. If it&apos;s for caching, the data-provider will fill in approximations, instead of doing heavy lifting from some back-end. If this is not a caching call, the exact size should be requested and delivered at some later point.</summary>
    /// <since_tizen> 6 </since_tizen>
    public bool Cache_request;
    /// <summary>Constructor for SizeCallConfig.
    /// </summary>
    /// <param name="Range">The range of items to fill into @.memory. The length of memory must be bigger or equal to the requested items</param>
    /// <param name="Cache_request">Indicate if this request is made for caching or displaying. If it&apos;s for caching, the data-provider will fill in approximations, instead of doing heavy lifting from some back-end. If this is not a caching call, the exact size should be requested and delivered at some later point.</param>
    /// <since_tizen> 6 </since_tizen>
    public SizeCallConfig(
        CoreUI.UI.PositionManager.RequestRange Range = default(CoreUI.UI.PositionManager.RequestRange),
        bool Cache_request = default(bool)    )
    {
        this.Range = Range;
        this.Cache_request = Cache_request;
    }

    /// <summary>Packs tuple into SizeCallConfig object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator SizeCallConfig(
        (
         CoreUI.UI.PositionManager.RequestRange Range,
         bool Cache_request
        ) tuple)
    {
        return new SizeCallConfig{
            Range = tuple.Range,
            Cache_request = tuple.Cache_request,
        };
    }
    /// <summary>Unpacks SizeCallConfig into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out CoreUI.UI.PositionManager.RequestRange Range,
        out bool Cache_request
    )
    {
        Range = this.Range;
        Cache_request = this.Cache_request;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Range.GetHashCode();
        hash = hash * 23 + Cache_request.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(SizeCallConfig other)
    {
        return Range == other.Range && Cache_request == other.Cache_request        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is SizeCallConfig) ? Equals((SizeCallConfig)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(SizeCallConfig lhs, SizeCallConfig rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(SizeCallConfig lhs, SizeCallConfig rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator SizeCallConfig(IntPtr ptr)
    {
        var tmp = (SizeCallConfig.NativeStruct)Marshal.PtrToStructure(ptr, typeof(SizeCallConfig.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static SizeCallConfig FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct SizeCallConfig.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public CoreUI.UI.PositionManager.RequestRange.NativeStruct Range;
        /// <summary>Internal wrapper for field Cache_request</summary>
        public System.Byte Cache_request;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator SizeCallConfig.NativeStruct(SizeCallConfig _external_struct)
        {
            var _internal_struct = new SizeCallConfig.NativeStruct();
            _internal_struct.Range = _external_struct.Range;
            _internal_struct.Cache_request = _external_struct.Cache_request ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator SizeCallConfig(SizeCallConfig.NativeStruct _internal_struct)
        {
            var _external_struct = new SizeCallConfig();
            _external_struct.Range = _internal_struct.Range;
            _external_struct.Cache_request = _internal_struct.Cache_request != 0;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.UI.PositionManager {
/// <summary>Struct returned by the object access callback.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct ObjectBatchResult : IEquatable<ObjectBatchResult>
{
    /// <summary>The group where the first item is part of</summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.Item Group;
    /// <summary>The depth of the parent</summary>
    /// <since_tizen> 6 </since_tizen>
    public byte Parent_depth;
    /// <summary>The number of items that are filled into the slice</summary>
    /// <since_tizen> 6 </since_tizen>
    public uint Filled_items;
    /// <summary>Constructor for ObjectBatchResult.
    /// </summary>
    /// <param name="Group">The group where the first item is part of</param>
    /// <param name="Parent_depth">The depth of the parent</param>
    /// <param name="Filled_items">The number of items that are filled into the slice</param>
    /// <since_tizen> 6 </since_tizen>
    public ObjectBatchResult(
        CoreUI.UI.Item Group = default(CoreUI.UI.Item),
        byte Parent_depth = default(byte),
        uint Filled_items = default(uint)    )
    {
        this.Group = Group;
        this.Parent_depth = Parent_depth;
        this.Filled_items = Filled_items;
    }

    /// <summary>Packs tuple into ObjectBatchResult object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator ObjectBatchResult(
        (
         CoreUI.UI.Item Group,
         byte Parent_depth,
         uint Filled_items
        ) tuple)
    {
        return new ObjectBatchResult{
            Group = tuple.Group,
            Parent_depth = tuple.Parent_depth,
            Filled_items = tuple.Filled_items,
        };
    }
    /// <summary>Unpacks ObjectBatchResult into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out CoreUI.UI.Item Group,
        out byte Parent_depth,
        out uint Filled_items
    )
    {
        Group = this.Group;
        Parent_depth = this.Parent_depth;
        Filled_items = this.Filled_items;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Group.GetHashCode();
        hash = hash * 23 + Parent_depth.GetHashCode();
        hash = hash * 23 + Filled_items.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(ObjectBatchResult other)
    {
        return Group == other.Group && Parent_depth == other.Parent_depth && Filled_items == other.Filled_items        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is ObjectBatchResult) ? Equals((ObjectBatchResult)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(ObjectBatchResult lhs, ObjectBatchResult rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(ObjectBatchResult lhs, ObjectBatchResult rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ObjectBatchResult(IntPtr ptr)
    {
        var tmp = (ObjectBatchResult.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ObjectBatchResult.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static ObjectBatchResult FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ObjectBatchResult.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        /// <summary>Internal wrapper for field Group</summary>
        public System.IntPtr Group;
        
        public byte Parent_depth;
        
        public uint Filled_items;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ObjectBatchResult.NativeStruct(ObjectBatchResult _external_struct)
        {
            var _internal_struct = new ObjectBatchResult.NativeStruct();
            _internal_struct.Group = _external_struct.Group?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Parent_depth = _external_struct.Parent_depth;
            _internal_struct.Filled_items = _external_struct.Filled_items;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ObjectBatchResult(ObjectBatchResult.NativeStruct _internal_struct)
        {
            var _external_struct = new ObjectBatchResult();

            _external_struct.Group = (CoreUI.UI.Item) CoreUI.Wrapper.Globals.CreateWrapperFor(_internal_struct.Group);
            _external_struct.Parent_depth = _internal_struct.Parent_depth;
            _external_struct.Filled_items = _internal_struct.Filled_items;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

