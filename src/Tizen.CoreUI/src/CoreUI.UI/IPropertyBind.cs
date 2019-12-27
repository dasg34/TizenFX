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
namespace CoreUI.UI {
/// <summary>CoreUI UI Property_Bind interface. view object can have <see cref="CoreUI.IModel"/> to manage the data, the interface can help loading and tracking child data from the model property. see <see cref="CoreUI.IModel"/> see <see cref="CoreUI.UI.IFactory"/></summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.UI.PropertyBindConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IPropertyBind : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">key string for bind model property data</param>
    /// <param name="property">Model property name</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    CoreUI.DataTypes.Error BindProperty(System.String key, System.String property);

    /// <summary>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.PropertyBindPropertiesChangedEventArgs"/></value>
    event EventHandler<CoreUI.UI.PropertyBindPropertiesChangedEventArgs> PropertiesChangedEvent;
    /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.PropertyBindPropertyBoundEventArgs"/></value>
    event EventHandler<CoreUI.UI.PropertyBindPropertyBoundEventArgs> PropertyBoundEvent;
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IPropertyBind.PropertiesChangedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class PropertyBindPropertiesChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.PropertyEvent arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IPropertyBind.PropertyBoundEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class PropertyBindPropertyBoundEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</value>
    /// <since_tizen> 6 </since_tizen>
    public System.String arg { get; set; }
}

/// <summary>CoreUI UI Property_Bind interface. view object can have <see cref="CoreUI.IModel"/> to manage the data, the interface can help loading and tracking child data from the model property. see <see cref="CoreUI.IModel"/> see <see cref="CoreUI.UI.IFactory"/></summary>
/// <since_tizen> 6 </since_tizen>
public sealed class PropertyBindConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IPropertyBind
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(PropertyBindConcrete))
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
    private PropertyBindConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_property_bind_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IPropertyBind"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private PropertyBindConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.PropertyBindPropertiesChangedEventArgs"/></value>
    public event EventHandler<CoreUI.UI.PropertyBindPropertiesChangedEventArgs> PropertiesChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PropertyBindPropertiesChangedEventArgs{ arg =  info });
            string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event PropertiesChangedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPropertiesChangedEvent(CoreUI.UI.PropertyBindPropertiesChangedEventArgs e)
    {
        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.PropertyBindPropertyBoundEventArgs"/></value>
    public event EventHandler<CoreUI.UI.PropertyBindPropertyBoundEventArgs> PropertyBoundEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PropertyBindPropertyBoundEventArgs{ arg = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(info) });
            string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event PropertyBoundEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPropertyBoundEvent(CoreUI.UI.PropertyBindPropertyBoundEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.StringConversion.ManagedStringToNativeUtf8Alloc(e.arg);
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND", info, (p) => CoreUI.DataTypes.MemoryNative.Free(p));
    }


#pragma warning disable CS0628
    /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">key string for bind model property data</param>
    /// <param name="property">Model property name</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    public CoreUI.DataTypes.Error BindProperty(System.String key, System.String property) {
        var _ret_var = CoreUI.UI.PropertyBindConcrete.NativeMethods.efl_ui_property_bind_ptr.Value.Delegate(this.NativeHandle, key, property);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.UI.PropertyBindConcrete.efl_ui_property_bind_interface_get();
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

            if (efl_ui_property_bind_static_delegate == null)
            {
                efl_ui_property_bind_static_delegate = new efl_ui_property_bind_delegate(property_bind);
            }

            if (methods.Contains("BindProperty"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_property_bind_static_delegate) });
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
            return CoreUI.UI.PropertyBindConcrete.efl_ui_property_bind_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.DataTypes.Error efl_ui_property_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        
        internal delegate CoreUI.DataTypes.Error efl_ui_property_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_property_bind_api_delegate> efl_ui_property_bind_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_property_bind_api_delegate>(Module, "efl_ui_property_bind");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Error property_bind(System.IntPtr obj, System.IntPtr pd, System.String key, System.String property)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_property_bind was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                try
                {
                    _ret_var = ((IPropertyBind)ws.Target).BindProperty(key, property);
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
                return efl_ui_property_bind_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), key, property);
            }
        }

        private static efl_ui_property_bind_delegate efl_ui_property_bind_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.UI {
/// <summary>EFL UI property event data structure triggered when an object property change due to the interaction on the object.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct PropertyEvent : IEquatable<PropertyEvent>
{
    /// <summary>List of changed properties</summary>
    /// <since_tizen> 6 </since_tizen>
    public IList<CoreUI.DataTypes.Stringshare> Changed_properties;
    /// <summary>Constructor for PropertyEvent.
    /// </summary>
    /// <param name="Changed_properties">List of changed properties</param>
    /// <since_tizen> 6 </since_tizen>
    public PropertyEvent(
        IList<CoreUI.DataTypes.Stringshare> Changed_properties = default(IList<CoreUI.DataTypes.Stringshare>)    )
    {
        this.Changed_properties = Changed_properties;
    }

    /// <summary>Unpacks PropertyEvent into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out IList<CoreUI.DataTypes.Stringshare> Changed_properties
    )
    {
        Changed_properties = this.Changed_properties;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Changed_properties.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(PropertyEvent other)
    {
        return Changed_properties == other.Changed_properties        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is PropertyEvent) ? Equals((PropertyEvent)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(PropertyEvent lhs, PropertyEvent rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(PropertyEvent lhs, PropertyEvent rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator PropertyEvent(IntPtr ptr)
    {
        var tmp = (PropertyEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(PropertyEvent.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static PropertyEvent FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct PropertyEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public System.IntPtr Changed_properties;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator PropertyEvent.NativeStruct(PropertyEvent _external_struct)
        {
            var _internal_struct = new PropertyEvent.NativeStruct();
            _internal_struct.Changed_properties = CoreUI.Wrapper.Globals.IListToNativeArray(_external_struct.Changed_properties, false);
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator PropertyEvent(PropertyEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new PropertyEvent();
            _external_struct.Changed_properties = CoreUI.Wrapper.Globals.NativeArrayToIList<CoreUI.DataTypes.Stringshare>(_internal_struct.Changed_properties);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

