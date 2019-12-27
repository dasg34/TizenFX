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
/// <summary>This type is a alias for struct tm. It is intended to be a standard way to reference it in .eo files.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct Time : IEquatable<Time>
{
    /// <summary>Seconds.	[0-60] (1 leap second)</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Tm_sec;
    /// <summary>Minutes.	[0-59]</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Tm_min;
    /// <summary>Hours.	[0-23]</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Tm_hour;
    /// <summary>Day.		[1-31]</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Tm_mday;
    /// <summary>Month.	[0-11]</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Tm_mon;
    /// <summary>Year	- 1900.</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Tm_year;
    /// <summary>Day of week.	[0-6]</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Tm_wday;
    /// <summary>Days in year.[0-365]</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Tm_yday;
    /// <summary>DST. [-1/0/1]</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Tm_isdst;
    /// <summary>Constructor for Time.
    /// </summary>
    /// <param name="Tm_sec">Seconds.	[0-60] (1 leap second)</param>
    /// <param name="Tm_min">Minutes.	[0-59]</param>
    /// <param name="Tm_hour">Hours.	[0-23]</param>
    /// <param name="Tm_mday">Day.		[1-31]</param>
    /// <param name="Tm_mon">Month.	[0-11]</param>
    /// <param name="Tm_year">Year	- 1900.</param>
    /// <param name="Tm_wday">Day of week.	[0-6]</param>
    /// <param name="Tm_yday">Days in year.[0-365]</param>
    /// <param name="Tm_isdst">DST. [-1/0/1]</param>
    /// <since_tizen> 6 </since_tizen>
    public Time(
        int Tm_sec = default(int),
        int Tm_min = default(int),
        int Tm_hour = default(int),
        int Tm_mday = default(int),
        int Tm_mon = default(int),
        int Tm_year = default(int),
        int Tm_wday = default(int),
        int Tm_yday = default(int),
        int Tm_isdst = default(int)    )
    {
        this.Tm_sec = Tm_sec;
        this.Tm_min = Tm_min;
        this.Tm_hour = Tm_hour;
        this.Tm_mday = Tm_mday;
        this.Tm_mon = Tm_mon;
        this.Tm_year = Tm_year;
        this.Tm_wday = Tm_wday;
        this.Tm_yday = Tm_yday;
        this.Tm_isdst = Tm_isdst;
    }

    /// <summary>Unpacks Time into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out int Tm_sec,
        out int Tm_min,
        out int Tm_hour,
        out int Tm_mday,
        out int Tm_mon,
        out int Tm_year,
        out int Tm_wday,
        out int Tm_yday,
        out int Tm_isdst
    )
    {
        Tm_sec = this.Tm_sec;
        Tm_min = this.Tm_min;
        Tm_hour = this.Tm_hour;
        Tm_mday = this.Tm_mday;
        Tm_mon = this.Tm_mon;
        Tm_year = this.Tm_year;
        Tm_wday = this.Tm_wday;
        Tm_yday = this.Tm_yday;
        Tm_isdst = this.Tm_isdst;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Tm_sec.GetHashCode();
        hash = hash * 23 + Tm_min.GetHashCode();
        hash = hash * 23 + Tm_hour.GetHashCode();
        hash = hash * 23 + Tm_mday.GetHashCode();
        hash = hash * 23 + Tm_mon.GetHashCode();
        hash = hash * 23 + Tm_year.GetHashCode();
        hash = hash * 23 + Tm_wday.GetHashCode();
        hash = hash * 23 + Tm_yday.GetHashCode();
        hash = hash * 23 + Tm_isdst.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(Time other)
    {
        return Tm_sec == other.Tm_sec && Tm_min == other.Tm_min && Tm_hour == other.Tm_hour && Tm_mday == other.Tm_mday && Tm_mon == other.Tm_mon && Tm_year == other.Tm_year && Tm_wday == other.Tm_wday && Tm_yday == other.Tm_yday && Tm_isdst == other.Tm_isdst        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is Time) ? Equals((Time)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(Time lhs, Time rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(Time lhs, Time rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Time(IntPtr ptr)
    {
        var tmp = (Time.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Time.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static Time FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Time.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public int Tm_sec;
        
        public int Tm_min;
        
        public int Tm_hour;
        
        public int Tm_mday;
        
        public int Tm_mon;
        
        public int Tm_year;
        
        public int Tm_wday;
        
        public int Tm_yday;
        
        public int Tm_isdst;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Time.NativeStruct(Time _external_struct)
        {
            var _internal_struct = new Time.NativeStruct();
            _internal_struct.Tm_sec = _external_struct.Tm_sec;
            _internal_struct.Tm_min = _external_struct.Tm_min;
            _internal_struct.Tm_hour = _external_struct.Tm_hour;
            _internal_struct.Tm_mday = _external_struct.Tm_mday;
            _internal_struct.Tm_mon = _external_struct.Tm_mon;
            _internal_struct.Tm_year = _external_struct.Tm_year;
            _internal_struct.Tm_wday = _external_struct.Tm_wday;
            _internal_struct.Tm_yday = _external_struct.Tm_yday;
            _internal_struct.Tm_isdst = _external_struct.Tm_isdst;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Time(Time.NativeStruct _internal_struct)
        {
            var _external_struct = new Time();
            _external_struct.Tm_sec = _internal_struct.Tm_sec;
            _external_struct.Tm_min = _internal_struct.Tm_min;
            _external_struct.Tm_hour = _internal_struct.Tm_hour;
            _external_struct.Tm_mday = _internal_struct.Tm_mday;
            _external_struct.Tm_mon = _internal_struct.Tm_mon;
            _external_struct.Tm_year = _internal_struct.Tm_year;
            _external_struct.Tm_wday = _internal_struct.Tm_wday;
            _external_struct.Tm_yday = _internal_struct.Tm_yday;
            _external_struct.Tm_isdst = _internal_struct.Tm_isdst;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI {
/// <summary>This type describes the version of EFL with an optional variant.
/// 
/// This may be used to query the current running version of EFL. Or it can be passed by applications at startup time to inform EFL of the version a certain application was built for.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct Version : IEquatable<Version>
{
    /// <summary>Major component of the version (&gt;= 1).</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Major;
    /// <summary>Minor component of the version (&gt;= 0).</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Minor;
    /// <summary>Micro component of the version (&gt;= 0).</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Micro;
    /// <summary>Revision component of the version (&gt;= 0).</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Revision;
    /// <summary>Special version string for this build of EFL, <c>null</c> for vanilla (upstream) EFL. Contains <c>EFL_VERSION_FLAVOR</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public System.String Flavor;
    /// <summary>Contains <c>EFL_BUILD_ID</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public System.String Build_id;
    /// <summary>Constructor for Version.
    /// </summary>
    /// <param name="Major">Major component of the version (&gt;= 1).</param>
    /// <param name="Minor">Minor component of the version (&gt;= 0).</param>
    /// <param name="Micro">Micro component of the version (&gt;= 0).</param>
    /// <param name="Revision">Revision component of the version (&gt;= 0).</param>
    /// <param name="Flavor">Special version string for this build of EFL, <c>null</c> for vanilla (upstream) EFL. Contains <c>EFL_VERSION_FLAVOR</c>.</param>
    /// <param name="Build_id">Contains <c>EFL_BUILD_ID</c>.</param>
    /// <since_tizen> 6 </since_tizen>
    public Version(
        int Major = default(int),
        int Minor = default(int),
        int Micro = default(int),
        int Revision = default(int),
        System.String Flavor = default(System.String),
        System.String Build_id = default(System.String)    )
    {
        this.Major = Major;
        this.Minor = Minor;
        this.Micro = Micro;
        this.Revision = Revision;
        this.Flavor = Flavor;
        this.Build_id = Build_id;
    }

    /// <summary>Unpacks Version into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out int Major,
        out int Minor,
        out int Micro,
        out int Revision,
        out System.String Flavor,
        out System.String Build_id
    )
    {
        Major = this.Major;
        Minor = this.Minor;
        Micro = this.Micro;
        Revision = this.Revision;
        Flavor = this.Flavor;
        Build_id = this.Build_id;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Major.GetHashCode();
        hash = hash * 23 + Minor.GetHashCode();
        hash = hash * 23 + Micro.GetHashCode();
        hash = hash * 23 + Revision.GetHashCode();
        hash = hash * 23 + Flavor.GetHashCode(StringComparison.Ordinal);
        hash = hash * 23 + Build_id.GetHashCode(StringComparison.Ordinal);
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(Version other)
    {
        return Major == other.Major && Minor == other.Minor && Micro == other.Micro && Revision == other.Revision && Flavor == other.Flavor && Build_id == other.Build_id        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is Version) ? Equals((Version)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(Version lhs, Version rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(Version lhs, Version rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Version(IntPtr ptr)
    {
        var tmp = (Version.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Version.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static Version FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Version.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public int Major;
        
        public int Minor;
        
        public int Micro;
        
        public int Revision;
        /// <summary>Internal wrapper for field Flavor</summary>
        public System.IntPtr Flavor;
        /// <summary>Internal wrapper for field Build_id</summary>
        public System.IntPtr Build_id;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Version.NativeStruct(Version _external_struct)
        {
            var _internal_struct = new Version.NativeStruct();
            _internal_struct.Major = _external_struct.Major;
            _internal_struct.Minor = _external_struct.Minor;
            _internal_struct.Micro = _external_struct.Micro;
            _internal_struct.Revision = _external_struct.Revision;
            _internal_struct.Flavor = CoreUI.DataTypes.MemoryNative.StrDup(_external_struct.Flavor);
            _internal_struct.Build_id = CoreUI.DataTypes.MemoryNative.StrDup(_external_struct.Build_id);
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Version(Version.NativeStruct _internal_struct)
        {
            var _external_struct = new Version();
            _external_struct.Major = _internal_struct.Major;
            _external_struct.Minor = _internal_struct.Minor;
            _external_struct.Micro = _internal_struct.Micro;
            _external_struct.Revision = _internal_struct.Revision;
            _external_struct.Flavor = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(_internal_struct.Flavor);
            _external_struct.Build_id = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(_internal_struct.Build_id);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

