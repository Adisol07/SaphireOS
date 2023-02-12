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
        public List<GraphicsInstruction> Instructions { get; set; } = new List<GraphicsInstruction>();
        public bool IsVisible { get; set; } = false;
        public int Level { get; set; } = 0;
        public bool NeedUpdate { get; set; } = false;

        public void Render()
        {
            if (IsVisible == false)
                return;
            foreach (var i in Instructions)
            {
                i.Render();
            }
            GraphicsDriver.SwapBuffers();
        }
    }
}
