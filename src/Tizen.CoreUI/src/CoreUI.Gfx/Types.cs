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
namespace CoreUI.Gfx {
/// <summary>CoreUI alignment type: As a horizontal component, 0.0 means the start of the axis in the direction that the current language reads, 1.0 means the end of the axis.
/// 
/// As a vertical component, 0.0 is the top, 1.0 is the bottom.
/// 
/// The default for this type is always 0.5 unless explicitly specified.</summary>
/// <since_tizen> 6 </since_tizen>
public struct Align : IEquatable<Align>
{
    private double payload;

    /// <summary>Converts an instance of double to this struct.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    /// <since_tizen> 6 </since_tizen>
    public static implicit operator Align(double value)
    {
        return new Align{payload=value};
    }

    /// <summary>Converts an instance of this struct to double.
    /// </summary>
    /// <param name="value">The value to be converted packed in this struct.</param>
    /// <returns>The actual value the alias is wrapping.</returns>
    /// <since_tizen> 6 </since_tizen>
    public static implicit operator double(Align value)
    {
        return value.payload;
    }
    /// <summary>Converts an instance of double to this struct.</summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>A struct with the given value.</returns>
    public static Align FromDouble(double value)
    {
        return value;
    }

    /// <summary>Converts an instance of this struct to double.</summary>
    /// <returns>The actual value the alias is wrapping.</returns>
    public double ToDouble()
    {
        return this;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode() => payload.GetHashCode();
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(Align other) => payload == other.payload;
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is Align) ? Equals((Align)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(Align lhs, Align rhs)
        => lhs.payload == rhs.payload;
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(Align lhs, Align rhs)
        => lhs.payload != rhs.payload;
}
}

namespace CoreUI.Gfx {
/// <summary>Graphics render operation mode</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public enum RenderOp
{
/// <summary>Alpha blending onto destination (default); d = d*(1-sa) + s.</summary>
/// <since_tizen> 6 </since_tizen>
Blend = 0,
/// <summary>Copy source to destination; d = s.</summary>
/// <since_tizen> 6 </since_tizen>
Copy = 1,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
/// <since_tizen> 6 </since_tizen>
Last = 2,
}
}

namespace CoreUI.Gfx {
/// <summary>These values determine how the points are interpreted in a stream of points.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public enum PathCommandType
{
/// <summary>The end of stream , no more points to process.</summary>
/// <since_tizen> 6 </since_tizen>
End = 0,
/// <summary>The next point is the start point of a sub path.</summary>
/// <since_tizen> 6 </since_tizen>
MoveTo = 1,
/// <summary>The next point is used to draw a line from current point.</summary>
/// <since_tizen> 6 </since_tizen>
LineTo = 2,
/// <summary>The next three point is used to draw a cubic bezier curve from current point.</summary>
/// <since_tizen> 6 </since_tizen>
CubicTo = 3,
/// <summary>Close the current subpath by drawing a line between current point and the first point of current subpath.</summary>
/// <since_tizen> 6 </since_tizen>
Close = 4,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
/// <since_tizen> 6 </since_tizen>
Last = 5,
}
}

namespace CoreUI.Gfx {
/// <summary>These values determine how the end of opened sub-paths are rendered in a stroke. <span class="text-muted">CoreUI.Gfx.IShape.SetStrokeCap (object still in beta stage)</span></summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public enum Cap
{
/// <summary>The end of lines is rendered as a full stop on the last point itself.</summary>
/// <since_tizen> 6 </since_tizen>
Butt = 0,
/// <summary>The end of lines is rendered as a half-circle around the last point.</summary>
/// <since_tizen> 6 </since_tizen>
Round = 1,
/// <summary>The end of lines is rendered as a square around the last point.</summary>
/// <since_tizen> 6 </since_tizen>
Square = 2,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
/// <since_tizen> 6 </since_tizen>
Last = 3,
}
}

namespace CoreUI.Gfx {
/// <summary>These values determine how two joining lines are rendered in a stroker. <span class="text-muted">CoreUI.Gfx.IShape.SetStrokeJoin (object still in beta stage)</span></summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public enum Join
{
/// <summary>Used to render rounded line joins. Circular arcs are used to join two lines smoothly.</summary>
/// <since_tizen> 6 </since_tizen>
Miter = 0,
/// <summary>Used to render beveled line joins. The outer corner of the joined lines is filled by enclosing the triangular region of the corner with a straight line between the outer corners of each stroke.</summary>
/// <since_tizen> 6 </since_tizen>
Round = 1,
/// <summary>Used to render mitered line joins. The intersection of the strokes is clipped at a line perpendicular to the bisector of the angle between the strokes, at the distance from the intersection of the segments equal to the product of the miter limit value and the border radius.  This prevents long spikes being created.</summary>
/// <since_tizen> 6 </since_tizen>
Bevel = 2,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
/// <since_tizen> 6 </since_tizen>
Last = 3,
}
}

namespace CoreUI.Gfx {
/// <summary>Specifies how the area outside the gradient area should be filled. <span class="text-muted">CoreUI.Gfx.IGradient.SetSpread (object still in beta stage)</span></summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public enum GradientSpread
{
/// <summary>The area is filled with the closest stop color. This is the default.</summary>
/// <since_tizen> 6 </since_tizen>
Pad = 0,
/// <summary>The gradient is reflected outside the gradient area.</summary>
/// <since_tizen> 6 </since_tizen>
Reflect = 1,
/// <summary>The gradient is repeated outside the gradient area.</summary>
/// <since_tizen> 6 </since_tizen>
Repeat = 2,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
/// <since_tizen> 6 </since_tizen>
Last = 3,
}
}

namespace CoreUI.Gfx {
/// <summary>How an image&apos;s center region (the complement to the border region) should be rendered by EFL</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public enum CenterFillMode
{
/// <summary>Image&apos;s center region is <c>not</c> to be rendered</summary>
/// <since_tizen> 6 </since_tizen>
None = 0,
/// <summary>Image&apos;s center region is to be <c>blended</c> with objects underneath it, if it has transparency. This is the default behavior for image objects</summary>
/// <since_tizen> 6 </since_tizen>
Default = 1,
/// <summary>Image&apos;s center region is to be made solid, even if it has transparency on it</summary>
/// <since_tizen> 6 </since_tizen>
Solid = 2,
}
}

namespace CoreUI.Gfx {
/// <summary>What property got changed for this object</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public enum ChangeFlag
{
/// <summary>Nothing changed.</summary>
/// <since_tizen> 6 </since_tizen>
None = 0,
/// <summary>Matrix got changed.</summary>
/// <since_tizen> 6 </since_tizen>
Matrix = 1,
/// <summary>Path got changed.</summary>
/// <since_tizen> 6 </since_tizen>
Path = 2,
/// <summary>Coloring or fill information changed, not geometry.</summary>
/// <since_tizen> 6 </since_tizen>
Fill = 4,
/// <summary>All properties got changed.</summary>
/// <since_tizen> 6 </since_tizen>
All = 65535,
}
}

namespace CoreUI.Gfx {
/// <summary>Aspect types/policies for scaling size hints.
/// 
/// See also <see cref="CoreUI.Gfx.IHint.HintAspect"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public enum HintAspect
{
/// <summary>No preference on either direction of the container for aspect ratio control.</summary>
/// <since_tizen> 6 </since_tizen>
None = 0,
/// <summary>Same effect as disabling aspect ratio preference</summary>
/// <since_tizen> 6 </since_tizen>
Neither = 1,
/// <summary>Use all horizontal container space to place an object, using the given aspect.</summary>
/// <since_tizen> 6 </since_tizen>
Horizontal = 2,
/// <summary>Use all vertical container space to place an object, using the given aspect.</summary>
/// <since_tizen> 6 </since_tizen>
Vertical = 3,
/// <summary>Use all horizontal and vertical container spaces to place an object (never growing it out of those bounds), using the given aspect.</summary>
/// <since_tizen> 6 </since_tizen>
Both = 4,
}
}

namespace CoreUI.Gfx {
/// <summary>Type describing dash. <span class="text-muted">CoreUI.Gfx.IShape.SetStrokeDash (object still in beta stage)</span></summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct Dash : IEquatable<Dash>
{
    /// <summary>Dash drawing length.</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Length;
    /// <summary>Distance between two dashes.</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Gap;
    /// <summary>Constructor for Dash.
    /// </summary>
    /// <param name="Length">Dash drawing length.</param>
    /// <param name="Gap">Distance between two dashes.</param>
    /// <since_tizen> 6 </since_tizen>
    public Dash(
        double Length = default(double),
        double Gap = default(double)    )
    {
        this.Length = Length;
        this.Gap = Gap;
    }

    /// <summary>Packs tuple into Dash object.
    ///<para>Since EFL 1.24.</para>
    ///</summary>
    public static implicit operator Dash(
        (
         double Length,
         double Gap
        ) tuple)
    {
        return new Dash{
            Length = tuple.Length,
            Gap = tuple.Gap,
        };
    }
    /// <summary>Unpacks Dash into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out double Length,
        out double Gap
    )
    {
        Length = this.Length;
        Gap = this.Gap;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Length.GetHashCode();
        hash = hash * 23 + Gap.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(Dash other)
    {
        return Length == other.Length && Gap == other.Gap        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is Dash) ? Equals((Dash)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(Dash lhs, Dash rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(Dash lhs, Dash rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Dash(IntPtr ptr)
    {
        var tmp = (Dash.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Dash.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static Dash FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Dash.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public double Length;
        
        public double Gap;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Dash.NativeStruct(Dash _external_struct)
        {
            var _internal_struct = new Dash.NativeStruct();
            _internal_struct.Length = _external_struct.Length;
            _internal_struct.Gap = _external_struct.Gap;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Dash(Dash.NativeStruct _internal_struct)
        {
            var _external_struct = new Dash();
            _external_struct.Length = _internal_struct.Length;
            _external_struct.Gap = _internal_struct.Gap;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.Gfx {
/// <summary>Type defining gradient stops. Describes the location and color of a transition point in a gradient.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct GradientStop : IEquatable<GradientStop>
{
    /// <summary>The location of the gradient stop within the gradient vector</summary>
    /// <since_tizen> 6 </since_tizen>
    public double Offset;
    /// <summary>The component R color of the gradient stop</summary>
    /// <since_tizen> 6 </since_tizen>
    public int R;
    /// <summary>The component G color of the gradient stop</summary>
    /// <since_tizen> 6 </since_tizen>
    public int G;
    /// <summary>The component B color of the gradient stop</summary>
    /// <since_tizen> 6 </since_tizen>
    public int B;
    /// <summary>The component A color of the gradient stop</summary>
    /// <since_tizen> 6 </since_tizen>
    public int A;
    /// <summary>Constructor for GradientStop.
    /// </summary>
    /// <param name="Offset">The location of the gradient stop within the gradient vector</param>
    /// <param name="R">The component R color of the gradient stop</param>
    /// <param name="G">The component G color of the gradient stop</param>
    /// <param name="B">The component B color of the gradient stop</param>
    /// <param name="A">The component A color of the gradient stop</param>
    /// <since_tizen> 6 </since_tizen>
    public GradientStop(
        double Offset = default(double),
        int R = default(int),
        int G = default(int),
        int B = default(int),
        int A = default(int)    )
    {
        this.Offset = Offset;
        this.R = R;
        this.G = G;
        this.B = B;
        this.A = A;
    }

    /// <summary>Unpacks GradientStop into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out double Offset,
        out int R,
        out int G,
        out int B,
        out int A
    )
    {
        Offset = this.Offset;
        R = this.R;
        G = this.G;
        B = this.B;
        A = this.A;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Offset.GetHashCode();
        hash = hash * 23 + R.GetHashCode();
        hash = hash * 23 + G.GetHashCode();
        hash = hash * 23 + B.GetHashCode();
        hash = hash * 23 + A.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(GradientStop other)
    {
        return Offset == other.Offset && R == other.R && G == other.G && B == other.B && A == other.A        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is GradientStop) ? Equals((GradientStop)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(GradientStop lhs, GradientStop rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(GradientStop lhs, GradientStop rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator GradientStop(IntPtr ptr)
    {
        var tmp = (GradientStop.NativeStruct)Marshal.PtrToStructure(ptr, typeof(GradientStop.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static GradientStop FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct GradientStop.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public double Offset;
        
        public int R;
        
        public int G;
        
        public int B;
        
        public int A;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator GradientStop.NativeStruct(GradientStop _external_struct)
        {
            var _internal_struct = new GradientStop.NativeStruct();
            _internal_struct.Offset = _external_struct.Offset;
            _internal_struct.R = _external_struct.R;
            _internal_struct.G = _external_struct.G;
            _internal_struct.B = _external_struct.B;
            _internal_struct.A = _external_struct.A;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator GradientStop(GradientStop.NativeStruct _internal_struct)
        {
            var _external_struct = new GradientStop();
            _external_struct.Offset = _internal_struct.Offset;
            _external_struct.R = _internal_struct.R;
            _external_struct.G = _internal_struct.G;
            _external_struct.B = _internal_struct.B;
            _external_struct.A = _internal_struct.A;
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

namespace CoreUI.Gfx.Event {
/// <summary>Data sent along a &quot;render,post&quot; event, after a frame has been rendered.</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[CoreUI.Wrapper.BindingEntity]
[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
public struct RenderPost : IEquatable<RenderPost>
{
    /// <summary>A list of rectangles that were updated in the canvas.</summary>
    /// <since_tizen> 6 </since_tizen>
    public IList<CoreUI.DataTypes.Rect> Updated_area;
    /// <summary>Constructor for RenderPost.
    /// </summary>
    /// <param name="Updated_area">A list of rectangles that were updated in the canvas.</param>
    /// <since_tizen> 6 </since_tizen>
    public RenderPost(
        IList<CoreUI.DataTypes.Rect> Updated_area = default(IList<CoreUI.DataTypes.Rect>)    )
    {
        this.Updated_area = Updated_area;
    }

    /// <summary>Unpacks RenderPost into tuple.
    /// <para>Since EFL 1.24.</para>
    /// </summary>
    public void Deconstruct(
        out IList<CoreUI.DataTypes.Rect> Updated_area
    )
    {
        Updated_area = this.Updated_area;
    }
    /// <summary>Get a hash code for this item.
    /// </summary>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Updated_area.GetHashCode();
        return hash;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public bool Equals(RenderPost other)
    {
        return Updated_area == other.Updated_area        ;
    }
    /// <summary>Equality comparison.
    /// </summary>
    public override bool Equals(object other)
        => ((other is RenderPost) ? Equals((RenderPost)other) : false);
    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator ==(RenderPost lhs, RenderPost rhs)
        => lhs.Equals(rhs);    /// <summary>Equality comparison.
    /// </summary>
    public static bool operator !=(RenderPost lhs, RenderPost rhs)
        => !lhs.Equals(rhs);    /// <summary>Implicit conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator RenderPost(IntPtr ptr)
    {
        var tmp = (RenderPost.NativeStruct)Marshal.PtrToStructure(ptr, typeof(RenderPost.NativeStruct));
        return tmp;
    }

    /// <summary>Conversion to the managed representation from a native pointer.
    /// </summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static RenderPost FromIntPtr(IntPtr ptr)
    {
        return ptr;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct RenderPost.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeStruct
    {
        
        public System.IntPtr Updated_area;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator RenderPost.NativeStruct(RenderPost _external_struct)
        {
            var _internal_struct = new RenderPost.NativeStruct();
            _internal_struct.Updated_area = CoreUI.Wrapper.Globals.IListToNativeList(_external_struct.Updated_area, false);
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator RenderPost(RenderPost.NativeStruct _internal_struct)
        {
            var _external_struct = new RenderPost();
            _external_struct.Updated_area = CoreUI.Wrapper.Globals.NativeListToIList<CoreUI.DataTypes.Rect>(_internal_struct.Updated_area);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}

