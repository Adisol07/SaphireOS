using SaphireOS.System.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.SDK.Graphics
{
    public class Graphics
    {
        public Layer Layer { get; set; }

        public Graphics(Layer layer)
        { Layer = layer; }

        public void Fill(Color color)
        {
            for (int x = 0; x < GraphicsDriver.ScreenX; x++)
            {
                for (int y = 0; y < GraphicsDriver.ScreenY; y++)
                {
                    Layer.Instructions.Add(new Tuple<SDK.Mathematics.Vector2, Color>(new SDK.Mathematics.Vector2(x, y), color));
                }
            }
        }
        public void Clear(Color color) => Fill(color);
    }
}
