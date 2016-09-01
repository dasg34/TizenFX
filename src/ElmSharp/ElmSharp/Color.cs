using System;
using System.Globalization;

namespace ElmSharp
{
    public struct Color
    {
        readonly int _a;
        readonly int _r;
        readonly int _g;
        readonly int _b;

        public int A
        {
            get { return _a; }
        }

        public int R
        {
            get { return _r; }
        }

        public int G
        {
            get { return _g; }
        }

        public int B
        {
            get { return _b; }
        }

        public Color(int r, int g, int b) : this(r, g, b, 255)
        {
        }

        public Color(int r, int g, int b, int a)
        {
            _r = Clamp(r, 0, 255);
            _g = Clamp(g, 0, 255);
            _b = Clamp(b, 0, 255);
            _a = Clamp(a, 0, 255);
        }

        public override int GetHashCode()
        {
            int hashcode = _r.GetHashCode();
            hashcode = (hashcode * 397) ^ _g.GetHashCode();
            hashcode = (hashcode * 397) ^ _b.GetHashCode();
            hashcode = (hashcode * 397) ^ _a.GetHashCode();
            return hashcode;
        }

        public override bool Equals(object obj)
        {
            if (obj is Color)
            {
                return EqualsInner(this, (Color)obj);
            }
            return base.Equals(obj);
        }

        static bool EqualsInner(Color color1, Color color2)
        {
            return color1._r == color2._r && color1._g == color2._g && color1._b == color2._b && color1._a == color2._a;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[Color: R={0}, G={1}, B={2}, A={3}]", R, G, B, A);
        }

        public static Color FromHex(string hex)
        {
            hex = hex.Replace("#", "");
            switch (hex.Length)
            {
                case 3: //#rgb => ffrrggbb
                    hex = string.Format("ff{0}{1}{2}{3}{4}{5}", hex[0], hex[0], hex[1], hex[1], hex[2], hex[2]);
                    break;
                case 4: //#argb => aarrggbb
                    hex = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", hex[0], hex[0], hex[1], hex[1], hex[2], hex[2], hex[3], hex[3]);
                    break;
                case 6: //#rrggbb => ffrrggbb
                    hex = string.Format("ff{0}", hex);
                    break;
            }
            return FromUint(Convert.ToUInt32(hex.Replace("#", ""), 16));
        }

        public static Color FromUint(uint argb)
        {
            return FromRgba((byte)((argb & 0x00ff0000) >> 0x10), (byte)((argb & 0x0000ff00) >> 0x8), (byte)(argb & 0x000000ff), (byte)((argb & 0xff000000) >> 0x18));
        }

        public static Color FromRgba(int r, int g, int b, int a)
        {
            return new Color(r, g, b, a);
        }

        public static Color FromRgb(int r, int g, int b)
        {
            return FromRgba(r, g, b, 255);
        }

        internal static int Clamp(int self, int min, int max)
        {
            return Math.Min(max, Math.Max(self, min));
        }

        #region Color Definitions
        public static readonly Color Transparent = FromRgba(0, 0, 0, 0);
        public static readonly Color Aqua = FromRgb(0, 255, 255);
        public static readonly Color Black = FromRgb(0, 0, 0);
        public static readonly Color Blue = FromRgb(0, 0, 255);
        public static readonly Color Fuchsia = FromRgb(255, 0, 255);
        public static readonly Color Gray = FromRgb(128, 128, 128);
        public static readonly Color Green = FromRgb(0, 128, 0);
        public static readonly Color Lime = FromRgb(0, 255, 0);
        public static readonly Color Maroon = FromRgb(128, 0, 0);
        public static readonly Color Navy = FromRgb(0, 0, 128);
        public static readonly Color Olive = FromRgb(128, 128, 0);
        public static readonly Color Orange = FromRgb(255, 165, 0);
        public static readonly Color Purple = FromRgb(128, 0, 128);
        public static readonly Color Pink = FromRgb(255, 102, 255);
        public static readonly Color Red = FromRgb(255, 0, 0);
        public static readonly Color Silver = FromRgb(192, 192, 192);
        public static readonly Color Teal = FromRgb(0, 128, 128);
        public static readonly Color White = FromRgb(255, 255, 255);
        public static readonly Color Yellow = FromRgb(255, 255, 0);
        #endregion
    }
}
