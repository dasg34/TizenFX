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
/// <summary>Interface used by widgets which can display scrollbars, enabling them to hold more content than actually visible through the viewport. A scrollbar contains a draggable part (thumb) which allows the user to move the viewport around the content. The size of the thumb relates to the size of the viewport compared to the whole content.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.UI.ScrollBarConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IScrollBar : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
    /// <param name="hbar">Horizontal scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
    /// <param name="vbar">Vertical scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
    /// <since_tizen> 6 </since_tizen>
    void GetBarMode(out CoreUI.UI.ScrollBarMode hbar, out CoreUI.UI.ScrollBarMode vbar);

    /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
    /// <param name="hbar">Horizontal scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
    /// <param name="vbar">Vertical scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetBarMode(CoreUI.UI.ScrollBarMode hbar, CoreUI.UI.ScrollBarMode vbar);

    /// <summary>This returns the relative size the thumb should have, given the current size of the viewport and the content. <c>0.0</c> means the viewport is much smaller than the content: the thumb will have its minimum size. <c>1.0</c> means the viewport has the same size as the content (or bigger): the thumb will have the same size as the scrollbar and cannot move.</summary>
    /// <param name="width">Value between <c>0.0</c> and <c>1.0</c>.</param>
    /// <param name="height">Value between <c>0.0</c> and <c>1.0</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    void GetBarSize(out double width, out double height);

    /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
    /// <param name="posx">Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</param>
    /// <param name="posy">Value between <c>0.0</c> (the top side of the thumb is touching the top edge of the widget) and <c>1.0</c> (the bottom side of the thumb is touching the bottom edge of the widget).</param>
    /// <since_tizen> 6 </since_tizen>
    void GetBarPosition(out double posx, out double posy);

    /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
    /// <param name="posx">Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</param>
    /// <param name="posy">Value between <c>0.0</c> (the top side of the thumb is touching the top edge of the widget) and <c>1.0</c> (the bottom side of the thumb is touching the bottom edge of the widget).</param>
    /// <since_tizen> 6 </since_tizen>
    void SetBarPosition(double posx, double posy);

    /// <summary>Emitted when thumb is pressed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollBarBarPressedEventArgs"/></value>
    event EventHandler<CoreUI.UI.ScrollBarBarPressedEventArgs> BarPressedEvent;
    /// <summary>Emitted when thumb is unpressed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollBarBarUnpressedEventArgs"/></value>
    event EventHandler<CoreUI.UI.ScrollBarBarUnpressedEventArgs> BarUnpressedEvent;
    /// <summary>Emitted when thumb is dragged.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollBarBarDraggedEventArgs"/></value>
    event EventHandler<CoreUI.UI.ScrollBarBarDraggedEventArgs> BarDraggedEvent;
    /// <summary>Emitted when thumb size has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler BarSizeChangedEvent;
    /// <summary>Emitted when thumb position has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler BarPosChangedEvent;
    /// <summary>Emitted when scrollbar is shown.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollBarBarShowEventArgs"/></value>
    event EventHandler<CoreUI.UI.ScrollBarBarShowEventArgs> BarShowEvent;
    /// <summary>Emitted when scrollbar is hidden.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollBarBarHideEventArgs"/></value>
    event EventHandler<CoreUI.UI.ScrollBarBarHideEventArgs> BarHideEvent;
    /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
    /// <value>Horizontal scrollbar mode.</value>
    /// <since_tizen> 6 </since_tizen>
    (CoreUI.UI.ScrollBarMode, CoreUI.UI.ScrollBarMode) BarMode {
        get;
        set;
    }

    /// <summary>This returns the relative size the thumb should have, given the current size of the viewport and the content. <c>0.0</c> means the viewport is much smaller than the content: the thumb will have its minimum size. <c>1.0</c> means the viewport has the same size as the content (or bigger): the thumb will have the same size as the scrollbar and cannot move.</summary>
    /// <since_tizen> 6 </since_tizen>
    (double, double) BarSize {
        get;
    }

    /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
    /// <value>Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</value>
    /// <since_tizen> 6 </since_tizen>
    (double, double) BarPosition {
        get;
        set;
    }

}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollBar.BarPressedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ScrollBarBarPressedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Emitted when thumb is pressed.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.LayoutOrientation arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollBar.BarUnpressedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ScrollBarBarUnpressedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Emitted when thumb is unpressed.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.LayoutOrientation arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollBar.BarDraggedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ScrollBarBarDraggedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Emitted when thumb is dragged.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.LayoutOrientation arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollBar.BarShowEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ScrollBarBarShowEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Emitted when scrollbar is shown.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.LayoutOrientation arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollBar.BarHideEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ScrollBarBarHideEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Emitted when scrollbar is hidden.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.LayoutOrientation arg { get; set; }
}

/// <summary>Interface used by widgets which can display scrollbars, enabling them to hold more content than actually visible through the viewport. A scrollbar contains a draggable part (thumb) which allows the user to move the viewport around the content. The size of the thumb relates to the size of the viewport compared to the whole content.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ScrollBarConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IScrollBar
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ScrollBarConcrete))
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
    private ScrollBarConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_scrollbar_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IScrollBar"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ScrollBarConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Emitted when thumb is pressed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollBarBarPressedEventArgs"/></value>
    public event EventHandler<CoreUI.UI.ScrollBarBarPressedEventArgs> BarPressedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollBarBarPressedEventArgs{ arg =  (CoreUI.UI.LayoutOrientation)info });
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESSED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESSED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event BarPressedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnBarPressedEvent(CoreUI.UI.ScrollBarBarPressedEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESSED", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Emitted when thumb is unpressed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollBarBarUnpressedEventArgs"/></value>
    public event EventHandler<CoreUI.UI.ScrollBarBarUnpressedEventArgs> BarUnpressedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollBarBarUnpressedEventArgs{ arg =  (CoreUI.UI.LayoutOrientation)info });
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESSED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESSED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event BarUnpressedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnBarUnpressedEvent(CoreUI.UI.ScrollBarBarUnpressedEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESSED", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Emitted when thumb is dragged.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollBarBarDraggedEventArgs"/></value>
    public event EventHandler<CoreUI.UI.ScrollBarBarDraggedEventArgs> BarDraggedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollBarBarDraggedEventArgs{ arg =  (CoreUI.UI.LayoutOrientation)info });
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAGGED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAGGED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event BarDraggedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnBarDraggedEvent(CoreUI.UI.ScrollBarBarDraggedEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAGGED", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Emitted when thumb size has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler BarSizeChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event BarSizeChangedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnBarSizeChangedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED", IntPtr.Zero, null);
    }

    /// <summary>Emitted when thumb position has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler BarPosChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event BarPosChangedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnBarPosChangedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED", IntPtr.Zero, null);
    }

    /// <summary>Emitted when scrollbar is shown.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollBarBarShowEventArgs"/></value>
    public event EventHandler<CoreUI.UI.ScrollBarBarShowEventArgs> BarShowEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollBarBarShowEventArgs{ arg =  (CoreUI.UI.LayoutOrientation)info });
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event BarShowEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnBarShowEvent(CoreUI.UI.ScrollBarBarShowEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW", info, (p) => Marshal.FreeHGlobal(p));
    }

    /// <summary>Emitted when scrollbar is hidden.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollBarBarHideEventArgs"/></value>
    public event EventHandler<CoreUI.UI.ScrollBarBarHideEventArgs> BarHideEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollBarBarHideEventArgs{ arg =  (CoreUI.UI.LayoutOrientation)info });
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event BarHideEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnBarHideEvent(CoreUI.UI.ScrollBarBarHideEventArgs e)
    {
        IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE", info, (p) => Marshal.FreeHGlobal(p));
    }


#pragma warning disable CS0628
    /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
    /// <param name="hbar">Horizontal scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
    /// <param name="vbar">Vertical scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
    /// <since_tizen> 6 </since_tizen>
    public void GetBarMode(out CoreUI.UI.ScrollBarMode hbar, out CoreUI.UI.ScrollBarMode vbar) {
        CoreUI.UI.ScrollBarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(this.NativeHandle, out hbar, out vbar);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
    /// <param name="hbar">Horizontal scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
    /// <param name="vbar">Vertical scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetBarMode(CoreUI.UI.ScrollBarMode hbar, CoreUI.UI.ScrollBarMode vbar) {
        CoreUI.UI.ScrollBarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(this.NativeHandle, hbar, vbar);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This returns the relative size the thumb should have, given the current size of the viewport and the content. <c>0.0</c> means the viewport is much smaller than the content: the thumb will have its minimum size. <c>1.0</c> means the viewport has the same size as the content (or bigger): the thumb will have the same size as the scrollbar and cannot move.</summary>
    /// <param name="width">Value between <c>0.0</c> and <c>1.0</c>.</param>
    /// <param name="height">Value between <c>0.0</c> and <c>1.0</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    public void GetBarSize(out double width, out double height) {
        CoreUI.UI.ScrollBarConcrete.NativeMethods.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(this.NativeHandle, out width, out height);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
    /// <param name="posx">Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</param>
    /// <param name="posy">Value between <c>0.0</c> (the top side of the thumb is touching the top edge of the widget) and <c>1.0</c> (the bottom side of the thumb is touching the bottom edge of the widget).</param>
    /// <since_tizen> 6 </since_tizen>
    public void GetBarPosition(out double posx, out double posy) {
        CoreUI.UI.ScrollBarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(this.NativeHandle, out posx, out posy);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
    /// <param name="posx">Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</param>
    /// <param name="posy">Value between <c>0.0</c> (the top side of the thumb is touching the top edge of the widget) and <c>1.0</c> (the bottom side of the thumb is touching the bottom edge of the widget).</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetBarPosition(double posx, double posy) {
        CoreUI.UI.ScrollBarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(this.NativeHandle, posx, posy);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
    /// <value>Horizontal scrollbar mode.</value>
    /// <since_tizen> 6 </since_tizen>
    public (CoreUI.UI.ScrollBarMode, CoreUI.UI.ScrollBarMode) BarMode {
        get {
            CoreUI.UI.ScrollBarMode _out_hbar = default(CoreUI.UI.ScrollBarMode);
            CoreUI.UI.ScrollBarMode _out_vbar = default(CoreUI.UI.ScrollBarMode);
            GetBarMode(out _out_hbar, out _out_vbar);
            return (_out_hbar, _out_vbar);
        }
        set { SetBarMode( value.Item1,  value.Item2); }
    }

    /// <summary>This returns the relative size the thumb should have, given the current size of the viewport and the content. <c>0.0</c> means the viewport is much smaller than the content: the thumb will have its minimum size. <c>1.0</c> means the viewport has the same size as the content (or bigger): the thumb will have the same size as the scrollbar and cannot move.</summary>
    /// <since_tizen> 6 </since_tizen>
    public (double, double) BarSize {
        get {
            double _out_width = default(double);
            double _out_height = default(double);
            GetBarSize(out _out_width, out _out_height);
            return (_out_width, _out_height);
        }
    }

    /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
    /// <value>Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</value>
    /// <since_tizen> 6 </since_tizen>
    public (double, double) BarPosition {
        get {
            double _out_posx = default(double);
            double _out_posy = default(double);
            GetBarPosition(out _out_posx, out _out_posy);
            return (_out_posx, _out_posy);
        }
        set { SetBarPosition( value.Item1,  value.Item2); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.UI.ScrollBarConcrete.efl_ui_scrollbar_interface_get();
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

            if (efl_ui_scrollbar_bar_mode_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_mode_get_static_delegate = new efl_ui_scrollbar_bar_mode_get_delegate(bar_mode_get);
            }

            if (methods.Contains("GetBarMode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_mode_set_static_delegate == null)
            {
                efl_ui_scrollbar_bar_mode_set_static_delegate = new efl_ui_scrollbar_bar_mode_set_delegate(bar_mode_set);
            }

            if (methods.Contains("SetBarMode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_set_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_size_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_size_get_static_delegate = new efl_ui_scrollbar_bar_size_get_delegate(bar_size_get);
            }

            if (methods.Contains("GetBarSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_size_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_position_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_position_get_static_delegate = new efl_ui_scrollbar_bar_position_get_delegate(bar_position_get);
            }

            if (methods.Contains("GetBarPosition"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_position_set_static_delegate == null)
            {
                efl_ui_scrollbar_bar_position_set_static_delegate = new efl_ui_scrollbar_bar_position_set_delegate(bar_position_set);
            }

            if (methods.Contains("SetBarPosition"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_set_static_delegate) });
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
            return CoreUI.UI.ScrollBarConcrete.efl_ui_scrollbar_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_scrollbar_bar_mode_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.UI.ScrollBarMode hbar,  out CoreUI.UI.ScrollBarMode vbar);

        
        internal delegate void efl_ui_scrollbar_bar_mode_get_api_delegate(System.IntPtr obj,  out CoreUI.UI.ScrollBarMode hbar,  out CoreUI.UI.ScrollBarMode vbar);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate> efl_ui_scrollbar_bar_mode_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate>(Module, "efl_ui_scrollbar_bar_mode_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_mode_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.UI.ScrollBarMode hbar, out CoreUI.UI.ScrollBarMode vbar)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_mode_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                hbar = default(CoreUI.UI.ScrollBarMode);vbar = default(CoreUI.UI.ScrollBarMode);
                try
                {
                    ((IScrollBar)ws.Target).GetBarMode(out hbar, out vbar);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out hbar, out vbar);
            }
        }

        private static efl_ui_scrollbar_bar_mode_get_delegate efl_ui_scrollbar_bar_mode_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.ScrollBarMode hbar,  CoreUI.UI.ScrollBarMode vbar);

        
        internal delegate void efl_ui_scrollbar_bar_mode_set_api_delegate(System.IntPtr obj,  CoreUI.UI.ScrollBarMode hbar,  CoreUI.UI.ScrollBarMode vbar);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate> efl_ui_scrollbar_bar_mode_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate>(Module, "efl_ui_scrollbar_bar_mode_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_mode_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.ScrollBarMode hbar, CoreUI.UI.ScrollBarMode vbar)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_mode_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollBar)ws.Target).SetBarMode(hbar, vbar);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), hbar, vbar);
            }
        }

        private static efl_ui_scrollbar_bar_mode_set_delegate efl_ui_scrollbar_bar_mode_set_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_size_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double width,  out double height);

        
        internal delegate void efl_ui_scrollbar_bar_size_get_api_delegate(System.IntPtr obj,  out double width,  out double height);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate> efl_ui_scrollbar_bar_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate>(Module, "efl_ui_scrollbar_bar_size_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_size_get(System.IntPtr obj, System.IntPtr pd, out double width, out double height)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_size_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                width = default(double);height = default(double);
                try
                {
                    ((IScrollBar)ws.Target).GetBarSize(out width, out height);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out width, out height);
            }
        }

        private static efl_ui_scrollbar_bar_size_get_delegate efl_ui_scrollbar_bar_size_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_position_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double posx,  out double posy);

        
        internal delegate void efl_ui_scrollbar_bar_position_get_api_delegate(System.IntPtr obj,  out double posx,  out double posy);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate> efl_ui_scrollbar_bar_position_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate>(Module, "efl_ui_scrollbar_bar_position_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_position_get(System.IntPtr obj, System.IntPtr pd, out double posx, out double posy)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_position_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                posx = default(double);posy = default(double);
                try
                {
                    ((IScrollBar)ws.Target).GetBarPosition(out posx, out posy);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out posx, out posy);
            }
        }

        private static efl_ui_scrollbar_bar_position_get_delegate efl_ui_scrollbar_bar_position_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  double posx,  double posy);

        
        internal delegate void efl_ui_scrollbar_bar_position_set_api_delegate(System.IntPtr obj,  double posx,  double posy);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate> efl_ui_scrollbar_bar_position_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate>(Module, "efl_ui_scrollbar_bar_position_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_position_set(System.IntPtr obj, System.IntPtr pd, double posx, double posy)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_position_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollBar)ws.Target).SetBarPosition(posx, posy);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), posx, posy);
            }
        }

        private static efl_ui_scrollbar_bar_position_set_delegate efl_ui_scrollbar_bar_position_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.UI {
/// <summary>When should the scrollbar be shown.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public enum ScrollBarMode
{
/// <summary>Visible if necessary.</summary>
/// <since_tizen> 6 </since_tizen>
Auto = 0,
/// <summary>Always visible.</summary>
/// <since_tizen> 6 </since_tizen>
On = 1,
/// <summary>Always invisible.</summary>
/// <since_tizen> 6 </since_tizen>
Off = 2,
/// <summary>For internal use only.</summary>
/// <since_tizen> 6 </since_tizen>
Last = 3,
}
}

