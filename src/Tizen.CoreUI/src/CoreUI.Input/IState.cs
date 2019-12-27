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
/// <summary>CoreUI input state interface.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Input.StateConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IState : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
}

/// <summary>CoreUI input state interface.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class StateConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IState
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(StateConcrete))
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
    private StateConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
        efl_input_state_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IState"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private StateConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.Input.StateConcrete.efl_input_state_interface_get();
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
            return CoreUI.Input.StateConcrete.efl_input_state_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

