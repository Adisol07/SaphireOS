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

        public Color()
        { }
        public Color(byte a, byte r, byte g, byte b)
        { A = a; R = r; G = g; B = b; }
        public Color(byte r, byte g, byte b)
        { A = 255; R = r; G = g; B = b; }
    }
}
