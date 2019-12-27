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
/// <summary>Basic Model abstraction.
/// 
/// A model in EFL can have a set of key-value properties, where key can only be a string. The value can be anything within an Eina_Value. If a property is not yet available EAGAIN is returned.
/// 
/// Additionally a model can have a list of children. The fetching of the children is asynchronous, this has the advantage of having as few data sets as possible in the memory itself.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.ModelConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IModel : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Get properties from model.
    /// 
    /// Properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="CoreUI.IModel.PropertiesChangedEvent"/> will be raised to notify listeners of any modifications in the properties.
    /// 
    /// See also <see cref="CoreUI.IModel.PropertiesChangedEvent"/>.</summary>
    /// <returns>Array of current properties</returns>
    /// <since_tizen> 6 </since_tizen>
    IEnumerable<System.String> GetProperties();

    /// <summary><br/>
    /// <b>Note:</b> Retrieve the value of a given property name.
    /// 
    /// At this point the caller is free to get values from properties. The event <see cref="CoreUI.IModel.PropertiesChangedEvent"/> may be raised to notify listeners of the property/value.
    /// 
    /// See <see cref="CoreUI.IModel.GetProperties"/>, <see cref="CoreUI.IModel.PropertiesChangedEvent"/></summary>
    /// <param name="property">Property name</param>
    /// <returns>Property value</returns>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.DataTypes.Value GetProperty(System.String property);

    /// <summary><br/>
    /// <b>Note:</b> Set a property value of a given property name.
    /// 
    /// The caller must first read <see cref="CoreUI.IModel.GetProperties"/> to obtain the list of available properties before being able to access them through <see cref="CoreUI.IModel.GetProperty"/>. This function sets a new property value into given property name. Once the operation is completed the concrete implementation should raise <see cref="CoreUI.IModel.PropertiesChangedEvent"/> event in order to notify listeners of the new value of the property.
    /// 
    /// If the model doesn&apos;t have the property then there are two possibilities, either raise an error or create the new property in model
    /// 
    /// See <see cref="CoreUI.IModel.GetProperty"/>, <see cref="CoreUI.IModel.PropertiesChangedEvent"/></summary>
    /// <param name="property">Property name</param>
    /// <param name="value">Property value</param>
    /// <returns>Return an error in case the property could not be set, or the value that was set otherwise.</returns>
    /// <since_tizen> 6 </since_tizen>
     CoreUI.DataTypes.Future SetProperty(System.String property, CoreUI.DataTypes.Value value);

    /// <summary>Number of children.
    /// 
    /// After @[.properties,changed] is emitted, <see cref="CoreUI.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="CoreUI.IModel.GetChildrenCount"/> can also be used before calling <see cref="CoreUI.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="CoreUI.IModel.ChildrenCountChangedEvent"/> is emitted when count is finished.
    /// 
    /// See also <see cref="CoreUI.IModel.GetChildrenSlice"/>.</summary>
    /// <returns>Current known children count</returns>
    /// <since_tizen> 6 </since_tizen>
    uint GetChildrenCount();

    /// <summary>Get a future value when it changes to something that is not error:EAGAIN
    /// 
    /// <see cref="CoreUI.IModel.GetProperty"/> can return an error with code EAGAIN when it doesn&apos;t have any meaningful value. To make life easier, this future will resolve when the error:EAGAIN disappears. Either into a failed future in case the error code changed to something else or a success with the value of the property whenever the property finally changes.
    /// 
    /// The future can also be canceled if the model itself gets destroyed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="property">Property name.</param>
    /// <returns>Future to be resolved when the property changes to anything other than error:EAGAIN</returns>
     CoreUI.DataTypes.Future GetPropertyReady(System.String property);

    /// <summary>Get children slice OR full range.
    /// 
    /// <see cref="CoreUI.IModel.GetChildrenSlice"/> behaves in two different ways, it may provide the slice if <c>count</c> is non-zero OR full range otherwise.
    /// 
    /// Since &apos;slice&apos; is a range, for example if we have 20 children a slice could be the range from 3(start) with 4(count), see:
    /// 
    /// child 0  [no] child 1  [no] child 2  [no] child 3  [yes] child 4  [yes] child 5  [yes] child 6  [yes] child 7  [no]
    /// 
    /// Optionally the user can call <see cref="CoreUI.IModel.GetChildrenCount"/> to know the number of children so a valid range can be known in advance.
    /// 
    /// See <see cref="CoreUI.IModel.GetChildrenCount"/>
    /// 
    /// <b>NOTE: </b>The returned children will live only as long as the future itself. Once the future is done, if you want to keep the object alive, you need to take a reference for yourself.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="start">Range begin - start from here.</param>
    /// <param name="count">Range size. If count is 0, start is ignored.</param>
    /// <returns>Array of children</returns>
     CoreUI.DataTypes.Future GetChildrenSlice(uint start, uint count);

    /// <summary>Add a new child.
    /// 
    /// Add a new child, possibly dummy, depending on the implementation, of a internal keeping. When the child is effectively added the event <see cref="CoreUI.IModel.ChildAddedEvent"/> is then raised and the new child is kept along with other children.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Child object</returns>
    CoreUI.Object AddChild();

    /// <summary>Remove a child.
    /// 
    /// Remove a child of a internal keeping. When the child is effectively removed the event <see cref="CoreUI.IModel.ChildRemovedEvent"/> is then raised to give a chance for listeners to perform any cleanup and/or update references.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="child">Child to be removed</param>
    void DelChild(CoreUI.Object child);

    /// <summary>Async wrapper for <see cref="SetProperty" />.
    /// </summary>
    /// <param name="property">Property name</param>
    /// <param name="value">Property value</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    System.Threading.Tasks.Task<CoreUI.DataTypes.Value> SetPropertyAsync(System.String property, CoreUI.DataTypes.Value value,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

    /// <summary>Async wrapper for <see cref="GetPropertyReady" />.
    /// </summary>
    /// <param name="property">Property name.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    System.Threading.Tasks.Task<CoreUI.DataTypes.Value> GetPropertyReadyAsync(System.String property,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

    /// <summary>Async wrapper for <see cref="GetChildrenSlice" />.
    /// </summary>
    /// <param name="start">Range begin - start from here.</param>
    /// <param name="count">Range size. If count is 0, start is ignored.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    System.Threading.Tasks.Task<CoreUI.DataTypes.Value> GetChildrenSliceAsync(uint start, uint count,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken));

    /// <summary>Event dispatched when properties list is available.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ModelPropertiesChangedEventArgs"/></value>
    event EventHandler<CoreUI.ModelPropertiesChangedEventArgs> PropertiesChangedEvent;
    /// <summary>Event dispatched when new child is added.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ModelChildAddedEventArgs"/></value>
    event EventHandler<CoreUI.ModelChildAddedEventArgs> ChildAddedEvent;
    /// <summary>Event dispatched when child is removed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ModelChildRemovedEventArgs"/></value>
    event EventHandler<CoreUI.ModelChildRemovedEventArgs> ChildRemovedEvent;
    /// <summary>Event dispatched when children count is finished.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ChildrenCountChangedEvent;
    /// <summary>Get properties from model.
    /// 
    /// Properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="CoreUI.IModel.PropertiesChangedEvent"/> will be raised to notify listeners of any modifications in the properties.
    /// 
    /// See also <see cref="CoreUI.IModel.PropertiesChangedEvent"/>.</summary>
    /// <value>Array of current properties</value>
    /// <since_tizen> 6 </since_tizen>
    IEnumerable<System.String> Properties {
        get;
    }

    /// <summary>Number of children.
    /// 
    /// After @[.properties,changed] is emitted, <see cref="CoreUI.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="CoreUI.IModel.GetChildrenCount"/> can also be used before calling <see cref="CoreUI.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="CoreUI.IModel.ChildrenCountChangedEvent"/> is emitted when count is finished.
    /// 
    /// See also <see cref="CoreUI.IModel.GetChildrenSlice"/>.</summary>
    /// <value>Current known children count</value>
    /// <since_tizen> 6 </since_tizen>
    uint ChildrenCount {
        get;
    }

}

/// <summary>Event argument wrapper for event <see cref="CoreUI.IModel.PropertiesChangedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ModelPropertiesChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Event dispatched when properties list is available.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.ModelPropertyEvent arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.IModel.ChildAddedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ModelChildAddedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Event dispatched when new child is added.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.ModelChildrenEvent arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.IModel.ChildRemovedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ModelChildRemovedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Event dispatched when child is removed.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.ModelChildrenEvent arg { get; set; }
}

/// <summary>Basic Model abstraction.
/// 
/// A model in EFL can have a set of key-value properties, where key can only be a string. The value can be anything within an Eina_Value. If a property is not yet available EAGAIN is returned.
/// 
/// Additionally a model can have a list of children. The fetching of the children is asynchronous, this has the advantage of having as few data sets as possible in the memory itself.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ModelConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IModel
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ModelConcrete))
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
    private ModelConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_model_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IModel"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ModelConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Event dispatched when properties list is available.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ModelPropertiesChangedEventArgs"/></value>
    public event EventHandler<CoreUI.ModelPropertiesChangedEventArgs> PropertiesChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ModelPropertiesChangedEventArgs{ arg =  info });
            string key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_MODEL_EVENT_PROPERTIES_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event PropertiesChangedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPropertiesChangedEvent(CoreUI.ModelPropertiesChangedEventArgs e)
    {
        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_MODEL_EVENT_PROPERTIES_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Event dispatched when new child is added.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ModelChildAddedEventArgs"/></value>
    public event EventHandler<CoreUI.ModelChildAddedEventArgs> ChildAddedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ModelChildAddedEventArgs{ arg =  info });
            string key = "_EFL_MODEL_EVENT_CHILD_ADDED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_MODEL_EVENT_CHILD_ADDED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ChildAddedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnChildAddedEvent(CoreUI.ModelChildAddedEventArgs e)
    {
        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_MODEL_EVENT_CHILD_ADDED", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Event dispatched when child is removed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ModelChildRemovedEventArgs"/></value>
    public event EventHandler<CoreUI.ModelChildRemovedEventArgs> ChildRemovedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ModelChildRemovedEventArgs{ arg =  info });
            string key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_MODEL_EVENT_CHILD_REMOVED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ChildRemovedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnChildRemovedEvent(CoreUI.ModelChildRemovedEventArgs e)
    {
        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_MODEL_EVENT_CHILD_REMOVED", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Event dispatched when children count is finished.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ChildrenCountChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ChildrenCountChangedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnChildrenCountChangedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_MODEL_EVENT_CHILDREN_COUNT_CHANGED", IntPtr.Zero, null);
    }


#pragma warning disable CS0628
    /// <summary>Get properties from model.
    /// 
    /// Properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="CoreUI.IModel.PropertiesChangedEvent"/> will be raised to notify listeners of any modifications in the properties.
    /// 
    /// See also <see cref="CoreUI.IModel.PropertiesChangedEvent"/>.</summary>
    /// <returns>Array of current properties</returns>
    /// <since_tizen> 6 </since_tizen>
    public IEnumerable<System.String> GetProperties() {
        var _ret_var = CoreUI.ModelConcrete.NativeMethods.efl_model_properties_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return CoreUI.Wrapper.Globals.IteratorToIEnumerable<System.String>(_ret_var);
    }

    /// <summary><br/>
    /// <b>Note:</b> Retrieve the value of a given property name.
    /// 
    /// At this point the caller is free to get values from properties. The event <see cref="CoreUI.IModel.PropertiesChangedEvent"/> may be raised to notify listeners of the property/value.
    /// 
    /// See <see cref="CoreUI.IModel.GetProperties"/>, <see cref="CoreUI.IModel.PropertiesChangedEvent"/></summary>
    /// <param name="property">Property name</param>
    /// <returns>Property value</returns>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Value GetProperty(System.String property) {
        var _ret_var = CoreUI.ModelConcrete.NativeMethods.efl_model_property_get_ptr.Value.Delegate(this.NativeHandle, property);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><br/>
    /// <b>Note:</b> Set a property value of a given property name.
    /// 
    /// The caller must first read <see cref="CoreUI.IModel.GetProperties"/> to obtain the list of available properties before being able to access them through <see cref="CoreUI.IModel.GetProperty"/>. This function sets a new property value into given property name. Once the operation is completed the concrete implementation should raise <see cref="CoreUI.IModel.PropertiesChangedEvent"/> event in order to notify listeners of the new value of the property.
    /// 
    /// If the model doesn&apos;t have the property then there are two possibilities, either raise an error or create the new property in model
    /// 
    /// See <see cref="CoreUI.IModel.GetProperty"/>, <see cref="CoreUI.IModel.PropertiesChangedEvent"/></summary>
    /// <param name="property">Property name</param>
    /// <param name="value">Property value</param>
    /// <returns>Return an error in case the property could not be set, or the value that was set otherwise.</returns>
    /// <since_tizen> 6 </since_tizen>
    public  CoreUI.DataTypes.Future SetProperty(System.String property, CoreUI.DataTypes.Value value) {
        var _ret_var = CoreUI.ModelConcrete.NativeMethods.efl_model_property_set_ptr.Value.Delegate(this.NativeHandle, property, value);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Number of children.
    /// 
    /// After @[.properties,changed] is emitted, <see cref="CoreUI.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="CoreUI.IModel.GetChildrenCount"/> can also be used before calling <see cref="CoreUI.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="CoreUI.IModel.ChildrenCountChangedEvent"/> is emitted when count is finished.
    /// 
    /// See also <see cref="CoreUI.IModel.GetChildrenSlice"/>.</summary>
    /// <returns>Current known children count</returns>
    /// <since_tizen> 6 </since_tizen>
    public uint GetChildrenCount() {
        var _ret_var = CoreUI.ModelConcrete.NativeMethods.efl_model_children_count_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Get a future value when it changes to something that is not error:EAGAIN
    /// 
    /// <see cref="CoreUI.IModel.GetProperty"/> can return an error with code EAGAIN when it doesn&apos;t have any meaningful value. To make life easier, this future will resolve when the error:EAGAIN disappears. Either into a failed future in case the error code changed to something else or a success with the value of the property whenever the property finally changes.
    /// 
    /// The future can also be canceled if the model itself gets destroyed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="property">Property name.</param>
    /// <returns>Future to be resolved when the property changes to anything other than error:EAGAIN</returns>
    public  CoreUI.DataTypes.Future GetPropertyReady(System.String property) {
        var _ret_var = CoreUI.ModelConcrete.NativeMethods.efl_model_property_ready_get_ptr.Value.Delegate(this.NativeHandle, property);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Get children slice OR full range.
    /// 
    /// <see cref="CoreUI.IModel.GetChildrenSlice"/> behaves in two different ways, it may provide the slice if <c>count</c> is non-zero OR full range otherwise.
    /// 
    /// Since &apos;slice&apos; is a range, for example if we have 20 children a slice could be the range from 3(start) with 4(count), see:
    /// 
    /// child 0  [no] child 1  [no] child 2  [no] child 3  [yes] child 4  [yes] child 5  [yes] child 6  [yes] child 7  [no]
    /// 
    /// Optionally the user can call <see cref="CoreUI.IModel.GetChildrenCount"/> to know the number of children so a valid range can be known in advance.
    /// 
    /// See <see cref="CoreUI.IModel.GetChildrenCount"/>
    /// 
    /// <b>NOTE: </b>The returned children will live only as long as the future itself. Once the future is done, if you want to keep the object alive, you need to take a reference for yourself.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="start">Range begin - start from here.</param>
    /// <param name="count">Range size. If count is 0, start is ignored.</param>
    /// <returns>Array of children</returns>
    public  CoreUI.DataTypes.Future GetChildrenSlice(uint start, uint count) {
        var _ret_var = CoreUI.ModelConcrete.NativeMethods.efl_model_children_slice_get_ptr.Value.Delegate(this.NativeHandle, start, count);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Add a new child.
    /// 
    /// Add a new child, possibly dummy, depending on the implementation, of a internal keeping. When the child is effectively added the event <see cref="CoreUI.IModel.ChildAddedEvent"/> is then raised and the new child is kept along with other children.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Child object</returns>
    public CoreUI.Object AddChild() {
        var _ret_var = CoreUI.ModelConcrete.NativeMethods.efl_model_child_add_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Remove a child.
    /// 
    /// Remove a child of a internal keeping. When the child is effectively removed the event <see cref="CoreUI.IModel.ChildRemovedEvent"/> is then raised to give a chance for listeners to perform any cleanup and/or update references.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="child">Child to be removed</param>
    public void DelChild(CoreUI.Object child) {
        CoreUI.ModelConcrete.NativeMethods.efl_model_child_del_ptr.Value.Delegate(this.NativeHandle, child);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Async wrapper for <see cref="SetProperty" />.
    /// </summary>
    /// <param name="property">Property name</param>
    /// <param name="value">Property value</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> SetPropertyAsync(System.String property, CoreUI.DataTypes.Value value,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        CoreUI.DataTypes.Future future = SetProperty( property,  value);
        return CoreUI.Wrapper.Globals.WrapAsync(future, token);
    }

    /// <summary>Async wrapper for <see cref="GetPropertyReady" />.
    /// </summary>
    /// <param name="property">Property name.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> GetPropertyReadyAsync(System.String property,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        CoreUI.DataTypes.Future future = GetPropertyReady( property);
        return CoreUI.Wrapper.Globals.WrapAsync(future, token);
    }

    /// <summary>Async wrapper for <see cref="GetChildrenSlice" />.
    /// </summary>
    /// <param name="start">Range begin - start from here.</param>
    /// <param name="count">Range size. If count is 0, start is ignored.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> GetChildrenSliceAsync(uint start, uint count,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        CoreUI.DataTypes.Future future = GetChildrenSlice( start,  count);
        return CoreUI.Wrapper.Globals.WrapAsync(future, token);
    }

    /// <summary>Get properties from model.
    /// 
    /// Properties_get is due to provide callers a way the fetch the current properties implemented/used by the model. The event <see cref="CoreUI.IModel.PropertiesChangedEvent"/> will be raised to notify listeners of any modifications in the properties.
    /// 
    /// See also <see cref="CoreUI.IModel.PropertiesChangedEvent"/>.</summary>
    /// <value>Array of current properties</value>
    /// <since_tizen> 6 </since_tizen>
    public IEnumerable<System.String> Properties {
        get { return GetProperties(); }
    }

    /// <summary>Number of children.
    /// 
    /// After @[.properties,changed] is emitted, <see cref="CoreUI.IModel.GetChildrenCount"/> can be used to get the number of children. <see cref="CoreUI.IModel.GetChildrenCount"/> can also be used before calling <see cref="CoreUI.IModel.GetChildrenSlice"/> so a valid range is known. Event <see cref="CoreUI.IModel.ChildrenCountChangedEvent"/> is emitted when count is finished.
    /// 
    /// See also <see cref="CoreUI.IModel.GetChildrenSlice"/>.</summary>
    /// <value>Current known children count</value>
    /// <since_tizen> 6 </since_tizen>
    public uint ChildrenCount {
        get { return GetChildrenCount(); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.ModelConcrete.efl_model_interface_get();
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

            if (efl_model_properties_get_static_delegate == null)
            {
                efl_model_properties_get_static_delegate = new efl_model_properties_get_delegate(properties_get);
            }

            if (methods.Contains("GetProperties"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_properties_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_properties_get_static_delegate) });
            }

            if (efl_model_property_get_static_delegate == null)
            {
                efl_model_property_get_static_delegate = new efl_model_property_get_delegate(property_get);
            }

            if (methods.Contains("GetProperty"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_property_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_get_static_delegate) });
            }

            if (efl_model_property_set_static_delegate == null)
            {
                efl_model_property_set_static_delegate = new efl_model_property_set_delegate(property_set);
            }

            if (methods.Contains("SetProperty"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_property_set"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_set_static_delegate) });
            }

            if (efl_model_children_count_get_static_delegate == null)
            {
                efl_model_children_count_get_static_delegate = new efl_model_children_count_get_delegate(children_count_get);
            }

            if (methods.Contains("GetChildrenCount"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_children_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_children_count_get_static_delegate) });
            }

            if (efl_model_property_ready_get_static_delegate == null)
            {
                efl_model_property_ready_get_static_delegate = new efl_model_property_ready_get_delegate(property_ready_get);
            }

            if (methods.Contains("GetPropertyReady"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_property_ready_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_property_ready_get_static_delegate) });
            }

            if (efl_model_children_slice_get_static_delegate == null)
            {
                efl_model_children_slice_get_static_delegate = new efl_model_children_slice_get_delegate(children_slice_get);
            }

            if (methods.Contains("GetChildrenSlice"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_children_slice_get"), func = Marshal.GetFunctionPointerForDelegate(efl_model_children_slice_get_static_delegate) });
            }

            if (efl_model_child_add_static_delegate == null)
            {
                efl_model_child_add_static_delegate = new efl_model_child_add_delegate(child_add);
            }

            if (methods.Contains("AddChild"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_child_add"), func = Marshal.GetFunctionPointerForDelegate(efl_model_child_add_static_delegate) });
            }

            if (efl_model_child_del_static_delegate == null)
            {
                efl_model_child_del_static_delegate = new efl_model_child_del_delegate(child_del);
            }

            if (methods.Contains("DelChild"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_model_child_del"), func = Marshal.GetFunctionPointerForDelegate(efl_model_child_del_static_delegate) });
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
            return CoreUI.ModelConcrete.efl_model_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_model_properties_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate System.IntPtr efl_model_properties_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_properties_get_api_delegate> efl_model_properties_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_properties_get_api_delegate>(Module, "efl_model_properties_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr properties_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_properties_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<System.String> _ret_var = null;
                try
                {
                    _ret_var = ((IModel)ws.Target).GetProperties();
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
                return efl_model_properties_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_model_properties_get_delegate efl_model_properties_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))]
        private delegate CoreUI.DataTypes.Value efl_model_property_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))]
        internal delegate CoreUI.DataTypes.Value efl_model_property_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_property_get_api_delegate> efl_model_property_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_property_get_api_delegate>(Module, "efl_model_property_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Value property_get(System.IntPtr obj, System.IntPtr pd, System.String property)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_property_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Value _ret_var = default(CoreUI.DataTypes.Value);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetProperty(property);
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
                return efl_model_property_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), property);
            }
        }

        private static efl_model_property_get_delegate efl_model_property_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        private delegate  CoreUI.DataTypes.Future efl_model_property_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))] CoreUI.DataTypes.Value value);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        internal delegate  CoreUI.DataTypes.Future efl_model_property_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))] CoreUI.DataTypes.Value value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_property_set_api_delegate> efl_model_property_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_property_set_api_delegate>(Module, "efl_model_property_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static  CoreUI.DataTypes.Future property_set(System.IntPtr obj, System.IntPtr pd, System.String property, CoreUI.DataTypes.Value value)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_property_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                 CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                try
                {
                    _ret_var = ((IModel)ws.Target).SetProperty(property, value);
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
                return efl_model_property_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), property, value);
            }
        }

        private static efl_model_property_set_delegate efl_model_property_set_static_delegate;

        
        private delegate uint efl_model_children_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate uint efl_model_children_count_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_children_count_get_api_delegate> efl_model_children_count_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_children_count_get_api_delegate>(Module, "efl_model_children_count_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static uint children_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_children_count_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetChildrenCount();
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
                return efl_model_children_count_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_model_children_count_get_delegate efl_model_children_count_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        private delegate  CoreUI.DataTypes.Future efl_model_property_ready_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        internal delegate  CoreUI.DataTypes.Future efl_model_property_ready_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String property);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_property_ready_get_api_delegate> efl_model_property_ready_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_property_ready_get_api_delegate>(Module, "efl_model_property_ready_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static  CoreUI.DataTypes.Future property_ready_get(System.IntPtr obj, System.IntPtr pd, System.String property)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_property_ready_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                 CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetPropertyReady(property);
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
                return efl_model_property_ready_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), property);
            }
        }

        private static efl_model_property_ready_get_delegate efl_model_property_ready_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        private delegate  CoreUI.DataTypes.Future efl_model_children_slice_get_delegate(System.IntPtr obj, System.IntPtr pd,  uint start,  uint count);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        internal delegate  CoreUI.DataTypes.Future efl_model_children_slice_get_api_delegate(System.IntPtr obj,  uint start,  uint count);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_children_slice_get_api_delegate> efl_model_children_slice_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_children_slice_get_api_delegate>(Module, "efl_model_children_slice_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static  CoreUI.DataTypes.Future children_slice_get(System.IntPtr obj, System.IntPtr pd, uint start, uint count)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_children_slice_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                 CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                try
                {
                    _ret_var = ((IModel)ws.Target).GetChildrenSlice(start, count);
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
                return efl_model_children_slice_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), start, count);
            }
        }

        private static efl_model_children_slice_get_delegate efl_model_children_slice_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Object efl_model_child_add_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Object efl_model_child_add_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_child_add_api_delegate> efl_model_child_add_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_child_add_api_delegate>(Module, "efl_model_child_add");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Object child_add(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_child_add was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Object _ret_var = default(CoreUI.Object);
                try
                {
                    _ret_var = ((IModel)ws.Target).AddChild();
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
                return efl_model_child_add_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_model_child_add_delegate efl_model_child_add_static_delegate;

        
        private delegate void efl_model_child_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object child);

        
        internal delegate void efl_model_child_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object child);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_model_child_del_api_delegate> efl_model_child_del_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_model_child_del_api_delegate>(Module, "efl_model_child_del");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void child_del(System.IntPtr obj, System.IntPtr pd, CoreUI.Object child)
        {
            CoreUI.DataTypes.Log.Debug("function efl_model_child_del was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IModel)ws.Target).DelChild(child);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_model_child_del_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), child);
            }
        }

        private static efl_model_child_del_delegate efl_model_child_del_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI {
/// <summary>EFL model property event data structure</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct ModelPropertyEvent : IEquatable<ModelPropertyEvent>
{
    /// <summary>List of changed properties</summary>
    /// <since_tizen> 6 </since_tizen>
    public IList<CoreUI.DataTypes.Stringshare> Changed_properties;
    /// <summary>Removed properties identified by name</summary>
    /// <since_tizen> 6 </since_tizen>
    public IList<CoreUI.DataTypes.Stringshare> Invalidated_properties;
    /// <summary>Constructor for ModelPropertyEvent.
    /// </summary>
    /// <param name="Changed_properties">List of changed properties</param>
    /// <param name="Invalidated_properties">Removed properties identified by name</param>
    /// <since_tizen> 6 </since_tizen>
    public ModelPropertyEvent(
        IList<CoreUI.DataTypes.Stringshare> Changed_properties = default(IList<CoreUI.DataTypes.Stringshare>),
        IList<CoreUI.DataTypes.Stringshare> Invalidated_properties = default(IList<CoreUI.DataTypes.Stringshare>)    )
    {
        this.Changed_properties = Changed_properties;
        this.Invalidated_properties = Invalidated_properties;
    }

    /// <summary>Packs tuple into ModelPropertyEvent object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator ModelPropertyEvent(
        (
         IList<CoreUI.DataTypes.Stringshare> Changed_properties,
         IList<CoreUI.DataTypes.Stringshare> Invalidated_properties
        ) tuple)
    {
        return new ModelPropertyEvent{
            Changed_properties = tuple.Changed_properties,
            Invalidated_properties = tuple.Invalidated_properties,
        };
    }
    /// <summary>Unpacks ModelPropertyEvent into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out IList<CoreUI.DataTypes.Stringshare> Changed_properties,
        out IList<CoreUI.DataTypes.Stringshare> Invalidated_properties
    )
    {
        Changed_properties = this.Changed_properties;
        Invalidated_properties = this.Invalidated_properties;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Changed_properties.GetHashCode();
        hash = hash * 23 + Invalidated_properties.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(ModelPropertyEvent other)
    {
        return Changed_properties == other.Changed_properties && Invalidated_properties == other.Invalidated_properties        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is ModelPropertyEvent) ? Equals((ModelPropertyEvent)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(ModelPropertyEvent lhs, ModelPropertyEvent rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(ModelPropertyEvent lhs, ModelPropertyEvent rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ModelPropertyEvent(IntPtr ptr)
    {
        var tmp = (ModelPropertyEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ModelPropertyEvent.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static ModelPropertyEvent FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ModelPropertyEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public System.IntPtr Changed_properties;
        
        public System.IntPtr Invalidated_properties;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ModelPropertyEvent.NativeStruct(ModelPropertyEvent _external_struct)
        {
            var _internal_struct = new ModelPropertyEvent.NativeStruct();
            _internal_struct.Changed_properties = CoreUI.Wrapper.Globals.IListToNativeArray(_external_struct.Changed_properties, false);
            _internal_struct.Invalidated_properties = CoreUI.Wrapper.Globals.IListToNativeArray(_external_struct.Invalidated_properties, false);
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ModelPropertyEvent(ModelPropertyEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new ModelPropertyEvent();
            _external_struct.Changed_properties = CoreUI.Wrapper.Globals.NativeArrayToIList<CoreUI.DataTypes.Stringshare>(_internal_struct.Changed_properties);
            _external_struct.Invalidated_properties = CoreUI.Wrapper.Globals.NativeArrayToIList<CoreUI.DataTypes.Stringshare>(_internal_struct.Invalidated_properties);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI {
/// <summary>Every time a child is added the event <see cref="CoreUI.IModel.ChildAddedEvent"/> is dispatched passing along this structure.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct ModelChildrenEvent : IEquatable<ModelChildrenEvent>
{
    /// <summary>index is a hint and is intended to provide a way for applications to control/know children relative positions through listings.</summary>
    /// <since_tizen> 6 </since_tizen>
    public uint Index;
    /// <summary>If an object has been built for this index and it is currently tracked by the parent, it will be available here.</summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Object Child;
    /// <summary>Constructor for ModelChildrenEvent.
    /// </summary>
    /// <param name="Index">index is a hint and is intended to provide a way for applications to control/know children relative positions through listings.</param>
    /// <param name="Child">If an object has been built for this index and it is currently tracked by the parent, it will be available here.</param>
    /// <since_tizen> 6 </since_tizen>
    public ModelChildrenEvent(
        uint Index = default(uint),
        CoreUI.Object Child = default(CoreUI.Object)    )
    {
        this.Index = Index;
        this.Child = Child;
    }

    /// <summary>Packs tuple into ModelChildrenEvent object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator ModelChildrenEvent(
        (
         uint Index,
         CoreUI.Object Child
        ) tuple)
    {
        return new ModelChildrenEvent{
            Index = tuple.Index,
            Child = tuple.Child,
        };
    }
    /// <summary>Unpacks ModelChildrenEvent into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out uint Index,
        out CoreUI.Object Child
    )
    {
        Index = this.Index;
        Child = this.Child;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Index.GetHashCode();
        hash = hash * 23 + Child.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(ModelChildrenEvent other)
    {
        return Index == other.Index && Child == other.Child        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is ModelChildrenEvent) ? Equals((ModelChildrenEvent)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(ModelChildrenEvent lhs, ModelChildrenEvent rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(ModelChildrenEvent lhs, ModelChildrenEvent rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ModelChildrenEvent(IntPtr ptr)
    {
        var tmp = (ModelChildrenEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ModelChildrenEvent.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static ModelChildrenEvent FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ModelChildrenEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public uint Index;
        /// <summary>Internal wrapper for field Child</summary>
        public System.IntPtr Child;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ModelChildrenEvent.NativeStruct(ModelChildrenEvent _external_struct)
        {
            var _internal_struct = new ModelChildrenEvent.NativeStruct();
            _internal_struct.Index = _external_struct.Index;
            _internal_struct.Child = _external_struct.Child?.NativeHandle ?? System.IntPtr.Zero;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ModelChildrenEvent(ModelChildrenEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new ModelChildrenEvent();
            _external_struct.Index = _internal_struct.Index;

            _external_struct.Child = (CoreUI.Object) CoreUI.Wrapper.Globals.CreateWrapperFor(_internal_struct.Child);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

