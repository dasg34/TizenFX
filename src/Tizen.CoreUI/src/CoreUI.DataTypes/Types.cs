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
namespace CoreUI.DataTypes
{
/// <summary>A rectangle in pixel dimensions.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct Rect : IEquatable<Rect>
{
    /// <summary>X coordinate of the rectangle, from the top-left corner.</summary>
    /// <since_tizen> 6 </since_tizen>
    public int X;
    /// <summary>Y coordinate of the rectangle, from the top-left corner.</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Y;
    /// <summary>Width of the rectangle in pixels.</summary>
    /// <since_tizen> 6 </since_tizen>
    public int W;
    /// <summary>Height of the rectangle in pixels.</summary>
    /// <since_tizen> 6 </since_tizen>
    public int H;
    /// <summary>Constructor for Rect.
    /// </summary>
    /// <param name="X">X coordinate of the rectangle, from the top-left corner.</param>
    /// <param name="Y">Y coordinate of the rectangle, from the top-left corner.</param>
    /// <param name="W">Width of the rectangle in pixels.</param>
    /// <param name="H">Height of the rectangle in pixels.</param>
    /// <since_tizen> 6 </since_tizen>
    public Rect(
        int X = default(int),
        int Y = default(int),
        int W = default(int),
        int H = default(int)    )
    {
        this.X = X;
        this.Y = Y;
        this.W = W;
        this.H = H;
    }

    /// <summary>Packs tuple into Rect object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator Rect(
        (
         int X,
         int Y,
         int W,
         int H
        ) tuple)
    {
        return new Rect{
            X = tuple.X,
            Y = tuple.Y,
            W = tuple.W,
            H = tuple.H,
        };
    }
    /// <summary>Unpacks Rect into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out int X,
        out int Y,
        out int W,
        out int H
    )
    {
        X = this.X;
        Y = this.Y;
        W = this.W;
        H = this.H;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + X.GetHashCode();
        hash = hash * 23 + Y.GetHashCode();
        hash = hash * 23 + W.GetHashCode();
        hash = hash * 23 + H.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(Rect other)
    {
        return X == other.X && Y == other.Y && W == other.W && H == other.H        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is Rect) ? Equals((Rect)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(Rect lhs, Rect rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(Rect lhs, Rect rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Rect(IntPtr ptr)
    {
        var tmp = (Rect.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Rect.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static Rect FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Rect.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public int X;
        
        public int Y;
        
        public int W;
        
        public int H;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Rect.NativeStruct(Rect _external_struct)
        {
            var _internal_struct = new Rect.NativeStruct();
            _internal_struct.X = _external_struct.X;
            _internal_struct.Y = _external_struct.Y;
            _internal_struct.W = _external_struct.W;
            _internal_struct.H = _external_struct.H;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Rect(Rect.NativeStruct _internal_struct)
        {
            var _external_struct = new Rect();
            _external_struct.X = _internal_struct.X;
            _external_struct.Y = _internal_struct.Y;
            _external_struct.W = _internal_struct.W;
            _external_struct.H = _internal_struct.H;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.DataTypes
{
/// <summary>A 2D location in pixels.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct Position2D : IEquatable<Position2D>
{
    /// <summary>X position in pixels, from the top-left corner.</summary>
    /// <since_tizen> 6 </since_tizen>
    public int X;
    /// <summary>Y position in pixels, from the top-left corner.</summary>
    /// <since_tizen> 6 </since_tizen>
    public int Y;
    /// <summary>Constructor for Position2D.
    /// </summary>
    /// <param name="X">X position in pixels, from the top-left corner.</param>
    /// <param name="Y">Y position in pixels, from the top-left corner.</param>
    /// <since_tizen> 6 </since_tizen>
    public Position2D(
        int X = default(int),
        int Y = default(int)    )
    {
        this.X = X;
        this.Y = Y;
    }

    /// <summary>Packs tuple into Position2D object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator Position2D(
        (
         int X,
         int Y
        ) tuple)
    {
        return new Position2D{
            X = tuple.X,
            Y = tuple.Y,
        };
    }
    /// <summary>Unpacks Position2D into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out int X,
        out int Y
    )
    {
        X = this.X;
        Y = this.Y;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + X.GetHashCode();
        hash = hash * 23 + Y.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(Position2D other)
    {
        return X == other.X && Y == other.Y        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is Position2D) ? Equals((Position2D)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(Position2D lhs, Position2D rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(Position2D lhs, Position2D rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Position2D(IntPtr ptr)
    {
        var tmp = (Position2D.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Position2D.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static Position2D FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Position2D.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public int X;
        
        public int Y;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Position2D.NativeStruct(Position2D _external_struct)
        {
            var _internal_struct = new Position2D.NativeStruct();
            _internal_struct.X = _external_struct.X;
            _internal_struct.Y = _external_struct.Y;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Position2D(Position2D.NativeStruct _internal_struct)
        {
            var _external_struct = new Position2D();
            _external_struct.X = _internal_struct.X;
            _external_struct.Y = _internal_struct.Y;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.DataTypes
{
/// <summary>A 2D size in pixels.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct Size2D : IEquatable<Size2D>
{
    /// <summary>X position in pixels, from the top-left corner.</summary>
    /// <since_tizen> 6 </since_tizen>
    public int W;
    /// <summary>Y position in pixels, from the top-left corner.</summary>
    /// <since_tizen> 6 </since_tizen>
    public int H;
    /// <summary>Constructor for Size2D.
    /// </summary>
    /// <param name="W">X position in pixels, from the top-left corner.</param>
    /// <param name="H">Y position in pixels, from the top-left corner.</param>
    /// <since_tizen> 6 </since_tizen>
    public Size2D(
        int W = default(int),
        int H = default(int)    )
    {
        this.W = W;
        this.H = H;
    }

    /// <summary>Packs tuple into Size2D object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator Size2D(
        (
         int W,
         int H
        ) tuple)
    {
        return new Size2D{
            W = tuple.W,
            H = tuple.H,
        };
    }
    /// <summary>Unpacks Size2D into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out int W,
        out int H
    )
    {
        W = this.W;
        H = this.H;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + W.GetHashCode();
        hash = hash * 23 + H.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(Size2D other)
    {
        return W == other.W && H == other.H        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is Size2D) ? Equals((Size2D)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(Size2D lhs, Size2D rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(Size2D lhs, Size2D rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Size2D(IntPtr ptr)
    {
        var tmp = (Size2D.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Size2D.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static Size2D FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Size2D.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public int W;
        
        public int H;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Size2D.NativeStruct(Size2D _external_struct)
        {
            var _internal_struct = new Size2D.NativeStruct();
            _internal_struct.W = _external_struct.W;
            _internal_struct.H = _external_struct.H;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Size2D(Size2D.NativeStruct _internal_struct)
        {
            var _external_struct = new Size2D();
            _external_struct.W = _internal_struct.W;
            _external_struct.H = _internal_struct.H;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.DataTypes
{
/// <summary>Eina file data structure</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct File : IEquatable<File>
{
    /// <summary>Placeholder field</summary>
    public IntPtr field;
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
return field.GetHashCode();
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(File other)
    {
        return field.Equals(other.field)        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is File) ? Equals((File)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(File lhs, File rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(File lhs, File rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator File(IntPtr ptr)
    {
        var tmp = (File.NativeStruct)Marshal.PtrToStructure(ptr, typeof(File.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static File FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct File.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        internal IntPtr field;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator File.NativeStruct(File _external_struct)
        {
            var _internal_struct = new File.NativeStruct();
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator File(File.NativeStruct _internal_struct)
        {
            var _external_struct = new File();
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.DataTypes
{
/// <summary>A simple 2D vector type using floating point values.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct Vector2 : IEquatable<Vector2>
{
    /// <summary>X coordinate.</summary>
    /// <since_tizen> 6 </since_tizen>
    public double X;
    /// <summary>Y coordinate.</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Y;
    /// <summary>Constructor for Vector2.
    /// </summary>
    /// <param name="X">X coordinate.</param>
    /// <param name="Y">Y coordinate.</param>
    /// <since_tizen> 6 </since_tizen>
    public Vector2(
        double X = default(double),
        double Y = default(double)    )
    {
        this.X = X;
        this.Y = Y;
    }

    /// <summary>Packs tuple into Vector2 object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator Vector2(
        (
         double X,
         double Y
        ) tuple)
    {
        return new Vector2{
            X = tuple.X,
            Y = tuple.Y,
        };
    }
    /// <summary>Unpacks Vector2 into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out double X,
        out double Y
    )
    {
        X = this.X;
        Y = this.Y;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + X.GetHashCode();
        hash = hash * 23 + Y.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(Vector2 other)
    {
        return X == other.X && Y == other.Y        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is Vector2) ? Equals((Vector2)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(Vector2 lhs, Vector2 rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(Vector2 lhs, Vector2 rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Vector2(IntPtr ptr)
    {
        var tmp = (Vector2.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Vector2.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static Vector2 FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Vector2.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public double X;
        
        public double Y;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Vector2.NativeStruct(Vector2 _external_struct)
        {
            var _internal_struct = new Vector2.NativeStruct();
            _internal_struct.X = _external_struct.X;
            _internal_struct.Y = _external_struct.Y;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Vector2(Vector2.NativeStruct _internal_struct)
        {
            var _external_struct = new Vector2();
            _external_struct.X = _internal_struct.X;
            _external_struct.Y = _internal_struct.Y;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.DataTypes
{
/// <summary>Eina 3x3 Matrix</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct Matrix3 : IEquatable<Matrix3>
{
    /// <summary>XX matrix value</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Xx;
    /// <summary>XY matrix value</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Xy;
    /// <summary>XZ matrix value</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Xz;
    /// <summary>YX matrix value</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Yx;
    /// <summary>YY matrix value</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Yy;
    /// <summary>YZ matrix value</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Yz;
    /// <summary>ZX matrix value</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Zx;
    /// <summary>ZY matrix value</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Zy;
    /// <summary>ZZ matrix value</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Zz;
    /// <summary>Constructor for Matrix3.
    /// </summary>
    /// <param name="Xx">XX matrix value</param>
    /// <param name="Xy">XY matrix value</param>
    /// <param name="Xz">XZ matrix value</param>
    /// <param name="Yx">YX matrix value</param>
    /// <param name="Yy">YY matrix value</param>
    /// <param name="Yz">YZ matrix value</param>
    /// <param name="Zx">ZX matrix value</param>
    /// <param name="Zy">ZY matrix value</param>
    /// <param name="Zz">ZZ matrix value</param>
    /// <since_tizen> 6 </since_tizen>
    public Matrix3(
        double Xx = default(double),
        double Xy = default(double),
        double Xz = default(double),
        double Yx = default(double),
        double Yy = default(double),
        double Yz = default(double),
        double Zx = default(double),
        double Zy = default(double),
        double Zz = default(double)    )
    {
        this.Xx = Xx;
        this.Xy = Xy;
        this.Xz = Xz;
        this.Yx = Yx;
        this.Yy = Yy;
        this.Yz = Yz;
        this.Zx = Zx;
        this.Zy = Zy;
        this.Zz = Zz;
    }

    /// <summary>Unpacks Matrix3 into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out double Xx,
        out double Xy,
        out double Xz,
        out double Yx,
        out double Yy,
        out double Yz,
        out double Zx,
        out double Zy,
        out double Zz
    )
    {
        Xx = this.Xx;
        Xy = this.Xy;
        Xz = this.Xz;
        Yx = this.Yx;
        Yy = this.Yy;
        Yz = this.Yz;
        Zx = this.Zx;
        Zy = this.Zy;
        Zz = this.Zz;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Xx.GetHashCode();
        hash = hash * 23 + Xy.GetHashCode();
        hash = hash * 23 + Xz.GetHashCode();
        hash = hash * 23 + Yx.GetHashCode();
        hash = hash * 23 + Yy.GetHashCode();
        hash = hash * 23 + Yz.GetHashCode();
        hash = hash * 23 + Zx.GetHashCode();
        hash = hash * 23 + Zy.GetHashCode();
        hash = hash * 23 + Zz.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(Matrix3 other)
    {
        return Xx == other.Xx && Xy == other.Xy && Xz == other.Xz && Yx == other.Yx && Yy == other.Yy && Yz == other.Yz && Zx == other.Zx && Zy == other.Zy && Zz == other.Zz        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is Matrix3) ? Equals((Matrix3)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(Matrix3 lhs, Matrix3 rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(Matrix3 lhs, Matrix3 rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Matrix3(IntPtr ptr)
    {
        var tmp = (Matrix3.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Matrix3.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static Matrix3 FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Matrix3.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public double Xx;
        
        public double Xy;
        
        public double Xz;
        
        public double Yx;
        
        public double Yy;
        
        public double Yz;
        
        public double Zx;
        
        public double Zy;
        
        public double Zz;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Matrix3.NativeStruct(Matrix3 _external_struct)
        {
            var _internal_struct = new Matrix3.NativeStruct();
            _internal_struct.Xx = _external_struct.Xx;
            _internal_struct.Xy = _external_struct.Xy;
            _internal_struct.Xz = _external_struct.Xz;
            _internal_struct.Yx = _external_struct.Yx;
            _internal_struct.Yy = _external_struct.Yy;
            _internal_struct.Yz = _external_struct.Yz;
            _internal_struct.Zx = _external_struct.Zx;
            _internal_struct.Zy = _external_struct.Zy;
            _internal_struct.Zz = _external_struct.Zz;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Matrix3(Matrix3.NativeStruct _internal_struct)
        {
            var _external_struct = new Matrix3();
            _external_struct.Xx = _internal_struct.Xx;
            _external_struct.Xy = _internal_struct.Xy;
            _external_struct.Xz = _internal_struct.Xz;
            _external_struct.Yx = _internal_struct.Yx;
            _external_struct.Yy = _internal_struct.Yy;
            _external_struct.Yz = _internal_struct.Yz;
            _external_struct.Zx = _internal_struct.Zx;
            _external_struct.Zy = _internal_struct.Zy;
            _external_struct.Zz = _internal_struct.Zz;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

