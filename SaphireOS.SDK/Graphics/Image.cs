using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dw = System.Drawing;

namespace SaphireOS.SDK.Graphics
{
    public class Image
    {
        private Bitmap bitmap;
        public Color[] Pixels { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Image()
        { }
        public Image(byte[] raw)
        { bitmap = new Bitmap(raw); loadPixels(); }
        public Image(string path)
        { bitmap = new Bitmap(File.ReadAllBytes(path)); loadPixels(); }

        public int[] GetRaw()
        { return bitmap.rawData; }

        private void loadPixels()
        {
            Pixels = new Color[bitmap.rawData.Length - 1];
            int index = 0;
            foreach (int i in bitmap.rawData)
            {
                dw.Color clr = dw.Color.FromArgb(i);
                Pixels[index] = new Color(clr.A, clr.R, clr.G, clr.B);
                index++;
            }
        }
    }
}
