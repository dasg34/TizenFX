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
/// <summary>Interface for factory-pattern object creation.
/// 
/// This object represents a Factory in the factory pattern. Objects should be created via the method <span class="text-muted">CoreUI.UI.ViewFactory.CreateWithEvent (object still in beta stage)</span>, which will in turn call the necessary APIs from this interface. Objects created this way should be removed using <see cref="CoreUI.UI.IFactory.Release"/>.
/// 
/// It is recommended to not create your own <see cref="CoreUI.UI.IFactory"/> and use event handler as much as possible.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.UI.FactoryConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IFactory : 
    CoreUI.UI.IFactoryBind,
    CoreUI.UI.IPropertyBind,
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Release a UI object and disconnect from models.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ui_views">Object to remove.</param>
    void Release(IEnumerable<CoreUI.Gfx.IEntity> ui_views);

    /// <summary>Event emitted when an item is under construction (between the CoreUI.Object.constructor and <see cref="CoreUI.Object.FinalizeAdd"/> call on the item). Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this won&apos;t be called when objects are pulled from the cache.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.FactoryItemConstructingEventArgs"/></value>
    event EventHandler<CoreUI.UI.FactoryItemConstructingEventArgs> ItemConstructingEvent;
    /// <summary>Event emitted when an item has processed <see cref="CoreUI.Object.FinalizeAdd"/>, but before all the factory are done building it. Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this will be called when objects are pulled from the cache.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.FactoryItemBuildingEventArgs"/></value>
    event EventHandler<CoreUI.UI.FactoryItemBuildingEventArgs> ItemBuildingEvent;
    /// <summary>Event emitted when an item has been successfully created by the factory and is about to be used by an <see cref="CoreUI.UI.IView"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.FactoryItemCreatedEventArgs"/></value>
    event EventHandler<CoreUI.UI.FactoryItemCreatedEventArgs> ItemCreatedEvent;
    /// <summary>Event emitted when an item is being released by the <see cref="CoreUI.UI.IFactory"/>. It must be assumed that after this call, the object can be recycles to another <see cref="CoreUI.UI.IView"/> and there can be more than one call for the same item.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.FactoryItemReleasingEventArgs"/></value>
    event EventHandler<CoreUI.UI.FactoryItemReleasingEventArgs> ItemReleasingEvent;
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IFactory.ItemConstructingEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class FactoryItemConstructingEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Event emitted when an item is under construction (between the CoreUI.Object.constructor and <see cref="CoreUI.Object.FinalizeAdd"/> call on the item). Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this won&apos;t be called when objects are pulled from the cache.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IFactory.ItemBuildingEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class FactoryItemBuildingEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Event emitted when an item has processed <see cref="CoreUI.Object.FinalizeAdd"/>, but before all the factory are done building it. Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this will be called when objects are pulled from the cache.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IFactory.ItemCreatedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class FactoryItemCreatedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Event emitted when an item has been successfully created by the factory and is about to be used by an <see cref="CoreUI.UI.IView"/>.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IFactory.ItemReleasingEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class FactoryItemReleasingEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Event emitted when an item is being released by the <see cref="CoreUI.UI.IFactory"/>. It must be assumed that after this call, the object can be recycles to another <see cref="CoreUI.UI.IView"/> and there can be more than one call for the same item.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity arg { get; set; }
}

/// <summary>Interface for factory-pattern object creation.
/// 
/// This object represents a Factory in the factory pattern. Objects should be created via the method <span class="text-muted">CoreUI.UI.ViewFactory.CreateWithEvent (object still in beta stage)</span>, which will in turn call the necessary APIs from this interface. Objects created this way should be removed using <see cref="CoreUI.UI.IFactory.Release"/>.
/// 
/// It is recommended to not create your own <see cref="CoreUI.UI.IFactory"/> and use event handler as much as possible.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class FactoryConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IFactory,
    CoreUI.UI.IFactoryBind,
    CoreUI.UI.IPropertyBind
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(FactoryConcrete))
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
    private FactoryConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_factory_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IFactory"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private FactoryConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Event emitted when an item is under construction (between the CoreUI.Object.constructor and <see cref="CoreUI.Object.FinalizeAdd"/> call on the item). Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this won&apos;t be called when objects are pulled from the cache.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.FactoryItemConstructingEventArgs"/></value>
    public event EventHandler<CoreUI.UI.FactoryItemConstructingEventArgs> ItemConstructingEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.FactoryItemConstructingEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.EntityConcrete) });
            string key = "_EFL_UI_FACTORY_EVENT_ITEM_CONSTRUCTING";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_FACTORY_EVENT_ITEM_CONSTRUCTING";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ItemConstructingEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnItemConstructingEvent(CoreUI.UI.FactoryItemConstructingEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_FACTORY_EVENT_ITEM_CONSTRUCTING", info, null);
    }

    /// <summary>Event emitted when an item has processed <see cref="CoreUI.Object.FinalizeAdd"/>, but before all the factory are done building it. Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this will be called when objects are pulled from the cache.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.FactoryItemBuildingEventArgs"/></value>
    public event EventHandler<CoreUI.UI.FactoryItemBuildingEventArgs> ItemBuildingEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.FactoryItemBuildingEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.EntityConcrete) });
            string key = "_EFL_UI_FACTORY_EVENT_ITEM_BUILDING";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_FACTORY_EVENT_ITEM_BUILDING";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ItemBuildingEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnItemBuildingEvent(CoreUI.UI.FactoryItemBuildingEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_FACTORY_EVENT_ITEM_BUILDING", info, null);
    }

    /// <summary>Event emitted when an item has been successfully created by the factory and is about to be used by an <see cref="CoreUI.UI.IView"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.FactoryItemCreatedEventArgs"/></value>
    public event EventHandler<CoreUI.UI.FactoryItemCreatedEventArgs> ItemCreatedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.FactoryItemCreatedEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.EntityConcrete) });
            string key = "_EFL_UI_FACTORY_EVENT_ITEM_CREATED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_FACTORY_EVENT_ITEM_CREATED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ItemCreatedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnItemCreatedEvent(CoreUI.UI.FactoryItemCreatedEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_FACTORY_EVENT_ITEM_CREATED", info, null);
    }

    /// <summary>Event emitted when an item is being released by the <see cref="CoreUI.UI.IFactory"/>. It must be assumed that after this call, the object can be recycles to another <see cref="CoreUI.UI.IView"/> and there can be more than one call for the same item.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.FactoryItemReleasingEventArgs"/></value>
    public event EventHandler<CoreUI.UI.FactoryItemReleasingEventArgs> ItemReleasingEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.FactoryItemReleasingEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.EntityConcrete) });
            string key = "_EFL_UI_FACTORY_EVENT_ITEM_RELEASING";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_FACTORY_EVENT_ITEM_RELEASING";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ItemReleasingEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnItemReleasingEvent(CoreUI.UI.FactoryItemReleasingEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_FACTORY_EVENT_ITEM_RELEASING", info, null);
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
    /// <summary>Create a UI object from the necessary properties in the specified model.
    /// 
    /// <b>NOTE: </b>This is the function you need to implement for a custom factory, but if you want to use a factory, you should rely on <span class="text-muted">CoreUI.UI.ViewFactory.CreateWithEvent (object still in beta stage)</span>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="models">CoreUI iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
    /// <returns>Created UI object.</returns>
    protected  CoreUI.DataTypes.Future Create(IEnumerable<CoreUI.IModel> models) {
        var _in_models = CoreUI.Wrapper.Globals.IEnumerableToIterator(models, true);
var _ret_var = CoreUI.UI.FactoryConcrete.NativeMethods.efl_ui_factory_create_ptr.Value.Delegate(this.NativeHandle, _in_models);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Release a UI object and disconnect from models.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ui_views">Object to remove.</param>
    public void Release(IEnumerable<CoreUI.Gfx.IEntity> ui_views) {
        var _in_ui_views = CoreUI.Wrapper.Globals.IEnumerableToIterator(ui_views, true);
CoreUI.UI.FactoryConcrete.NativeMethods.efl_ui_factory_release_ptr.Value.Delegate(this.NativeHandle, _in_ui_views);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="CoreUI.UI.IFactory"/> need to be <see cref="CoreUI.UI.IPropertyBind.BindProperty"/> at least once.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">Key string for bind model property data</param>
    /// <param name="factory"><see cref="CoreUI.UI.IFactory"/> for create and bind model property data</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    public CoreUI.DataTypes.Error BindFactory(System.String key, CoreUI.UI.IFactory factory) {
        var _ret_var = CoreUI.UI.FactoryBindConcrete.NativeMethods.efl_ui_factory_bind_ptr.Value.Delegate(this.NativeHandle, key, factory);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

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

    /// <summary>Async wrapper for <see cref="Create" />.
    /// </summary>
    /// <param name="models">CoreUI iterator providing the model to be associated to the new item. It should remain valid until the end of the function call.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> CreateAsync(IEnumerable<CoreUI.IModel> models,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        CoreUI.DataTypes.Future future = Create( models);
        return CoreUI.Wrapper.Globals.WrapAsync(future, token);
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.UI.FactoryConcrete.efl_ui_factory_interface_get();
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

            if (efl_ui_factory_release_static_delegate == null)
            {
                efl_ui_factory_release_static_delegate = new efl_ui_factory_release_delegate(release);
            }

            if (methods.Contains("Release"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_factory_release"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_release_static_delegate) });
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
            return CoreUI.UI.FactoryConcrete.efl_ui_factory_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        private delegate  CoreUI.DataTypes.Future efl_ui_factory_create_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr models);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        internal delegate  CoreUI.DataTypes.Future efl_ui_factory_create_api_delegate(System.IntPtr obj,  System.IntPtr models);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_create_api_delegate> efl_ui_factory_create_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_create_api_delegate>(Module, "efl_ui_factory_create");

        
        private delegate void efl_ui_factory_release_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr ui_views);

        
        internal delegate void efl_ui_factory_release_api_delegate(System.IntPtr obj,  System.IntPtr ui_views);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_release_api_delegate> efl_ui_factory_release_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_release_api_delegate>(Module, "efl_ui_factory_release");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void release(System.IntPtr obj, System.IntPtr pd, System.IntPtr ui_views)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_factory_release was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_ui_views = CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.IEntity>(ui_views);

                try
                {
                    ((IFactory)ws.Target).Release(_in_ui_views);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_factory_release_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), ui_views);
            }
        }

        private static efl_ui_factory_release_delegate efl_ui_factory_release_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.UI {
/// <summary>EFL UI Factory event structure provided when an item was just created.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct FactoryItemCreatedEvent : IEquatable<FactoryItemCreatedEvent>
{
    /// <summary>The model already set on the new item.</summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.IModel Model;
    /// <summary>The item that was just created.</summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity Item;
    /// <summary>Constructor for FactoryItemCreatedEvent.
    /// </summary>
    /// <param name="Model">The model already set on the new item.</param>
    /// <param name="Item">The item that was just created.</param>
    /// <since_tizen> 6 </since_tizen>
    public FactoryItemCreatedEvent(
        CoreUI.IModel Model = default(CoreUI.IModel),
        CoreUI.Gfx.IEntity Item = default(CoreUI.Gfx.IEntity)    )
    {
        this.Model = Model;
        this.Item = Item;
    }

    /// <summary>Packs tuple into FactoryItemCreatedEvent object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator FactoryItemCreatedEvent(
        (
         CoreUI.IModel Model,
         CoreUI.Gfx.IEntity Item
        ) tuple)
    {
        return new FactoryItemCreatedEvent{
            Model = tuple.Model,
            Item = tuple.Item,
        };
    }
    /// <summary>Unpacks FactoryItemCreatedEvent into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out CoreUI.IModel Model,
        out CoreUI.Gfx.IEntity Item
    )
    {
        Model = this.Model;
        Item = this.Item;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Model.GetHashCode();
        hash = hash * 23 + Item.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(FactoryItemCreatedEvent other)
    {
        return Model == other.Model && Item == other.Item        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is FactoryItemCreatedEvent) ? Equals((FactoryItemCreatedEvent)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(FactoryItemCreatedEvent lhs, FactoryItemCreatedEvent rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(FactoryItemCreatedEvent lhs, FactoryItemCreatedEvent rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator FactoryItemCreatedEvent(IntPtr ptr)
    {
        var tmp = (FactoryItemCreatedEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(FactoryItemCreatedEvent.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static FactoryItemCreatedEvent FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct FactoryItemCreatedEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        /// <summary>Internal wrapper for field Model</summary>
        public System.IntPtr Model;
        /// <summary>Internal wrapper for field Item</summary>
        public System.IntPtr Item;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator FactoryItemCreatedEvent.NativeStruct(FactoryItemCreatedEvent _external_struct)
        {
            var _internal_struct = new FactoryItemCreatedEvent.NativeStruct();
            _internal_struct.Model = _external_struct.Model?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Item = _external_struct.Item?.NativeHandle ?? System.IntPtr.Zero;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator FactoryItemCreatedEvent(FactoryItemCreatedEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new FactoryItemCreatedEvent();

            _external_struct.Model = (CoreUI.ModelConcrete) CoreUI.Wrapper.Globals.CreateWrapperFor(_internal_struct.Model);

            _external_struct.Item = (CoreUI.Gfx.EntityConcrete) CoreUI.Wrapper.Globals.CreateWrapperFor(_internal_struct.Item);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

