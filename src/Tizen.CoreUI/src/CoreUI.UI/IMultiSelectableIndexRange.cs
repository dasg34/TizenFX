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
/// <summary>Interface for getting access to a range of selected items through their indices.
/// 
/// The implementor of this interface provides the possibility to select multiple <see cref="CoreUI.UI.ISelectable"/> objects. If not, only <see cref="CoreUI.UI.ISingleSelectable"/> should be implemented. A widget can only provide either this interface or <see cref="CoreUI.UI.IMultiSelectableObjectRange"/>, but not both.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.UI.MultiSelectableIndexRangeConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IMultiSelectableIndexRange : 
    CoreUI.UI.IMultiSelectable,
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Gets an iterator over the indices of all the selected children.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The iterator gives the indices of the selected children. It is valid until any change is made to the selection state.</returns>
    IEnumerable<uint> NewSelectedNdxIterator();

    /// <summary>Gets an iterator over the indices of all the unselected children.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The iterator gives the indices of the unselected children. It is valid until any change is made to the selection state.</returns>
    IEnumerable<uint> NewUnselectedNdxIterator();

}

/// <summary>Interface for getting access to a range of selected items through their indices.
/// 
/// The implementor of this interface provides the possibility to select multiple <see cref="CoreUI.UI.ISelectable"/> objects. If not, only <see cref="CoreUI.UI.ISingleSelectable"/> should be implemented. A widget can only provide either this interface or <see cref="CoreUI.UI.IMultiSelectableObjectRange"/>, but not both.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class MultiSelectableIndexRangeConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IMultiSelectableIndexRange,
    CoreUI.UI.IMultiSelectable,
    CoreUI.UI.ISingleSelectable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(MultiSelectableIndexRangeConcrete))
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
    private MultiSelectableIndexRangeConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_multi_selectable_index_range_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IMultiSelectableIndexRange"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private MultiSelectableIndexRangeConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
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
    /// <summary>Gets an iterator over the indices of all the selected children.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The iterator gives the indices of the selected children. It is valid until any change is made to the selection state.</returns>
    public IEnumerable<uint> NewSelectedNdxIterator() {
        var _ret_var = CoreUI.UI.MultiSelectableIndexRangeConcrete.NativeMethods.efl_ui_multi_selectable_selected_ndx_iterator_new_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return CoreUI.Wrapper.Globals.IteratorToIEnumerable<uint>(_ret_var);
    }

    /// <summary>Gets an iterator over the indices of all the unselected children.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The iterator gives the indices of the unselected children. It is valid until any change is made to the selection state.</returns>
    public IEnumerable<uint> NewUnselectedNdxIterator() {
        var _ret_var = CoreUI.UI.MultiSelectableIndexRangeConcrete.NativeMethods.efl_ui_multi_selectable_unselected_ndx_iterator_new_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return CoreUI.Wrapper.Globals.IteratorToIEnumerable<uint>(_ret_var);
    }

    /// <summary>The mode type for children selection.</summary>
    /// <returns>Type of selection of children</returns>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.SelectMode GetSelectMode() {
        var _ret_var = CoreUI.UI.MultiSelectableConcrete.NativeMethods.efl_ui_multi_selectable_select_mode_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The mode type for children selection.</summary>
    /// <param name="mode">Type of selection of children</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetSelectMode(CoreUI.UI.SelectMode mode) {
        CoreUI.UI.MultiSelectableConcrete.NativeMethods.efl_ui_multi_selectable_select_mode_set_ptr.Value.Delegate(this.NativeHandle, mode);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Select all <see cref="CoreUI.UI.ISelectable"/></summary>
    /// <since_tizen> 6 </since_tizen>
    public void SelectAll() {
        CoreUI.UI.MultiSelectableConcrete.NativeMethods.efl_ui_multi_selectable_all_select_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Unselect all <see cref="CoreUI.UI.ISelectable"/></summary>
    /// <since_tizen> 6 </since_tizen>
    public void UnselectAll() {
        CoreUI.UI.MultiSelectableConcrete.NativeMethods.efl_ui_multi_selectable_all_unselect_ptr.Value.Delegate(this.NativeHandle);
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

    /// <summary>The mode type for children selection.</summary>
    /// <value>Type of selection of children</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.SelectMode SelectMode {
        get { return GetSelectMode(); }
        set { SetSelectMode(value); }
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
        return CoreUI.UI.MultiSelectableIndexRangeConcrete.efl_ui_multi_selectable_index_range_interface_get();
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

            if (efl_ui_multi_selectable_selected_ndx_iterator_new_static_delegate == null)
            {
                efl_ui_multi_selectable_selected_ndx_iterator_new_static_delegate = new efl_ui_multi_selectable_selected_ndx_iterator_new_delegate(selected_ndx_iterator_new);
            }

            if (methods.Contains("NewSelectedNdxIterator"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_selected_ndx_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_selected_ndx_iterator_new_static_delegate) });
            }

            if (efl_ui_multi_selectable_unselected_ndx_iterator_new_static_delegate == null)
            {
                efl_ui_multi_selectable_unselected_ndx_iterator_new_static_delegate = new efl_ui_multi_selectable_unselected_ndx_iterator_new_delegate(unselected_ndx_iterator_new);
            }

            if (methods.Contains("NewUnselectedNdxIterator"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_unselected_ndx_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_unselected_ndx_iterator_new_static_delegate) });
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
            return CoreUI.UI.MultiSelectableIndexRangeConcrete.efl_ui_multi_selectable_index_range_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_ui_multi_selectable_selected_ndx_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate System.IntPtr efl_ui_multi_selectable_selected_ndx_iterator_new_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_selected_ndx_iterator_new_api_delegate> efl_ui_multi_selectable_selected_ndx_iterator_new_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_selected_ndx_iterator_new_api_delegate>(Module, "efl_ui_multi_selectable_selected_ndx_iterator_new");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr selected_ndx_iterator_new(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_multi_selectable_selected_ndx_iterator_new was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<uint> _ret_var = null;
                try
                {
                    _ret_var = ((IMultiSelectableIndexRange)ws.Target).NewSelectedNdxIterator();
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
                return efl_ui_multi_selectable_selected_ndx_iterator_new_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_multi_selectable_selected_ndx_iterator_new_delegate efl_ui_multi_selectable_selected_ndx_iterator_new_static_delegate;

        
        private delegate System.IntPtr efl_ui_multi_selectable_unselected_ndx_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate System.IntPtr efl_ui_multi_selectable_unselected_ndx_iterator_new_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_unselected_ndx_iterator_new_api_delegate> efl_ui_multi_selectable_unselected_ndx_iterator_new_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_multi_selectable_unselected_ndx_iterator_new_api_delegate>(Module, "efl_ui_multi_selectable_unselected_ndx_iterator_new");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr unselected_ndx_iterator_new(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_multi_selectable_unselected_ndx_iterator_new was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<uint> _ret_var = null;
                try
                {
                    _ret_var = ((IMultiSelectableIndexRange)ws.Target).NewUnselectedNdxIterator();
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
                return efl_ui_multi_selectable_unselected_ndx_iterator_new_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_multi_selectable_unselected_ndx_iterator_new_delegate efl_ui_multi_selectable_unselected_ndx_iterator_new_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.UI {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class MultiSelectableIndexRangeConcreteExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<CoreUI.UI.SelectMode> SelectMode<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IMultiSelectableIndexRange, T>magic = null) where T : CoreUI.UI.IMultiSelectableIndexRange {
        return new CoreUI.BindableProperty<CoreUI.UI.SelectMode>("select_mode", fac);
    }

    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<CoreUI.UI.ISelectable> FallbackSelection<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IMultiSelectableIndexRange, T>magic = null) where T : CoreUI.UI.IMultiSelectableIndexRange {
        return new CoreUI.BindableProperty<CoreUI.UI.ISelectable>("fallback_selection", fac);
    }

}
#pragma warning restore CS1591
}

