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
/// <summary><see cref="CoreUI.UI.IFactory"/> that creates <see cref="CoreUI.UI.Layout"/> objects with caching.
/// 
/// This factory is meant to be used by <see cref="CoreUI.UI.IView"/> objects that use items with Layout and need the items to be created, updated, their model set and connected automatically before the <see cref="CoreUI.UI.IView"/> receives the item instance.
/// 
/// This class inherits from <see cref="CoreUI.UI.CachingFactory"/> and inherits all its properties.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.UI.LayoutFactory.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public class LayoutFactory : CoreUI.UI.CachingFactory
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LayoutFactory))
            {
                return GetCoreUIClassStatic();
            }
            else
            {
                return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_layout_factory_class_get();

    /// <summary>Initializes a new instance of the <see cref="LayoutFactory"/> class.
    /// </summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
/// <param name="itemClass">Define the class of the item returned by this factory. See <see cref="CoreUI.UI.WidgetFactory.SetItemClass" /></param>
    public LayoutFactory(CoreUI.Object parent, Type itemClass = null) : base(efl_ui_layout_factory_class_get(), parent)
    {
        if (CoreUI.Wrapper.Globals.ParamHelperCheck(itemClass))
        {
            SetItemClass(CoreUI.Wrapper.Globals.GetParamHelper(itemClass));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.
    /// </summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    /// <since_tizen> 6 </since_tizen>
    protected LayoutFactory(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LayoutFactory"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
    /// </summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    internal LayoutFactory(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LayoutFactory"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
    /// </summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The CoreUI.Object parent of this instance.</param>
    protected LayoutFactory(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Set the theme that will be applied to the created <see cref="CoreUI.UI.Layout"/> objects. See <see cref="CoreUI.UI.LayoutBase.Theme"/> for more details.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="klass">The class of the group.</param>
    /// <param name="group">The group.</param>
    /// <param name="style">The style to use.</param>
    public virtual void ThemeConfig(System.String klass, System.String group, System.String style) {
        CoreUI.UI.LayoutFactory.NativeMethods.efl_ui_layout_factory_theme_config_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), klass, group, style);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.UI.LayoutFactory.efl_ui_layout_factory_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal new class NativeMethods : CoreUI.UI.CachingFactory.NativeMethods
    {
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_layout_factory_theme_config_static_delegate == null)
            {
                efl_ui_layout_factory_theme_config_static_delegate = new efl_ui_layout_factory_theme_config_delegate(theme_config);
            }

            if (methods.Contains("ThemeConfig"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_factory_theme_config"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_factory_theme_config_static_delegate) });
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return CoreUI.UI.LayoutFactory.efl_ui_layout_factory_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_layout_factory_theme_config_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String group, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String style);

        
        internal delegate void efl_ui_layout_factory_theme_config_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String group, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String style);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_factory_theme_config_api_delegate> efl_ui_layout_factory_theme_config_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_factory_theme_config_api_delegate>(Module, "efl_ui_layout_factory_theme_config");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void theme_config(System.IntPtr obj, System.IntPtr pd, System.String klass, System.String group, System.String style)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_layout_factory_theme_config was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((LayoutFactory)ws.Target).ThemeConfig(klass, group, style);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_layout_factory_theme_config_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), klass, group, style);
            }
        }

        private static efl_ui_layout_factory_theme_config_delegate efl_ui_layout_factory_theme_config_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

