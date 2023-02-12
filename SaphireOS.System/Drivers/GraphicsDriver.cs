﻿using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.System.Drivers
{
    public static class GraphicsDriver
    {
        public static Canvas Screen { get; private set; }
        public static int ScreenX { get; private set; }
        public static int ScreenY { get; private set; }

        public static void Initialize()
        {
            ScreenX = 1280;
            ScreenY = 720;
            Screen = FullScreenCanvas.GetFullScreenCanvas(new Mode(ScreenX, ScreenY, ColorDepth.ColorDepth32));
            Clear(Color.Black);
            SwapBuffers();
        }

        public static Color GetPoint(int x, int y)
        {
            return Screen.GetPointColor(x, y);
        }
        public static void DrawPoint(int x, int y, Color color)
        {
            Screen.DrawPoint(new Pen(color), new Cosmos.System.Graphics.Point(x, y));
        }
        public static void Clear(Color color)
        {
            Screen.Clear(color);
        }
        public static void Display() => SwapBuffers();
        public static void SwapBuffers()
        {
            Screen.Display();
        }
    }
}
