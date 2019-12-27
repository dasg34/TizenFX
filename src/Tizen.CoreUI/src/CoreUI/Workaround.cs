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
#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

///<summary>Eo class description, passed to efl_class_new.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
internal struct ClassDescription : IEquatable<ClassDescription>
{
    ///<summary>Current Eo version.</summary>
    /// <since_tizen> 6 </since_tizen>
    internal uint version;
    ///<summary>Name of the class.</summary>
    /// <since_tizen> 6 </since_tizen>
    [MarshalAs(UnmanagedType.LPStr)] internal String name;
    ///<summary>Class type.</summary>
    /// <since_tizen> 6 </since_tizen>
    internal int class_type;
    ///<summary>Size of data (private + protected + public) per instance.</summary>
    /// <since_tizen> 6 </since_tizen>
    internal UIntPtr data_size;
    ///<summary>Initializer for the class.</summary>
    /// <since_tizen> 6 </since_tizen>
    internal IntPtr class_initializer;
    ///<summary>Constructor of the class.</summary>
    /// <since_tizen> 6 </since_tizen>
    internal IntPtr class_constructor;
    ///<summary>Destructor of the class.</summary>
    /// <since_tizen> 6 </since_tizen>
    internal IntPtr class_destructor;

    /// <summary>
    ///   Gets a hash for <see cref="ClassDescription" />.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A hash code.</returns>
    public override int GetHashCode()
        => version.GetHashCode() ^ name.GetHashCode(StringComparison.Ordinal)
        ^ class_type ^ data_size.GetHashCode();

    /// <summary>Returns whether this <see cref="ClassDescription" />
    /// is equal to the given <see cref="object" />.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="other">The <see cref="object" /> to be compared to.</param>
    /// <returns><c>true</c> if is equal to <c>other</c>.</returns>
    public override bool Equals(object other)
        => (!(other is ClassDescription)) ? false
        : Equals((ClassDescription)other);


    /// <summary>Returns whether this <see cref="ClassDescription" /> is equal
    /// to the given <see cref="ClassDescription" />.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="other">The <see cref="ClassDescription" /> to be compared to.</param>
    /// <returns><c>true</c> if is equal to <c>other</c>.</returns>
    public bool Equals(ClassDescription other)
        => (name == other.name) && (class_type == other.class_type);

    /// <summary>Returns whether <c>lhs</c> is equal to <c>rhs</c>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is equal
    /// to <c>rhs</c>.</returns>
    public static bool operator==(ClassDescription lhs, ClassDescription rhs)
        => lhs.Equals(rhs);

    /// <summary>Returns whether <c>lhs</c> is not equal to <c>rhs</c>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is not equal
    /// to <c>rhs</c>.</returns>
    public static bool operator!=(ClassDescription lhs, ClassDescription rhs)
        => !(lhs == rhs);
}

///<summary>Description of an Eo API operation.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
internal struct CoreUIOpDescription
{
    ///<summary>The EAPI function offering this op. (String with the name of the function on Windows)</summary>
    /// <since_tizen> 6 </since_tizen>
    internal IntPtr api_func;
    ///<summary>The static function to be called for this op</summary>
    /// <since_tizen> 6 </since_tizen>
    internal IntPtr func;
}

///<summary>List of operations on a given Object.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
internal struct CoreUIObjectOps
{
    ///<summary>The op descriptions array of size count.</summary>
    /// <since_tizen> 6 </since_tizen>
    internal IntPtr descs;
    ///<summary>Number of op descriptions.</summary>
    /// <since_tizen> 6 </since_tizen>
    internal UIntPtr count;
};

namespace CoreUI
{

/// <summary>
/// This struct holds the description of a specific event.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
internal struct EventDescription
{
    ///<summary>Name of the event.</summary>
    /// <since_tizen> 6 </since_tizen>
    public IntPtr Name;
    ///<summary><c>true</c> if the event cannot be frozen.</summary>
    /// <since_tizen> 6 </since_tizen>
    [MarshalAs(UnmanagedType.U1)] public bool Unfreezable;
    ///<summary>Internal use: <c>true</c> if this is a legacy event.</summary>
    /// <since_tizen> 6 </since_tizen>
    [MarshalAs(UnmanagedType.U1)] public bool Legacy_is;
    ///<summary><c>true</c> if when the even is triggered again from a callback it
    ///will start from where it was.</summary>
    /// <since_tizen> 6 </since_tizen>
    [MarshalAs(UnmanagedType.U1)] public bool Restart;

    private static Dictionary<string, IntPtr> descriptions = new Dictionary<string, IntPtr>();

    ///<summary>Constructor for EventDescription</summary>
    /// <since_tizen> 6 </since_tizen>
    ///<param name="moduleName">The name of the module containing the event.</param>
    ///<param name="name">The name of the event.</param>
    public EventDescription(string moduleName, string name)
    {
        this.Name = GetNative(moduleName, name);
        this.Unfreezable = false;
        this.Legacy_is = false;
        this.Restart = false;
    }

    ///<summary>Get the native structure.</summary>
    /// <since_tizen> 6 </since_tizen>
    ///<param name="moduleName">The name of the module containing the event.</param>
    ///<param name="name">The name of the event.</param>
    ///<returns>Pointer to the native structure.</returns>
    public static IntPtr GetNative(string moduleName, string name)
    {
        if (!descriptions.ContainsKey(name))
        {
            IntPtr data = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(moduleName, name);

            if (data == IntPtr.Zero)
            {
                string error = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(CoreUI.Wrapper.Globals.dlerror());
                throw new Exception(error);
            }

            descriptions.Add(name, data);
        }

        return descriptions[name];
    }
};

/// <summary>
/// A parameter passed in event callbacks holding extra event parameters.
/// This is the full event information passed to callbacks in C.
/// </summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
internal struct Event
{
    /// <summary>
    /// The object the callback was called on.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.Object Object;

    /// <summary>
    /// The event description.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.EventDescription Desc;

    /// <summary>
    /// Extra event information passed by the event caller.
    /// Must be cast to the event type declared in the EO file. Keep in mind that:
    /// 1) Objects are passed as a normal Eo*. Event subscribers can call functions on these objects.
    /// 2) Structs, built-in types and containers are passed as const pointers, with one level of indirection.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public System.IntPtr Info;

    /// <summary>Constructor for Event.</summary>
    /// <since_tizen> 6 </since_tizen>
    public Event(
        CoreUI.Object obj = default(CoreUI.Object),
        CoreUI.EventDescription desc = default(CoreUI.EventDescription),
        System.IntPtr info = default(System.IntPtr))
    {
        this.Object = obj;
        this.Desc = desc;
        this.Info = info;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Event(IntPtr ptr)
    {
        var tmp = (Event.NativeStruct) Marshal.PtrToStructure(ptr, typeof(Event.NativeStruct));
        return tmp;
    }

    /// <summary>Internal wrapper for struct Event.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Object</summary>
        /// <since_tizen> 6 </since_tizen>
        public System.IntPtr Object;

        /// <summary>Internal wrapper for field Desc</summary>
        /// <since_tizen> 6 </since_tizen>
        public System.IntPtr Desc;

        /// <summary>Internal wrapper for field Info</summary>
        /// <since_tizen> 6 </since_tizen>
        public System.IntPtr Info;

        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="externalStruct">Managed struct to be converted.</param>
        /// <returns>Native representation of the managed struct.</returns>
        public static implicit operator Event.NativeStruct(Event externalStruct)
        {
            var internalStruct = new Event.NativeStruct();
            internalStruct.Object = externalStruct.Object?.NativeHandle ?? System.IntPtr.Zero;
            internalStruct.Desc = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(externalStruct.Desc);
            internalStruct.Info = externalStruct.Info;
            return internalStruct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="internalStruct">Native struct to be converted.</param>
        /// <returns>Managed representation of the native struct.</returns>
        public static implicit operator Event(Event.NativeStruct internalStruct)
        {
            var externalStruct = new Event();
            externalStruct.Object = (CoreUI.Object) CoreUI.Wrapper.Globals.CreateWrapperFor(internalStruct.Object);
            externalStruct.Desc = CoreUI.DataTypes.PrimitiveConversion.PointerToManaged<CoreUI.EventDescription>(internalStruct.Desc);
            externalStruct.Info = internalStruct.Info;
            return externalStruct;
        }
    }
}

internal delegate void EventCb(System.IntPtr data, ref Event.NativeStruct evt);
internal delegate void FreeWrapperSupervisorCb(System.IntPtr obj);

namespace Access
{

public delegate IntPtr ReadingInfoCb(System.IntPtr data, ref CoreUI.Canvas.Object obj);

//TIZEN_ONLY(20191127): disable efl_access on csharp
//public delegate bool GestureCb(System.IntPtr data, ref CoreUI.Access.GestureInfo info, ref CoreUI.Canvas.Object obj);
//

public struct ActionData : IEquatable<ActionData>
{
    public IntPtr name;
    public IntPtr action;
    public IntPtr param;
    public IntPtr func;


    /// <summary>
    ///   Gets a hash for <see cref="ActionData" />.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A hash code.</returns>
    public override int GetHashCode()
        => name.GetHashCode() ^ action.GetHashCode()
        ^ param.GetHashCode() ^ func.GetHashCode();

    /// <summary>Returns whether this <see cref="ActionData" />
    /// is equal to the given <see cref="object" />.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="other">The <see cref="object" /> to be compared to.</param>
    /// <returns><c>true</c> if is equal to <c>other</c>.</returns>
    public override bool Equals(object other)
        => (!(other is ActionData)) ? false
        : Equals((ActionData)other);


    /// <summary>Returns whether this <see cref="ActionData" /> is equal
    /// to the given <see cref="ActionData" />.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="other">The <see cref="ActionData" /> to be compared to.</param>
    /// <returns><c>true</c> if is equal to <c>other</c>.</returns>
    public bool Equals(ActionData other)
        => (name == other.name) && (action == other.action)
        && (param == other.param) && (func == other.func);

    /// <summary>Returns whether <c>lhs</c> is equal to <c>rhs</c>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is equal
    /// to <c>rhs</c>.</returns>
    public static bool operator==(ActionData lhs, ActionData rhs)
        => lhs.Equals(rhs);

    /// <summary>Returns whether <c>lhs</c> is not equal to <c>rhs</c>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is not equal
    /// to <c>rhs</c>.</returns>
    public static bool operator!=(ActionData lhs, ActionData rhs)
        => !(lhs == rhs);
}

} // namespace Access

} // namespace CoreUI
