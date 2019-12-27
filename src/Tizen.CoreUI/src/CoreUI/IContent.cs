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
/// <summary>Common interface for objects that have a single sub-object as content.
/// 
/// This is used for the default content part of widgets, as well as for individual parts through <see cref="CoreUI.IPart"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.ContentConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IContent : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// 
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
    /// <returns>The sub-object.</returns>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.Gfx.IEntity GetContent();

    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// 
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
    /// <param name="content">The sub-object.</param>
    /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
    /// <since_tizen> 6 </since_tizen>
    bool SetContent(CoreUI.Gfx.IEntity content);

    /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Unswallowed object</returns>
    CoreUI.Gfx.IEntity UnsetContent();

    /// <summary>Sent after the content is set or unset using the current content object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ContentContentChangedEventArgs"/></value>
    event EventHandler<CoreUI.ContentContentChangedEventArgs> ContentChangedEvent;
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// 
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
    /// <value>The sub-object.</value>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.Gfx.IEntity Content {
        get;
        set;
    }

}

/// <summary>Event argument wrapper for event <see cref="CoreUI.IContent.ContentChangedEvent"/>.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public class ContentContentChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.
    /// </summary>
    /// <value>Sent after the content is set or unset using the current content object.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity arg { get; set; }
}

/// <summary>Common interface for objects that have a single sub-object as content.
/// 
/// This is used for the default content part of widgets, as well as for individual parts through <see cref="CoreUI.IPart"/>.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ContentConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IContent
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ContentConcrete))
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
    private ContentConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_content_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IContent"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ContentConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Sent after the content is set or unset using the current content object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ContentContentChangedEventArgs"/></value>
    public event EventHandler<CoreUI.ContentContentChangedEventArgs> ContentChangedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContentContentChangedEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.EntityConcrete) });
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ContentChangedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnContentChangedEvent(CoreUI.ContentContentChangedEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_CONTENT_EVENT_CONTENT_CHANGED", info, null);
    }


#pragma warning disable CS0628
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// 
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
    /// <returns>The sub-object.</returns>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity GetContent() {
        var _ret_var = CoreUI.ContentConcrete.NativeMethods.efl_content_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// 
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
    /// <param name="content">The sub-object.</param>
    /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
    /// <since_tizen> 6 </since_tizen>
    public bool SetContent(CoreUI.Gfx.IEntity content) {
        var _ret_var = CoreUI.ContentConcrete.NativeMethods.efl_content_set_ptr.Value.Delegate(this.NativeHandle, content);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Unswallowed object</returns>
    public CoreUI.Gfx.IEntity UnsetContent() {
        var _ret_var = CoreUI.ContentConcrete.NativeMethods.efl_content_unset_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// 
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
    /// <value>The sub-object.</value>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Gfx.IEntity Content {
        get { return GetContent(); }
        set { SetContent(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.ContentConcrete.efl_content_interface_get();
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

            if (efl_content_get_static_delegate == null)
            {
                efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
            }

            if (methods.Contains("GetContent"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate) });
            }

            if (efl_content_set_static_delegate == null)
            {
                efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
            }

            if (methods.Contains("SetContent"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate) });
            }

            if (efl_content_unset_static_delegate == null)
            {
                efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
            }

            if (methods.Contains("UnsetContent"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate) });
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
            return CoreUI.ContentConcrete.efl_content_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Gfx.IEntity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Gfx.IEntity efl_content_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_content_get_api_delegate> efl_content_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_content_get_api_delegate>(Module, "efl_content_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.IEntity content_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_content_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.IEntity _ret_var = default(CoreUI.Gfx.IEntity);
                try
                {
                    _ret_var = ((IContent)ws.Target).GetContent();
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
                return efl_content_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_content_get_delegate efl_content_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity content);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity content);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_content_set_api_delegate> efl_content_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_content_set_api_delegate>(Module, "efl_content_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool content_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity content)
        {
            CoreUI.DataTypes.Log.Debug("function efl_content_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IContent)ws.Target).SetContent(content);
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
                return efl_content_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), content);
            }
        }

        private static efl_content_set_delegate efl_content_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Gfx.IEntity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Gfx.IEntity efl_content_unset_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_content_unset_api_delegate> efl_content_unset_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_content_unset_api_delegate>(Module, "efl_content_unset");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.IEntity content_unset(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_content_unset was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.IEntity _ret_var = default(CoreUI.Gfx.IEntity);
                try
                {
                    _ret_var = ((IContent)ws.Target).UnsetContent();
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
                return efl_content_unset_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_content_unset_delegate efl_content_unset_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class ContentConcreteExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<CoreUI.Gfx.IEntity> Content<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IContent, T>magic = null) where T : CoreUI.IContent {
        return new CoreUI.BindableProperty<CoreUI.Gfx.IEntity>("content", fac);
    }

}
#pragma warning restore CS1591
}

