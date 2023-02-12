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
        private Bitmap bitmap = null;
        public Color[] Pixels { get; set; } = new Color[0];
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;

        public Image()
        { }
        public Image(byte[] raw)
        { bitmap = new Bitmap(raw); load(); }
        public Image(string path)
        { bitmap = new Bitmap(File.ReadAllBytes(path)); load(); }

        public int[] GetRaw()
        { return bitmap.rawData; }

        private void load()
        {
            Width = (int)bitmap.Width;
            Height = (int)bitmap.Height;
            loadPixels();
        }
        private void loadPixels()
        {
            List<Color> bC = new List<Color>();
            foreach (int i in bitmap.rawData)
            {
                dw.Color clr = dw.Color.FromArgb(i);
                bC.Add(new Color(clr.A, clr.R, clr.G, clr.B));
            }
			Pixels = bC.ToArray();
		}
    }
}
