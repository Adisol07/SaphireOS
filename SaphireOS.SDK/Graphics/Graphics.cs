﻿using SaphireOS.SDK.Mathematics;
using SaphireOS.System.Drivers;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void DrawPoint(Vector2 pos, Color color)
        {
            Layer.Instructions.Add(new SetPointGraphicsInstruction(pos, color));
            Layer.NeedUpdate = true;
        }
        public void DrawPoint(int x, int y, Color color) => DrawPoint(new Vector2(x, y), color);
        public void Fill(Color color)
        {
			Layer.Instructions.Add(new FillGraphicsInstruction(color));
			Layer.NeedUpdate = true;
		}
        public void Clear(Color color) => Fill(color);
        public void DrawRectangle(Vector2 pos, Mathematics.Rectangle rectangle, Color color)
        {
            Layer.Instructions.Add(new RectangleGraphicsInstruction(pos, rectangle, color));
			Layer.NeedUpdate = true;
		}
        public void FillRectangle(Vector2 pos, Mathematics.Rectangle rectangle, Color color)
        {
			Layer.Instructions.Add(new FilledRectangleGraphicsInstruction(pos, rectangle, color));
			Layer.NeedUpdate = true;
		}
    }
}
