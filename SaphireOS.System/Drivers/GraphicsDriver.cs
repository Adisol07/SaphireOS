using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
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
        public static void DrawRectangle(int x, int y, int width, int height, Color color)
        {
            Screen.DrawRectangle(new Pen(color), new Cosmos.System.Graphics.Point(x, y), width, height);
        }
        public static void FillRectangle(int x, int y, int width, int height, Color color)
        {
            Screen.DrawFilledRectangle(new Pen(color), new Cosmos.System.Graphics.Point(x, y), width, height);
        }
        public static void DrawLine(int x1, int y1, int x2, int y2, Color color)
        {
            Screen.DrawLine(new Pen(color), new Cosmos.System.Graphics.Point(x1, y1), new Cosmos.System.Graphics.Point(x2, y2));
        }
        public static void DrawString(int x, int y, string str, Font font, Color color)
        {
            Screen.DrawString(str, font, new Pen(color), new Cosmos.System.Graphics.Point(x, y));
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
