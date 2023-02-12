using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.SDK.Graphics
{
    public class Color
    {
        public byte A { get; } = 0;
        public byte R { get; } = 0;
        public byte G { get; } = 0;
        public byte B { get; } = 0;

        public static Color Transparent => new Color(0, 0, 0, 0);
        public static Color White => new Color(255, 255, 255, 255);
        public static Color Black => new Color(255, 0, 0, 0);
        public static Color Red => new Color(255, 255, 0, 0);
        public static Color Green => new Color(255, 0, 255, 0);
        public static Color Blue => new Color(255, 0, 0, 255);
        public static Color Yellow => new Color(255, 255, 255, 0);
        public static Color Pink => new Color(255, 255, 192, 203);
        public static Color Brown => new Color(255, 160, 82, 45);

        public Color()
        { }
        public Color(byte a, byte r, byte g, byte b)
        { A = a; R = r; G = g; B = b; }
        public Color(byte r, byte g, byte b)
        { A = 255; R = r; G = g; B = b; }

        public static bool operator ==(Color left, Color right)
        {
            if (left.A == right.A && left.R == right.R && left.G == right.G && left.B == right.B)
            {
                return true;
            }
            else
                return false;
        }
		public static bool operator !=(Color left, Color right)
		{
			if (left.A != right.A || left.R != right.R || left.G != right.G || left.B != right.B)
			{
				return true;
			}
			else
				return false;
		}
		public static Color operator +(Color left, Color right)
		{
			return new Color((byte)(left.A + right.A), (byte)(left.R + right.R), (byte)(left.G + right.G), (byte)(left.B + right.B));
		}
		public static Color operator +(Color left, int num)
		{
			return new Color((byte)(left.A + num), (byte)(left.R + num), (byte)(left.G + num), (byte)(left.B + num));
		}
		public static Color operator -(Color left, Color right)
		{
			return new Color((byte)(left.A - right.A), (byte)(left.R - right.R), (byte)(left.G - right.G), (byte)(left.B - right.B));
		}
		public static Color operator -(Color left, int num)
		{
			return new Color((byte)(left.A - num), (byte)(left.R - num), (byte)(left.G - num), (byte)(left.B - num));
		}
		public static Color operator ++(Color left)
		{
			return new Color((byte)(left.A + 1), (byte)(left.R + 1), (byte)(left.G + 1), (byte)(left.B + 1));
		}
		public static Color operator --(Color left)
		{
			return new Color((byte)(left.A - 1), (byte)(left.R - 1), (byte)(left.G - 1), (byte)(left.B - 1));
		}
		public static Color operator *(Color left, Color right)
        {
            return new Color((byte)(left.A * right.A), (byte)(left.R * right.R), (byte)(left.G * right.G), (byte)(left.B * right.B));
        }
		public static Color operator /(Color left, Color right)
		{
			return new Color((byte)(left.A / right.A), (byte)(left.R / right.R), (byte)(left.G / right.G), (byte)(left.B / right.B));
		}
	}
}
