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
/// <summary>An object implementing this interface can send pointer events.
/// 
/// Windows and canvas objects may send input events.
/// 
/// A &quot;pointer&quot; refers to the main pointing device, which could be a mouse, trackpad, finger, pen, etc... In other words, the finger id in any pointer event will always be 0.
/// 
/// A &quot;finger&quot; refers to a single point of input, usually in an absolute coordinates input device, and that can support more than one input position at at time (think multi-touch screens). The first finger (id 0) is sent along with a pointer event, so be careful to not handle those events twice. Note that if the input device can support &quot;hovering&quot;, it is entirely possible to receive move events without down coming first.
/// 
/// A &quot;key&quot; is a key press from a keyboard or equivalent type of input device. Long, repeated, key presses will always happen like this: down...up,down...up,down...up (not down...up or down...down...down...up).</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Input.InterfaceConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IInterface : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Main pointer move (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerMoveEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfacePointerMoveEventArgs> PointerMoveEvent;
    /// <summary>Main pointer button pressed (button id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerDownEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfacePointerDownEventArgs> PointerDownEvent;
    /// <summary>Main pointer button released (button id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerUpEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfacePointerUpEventArgs> PointerUpEvent;
    /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerCancelEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfacePointerCancelEventArgs> PointerCancelEvent;
    /// <summary>Pointer entered a window or a widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerInEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfacePointerInEventArgs> PointerInEvent;
    /// <summary>Pointer left a window or a widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerOutEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfacePointerOutEventArgs> PointerOutEvent;
    /// <summary>Mouse wheel event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerWheelEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfacePointerWheelEventArgs> PointerWheelEvent;
    /// <summary>Pen or other axis event update.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerAxisEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfacePointerAxisEventArgs> PointerAxisEvent;
    /// <summary>Finger moved (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceFingerMoveEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfaceFingerMoveEventArgs> FingerMoveEvent;
    /// <summary>Finger pressed (finger id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceFingerDownEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfaceFingerDownEventArgs> FingerDownEvent;
    /// <summary>Finger released (finger id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceFingerUpEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfaceFingerUpEventArgs> FingerUpEvent;
    /// <summary>Keyboard key press.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceKeyDownEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfaceKeyDownEventArgs> KeyDownEvent;
    /// <summary>Keyboard key release.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceKeyUpEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfaceKeyUpEventArgs> KeyUpEvent;
    /// <summary>All input events are on hold or resumed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceHoldEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfaceHoldEventArgs> HoldEvent;
    /// <summary>A focus in event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceFocusInEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfaceFocusInEventArgs> FocusInEvent;
    /// <summary>A focus out event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceFocusOutEventArgs"/></value>
    event EventHandler<CoreUI.Input.InterfaceFocusOutEventArgs> FocusOutEvent;
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerMoveEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfacePointerMoveEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Main pointer move (current and previous positions are known).</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerDownEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfacePointerDownEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Main pointer button pressed (button id is known).</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerUpEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfacePointerUpEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Main pointer button released (button id is known).</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerCancelEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfacePointerCancelEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerInEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfacePointerInEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Pointer entered a window or a widget.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerOutEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfacePointerOutEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Pointer left a window or a widget.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerWheelEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfacePointerWheelEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Mouse wheel event.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerAxisEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfacePointerAxisEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Pen or other axis event update.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.FingerMoveEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfaceFingerMoveEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Finger moved (current and previous positions are known).</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.FingerDownEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfaceFingerDownEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Finger pressed (finger id is known).</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.FingerUpEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfaceFingerUpEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Finger released (finger id is known).</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.KeyDownEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfaceKeyDownEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Keyboard key press.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Key arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.KeyUpEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfaceKeyUpEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Keyboard key release.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Key arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.HoldEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfaceHoldEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>All input events are on hold or resumed.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Hold arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.FocusInEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfaceFocusInEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>A focus in event.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Focus arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.FocusOutEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class InterfaceFocusOutEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>A focus out event.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Input.Focus arg { get; set; }
}

/// <summary>An object implementing this interface can send pointer events.
/// 
/// Windows and canvas objects may send input events.
/// 
/// A &quot;pointer&quot; refers to the main pointing device, which could be a mouse, trackpad, finger, pen, etc... In other words, the finger id in any pointer event will always be 0.
/// 
/// A &quot;finger&quot; refers to a single point of input, usually in an absolute coordinates input device, and that can support more than one input position at at time (think multi-touch screens). The first finger (id 0) is sent along with a pointer event, so be careful to not handle those events twice. Note that if the input device can support &quot;hovering&quot;, it is entirely possible to receive move events without down coming first.
/// 
/// A &quot;key&quot; is a key press from a keyboard or equivalent type of input device. Long, repeated, key presses will always happen like this: down...up,down...up,down...up (not down...up or down...down...down...up).</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class InterfaceConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IInterface
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(InterfaceConcrete))
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
    private InterfaceConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
        efl_input_interface_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IInterface"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private InterfaceConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Main pointer move (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerMoveEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfacePointerMoveEventArgs> PointerMoveEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerMoveEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_POINTER_MOVE";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_MOVE";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerMoveEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPointerMoveEvent(CoreUI.Input.InterfacePointerMoveEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_MOVE", info, null);
    }

    /// <summary>Main pointer button pressed (button id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerDownEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfacePointerDownEventArgs> PointerDownEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerDownEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_POINTER_DOWN";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_DOWN";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerDownEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPointerDownEvent(CoreUI.Input.InterfacePointerDownEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_DOWN", info, null);
    }

    /// <summary>Main pointer button released (button id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerUpEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfacePointerUpEventArgs> PointerUpEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerUpEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_POINTER_UP";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_UP";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerUpEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPointerUpEvent(CoreUI.Input.InterfacePointerUpEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_UP", info, null);
    }

    /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerCancelEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfacePointerCancelEventArgs> PointerCancelEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerCancelEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_POINTER_CANCEL";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_CANCEL";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerCancelEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPointerCancelEvent(CoreUI.Input.InterfacePointerCancelEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_CANCEL", info, null);
    }

    /// <summary>Pointer entered a window or a widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerInEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfacePointerInEventArgs> PointerInEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerInEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_POINTER_IN";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_IN";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerInEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPointerInEvent(CoreUI.Input.InterfacePointerInEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_IN", info, null);
    }

    /// <summary>Pointer left a window or a widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerOutEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfacePointerOutEventArgs> PointerOutEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerOutEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_POINTER_OUT";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_OUT";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerOutEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPointerOutEvent(CoreUI.Input.InterfacePointerOutEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_OUT", info, null);
    }

    /// <summary>Mouse wheel event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerWheelEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfacePointerWheelEventArgs> PointerWheelEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerWheelEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_POINTER_WHEEL";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_WHEEL";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerWheelEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPointerWheelEvent(CoreUI.Input.InterfacePointerWheelEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_WHEEL", info, null);
    }

    /// <summary>Pen or other axis event update.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfacePointerAxisEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfacePointerAxisEventArgs> PointerAxisEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerAxisEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_POINTER_AXIS";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_AXIS";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerAxisEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnPointerAxisEvent(CoreUI.Input.InterfacePointerAxisEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_AXIS", info, null);
    }

    /// <summary>Finger moved (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceFingerMoveEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfaceFingerMoveEventArgs> FingerMoveEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceFingerMoveEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_FINGER_MOVE";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_FINGER_MOVE";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event FingerMoveEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnFingerMoveEvent(CoreUI.Input.InterfaceFingerMoveEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_FINGER_MOVE", info, null);
    }

    /// <summary>Finger pressed (finger id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceFingerDownEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfaceFingerDownEventArgs> FingerDownEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceFingerDownEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_FINGER_DOWN";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_FINGER_DOWN";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event FingerDownEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnFingerDownEvent(CoreUI.Input.InterfaceFingerDownEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_FINGER_DOWN", info, null);
    }

    /// <summary>Finger released (finger id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceFingerUpEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfaceFingerUpEventArgs> FingerUpEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceFingerUpEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
            string key = "_EFL_EVENT_FINGER_UP";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_FINGER_UP";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event FingerUpEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnFingerUpEvent(CoreUI.Input.InterfaceFingerUpEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_FINGER_UP", info, null);
    }

    /// <summary>Keyboard key press.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceKeyDownEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfaceKeyDownEventArgs> KeyDownEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceKeyDownEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Key) });
            string key = "_EFL_EVENT_KEY_DOWN";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_KEY_DOWN";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event KeyDownEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnKeyDownEvent(CoreUI.Input.InterfaceKeyDownEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_KEY_DOWN", info, null);
    }

    /// <summary>Keyboard key release.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceKeyUpEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfaceKeyUpEventArgs> KeyUpEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceKeyUpEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Key) });
            string key = "_EFL_EVENT_KEY_UP";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_KEY_UP";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event KeyUpEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnKeyUpEvent(CoreUI.Input.InterfaceKeyUpEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_KEY_UP", info, null);
    }

    /// <summary>All input events are on hold or resumed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceHoldEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfaceHoldEventArgs> HoldEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceHoldEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Hold) });
            string key = "_EFL_EVENT_HOLD";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_HOLD";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event HoldEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnHoldEvent(CoreUI.Input.InterfaceHoldEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_HOLD", info, null);
    }

    /// <summary>A focus in event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceFocusInEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfaceFocusInEventArgs> FocusInEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceFocusInEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Focus) });
            string key = "_EFL_EVENT_FOCUS_IN";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_FOCUS_IN";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event FocusInEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnFocusInEvent(CoreUI.Input.InterfaceFocusInEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_FOCUS_IN", info, null);
    }

    /// <summary>A focus out event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.Input.InterfaceFocusOutEventArgs"/></value>
    public event EventHandler<CoreUI.Input.InterfaceFocusOutEventArgs> FocusOutEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceFocusOutEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Focus) });
            string key = "_EFL_EVENT_FOCUS_OUT";
            AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_FOCUS_OUT";
            RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event FocusOutEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnFocusOutEvent(CoreUI.Input.InterfaceFocusOutEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_FOCUS_OUT", info, null);
    }


#pragma warning disable CS0628
#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.Input.InterfaceConcrete.efl_input_interface_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal new class NativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
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
            return CoreUI.Input.InterfaceConcrete.efl_input_interface_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

