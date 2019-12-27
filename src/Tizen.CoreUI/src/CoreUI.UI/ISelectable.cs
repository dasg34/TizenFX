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
/// <summary>Selectable interface for UI objects
/// 
/// An object implementing this interface can be selected. When the selected property of this object changes, the <see cref="CoreUI.UI.ISelectable.SelectedChangedEvent"/> event is emitted.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.UI.SelectableConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface ISelectable : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>The selected state of this object
    /// 
    /// A change to this property emits the changed event.</summary>
    /// <returns>The selected state of this object.</returns>
    /// <since_tizen> 6 </since_tizen>
    bool GetSelected();

    /// <summary>The selected state of this object
    /// 
    /// A change to this property emits the changed event.</summary>
    /// <param name="selected">The selected state of this object.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetSelected(bool selected);

    /// <summary>Called when the selected state has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.SelectableSelectedChangedEventArgs"/></value>
    event EventHandler<CoreUI.UI.SelectableSelectedChangedEventArgs> SelectedChangedEvent;
    /// <summary>The selected state of this object
    /// 
    /// A change to this property emits the changed event.</summary>
    /// <value>The selected state of this object.</value>
    /// <since_tizen> 6 </since_tizen>
    bool Selected {
        get;
        set;
    }

}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.ISelectable.SelectedChangedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class SelectableSelectedChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Called when the selected state has changed.</value>
    /// <since_tizen> 6 </since_tizen>
    public bool arg { get; set; }
}

/// <summary>Selectable interface for UI objects
/// 
/// An object implementing this interface can be selected. When the selected property of this object changes, the <see cref="CoreUI.UI.ISelectable.SelectedChangedEvent"/> event is emitted.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class SelectableConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    ISelectable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(SelectableConcrete))
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
    private SelectableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_selectable_interface_get();

    /// <summary>Initializes a new instance of the <see cref="ISelectable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private SelectableConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when the selected state has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.SelectableSelectedChangedEventArgs"/></value>
    public event EventHandler<CoreUI.UI.SelectableSelectedChangedEventArgs> SelectedChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.SelectableSelectedChangedEventArgs{ arg = Marshal.ReadByte(info) != 0 });
            string key = "_EFL_UI_EVENT_SELECTED_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SELECTED_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
        }
    }

    /// <summary>Method to raise event SelectedChangedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnSelectedChangedEvent(CoreUI.UI.SelectableSelectedChangedEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg ? (byte) 1 : (byte) 0);
        CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SELECTED_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
    }


#pragma warning disable CS0628
    /// <summary>The selected state of this object
    /// 
    /// A change to this property emits the changed event.</summary>
    /// <returns>The selected state of this object.</returns>
    /// <since_tizen> 6 </since_tizen>
    public bool GetSelected() {
        var _ret_var = CoreUI.UI.SelectableConcrete.NativeMethods.efl_ui_selectable_selected_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The selected state of this object
    /// 
    /// A change to this property emits the changed event.</summary>
    /// <param name="selected">The selected state of this object.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetSelected(bool selected) {
        CoreUI.UI.SelectableConcrete.NativeMethods.efl_ui_selectable_selected_set_ptr.Value.Delegate(this.NativeHandle, selected);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The selected state of this object
    /// 
    /// A change to this property emits the changed event.</summary>
    /// <value>The selected state of this object.</value>
    /// <since_tizen> 6 </since_tizen>
    public bool Selected {
        get { return GetSelected(); }
        set { SetSelected(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.UI.SelectableConcrete.efl_ui_selectable_interface_get();
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

            if (efl_ui_selectable_selected_get_static_delegate == null)
            {
                efl_ui_selectable_selected_get_static_delegate = new efl_ui_selectable_selected_get_delegate(selected_get);
            }

            if (methods.Contains("GetSelected"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_selected_get_static_delegate) });
            }

            if (efl_ui_selectable_selected_set_static_delegate == null)
            {
                efl_ui_selectable_selected_set_static_delegate = new efl_ui_selectable_selected_set_delegate(selected_set);
            }

            if (methods.Contains("SetSelected"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selectable_selected_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selectable_selected_set_static_delegate) });
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
            return CoreUI.UI.SelectableConcrete.efl_ui_selectable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_selectable_selected_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_ui_selectable_selected_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_selected_get_api_delegate> efl_ui_selectable_selected_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_selected_get_api_delegate>(Module, "efl_ui_selectable_selected_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool selected_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_selectable_selected_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ISelectable)ws.Target).GetSelected();
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
                return efl_ui_selectable_selected_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_selectable_selected_get_delegate efl_ui_selectable_selected_get_static_delegate;

        
        private delegate void efl_ui_selectable_selected_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool selected);

        
        internal delegate void efl_ui_selectable_selected_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool selected);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_selected_set_api_delegate> efl_ui_selectable_selected_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_selectable_selected_set_api_delegate>(Module, "efl_ui_selectable_selected_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void selected_set(System.IntPtr obj, System.IntPtr pd, bool selected)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_selectable_selected_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ISelectable)ws.Target).SetSelected(selected);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_selectable_selected_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), selected);
            }
        }

        private static efl_ui_selectable_selected_set_delegate efl_ui_selectable_selected_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.UI {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class SelectableConcreteExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<bool> Selected<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.ISelectable, T>magic = null) where T : CoreUI.UI.ISelectable {
        return new CoreUI.BindableProperty<bool>("selected", fac);
    }

}
#pragma warning restore CS1591
}

