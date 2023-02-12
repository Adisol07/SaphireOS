using SaphireOS.SDK.Mathematics;
using SaphireOS.System.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing = System.Drawing;

namespace SaphireOS.SDK.Graphics
{
    public class Layer
    {
        public List<Tuple<Vector2, Color>> Instructions { get; set; } = new List<Tuple<Vector2, Color>>();
        public bool IsVisible { get; set; } = false;
        public int Level { get; set; } = 0;

        public void Render()
        {
            if (IsVisible == false)
                return;
            foreach (var i in Instructions)
            {
                GraphicsDriver.DrawPoint(i.Item1.X, i.Item1.Y, Drawing.Color.FromArgb(i.Item2.A, i.Item2.R, i.Item2.G, i.Item2.B));
            }
            GraphicsDriver.SwapBuffers();
        }
    }
}
