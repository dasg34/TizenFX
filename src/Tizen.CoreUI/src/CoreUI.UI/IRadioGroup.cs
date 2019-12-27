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
/// <summary>Interface for manually handling a group of <see cref="CoreUI.UI.Radio"/> buttons.
/// 
/// See the documentation of <see cref="CoreUI.UI.Radio"/> for an explanation of radio button grouping.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.UI.RadioGroupConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IRadioGroup : 
    CoreUI.UI.ISingleSelectable,
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="CoreUI.UI.Radio.StateValue"/>.
    /// 
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <returns>The value of the currently selected radio button, or -1.</returns>
    /// <since_tizen> 6 </since_tizen>
    int GetSelectedValue();

    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="CoreUI.UI.Radio.StateValue"/>.
    /// 
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <param name="selected_value">The value of the currently selected radio button, or -1.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetSelectedValue(int selected_value);

    /// <summary>Register a new <see cref="CoreUI.UI.Radio"/> button to this group. Keep in mind that registering to a group will only handle button grouping, you still need to add the button to a layout for it to be rendered.
    /// 
    /// If the <see cref="CoreUI.UI.Radio.StateValue"/> of the new button is already used by a previous button in the group, the button will not be added.
    /// 
    /// See also <see cref="CoreUI.UI.IRadioGroup.Unregister"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="radio">The radio button to add to the group.</param>
    void Register(CoreUI.UI.Radio radio);

    /// <summary>Unregister an <see cref="CoreUI.UI.Radio"/> button from this group. This will unlink the behavior of this button from the other buttons in the group, but if it still belongs to a layout, it will still be rendered.
    /// 
    /// If the button was not registered in the group the call is ignored. If the button was selected, no button will be selected in the group after this call.
    /// 
    /// See also <see cref="CoreUI.UI.IRadioGroup.Register"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="radio">The radio button to remove from the group.</param>
    void Unregister(CoreUI.UI.Radio radio);

    /// <summary>Emitted each time the <c>selected_value</c> changes. The event information contains the <see cref="CoreUI.UI.Radio.StateValue"/> of the newly selected button or -1 if no button is now selected.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.RadioGroupValueChangedEventArgs"/></value>
    event EventHandler<CoreUI.UI.RadioGroupValueChangedEventArgs> ValueChangedEvent;
    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="CoreUI.UI.Radio.StateValue"/>.
    /// 
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <value>The value of the currently selected radio button, or -1.</value>
    /// <since_tizen> 6 </since_tizen>
    int SelectedValue {
        get;
        set;
    }

}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IRadioGroup.ValueChangedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class RadioGroupValueChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Emitted each time the <c>selected_value</c> changes. The event information contains the <see cref="CoreUI.UI.Radio.StateValue"/> of the newly selected button or -1 if no button is now selected.</value>
    /// <since_tizen> 6 </since_tizen>
    public int arg { get; set; }
}

/// <summary>Interface for manually handling a group of <see cref="CoreUI.UI.Radio"/> buttons.
/// 
/// See the documentation of <see cref="CoreUI.UI.Radio"/> for an explanation of radio button grouping.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class RadioGroupConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IRadioGroup,
    CoreUI.UI.ISingleSelectable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(RadioGroupConcrete))
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
    private RadioGroupConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_radio_group_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IRadioGroup"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private RadioGroupConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Emitted each time the <c>selected_value</c> changes. The event information contains the <see cref="CoreUI.UI.Radio.StateValue"/> of the newly selected button or -1 if no button is now selected.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.RadioGroupValueChangedEventArgs"/></value>
    public event EventHandler<CoreUI.UI.RadioGroupValueChangedEventArgs> ValueChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.RadioGroupValueChangedEventArgs{ arg = Marshal.ReadInt32(info) });
            string key = "_EFL_UI_RADIO_GROUP_EVENT_VALUE_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_RADIO_GROUP_EVENT_VALUE_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
        }
    }

    /// <summary>Method to raise event ValueChangedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnValueChangedEvent(CoreUI.UI.RadioGroupValueChangedEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_RADIO_GROUP_EVENT_VALUE_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
    }


    /// <summary>Emitted when there is a change in the selection state. This event will collect all the item selection change events that are happening within one loop iteration. This means, you will only get this event once, even if a lot of items have changed. If you are interested in detailed changes, subscribe to the individual <see cref="CoreUI.UI.ISelectable.SelectedChangedEvent"/> events of each item.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler SelectionChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_SELECTABLE_EVENT_SELECTION_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_SELECTABLE_EVENT_SELECTION_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
        }
    }

    /// <summary>Method to raise event SelectionChangedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnSelectionChangedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SELECTABLE_EVENT_SELECTION_CHANGED", IntPtr.Zero, null);
    }

#pragma warning disable CS0628
    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="CoreUI.UI.Radio.StateValue"/>.
    /// 
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <returns>The value of the currently selected radio button, or -1.</returns>
    /// <since_tizen> 6 </since_tizen>
    public int GetSelectedValue() {
        var _ret_var = CoreUI.UI.RadioGroupConcrete.NativeMethods.efl_ui_radio_group_selected_value_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="CoreUI.UI.Radio.StateValue"/>.
    /// 
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <param name="selected_value">The value of the currently selected radio button, or -1.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetSelectedValue(int selected_value) {
        CoreUI.UI.RadioGroupConcrete.NativeMethods.efl_ui_radio_group_selected_value_set_ptr.Value.Delegate(this.NativeHandle, selected_value);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Register a new <see cref="CoreUI.UI.Radio"/> button to this group. Keep in mind that registering to a group will only handle button grouping, you still need to add the button to a layout for it to be rendered.
    /// 
    /// If the <see cref="CoreUI.UI.Radio.StateValue"/> of the new button is already used by a previous button in the group, the button will not be added.
    /// 
    /// See also <see cref="CoreUI.UI.IRadioGroup.Unregister"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="radio">The radio button to add to the group.</param>
    public void Register(CoreUI.UI.Radio radio) {
        CoreUI.UI.RadioGroupConcrete.NativeMethods.efl_ui_radio_group_register_ptr.Value.Delegate(this.NativeHandle, radio);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Unregister an <see cref="CoreUI.UI.Radio"/> button from this group. This will unlink the behavior of this button from the other buttons in the group, but if it still belongs to a layout, it will still be rendered.
    /// 
    /// If the button was not registered in the group the call is ignored. If the button was selected, no button will be selected in the group after this call.
    /// 
    /// See also <see cref="CoreUI.UI.IRadioGroup.Register"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="radio">The radio button to remove from the group.</param>
    public void Unregister(CoreUI.UI.Radio radio) {
        CoreUI.UI.RadioGroupConcrete.NativeMethods.efl_ui_radio_group_unregister_ptr.Value.Delegate(this.NativeHandle, radio);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The selectable that was selected most recently.</summary>
    /// <returns>The latest selected item.</returns>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.ISelectable GetLastSelected() {
        var _ret_var = CoreUI.UI.SingleSelectableConcrete.NativeMethods.efl_ui_selectable_last_selected_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>A object that will be selected in case nothing is selected
    /// 
    /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.ISelectable GetFallbackSelection() {
        var _ret_var = CoreUI.UI.SingleSelectableConcrete.NativeMethods.efl_ui_selectable_fallback_selection_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>A object that will be selected in case nothing is selected
    /// 
    /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    /// <since_tizen> 6 </since_tizen>
    public void SetFallbackSelection(CoreUI.UI.ISelectable fallback) {
        CoreUI.UI.SingleSelectableConcrete.NativeMethods.efl_ui_selectable_fallback_selection_set_ptr.Value.Delegate(this.NativeHandle, fallback);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="CoreUI.UI.Radio.StateValue"/>.
    /// 
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <value>The value of the currently selected radio button, or -1.</value>
    /// <since_tizen> 6 </since_tizen>
    public int SelectedValue {
        get { return GetSelectedValue(); }
        set { SetSelectedValue(value); }
    }

    /// <summary>The selectable that was selected most recently.</summary>
    /// <value>The latest selected item.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.ISelectable LastSelected {
        get { return GetLastSelected(); }
    }

    /// <summary>A object that will be selected in case nothing is selected
    /// 
    /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.ISelectable FallbackSelection {
        get { return GetFallbackSelection(); }
        set { SetFallbackSelection(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.UI.RadioGroupConcrete.efl_ui_radio_group_interface_get();
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

            if (efl_ui_radio_group_selected_value_get_static_delegate == null)
            {
                efl_ui_radio_group_selected_value_get_static_delegate = new efl_ui_radio_group_selected_value_get_delegate(selected_value_get);
            }

            if (methods.Contains("GetSelectedValue"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_selected_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_selected_value_get_static_delegate) });
            }

            if (efl_ui_radio_group_selected_value_set_static_delegate == null)
            {
                efl_ui_radio_group_selected_value_set_static_delegate = new efl_ui_radio_group_selected_value_set_delegate(selected_value_set);
            }

            if (methods.Contains("SetSelectedValue"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_selected_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_selected_value_set_static_delegate) });
            }

            if (efl_ui_radio_group_register_static_delegate == null)
            {
                efl_ui_radio_group_register_static_delegate = new efl_ui_radio_group_register_delegate(register);
            }

            if (methods.Contains("Register"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_register"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_register_static_delegate) });
            }

            if (efl_ui_radio_group_unregister_static_delegate == null)
            {
                efl_ui_radio_group_unregister_static_delegate = new efl_ui_radio_group_unregister_delegate(unregister);
            }

            if (methods.Contains("Unregister"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_unregister"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_unregister_static_delegate) });
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
            return CoreUI.UI.RadioGroupConcrete.efl_ui_radio_group_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_ui_radio_group_selected_value_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_ui_radio_group_selected_value_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_group_selected_value_get_api_delegate> efl_ui_radio_group_selected_value_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_group_selected_value_get_api_delegate>(Module, "efl_ui_radio_group_selected_value_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int selected_value_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_radio_group_selected_value_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IRadioGroup)ws.Target).GetSelectedValue();
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
                return efl_ui_radio_group_selected_value_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_radio_group_selected_value_get_delegate efl_ui_radio_group_selected_value_get_static_delegate;

        
        private delegate void efl_ui_radio_group_selected_value_set_delegate(System.IntPtr obj, System.IntPtr pd,  int selected_value);

        
        internal delegate void efl_ui_radio_group_selected_value_set_api_delegate(System.IntPtr obj,  int selected_value);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_group_selected_value_set_api_delegate> efl_ui_radio_group_selected_value_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_group_selected_value_set_api_delegate>(Module, "efl_ui_radio_group_selected_value_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void selected_value_set(System.IntPtr obj, System.IntPtr pd, int selected_value)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_radio_group_selected_value_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IRadioGroup)ws.Target).SetSelectedValue(selected_value);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_radio_group_selected_value_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), selected_value);
            }
        }

        private static efl_ui_radio_group_selected_value_set_delegate efl_ui_radio_group_selected_value_set_static_delegate;

        
        private delegate void efl_ui_radio_group_register_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Radio radio);

        
        internal delegate void efl_ui_radio_group_register_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Radio radio);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_group_register_api_delegate> efl_ui_radio_group_register_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_group_register_api_delegate>(Module, "efl_ui_radio_group_register");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void register(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Radio radio)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_radio_group_register was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IRadioGroup)ws.Target).Register(radio);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_radio_group_register_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), radio);
            }
        }

        private static efl_ui_radio_group_register_delegate efl_ui_radio_group_register_static_delegate;

        
        private delegate void efl_ui_radio_group_unregister_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Radio radio);

        
        internal delegate void efl_ui_radio_group_unregister_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Radio radio);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_group_unregister_api_delegate> efl_ui_radio_group_unregister_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_radio_group_unregister_api_delegate>(Module, "efl_ui_radio_group_unregister");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void unregister(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Radio radio)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_radio_group_unregister was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IRadioGroup)ws.Target).Unregister(radio);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_radio_group_unregister_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), radio);
            }
        }

        private static efl_ui_radio_group_unregister_delegate efl_ui_radio_group_unregister_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.UI {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class RadioGroupConcreteExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<int> SelectedValue<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IRadioGroup, T>magic = null) where T : CoreUI.UI.IRadioGroup {
        return new CoreUI.BindableProperty<int>("selected_value", fac);
    }

    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<CoreUI.UI.ISelectable> FallbackSelection<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IRadioGroup, T>magic = null) where T : CoreUI.UI.IRadioGroup {
        return new CoreUI.BindableProperty<CoreUI.UI.ISelectable>("fallback_selection", fac);
    }

}
#pragma warning restore CS1591
}

