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
/// <summary>Interface that contains properties regarding the displaying of a value within a range.
/// 
/// A value range contains a value restricted between specified minimum and maximum limits at all times. This can be used for progressbars, sliders or spinners, for example.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.UI.RangeDisplayConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IRangeDisplay : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Control the value (position) of the widget within its valid range.
    /// 
    /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> are ignored and an error is printed.</summary>
    /// <returns>The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>).</returns>
    /// <since_tizen> 6 </since_tizen>
    double GetRangeValue();

    /// <summary>Control the value (position) of the widget within its valid range.
    /// 
    /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> are ignored and an error is printed.</summary>
    /// <param name="val">The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>).</param>
    /// <since_tizen> 6 </since_tizen>
    void SetRangeValue(double val);

    /// <summary>Set the minimum and maximum values for given range widget.
    /// 
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// <b>NOTE: </b>maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <since_tizen> 6 </since_tizen>
    void GetRangeLimits(out double min, out double max);

    /// <summary>Set the minimum and maximum values for given range widget.
    /// 
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// <b>NOTE: </b>maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetRangeLimits(double min, double max);

    /// <summary>Emitted when the <see cref="CoreUI.UI.IRangeDisplay.RangeValue"/> is getting changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ChangedEvent;
    /// <summary>Emitted when the <see cref="CoreUI.UI.IRangeDisplay.RangeValue"/> has reached the minimum of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler MinReachedEvent;
    /// <summary>Emitted when the <c>range_value</c> has reached the maximum of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler MaxReachedEvent;
    /// <summary>Control the value (position) of the widget within its valid range.
    /// 
    /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> are ignored and an error is printed.</summary>
    /// <value>The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>).</value>
    /// <since_tizen> 6 </since_tizen>
    double RangeValue {
        get;
        set;
    }

    /// <summary>Set the minimum and maximum values for given range widget.
    /// 
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// <b>NOTE: </b>maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <value>The minimum value.</value>
    /// <since_tizen> 6 </since_tizen>
    (double, double) RangeLimits {
        get;
        set;
    }

}

/// <summary>Interface that contains properties regarding the displaying of a value within a range.
/// 
/// A value range contains a value restricted between specified minimum and maximum limits at all times. This can be used for progressbars, sliders or spinners, for example.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class RangeDisplayConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IRangeDisplay
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(RangeDisplayConcrete))
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
    private RangeDisplayConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_range_display_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IRangeDisplay"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private RangeDisplayConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Emitted when the <see cref="CoreUI.UI.IRangeDisplay.RangeValue"/> is getting changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_RANGE_EVENT_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_RANGE_EVENT_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ChangedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnChangedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_RANGE_EVENT_CHANGED", IntPtr.Zero, null);
    }

    /// <summary>Emitted when the <see cref="CoreUI.UI.IRangeDisplay.RangeValue"/> has reached the minimum of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler MinReachedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_RANGE_EVENT_MIN_REACHED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_RANGE_EVENT_MIN_REACHED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event MinReachedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnMinReachedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_RANGE_EVENT_MIN_REACHED", IntPtr.Zero, null);
    }

    /// <summary>Emitted when the <c>range_value</c> has reached the maximum of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler MaxReachedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_RANGE_EVENT_MAX_REACHED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_RANGE_EVENT_MAX_REACHED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event MaxReachedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnMaxReachedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_RANGE_EVENT_MAX_REACHED", IntPtr.Zero, null);
    }


#pragma warning disable CS0628
    /// <summary>Control the value (position) of the widget within its valid range.
    /// 
    /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> are ignored and an error is printed.</summary>
    /// <returns>The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>).</returns>
    /// <since_tizen> 6 </since_tizen>
    public double GetRangeValue() {
        var _ret_var = CoreUI.UI.RangeDisplayConcrete.NativeMethods.efl_ui_range_value_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the value (position) of the widget within its valid range.
    /// 
    /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> are ignored and an error is printed.</summary>
    /// <param name="val">The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>).</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetRangeValue(double val) {
        CoreUI.UI.RangeDisplayConcrete.NativeMethods.efl_ui_range_value_set_ptr.Value.Delegate(this.NativeHandle, val);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set the minimum and maximum values for given range widget.
    /// 
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// <b>NOTE: </b>maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <since_tizen> 6 </since_tizen>
    public void GetRangeLimits(out double min, out double max) {
        CoreUI.UI.RangeDisplayConcrete.NativeMethods.efl_ui_range_limits_get_ptr.Value.Delegate(this.NativeHandle, out min, out max);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set the minimum and maximum values for given range widget.
    /// 
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// <b>NOTE: </b>maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetRangeLimits(double min, double max) {
        CoreUI.UI.RangeDisplayConcrete.NativeMethods.efl_ui_range_limits_set_ptr.Value.Delegate(this.NativeHandle, min, max);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control the value (position) of the widget within its valid range.
    /// 
    /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> are ignored and an error is printed.</summary>
    /// <value>The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>).</value>
    /// <since_tizen> 6 </since_tizen>
    public double RangeValue {
        get { return GetRangeValue(); }
        set { SetRangeValue(value); }
    }

    /// <summary>Set the minimum and maximum values for given range widget.
    /// 
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// <b>NOTE: </b>maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <value>The minimum value.</value>
    /// <since_tizen> 6 </since_tizen>
    public (double, double) RangeLimits {
        get {
            double _out_min = default(double);
            double _out_max = default(double);
            GetRangeLimits(out _out_min, out _out_max);
            return (_out_min, _out_max);
        }
        set { SetRangeLimits( value.Item1,  value.Item2); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.UI.RangeDisplayConcrete.efl_ui_range_display_interface_get();
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

            if (efl_ui_range_value_get_static_delegate == null)
            {
                efl_ui_range_value_get_static_delegate = new efl_ui_range_value_get_delegate(range_value_get);
            }

            if (methods.Contains("GetRangeValue"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_value_get_static_delegate) });
            }

            if (efl_ui_range_value_set_static_delegate == null)
            {
                efl_ui_range_value_set_static_delegate = new efl_ui_range_value_set_delegate(range_value_set);
            }

            if (methods.Contains("SetRangeValue"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_value_set_static_delegate) });
            }

            if (efl_ui_range_limits_get_static_delegate == null)
            {
                efl_ui_range_limits_get_static_delegate = new efl_ui_range_limits_get_delegate(range_limits_get);
            }

            if (methods.Contains("GetRangeLimits"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_limits_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_limits_get_static_delegate) });
            }

            if (efl_ui_range_limits_set_static_delegate == null)
            {
                efl_ui_range_limits_set_static_delegate = new efl_ui_range_limits_set_delegate(range_limits_set);
            }

            if (methods.Contains("SetRangeLimits"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_limits_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_limits_set_static_delegate) });
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
            return CoreUI.UI.RangeDisplayConcrete.efl_ui_range_display_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_ui_range_value_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_ui_range_value_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_range_value_get_api_delegate> efl_ui_range_value_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_range_value_get_api_delegate>(Module, "efl_ui_range_value_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double range_value_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_range_value_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IRangeDisplay)ws.Target).GetRangeValue();
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
                return efl_ui_range_value_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_range_value_get_delegate efl_ui_range_value_get_static_delegate;

        
        private delegate void efl_ui_range_value_set_delegate(System.IntPtr obj, System.IntPtr pd,  double val);

        
        internal delegate void efl_ui_range_value_set_api_delegate(System.IntPtr obj,  double val);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_range_value_set_api_delegate> efl_ui_range_value_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_range_value_set_api_delegate>(Module, "efl_ui_range_value_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void range_value_set(System.IntPtr obj, System.IntPtr pd, double val)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_range_value_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IRangeDisplay)ws.Target).SetRangeValue(val);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_range_value_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), val);
            }
        }

        private static efl_ui_range_value_set_delegate efl_ui_range_value_set_static_delegate;

        
        private delegate void efl_ui_range_limits_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double min,  out double max);

        
        internal delegate void efl_ui_range_limits_get_api_delegate(System.IntPtr obj,  out double min,  out double max);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_range_limits_get_api_delegate> efl_ui_range_limits_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_range_limits_get_api_delegate>(Module, "efl_ui_range_limits_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void range_limits_get(System.IntPtr obj, System.IntPtr pd, out double min, out double max)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_range_limits_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                min = default(double);max = default(double);
                try
                {
                    ((IRangeDisplay)ws.Target).GetRangeLimits(out min, out max);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_range_limits_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out min, out max);
            }
        }

        private static efl_ui_range_limits_get_delegate efl_ui_range_limits_get_static_delegate;

        
        private delegate void efl_ui_range_limits_set_delegate(System.IntPtr obj, System.IntPtr pd,  double min,  double max);

        
        internal delegate void efl_ui_range_limits_set_api_delegate(System.IntPtr obj,  double min,  double max);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_range_limits_set_api_delegate> efl_ui_range_limits_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_range_limits_set_api_delegate>(Module, "efl_ui_range_limits_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void range_limits_set(System.IntPtr obj, System.IntPtr pd, double min, double max)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_range_limits_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IRangeDisplay)ws.Target).SetRangeLimits(min, max);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_range_limits_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), min, max);
            }
        }

        private static efl_ui_range_limits_set_delegate efl_ui_range_limits_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.UI {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class RangeDisplayConcreteExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<double> RangeValue<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IRangeDisplay, T>magic = null) where T : CoreUI.UI.IRangeDisplay {
        return new CoreUI.BindableProperty<double>("range_value", fac);
    }

}
#pragma warning restore CS1591
}

