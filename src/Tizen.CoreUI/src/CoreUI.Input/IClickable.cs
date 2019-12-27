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
namespace CoreUI.Input {
/// <summary>CoreUI input clickable interface.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Input.ClickableConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IClickable : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>This returns true if the given object is currently in event emission</summary>
    /// <since_tizen> 6 </since_tizen>
    bool GetInteraction();

    /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.ClickableClickedEventArgs"/></value>
    event EventHandler<CoreUI.Input.ClickableClickedEventArgs> ClickedEvent;
    /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.ClickableClickedAnyEventArgs"/></value>
    event EventHandler<CoreUI.Input.ClickableClickedAnyEventArgs> ClickedAnyEvent;
    /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.ClickablePressedEventArgs"/></value>
    event EventHandler<CoreUI.Input.ClickablePressedEventArgs> PressedEvent;
    /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.ClickableUnpressedEventArgs"/></value>
    event EventHandler<CoreUI.Input.ClickableUnpressedEventArgs> UnpressedEvent;
    /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.ClickableLongpressedEventArgs"/></value>
    event EventHandler<CoreUI.Input.ClickableLongpressedEventArgs> LongpressedEvent;
    /// <summary>This returns true if the given object is currently in event emission</summary>
    /// <since_tizen> 6 </since_tizen>
    bool Interaction {
        get;
    }

}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IClickable.ClickedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ClickableClickedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Called when object is in sequence pressed and unpressed by the primary button</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.ClickableClicked arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IClickable.ClickedAnyEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ClickableClickedAnyEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.ClickableClicked arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IClickable.PressedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ClickablePressedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Called when the object is pressed, event_info is the button that got pressed</value>
    /// <since_tizen> 6 </since_tizen>
    public int arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IClickable.UnpressedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ClickableUnpressedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Called when the object is no longer pressed, event_info is the button that got pressed</value>
    /// <since_tizen> 6 </since_tizen>
    public int arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IClickable.LongpressedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ClickableLongpressedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Called when the object receives a long press, event_info is the button that got pressed</value>
    /// <since_tizen> 6 </since_tizen>
    public int arg { get; set; }
}

/// <summary>CoreUI input clickable interface.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ClickableConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IClickable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ClickableConcrete))
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
    private ClickableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
        efl_input_clickable_mixin_get();

    /// <summary>Initializes a new instance of the <see cref="IClickable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ClickableConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.ClickableClickedEventArgs"/></value>
    public event EventHandler<CoreUI.Input.ClickableClickedEventArgs> ClickedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableClickedEventArgs{ arg =  info });
            string key = "_EFL_INPUT_EVENT_CLICKED";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_INPUT_EVENT_CLICKED";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event ClickedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnClickedEvent(CoreUI.Input.ClickableClickedEventArgs e)
    {
        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_INPUT_EVENT_CLICKED", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.ClickableClickedAnyEventArgs"/></value>
    public event EventHandler<CoreUI.Input.ClickableClickedAnyEventArgs> ClickedAnyEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableClickedAnyEventArgs{ arg =  info });
            string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event ClickedAnyEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnClickedAnyEvent(CoreUI.Input.ClickableClickedAnyEventArgs e)
    {
        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_INPUT_EVENT_CLICKED_ANY", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.ClickablePressedEventArgs"/></value>
    public event EventHandler<CoreUI.Input.ClickablePressedEventArgs> PressedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickablePressedEventArgs{ arg = Marshal.ReadInt32(info) });
            string key = "_EFL_INPUT_EVENT_PRESSED";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_INPUT_EVENT_PRESSED";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PressedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPressedEvent(CoreUI.Input.ClickablePressedEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_INPUT_EVENT_PRESSED", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.ClickableUnpressedEventArgs"/></value>
    public event EventHandler<CoreUI.Input.ClickableUnpressedEventArgs> UnpressedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableUnpressedEventArgs{ arg = Marshal.ReadInt32(info) });
            string key = "_EFL_INPUT_EVENT_UNPRESSED";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_INPUT_EVENT_UNPRESSED";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event UnpressedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnUnpressedEvent(CoreUI.Input.ClickableUnpressedEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_INPUT_EVENT_UNPRESSED", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.ClickableLongpressedEventArgs"/></value>
    public event EventHandler<CoreUI.Input.ClickableLongpressedEventArgs> LongpressedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableLongpressedEventArgs{ arg = Marshal.ReadInt32(info) });
            string key = "_EFL_INPUT_EVENT_LONGPRESSED";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_INPUT_EVENT_LONGPRESSED";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event LongpressedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnLongpressedEvent(CoreUI.Input.ClickableLongpressedEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_INPUT_EVENT_LONGPRESSED", info, (p) => Marshal.FreeHGlobal(p));
    }


#pragma warning disable CS0628
    /// <summary>This returns true if the given object is currently in event emission</summary>
    /// <since_tizen> 6 </since_tizen>
    public bool GetInteraction() {
        var _ret_var = CoreUI.Input.ClickableConcrete.NativeMethods.efl_input_clickable_interaction_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Change internal states that a button got pressed.
    /// 
    /// When the button is already pressed, this is silently ignored.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected void Press(uint button) {
        CoreUI.Input.ClickableConcrete.NativeMethods.efl_input_clickable_press_ptr.Value.Delegate(this.NativeHandle, button);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Change internal states that a button got unpressed.
    /// 
    /// When the button is not pressed, this is silently ignored.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected void Unpress(uint button) {
        CoreUI.Input.ClickableConcrete.NativeMethods.efl_input_clickable_unpress_ptr.Value.Delegate(this.NativeHandle, button);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This aborts the internal state after a press call.
    /// 
    /// This will stop the timer for longpress and set the state of the clickable mixin back into the unpressed state.</summary>
    /// <since_tizen> 6 </since_tizen>
    protected void ResetButtonState(uint button) {
        CoreUI.Input.ClickableConcrete.NativeMethods.efl_input_clickable_button_state_reset_ptr.Value.Delegate(this.NativeHandle, button);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This aborts ongoing longpress event.
    /// 
    /// That is, this will stop the timer for longpress.</summary>
    /// <since_tizen> 6 </since_tizen>
    protected void LongpressAbort(uint button) {
        CoreUI.Input.ClickableConcrete.NativeMethods.efl_input_clickable_longpress_abort_ptr.Value.Delegate(this.NativeHandle, button);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This returns true if the given object is currently in event emission</summary>
    /// <since_tizen> 6 </since_tizen>
    public bool Interaction {
        get { return GetInteraction(); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.Input.ClickableConcrete.efl_input_clickable_mixin_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal new class NativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_input_clickable_interaction_get_static_delegate == null)
            {
                efl_input_clickable_interaction_get_static_delegate = new efl_input_clickable_interaction_get_delegate(interaction_get);
            }

            if (methods.Contains("GetInteraction"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_interaction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_interaction_get_static_delegate) });
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
            return CoreUI.Input.ClickableConcrete.efl_input_clickable_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_clickable_interaction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_input_clickable_interaction_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_interaction_get_api_delegate> efl_input_clickable_interaction_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_interaction_get_api_delegate>(Module, "efl_input_clickable_interaction_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool interaction_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_input_clickable_interaction_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IClickable)ws.Target).GetInteraction();
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
                return efl_input_clickable_interaction_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_input_clickable_interaction_get_delegate efl_input_clickable_interaction_get_static_delegate;

        
        private delegate void efl_input_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        internal delegate void efl_input_clickable_press_api_delegate(System.IntPtr obj,  uint button);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_press_api_delegate> efl_input_clickable_press_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_press_api_delegate>(Module, "efl_input_clickable_press");

        
        private delegate void efl_input_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        internal delegate void efl_input_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_unpress_api_delegate> efl_input_clickable_unpress_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_unpress_api_delegate>(Module, "efl_input_clickable_unpress");

        
        private delegate void efl_input_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        internal delegate void efl_input_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate> efl_input_clickable_button_state_reset_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate>(Module, "efl_input_clickable_button_state_reset");

        
        private delegate void efl_input_clickable_longpress_abort_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        internal delegate void efl_input_clickable_longpress_abort_api_delegate(System.IntPtr obj,  uint button);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate> efl_input_clickable_longpress_abort_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate>(Module, "efl_input_clickable_longpress_abort");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.Input {
/// <summary>A struct that expresses a click in elementary.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct ClickableClicked : IEquatable<ClickableClicked>
{
    /// <summary>The amount of how often the clicked event was repeated in a certain amount of time</summary>
    /// <since_tizen> 6 </since_tizen>
    public uint Repeated;
    /// <summary>The Button that is pressed</summary>
    /// <since_tizen> 6 </since_tizen>
    public uint Button;
    /// <summary>Constructor for ClickableClicked.
    /// </summary>
    /// <param name="Repeated">The amount of how often the clicked event was repeated in a certain amount of time</param>
    /// <param name="Button">The Button that is pressed</param>
    /// <since_tizen> 6 </since_tizen>
    public ClickableClicked(
        uint Repeated = default(uint),
        uint Button = default(uint)    )
    {
        this.Repeated = Repeated;
        this.Button = Button;
    }

    /// <summary>Packs tuple into ClickableClicked object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator ClickableClicked(
        (
         uint Repeated,
         uint Button
        ) tuple)
    {
        return new ClickableClicked{
            Repeated = tuple.Repeated,
            Button = tuple.Button,
        };
    }
    /// <summary>Unpacks ClickableClicked into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out uint Repeated,
        out uint Button
    )
    {
        Repeated = this.Repeated;
        Button = this.Button;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Repeated.GetHashCode();
        hash = hash * 23 + Button.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(ClickableClicked other)
    {
        return Repeated == other.Repeated && Button == other.Button        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is ClickableClicked) ? Equals((ClickableClicked)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(ClickableClicked lhs, ClickableClicked rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(ClickableClicked lhs, ClickableClicked rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ClickableClicked(IntPtr ptr)
    {
        var tmp = (ClickableClicked.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ClickableClicked.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static ClickableClicked FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ClickableClicked.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public uint Repeated;
        
        public uint Button;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ClickableClicked.NativeStruct(ClickableClicked _external_struct)
        {
            var _internal_struct = new ClickableClicked.NativeStruct();
            _internal_struct.Repeated = _external_struct.Repeated;
            _internal_struct.Button = _external_struct.Button;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ClickableClicked(ClickableClicked.NativeStruct _internal_struct)
        {
            var _external_struct = new ClickableClicked();
            _external_struct.Repeated = _internal_struct.Repeated;
            _external_struct.Button = _internal_struct.Button;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

