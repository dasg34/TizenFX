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
/// <summary>Interface for widgets capable of displaying content through a viewport, which might be smaller than the actual content. This interface does not control how the content is added. This is typically done through <see cref="CoreUI.IContent"/>.
/// 
/// When the content does not fit inside the viewport, typically <see cref="CoreUI.UI.IScrollBar"/> widgets will be used, but this is beyond the scope of this interface.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.UI.ScrollableConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IScrollable : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Position of the content inside the scroller.</summary>
    /// <returns>The position is a virtual value, where <c>0,0</c> means the top-left corner.</returns>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.DataTypes.Position2D GetContentPos();

    /// <summary>Position of the content inside the scroller.</summary>
    /// <param name="pos">The position is a virtual value, where <c>0,0</c> means the top-left corner.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetContentPos(CoreUI.DataTypes.Position2D pos);

    /// <summary>Current size of the content, for convenience.</summary>
    /// <returns>The content size in pixels.</returns>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.DataTypes.Size2D GetContentSize();

    /// <summary>Current position and size of the viewport (or scroller window), for convenience.
    /// 
    /// This is the viewport through which the content is displayed.</summary>
    /// <returns>It is absolute geometry.</returns>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.DataTypes.Rect GetViewportGeometry();

    /// <summary>When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This property determines if bouncing is enabled in each axis. When bouncing is disabled, scrolling just stops upon reaching the end of the content.</summary>
    /// <param name="horiz">Horizontal bouncing is enabled.</param>
    /// <param name="vert">Vertical bouncing is enabled.</param>
    /// <since_tizen> 6 </since_tizen>
    void GetBounceEnabled(out bool horiz, out bool vert);

    /// <summary>When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This property determines if bouncing is enabled in each axis. When bouncing is disabled, scrolling just stops upon reaching the end of the content.</summary>
    /// <param name="horiz">Horizontal bouncing is enabled.</param>
    /// <param name="vert">Vertical bouncing is enabled.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetBounceEnabled(bool horiz, bool vert);

    /// <summary>Freezes scrolling movement (by input of a user). Unlike <see cref="CoreUI.UI.IScrollable.MovementBlock"/>, this property freezes bidirectionally. If you want to freeze in only one direction, see <see cref="CoreUI.UI.IScrollable.MovementBlock"/>.</summary>
    /// <returns><c>true</c> if freeze.</returns>
    /// <since_tizen> 6 </since_tizen>
    bool GetScrollFreeze();

    /// <summary>Freezes scrolling movement (by input of a user). Unlike <see cref="CoreUI.UI.IScrollable.MovementBlock"/>, this property freezes bidirectionally. If you want to freeze in only one direction, see <see cref="CoreUI.UI.IScrollable.MovementBlock"/>.</summary>
    /// <param name="freeze"><c>true</c> if freeze.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetScrollFreeze(bool freeze);

    /// <summary>When hold turns on, it only scrolls by holding action.</summary>
    /// <returns><c>true</c> if hold.</returns>
    /// <since_tizen> 6 </since_tizen>
    bool GetScrollHold();

    /// <summary>When hold turns on, it only scrolls by holding action.</summary>
    /// <param name="hold"><c>true</c> if hold.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetScrollHold(bool hold);

    /// <summary>Controls infinite looping for a scroller.</summary>
    /// <param name="loop_h">Scroll horizontal looping is enabled.</param>
    /// <param name="loop_v">Scroll vertical looping is enabled.</param>
    /// <since_tizen> 6 </since_tizen>
    void GetLooping(out bool loop_h, out bool loop_v);

    /// <summary>Controls infinite looping for a scroller.</summary>
    /// <param name="loop_h">Scroll horizontal looping is enabled.</param>
    /// <param name="loop_v">Scroll vertical looping is enabled.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetLooping(bool loop_h, bool loop_v);

    /// <summary>Blocking of scrolling (per axis).
    /// 
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
    /// <returns>Which axis (or axes) to block.</returns>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.UI.LayoutOrientation GetMovementBlock();

    /// <summary>Blocking of scrolling (per axis).
    /// 
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
    /// <param name="block">Which axis (or axes) to block.<br/>The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/>.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetMovementBlock(CoreUI.UI.LayoutOrientation block);

    /// <summary>Control scrolling gravity on the scrollable.
    /// 
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
    /// <param name="x">Horizontal scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    /// <param name="y">Vertical scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    void GetGravity(out double x, out double y);

    /// <summary>Control scrolling gravity on the scrollable.
    /// 
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
    /// <param name="x">Horizontal scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    /// <param name="y">Vertical scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetGravity(double x, double y);

    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// 
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <param name="w">Whether to limit the minimum horizontal size.</param>
    /// <param name="h">Whether to limit the minimum vertical size.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetMatchContent(bool w, bool h);

    /// <summary>Amount to scroll in response to cursor key presses.</summary>
    /// <returns>The step size in pixels.</returns>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.DataTypes.Position2D GetStepSize();

    /// <summary>Amount to scroll in response to cursor key presses.</summary>
    /// <param name="step">The step size in pixels.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetStepSize(CoreUI.DataTypes.Position2D step);

    /// <summary>Show a specific virtual region within the scroller content object.
    /// 
    /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (<c>0,0</c> starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="rect">The position where to scroll and the size user want to see.</param>
    /// <param name="animation">Whether to scroll with animation or not.</param>
    void Scroll(CoreUI.DataTypes.Rect rect, bool animation);

    /// <summary>Called when scroll operation starts.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollStartedEvent;
    /// <summary>Called when scrolling.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollChangedEvent;
    /// <summary>Called when scroll operation finishes.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollFinishedEvent;
    /// <summary>Called when scrolling upwards.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollUpEvent;
    /// <summary>Called when scrolling downwards.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollDownEvent;
    /// <summary>Called when scrolling left.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollLeftEvent;
    /// <summary>Called when scrolling right.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollRightEvent;
    /// <summary>Called when hitting the top edge.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler EdgeUpEvent;
    /// <summary>Called when hitting the bottom edge.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler EdgeDownEvent;
    /// <summary>Called when hitting the left edge.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler EdgeLeftEvent;
    /// <summary>Called when hitting the right edge.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler EdgeRightEvent;
    /// <summary>Called when scroll animation starts.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollAnimStartedEvent;
    /// <summary>Called when scroll animation finishes.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollAnimFinishedEvent;
    /// <summary>Called when scroll drag starts.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollDragStartedEvent;
    /// <summary>Called when scroll drag finishes.</summary>
    /// <since_tizen> 6 </since_tizen>
    event EventHandler ScrollDragFinishedEvent;
    /// <summary>Called when scroll destination is finalized.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs"/></value>
    event EventHandler<CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs> ScrollDestinationFinalizedEvent;
    /// <summary>Position of the content inside the scroller.</summary>
    /// <value>The position is a virtual value, where <c>0,0</c> means the top-left corner.</value>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.DataTypes.Position2D ContentPos {
        get;
        set;
    }

    /// <summary>Current size of the content, for convenience.</summary>
    /// <value>The content size in pixels.</value>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.DataTypes.Size2D ContentSize {
        get;
    }

    /// <summary>Current position and size of the viewport (or scroller window), for convenience.
    /// 
    /// This is the viewport through which the content is displayed.</summary>
    /// <value>It is absolute geometry.</value>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.DataTypes.Rect ViewportGeometry {
        get;
    }

    /// <summary>When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This property determines if bouncing is enabled in each axis. When bouncing is disabled, scrolling just stops upon reaching the end of the content.</summary>
    /// <value>Horizontal bouncing is enabled.</value>
    /// <since_tizen> 6 </since_tizen>
    (bool, bool) BounceEnabled {
        get;
        set;
    }

    /// <summary>Freezes scrolling movement (by input of a user). Unlike <see cref="CoreUI.UI.IScrollable.MovementBlock"/>, this property freezes bidirectionally. If you want to freeze in only one direction, see <see cref="CoreUI.UI.IScrollable.MovementBlock"/>.</summary>
    /// <value><c>true</c> if freeze.</value>
    /// <since_tizen> 6 </since_tizen>
    bool ScrollFreeze {
        get;
        set;
    }

    /// <summary>When hold turns on, it only scrolls by holding action.</summary>
    /// <value><c>true</c> if hold.</value>
    /// <since_tizen> 6 </since_tizen>
    bool ScrollHold {
        get;
        set;
    }

    /// <summary>Controls infinite looping for a scroller.</summary>
    /// <value>Scroll horizontal looping is enabled.</value>
    /// <since_tizen> 6 </since_tizen>
    (bool, bool) Looping {
        get;
        set;
    }

    /// <summary>Blocking of scrolling (per axis).
    /// 
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
    /// <value>Which axis (or axes) to block.</value>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.UI.LayoutOrientation MovementBlock {
        get;
        set;
    }

    /// <summary>Control scrolling gravity on the scrollable.
    /// 
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
    /// <value>Horizontal scrolling gravity.</value>
    /// <since_tizen> 6 </since_tizen>
    (double, double) Gravity {
        get;
        set;
    }

    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// 
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <value>Whether to limit the minimum horizontal size.</value>
    /// <since_tizen> 6 </since_tizen>
    (bool, bool) MatchContent {
        set;
    }

    /// <summary>Amount to scroll in response to cursor key presses.</summary>
    /// <value>The step size in pixels.</value>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.DataTypes.Position2D StepSize {
        get;
        set;
    }

}

/// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollable.ScrollDestinationFinalizedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ScrollableScrollDestinationFinalizedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Called when scroll destination is finalized.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Position2D arg { get; set; }
}

/// <summary>Interface for widgets capable of displaying content through a viewport, which might be smaller than the actual content. This interface does not control how the content is added. This is typically done through <see cref="CoreUI.IContent"/>.
/// 
/// When the content does not fit inside the viewport, typically <see cref="CoreUI.UI.IScrollBar"/> widgets will be used, but this is beyond the scope of this interface.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ScrollableConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IScrollable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ScrollableConcrete))
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
    private ScrollableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_scrollable_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IScrollable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ScrollableConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when scroll operation starts.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollStartedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_STARTED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_STARTED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollStartedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollStartedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_STARTED", IntPtr.Zero, null);
    }

    /// <summary>Called when scrolling.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollChangedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollChangedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_CHANGED", IntPtr.Zero, null);
    }

    /// <summary>Called when scroll operation finishes.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollFinishedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_FINISHED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_FINISHED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollFinishedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollFinishedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_FINISHED", IntPtr.Zero, null);
    }

    /// <summary>Called when scrolling upwards.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollUpEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_UP";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_UP";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollUpEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollUpEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_UP", IntPtr.Zero, null);
    }

    /// <summary>Called when scrolling downwards.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollDownEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_DOWN";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_DOWN";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollDownEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollDownEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_DOWN", IntPtr.Zero, null);
    }

    /// <summary>Called when scrolling left.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollLeftEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_LEFT";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_LEFT";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollLeftEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollLeftEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_LEFT", IntPtr.Zero, null);
    }

    /// <summary>Called when scrolling right.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollRightEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollRightEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollRightEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_RIGHT", IntPtr.Zero, null);
    }

    /// <summary>Called when hitting the top edge.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler EdgeUpEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_EDGE_UP";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_EDGE_UP";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event EdgeUpEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnEdgeUpEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_EDGE_UP", IntPtr.Zero, null);
    }

    /// <summary>Called when hitting the bottom edge.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler EdgeDownEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_EDGE_DOWN";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_EDGE_DOWN";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event EdgeDownEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnEdgeDownEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_EDGE_DOWN", IntPtr.Zero, null);
    }

    /// <summary>Called when hitting the left edge.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler EdgeLeftEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_EDGE_LEFT";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_EDGE_LEFT";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event EdgeLeftEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnEdgeLeftEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_EDGE_LEFT", IntPtr.Zero, null);
    }

    /// <summary>Called when hitting the right edge.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler EdgeRightEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_EDGE_RIGHT";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_EDGE_RIGHT";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event EdgeRightEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnEdgeRightEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_EDGE_RIGHT", IntPtr.Zero, null);
    }

    /// <summary>Called when scroll animation starts.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollAnimStartedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_ANIM_STARTED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_ANIM_STARTED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollAnimStartedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollAnimStartedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_ANIM_STARTED", IntPtr.Zero, null);
    }

    /// <summary>Called when scroll animation finishes.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollAnimFinishedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollAnimFinishedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollAnimFinishedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED", IntPtr.Zero, null);
    }

    /// <summary>Called when scroll drag starts.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollDragStartedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_DRAG_STARTED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_DRAG_STARTED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollDragStartedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollDragStartedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_DRAG_STARTED", IntPtr.Zero, null);
    }

    /// <summary>Called when scroll drag finishes.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ScrollDragFinishedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value);
            string key = "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollDragFinishedEvent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollDragFinishedEvent()
    {
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED", IntPtr.Zero, null);
    }

    /// <summary>Called when scroll destination is finalized.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs"/></value>
    public event EventHandler<CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs> ScrollDestinationFinalizedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs{ arg =  info });
            string key = "_EFL_UI_EVENT_SCROLL_DESTINATION_FINALIZED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_UI_EVENT_SCROLL_DESTINATION_FINALIZED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ScrollDestinationFinalizedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnScrollDestinationFinalizedEvent(CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs e)
    {
        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_UI_EVENT_SCROLL_DESTINATION_FINALIZED", info, (p) => Marshal.FreeHGlobal(p));
    }


#pragma warning disable CS0628
    /// <summary>Position of the content inside the scroller.</summary>
    /// <returns>The position is a virtual value, where <c>0,0</c> means the top-left corner.</returns>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Position2D GetContentPos() {
        var _ret_var = CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_content_pos_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Position of the content inside the scroller.</summary>
    /// <param name="pos">The position is a virtual value, where <c>0,0</c> means the top-left corner.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetContentPos(CoreUI.DataTypes.Position2D pos) {
        CoreUI.DataTypes.Position2D.NativeStruct _in_pos = pos;
CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_content_pos_set_ptr.Value.Delegate(this.NativeHandle, _in_pos);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Current size of the content, for convenience.</summary>
    /// <returns>The content size in pixels.</returns>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Size2D GetContentSize() {
        var _ret_var = CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_content_size_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Current position and size of the viewport (or scroller window), for convenience.
    /// 
    /// This is the viewport through which the content is displayed.</summary>
    /// <returns>It is absolute geometry.</returns>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Rect GetViewportGeometry() {
        var _ret_var = CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This property determines if bouncing is enabled in each axis. When bouncing is disabled, scrolling just stops upon reaching the end of the content.</summary>
    /// <param name="horiz">Horizontal bouncing is enabled.</param>
    /// <param name="vert">Vertical bouncing is enabled.</param>
    /// <since_tizen> 6 </since_tizen>
    public void GetBounceEnabled(out bool horiz, out bool vert) {
        CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate(this.NativeHandle, out horiz, out vert);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This property determines if bouncing is enabled in each axis. When bouncing is disabled, scrolling just stops upon reaching the end of the content.</summary>
    /// <param name="horiz">Horizontal bouncing is enabled.</param>
    /// <param name="vert">Vertical bouncing is enabled.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetBounceEnabled(bool horiz, bool vert) {
        CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate(this.NativeHandle, horiz, vert);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Freezes scrolling movement (by input of a user). Unlike <see cref="CoreUI.UI.IScrollable.MovementBlock"/>, this property freezes bidirectionally. If you want to freeze in only one direction, see <see cref="CoreUI.UI.IScrollable.MovementBlock"/>.</summary>
    /// <returns><c>true</c> if freeze.</returns>
    /// <since_tizen> 6 </since_tizen>
    public bool GetScrollFreeze() {
        var _ret_var = CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Freezes scrolling movement (by input of a user). Unlike <see cref="CoreUI.UI.IScrollable.MovementBlock"/>, this property freezes bidirectionally. If you want to freeze in only one direction, see <see cref="CoreUI.UI.IScrollable.MovementBlock"/>.</summary>
    /// <param name="freeze"><c>true</c> if freeze.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetScrollFreeze(bool freeze) {
        CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate(this.NativeHandle, freeze);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>When hold turns on, it only scrolls by holding action.</summary>
    /// <returns><c>true</c> if hold.</returns>
    /// <since_tizen> 6 </since_tizen>
    public bool GetScrollHold() {
        var _ret_var = CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>When hold turns on, it only scrolls by holding action.</summary>
    /// <param name="hold"><c>true</c> if hold.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetScrollHold(bool hold) {
        CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate(this.NativeHandle, hold);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Controls infinite looping for a scroller.</summary>
    /// <param name="loop_h">Scroll horizontal looping is enabled.</param>
    /// <param name="loop_v">Scroll vertical looping is enabled.</param>
    /// <since_tizen> 6 </since_tizen>
    public void GetLooping(out bool loop_h, out bool loop_v) {
        CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_looping_get_ptr.Value.Delegate(this.NativeHandle, out loop_h, out loop_v);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Controls infinite looping for a scroller.</summary>
    /// <param name="loop_h">Scroll horizontal looping is enabled.</param>
    /// <param name="loop_v">Scroll vertical looping is enabled.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetLooping(bool loop_h, bool loop_v) {
        CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_looping_set_ptr.Value.Delegate(this.NativeHandle, loop_h, loop_v);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Blocking of scrolling (per axis).
    /// 
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
    /// <returns>Which axis (or axes) to block.</returns>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.LayoutOrientation GetMovementBlock() {
        var _ret_var = CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_movement_block_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Blocking of scrolling (per axis).
    /// 
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
    /// <param name="block">Which axis (or axes) to block.<br/>The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/>.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetMovementBlock(CoreUI.UI.LayoutOrientation block) {
        CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_movement_block_set_ptr.Value.Delegate(this.NativeHandle, block);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control scrolling gravity on the scrollable.
    /// 
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
    /// <param name="x">Horizontal scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    /// <param name="y">Vertical scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    public void GetGravity(out double x, out double y) {
        CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_gravity_get_ptr.Value.Delegate(this.NativeHandle, out x, out y);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control scrolling gravity on the scrollable.
    /// 
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
    /// <param name="x">Horizontal scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    /// <param name="y">Vertical scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetGravity(double x, double y) {
        CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_gravity_set_ptr.Value.Delegate(this.NativeHandle, x, y);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// 
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <param name="w">Whether to limit the minimum horizontal size.</param>
    /// <param name="h">Whether to limit the minimum vertical size.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetMatchContent(bool w, bool h) {
        CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_match_content_set_ptr.Value.Delegate(this.NativeHandle, w, h);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Amount to scroll in response to cursor key presses.</summary>
    /// <returns>The step size in pixels.</returns>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Position2D GetStepSize() {
        var _ret_var = CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_step_size_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Amount to scroll in response to cursor key presses.</summary>
    /// <param name="step">The step size in pixels.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetStepSize(CoreUI.DataTypes.Position2D step) {
        CoreUI.DataTypes.Position2D.NativeStruct _in_step = step;
CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_step_size_set_ptr.Value.Delegate(this.NativeHandle, _in_step);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Show a specific virtual region within the scroller content object.
    /// 
    /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (<c>0,0</c> starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="rect">The position where to scroll and the size user want to see.</param>
    /// <param name="animation">Whether to scroll with animation or not.</param>
    public void Scroll(CoreUI.DataTypes.Rect rect, bool animation) {
        CoreUI.DataTypes.Rect.NativeStruct _in_rect = rect;
CoreUI.UI.ScrollableConcrete.NativeMethods.efl_ui_scrollable_scroll_ptr.Value.Delegate(this.NativeHandle, _in_rect, animation);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position of the content inside the scroller.</summary>
    /// <value>The position is a virtual value, where <c>0,0</c> means the top-left corner.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Position2D ContentPos {
        get { return GetContentPos(); }
        set { SetContentPos(value); }
    }

    /// <summary>Current size of the content, for convenience.</summary>
    /// <value>The content size in pixels.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Size2D ContentSize {
        get { return GetContentSize(); }
    }

    /// <summary>Current position and size of the viewport (or scroller window), for convenience.
    /// 
    /// This is the viewport through which the content is displayed.</summary>
    /// <value>It is absolute geometry.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Rect ViewportGeometry {
        get { return GetViewportGeometry(); }
    }

    /// <summary>When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This property determines if bouncing is enabled in each axis. When bouncing is disabled, scrolling just stops upon reaching the end of the content.</summary>
    /// <value>Horizontal bouncing is enabled.</value>
    /// <since_tizen> 6 </since_tizen>
    public (bool, bool) BounceEnabled {
        get {
            bool _out_horiz = default(bool);
            bool _out_vert = default(bool);
            GetBounceEnabled(out _out_horiz, out _out_vert);
            return (_out_horiz, _out_vert);
        }
        set { SetBounceEnabled( value.Item1,  value.Item2); }
    }

    /// <summary>Freezes scrolling movement (by input of a user). Unlike <see cref="CoreUI.UI.IScrollable.MovementBlock"/>, this property freezes bidirectionally. If you want to freeze in only one direction, see <see cref="CoreUI.UI.IScrollable.MovementBlock"/>.</summary>
    /// <value><c>true</c> if freeze.</value>
    /// <since_tizen> 6 </since_tizen>
    public bool ScrollFreeze {
        get { return GetScrollFreeze(); }
        set { SetScrollFreeze(value); }
    }

    /// <summary>When hold turns on, it only scrolls by holding action.</summary>
    /// <value><c>true</c> if hold.</value>
    /// <since_tizen> 6 </since_tizen>
    public bool ScrollHold {
        get { return GetScrollHold(); }
        set { SetScrollHold(value); }
    }

    /// <summary>Controls infinite looping for a scroller.</summary>
    /// <value>Scroll horizontal looping is enabled.</value>
    /// <since_tizen> 6 </since_tizen>
    public (bool, bool) Looping {
        get {
            bool _out_loop_h = default(bool);
            bool _out_loop_v = default(bool);
            GetLooping(out _out_loop_h, out _out_loop_v);
            return (_out_loop_h, _out_loop_v);
        }
        set { SetLooping( value.Item1,  value.Item2); }
    }

    /// <summary>Blocking of scrolling (per axis).
    /// 
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
    /// <value>Which axis (or axes) to block.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.LayoutOrientation MovementBlock {
        get { return GetMovementBlock(); }
        set { SetMovementBlock(value); }
    }

    /// <summary>Control scrolling gravity on the scrollable.
    /// 
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
    /// <value>Horizontal scrolling gravity.</value>
    /// <since_tizen> 6 </since_tizen>
    public (double, double) Gravity {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetGravity(out _out_x, out _out_y);
            return (_out_x, _out_y);
        }
        set { SetGravity( value.Item1,  value.Item2); }
    }

    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// 
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <value>Whether to limit the minimum horizontal size.</value>
    /// <since_tizen> 6 </since_tizen>
    public (bool, bool) MatchContent {
        set { SetMatchContent( value.Item1,  value.Item2); }
    }

    /// <summary>Amount to scroll in response to cursor key presses.</summary>
    /// <value>The step size in pixels.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.DataTypes.Position2D StepSize {
        get { return GetStepSize(); }
        set { SetStepSize(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.UI.ScrollableConcrete.efl_ui_scrollable_interface_get();
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

            if (efl_ui_scrollable_content_pos_get_static_delegate == null)
            {
                efl_ui_scrollable_content_pos_get_static_delegate = new efl_ui_scrollable_content_pos_get_delegate(content_pos_get);
            }

            if (methods.Contains("GetContentPos"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_content_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_get_static_delegate) });
            }

            if (efl_ui_scrollable_content_pos_set_static_delegate == null)
            {
                efl_ui_scrollable_content_pos_set_static_delegate = new efl_ui_scrollable_content_pos_set_delegate(content_pos_set);
            }

            if (methods.Contains("SetContentPos"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_content_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_set_static_delegate) });
            }

            if (efl_ui_scrollable_content_size_get_static_delegate == null)
            {
                efl_ui_scrollable_content_size_get_static_delegate = new efl_ui_scrollable_content_size_get_delegate(content_size_get);
            }

            if (methods.Contains("GetContentSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_content_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_size_get_static_delegate) });
            }

            if (efl_ui_scrollable_viewport_geometry_get_static_delegate == null)
            {
                efl_ui_scrollable_viewport_geometry_get_static_delegate = new efl_ui_scrollable_viewport_geometry_get_delegate(viewport_geometry_get);
            }

            if (methods.Contains("GetViewportGeometry"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_viewport_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_viewport_geometry_get_static_delegate) });
            }

            if (efl_ui_scrollable_bounce_enabled_get_static_delegate == null)
            {
                efl_ui_scrollable_bounce_enabled_get_static_delegate = new efl_ui_scrollable_bounce_enabled_get_delegate(bounce_enabled_get);
            }

            if (methods.Contains("GetBounceEnabled"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_bounce_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_get_static_delegate) });
            }

            if (efl_ui_scrollable_bounce_enabled_set_static_delegate == null)
            {
                efl_ui_scrollable_bounce_enabled_set_static_delegate = new efl_ui_scrollable_bounce_enabled_set_delegate(bounce_enabled_set);
            }

            if (methods.Contains("SetBounceEnabled"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_bounce_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_set_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_freeze_get_static_delegate == null)
            {
                efl_ui_scrollable_scroll_freeze_get_static_delegate = new efl_ui_scrollable_scroll_freeze_get_delegate(scroll_freeze_get);
            }

            if (methods.Contains("GetScrollFreeze"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_freeze_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_get_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_freeze_set_static_delegate == null)
            {
                efl_ui_scrollable_scroll_freeze_set_static_delegate = new efl_ui_scrollable_scroll_freeze_set_delegate(scroll_freeze_set);
            }

            if (methods.Contains("SetScrollFreeze"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_freeze_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_set_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_hold_get_static_delegate == null)
            {
                efl_ui_scrollable_scroll_hold_get_static_delegate = new efl_ui_scrollable_scroll_hold_get_delegate(scroll_hold_get);
            }

            if (methods.Contains("GetScrollHold"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_hold_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_get_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_hold_set_static_delegate == null)
            {
                efl_ui_scrollable_scroll_hold_set_static_delegate = new efl_ui_scrollable_scroll_hold_set_delegate(scroll_hold_set);
            }

            if (methods.Contains("SetScrollHold"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_hold_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_set_static_delegate) });
            }

            if (efl_ui_scrollable_looping_get_static_delegate == null)
            {
                efl_ui_scrollable_looping_get_static_delegate = new efl_ui_scrollable_looping_get_delegate(looping_get);
            }

            if (methods.Contains("GetLooping"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_looping_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_get_static_delegate) });
            }

            if (efl_ui_scrollable_looping_set_static_delegate == null)
            {
                efl_ui_scrollable_looping_set_static_delegate = new efl_ui_scrollable_looping_set_delegate(looping_set);
            }

            if (methods.Contains("SetLooping"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_looping_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_set_static_delegate) });
            }

            if (efl_ui_scrollable_movement_block_get_static_delegate == null)
            {
                efl_ui_scrollable_movement_block_get_static_delegate = new efl_ui_scrollable_movement_block_get_delegate(movement_block_get);
            }

            if (methods.Contains("GetMovementBlock"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_movement_block_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_get_static_delegate) });
            }

            if (efl_ui_scrollable_movement_block_set_static_delegate == null)
            {
                efl_ui_scrollable_movement_block_set_static_delegate = new efl_ui_scrollable_movement_block_set_delegate(movement_block_set);
            }

            if (methods.Contains("SetMovementBlock"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_movement_block_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_set_static_delegate) });
            }

            if (efl_ui_scrollable_gravity_get_static_delegate == null)
            {
                efl_ui_scrollable_gravity_get_static_delegate = new efl_ui_scrollable_gravity_get_delegate(gravity_get);
            }

            if (methods.Contains("GetGravity"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_gravity_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_get_static_delegate) });
            }

            if (efl_ui_scrollable_gravity_set_static_delegate == null)
            {
                efl_ui_scrollable_gravity_set_static_delegate = new efl_ui_scrollable_gravity_set_delegate(gravity_set);
            }

            if (methods.Contains("SetGravity"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_gravity_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_set_static_delegate) });
            }

            if (efl_ui_scrollable_match_content_set_static_delegate == null)
            {
                efl_ui_scrollable_match_content_set_static_delegate = new efl_ui_scrollable_match_content_set_delegate(match_content_set);
            }

            if (methods.Contains("SetMatchContent"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_match_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_match_content_set_static_delegate) });
            }

            if (efl_ui_scrollable_step_size_get_static_delegate == null)
            {
                efl_ui_scrollable_step_size_get_static_delegate = new efl_ui_scrollable_step_size_get_delegate(step_size_get);
            }

            if (methods.Contains("GetStepSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_step_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_get_static_delegate) });
            }

            if (efl_ui_scrollable_step_size_set_static_delegate == null)
            {
                efl_ui_scrollable_step_size_set_static_delegate = new efl_ui_scrollable_step_size_set_delegate(step_size_set);
            }

            if (methods.Contains("SetStepSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_step_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_set_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_static_delegate == null)
            {
                efl_ui_scrollable_scroll_static_delegate = new efl_ui_scrollable_scroll_delegate(scroll);
            }

            if (methods.Contains("Scroll"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_static_delegate) });
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
            return CoreUI.UI.ScrollableConcrete.efl_ui_scrollable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.DataTypes.Position2D.NativeStruct efl_ui_scrollable_content_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Position2D.NativeStruct efl_ui_scrollable_content_pos_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate> efl_ui_scrollable_content_pos_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate>(Module, "efl_ui_scrollable_content_pos_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Position2D.NativeStruct content_pos_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_content_pos_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Position2D _ret_var = default(CoreUI.DataTypes.Position2D);
                try
                {
                    _ret_var = ((IScrollable)ws.Target).GetContentPos();
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
                return efl_ui_scrollable_content_pos_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_scrollable_content_pos_get_delegate efl_ui_scrollable_content_pos_get_static_delegate;

        
        private delegate void efl_ui_scrollable_content_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D.NativeStruct pos);

        
        internal delegate void efl_ui_scrollable_content_pos_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D.NativeStruct pos);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate> efl_ui_scrollable_content_pos_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate>(Module, "efl_ui_scrollable_content_pos_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void content_pos_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D.NativeStruct pos)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_content_pos_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Position2D _in_pos = pos;

                try
                {
                    ((IScrollable)ws.Target).SetContentPos(_in_pos);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_content_pos_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pos);
            }
        }

        private static efl_ui_scrollable_content_pos_set_delegate efl_ui_scrollable_content_pos_set_static_delegate;

        
        private delegate CoreUI.DataTypes.Size2D.NativeStruct efl_ui_scrollable_content_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D.NativeStruct efl_ui_scrollable_content_size_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate> efl_ui_scrollable_content_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate>(Module, "efl_ui_scrollable_content_size_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D.NativeStruct content_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_content_size_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IScrollable)ws.Target).GetContentSize();
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
                return efl_ui_scrollable_content_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_scrollable_content_size_get_delegate efl_ui_scrollable_content_size_get_static_delegate;

        
        private delegate CoreUI.DataTypes.Rect.NativeStruct efl_ui_scrollable_viewport_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Rect.NativeStruct efl_ui_scrollable_viewport_geometry_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate> efl_ui_scrollable_viewport_geometry_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate>(Module, "efl_ui_scrollable_viewport_geometry_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Rect.NativeStruct viewport_geometry_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_viewport_geometry_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _ret_var = default(CoreUI.DataTypes.Rect);
                try
                {
                    _ret_var = ((IScrollable)ws.Target).GetViewportGeometry();
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
                return efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_scrollable_viewport_geometry_get_delegate efl_ui_scrollable_viewport_geometry_get_static_delegate;

        
        private delegate void efl_ui_scrollable_bounce_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool horiz, [MarshalAs(UnmanagedType.U1)] out bool vert);

        
        internal delegate void efl_ui_scrollable_bounce_enabled_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool horiz, [MarshalAs(UnmanagedType.U1)] out bool vert);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate> efl_ui_scrollable_bounce_enabled_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate>(Module, "efl_ui_scrollable_bounce_enabled_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bounce_enabled_get(System.IntPtr obj, System.IntPtr pd, out bool horiz, out bool vert)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_bounce_enabled_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                horiz = default(bool);vert = default(bool);
                try
                {
                    ((IScrollable)ws.Target).GetBounceEnabled(out horiz, out vert);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out horiz, out vert);
            }
        }

        private static efl_ui_scrollable_bounce_enabled_get_delegate efl_ui_scrollable_bounce_enabled_get_static_delegate;

        
        private delegate void efl_ui_scrollable_bounce_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool horiz, [MarshalAs(UnmanagedType.U1)] bool vert);

        
        internal delegate void efl_ui_scrollable_bounce_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool horiz, [MarshalAs(UnmanagedType.U1)] bool vert);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate> efl_ui_scrollable_bounce_enabled_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate>(Module, "efl_ui_scrollable_bounce_enabled_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bounce_enabled_set(System.IntPtr obj, System.IntPtr pd, bool horiz, bool vert)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_bounce_enabled_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollable)ws.Target).SetBounceEnabled(horiz, vert);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), horiz, vert);
            }
        }

        private static efl_ui_scrollable_bounce_enabled_set_delegate efl_ui_scrollable_bounce_enabled_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_scrollable_scroll_freeze_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_ui_scrollable_scroll_freeze_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate> efl_ui_scrollable_scroll_freeze_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate>(Module, "efl_ui_scrollable_scroll_freeze_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool scroll_freeze_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_scroll_freeze_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IScrollable)ws.Target).GetScrollFreeze();
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
                return efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_scrollable_scroll_freeze_get_delegate efl_ui_scrollable_scroll_freeze_get_static_delegate;

        
        private delegate void efl_ui_scrollable_scroll_freeze_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool freeze);

        
        internal delegate void efl_ui_scrollable_scroll_freeze_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool freeze);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate> efl_ui_scrollable_scroll_freeze_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate>(Module, "efl_ui_scrollable_scroll_freeze_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void scroll_freeze_set(System.IntPtr obj, System.IntPtr pd, bool freeze)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_scroll_freeze_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollable)ws.Target).SetScrollFreeze(freeze);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), freeze);
            }
        }

        private static efl_ui_scrollable_scroll_freeze_set_delegate efl_ui_scrollable_scroll_freeze_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_scrollable_scroll_hold_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_ui_scrollable_scroll_hold_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate> efl_ui_scrollable_scroll_hold_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate>(Module, "efl_ui_scrollable_scroll_hold_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool scroll_hold_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_scroll_hold_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IScrollable)ws.Target).GetScrollHold();
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
                return efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_scrollable_scroll_hold_get_delegate efl_ui_scrollable_scroll_hold_get_static_delegate;

        
        private delegate void efl_ui_scrollable_scroll_hold_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool hold);

        
        internal delegate void efl_ui_scrollable_scroll_hold_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool hold);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate> efl_ui_scrollable_scroll_hold_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate>(Module, "efl_ui_scrollable_scroll_hold_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void scroll_hold_set(System.IntPtr obj, System.IntPtr pd, bool hold)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_scroll_hold_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollable)ws.Target).SetScrollHold(hold);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), hold);
            }
        }

        private static efl_ui_scrollable_scroll_hold_set_delegate efl_ui_scrollable_scroll_hold_set_static_delegate;

        
        private delegate void efl_ui_scrollable_looping_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool loop_h, [MarshalAs(UnmanagedType.U1)] out bool loop_v);

        
        internal delegate void efl_ui_scrollable_looping_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool loop_h, [MarshalAs(UnmanagedType.U1)] out bool loop_v);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate> efl_ui_scrollable_looping_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate>(Module, "efl_ui_scrollable_looping_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void looping_get(System.IntPtr obj, System.IntPtr pd, out bool loop_h, out bool loop_v)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_looping_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                loop_h = default(bool);loop_v = default(bool);
                try
                {
                    ((IScrollable)ws.Target).GetLooping(out loop_h, out loop_v);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_looping_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out loop_h, out loop_v);
            }
        }

        private static efl_ui_scrollable_looping_get_delegate efl_ui_scrollable_looping_get_static_delegate;

        
        private delegate void efl_ui_scrollable_looping_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool loop_h, [MarshalAs(UnmanagedType.U1)] bool loop_v);

        
        internal delegate void efl_ui_scrollable_looping_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool loop_h, [MarshalAs(UnmanagedType.U1)] bool loop_v);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate> efl_ui_scrollable_looping_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate>(Module, "efl_ui_scrollable_looping_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void looping_set(System.IntPtr obj, System.IntPtr pd, bool loop_h, bool loop_v)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_looping_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollable)ws.Target).SetLooping(loop_h, loop_v);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_looping_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), loop_h, loop_v);
            }
        }

        private static efl_ui_scrollable_looping_set_delegate efl_ui_scrollable_looping_set_static_delegate;

        
        private delegate CoreUI.UI.LayoutOrientation efl_ui_scrollable_movement_block_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.UI.LayoutOrientation efl_ui_scrollable_movement_block_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate> efl_ui_scrollable_movement_block_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate>(Module, "efl_ui_scrollable_movement_block_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.UI.LayoutOrientation movement_block_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_movement_block_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.UI.LayoutOrientation _ret_var = default(CoreUI.UI.LayoutOrientation);
                try
                {
                    _ret_var = ((IScrollable)ws.Target).GetMovementBlock();
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
                return efl_ui_scrollable_movement_block_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_scrollable_movement_block_get_delegate efl_ui_scrollable_movement_block_get_static_delegate;

        
        private delegate void efl_ui_scrollable_movement_block_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.LayoutOrientation block);

        
        internal delegate void efl_ui_scrollable_movement_block_set_api_delegate(System.IntPtr obj,  CoreUI.UI.LayoutOrientation block);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate> efl_ui_scrollable_movement_block_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate>(Module, "efl_ui_scrollable_movement_block_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void movement_block_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.LayoutOrientation block)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_movement_block_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollable)ws.Target).SetMovementBlock(block);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_movement_block_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), block);
            }
        }

        private static efl_ui_scrollable_movement_block_set_delegate efl_ui_scrollable_movement_block_set_static_delegate;

        
        private delegate void efl_ui_scrollable_gravity_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        internal delegate void efl_ui_scrollable_gravity_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate> efl_ui_scrollable_gravity_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate>(Module, "efl_ui_scrollable_gravity_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void gravity_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_gravity_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                x = default(double);y = default(double);
                try
                {
                    ((IScrollable)ws.Target).GetGravity(out x, out y);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_gravity_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out x, out y);
            }
        }

        private static efl_ui_scrollable_gravity_get_delegate efl_ui_scrollable_gravity_get_static_delegate;

        
        private delegate void efl_ui_scrollable_gravity_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        internal delegate void efl_ui_scrollable_gravity_set_api_delegate(System.IntPtr obj,  double x,  double y);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate> efl_ui_scrollable_gravity_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate>(Module, "efl_ui_scrollable_gravity_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void gravity_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_gravity_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollable)ws.Target).SetGravity(x, y);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_gravity_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), x, y);
            }
        }

        private static efl_ui_scrollable_gravity_set_delegate efl_ui_scrollable_gravity_set_static_delegate;

        
        private delegate void efl_ui_scrollable_match_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool w, [MarshalAs(UnmanagedType.U1)] bool h);

        
        internal delegate void efl_ui_scrollable_match_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool w, [MarshalAs(UnmanagedType.U1)] bool h);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate> efl_ui_scrollable_match_content_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate>(Module, "efl_ui_scrollable_match_content_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void match_content_set(System.IntPtr obj, System.IntPtr pd, bool w, bool h)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_match_content_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollable)ws.Target).SetMatchContent(w, h);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_match_content_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), w, h);
            }
        }

        private static efl_ui_scrollable_match_content_set_delegate efl_ui_scrollable_match_content_set_static_delegate;

        
        private delegate CoreUI.DataTypes.Position2D.NativeStruct efl_ui_scrollable_step_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Position2D.NativeStruct efl_ui_scrollable_step_size_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate> efl_ui_scrollable_step_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate>(Module, "efl_ui_scrollable_step_size_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Position2D.NativeStruct step_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_step_size_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Position2D _ret_var = default(CoreUI.DataTypes.Position2D);
                try
                {
                    _ret_var = ((IScrollable)ws.Target).GetStepSize();
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
                return efl_ui_scrollable_step_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_scrollable_step_size_get_delegate efl_ui_scrollable_step_size_get_static_delegate;

        
        private delegate void efl_ui_scrollable_step_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D.NativeStruct step);

        
        internal delegate void efl_ui_scrollable_step_size_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D.NativeStruct step);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate> efl_ui_scrollable_step_size_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate>(Module, "efl_ui_scrollable_step_size_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void step_size_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D.NativeStruct step)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_step_size_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Position2D _in_step = step;

                try
                {
                    ((IScrollable)ws.Target).SetStepSize(_in_step);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_step_size_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), step);
            }
        }

        private static efl_ui_scrollable_step_size_set_delegate efl_ui_scrollable_step_size_set_static_delegate;

        
        private delegate void efl_ui_scrollable_scroll_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Rect.NativeStruct rect, [MarshalAs(UnmanagedType.U1)] bool animation);

        
        internal delegate void efl_ui_scrollable_scroll_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Rect.NativeStruct rect, [MarshalAs(UnmanagedType.U1)] bool animation);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate> efl_ui_scrollable_scroll_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate>(Module, "efl_ui_scrollable_scroll");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void scroll(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Rect.NativeStruct rect, bool animation)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollable_scroll was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _in_rect = rect;

                try
                {
                    ((IScrollable)ws.Target).Scroll(_in_rect, animation);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollable_scroll_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), rect, animation);
            }
        }

        private static efl_ui_scrollable_scroll_delegate efl_ui_scrollable_scroll_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI.UI {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class ScrollableConcreteExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<CoreUI.DataTypes.Position2D> ContentPos<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IScrollable, T>magic = null) where T : CoreUI.UI.IScrollable {
        return new CoreUI.BindableProperty<CoreUI.DataTypes.Position2D>("content_pos", fac);
    }

    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<bool> ScrollFreeze<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IScrollable, T>magic = null) where T : CoreUI.UI.IScrollable {
        return new CoreUI.BindableProperty<bool>("scroll_freeze", fac);
    }

    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<bool> ScrollHold<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IScrollable, T>magic = null) where T : CoreUI.UI.IScrollable {
        return new CoreUI.BindableProperty<bool>("scroll_hold", fac);
    }

    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> MovementBlock<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IScrollable, T>magic = null) where T : CoreUI.UI.IScrollable {
        return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("movement_block", fac);
    }

    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<CoreUI.DataTypes.Position2D> StepSize<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IScrollable, T>magic = null) where T : CoreUI.UI.IScrollable {
        return new CoreUI.BindableProperty<CoreUI.DataTypes.Position2D>("step_size", fac);
    }

}
#pragma warning restore CS1591
}

