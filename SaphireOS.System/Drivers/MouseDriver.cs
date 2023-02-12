using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.System.Drivers
{
    public static class MouseDriver
    {
        public static int X;
        public static int Y;
        public static MouseState State;
        public static int PrevX;
        public static int PrevY;
        public static MouseState PrevState;
        public static List<Tuple<int, int, Color>> SavedPixels;
        public static List<LeftClick> LeftClicks { get; set; }
        public static List<RightClick> RightClicks { get; set; }

        public static void Initialize()
        {
            X = 3;
            Y = 3;
            PrevX = 0;
            PrevY = 0;
            PrevState = MouseState.None;
            SavedPixels = new List<Tuple<int, int, Color>>();
            LeftClicks = new List<LeftClick>();
            RightClicks = new List<RightClick>();
            MouseManager.X = (uint)X;
            MouseManager.Y = (uint)Y;
            MouseManager.MouseState = MouseState.None;
            MouseManager.ScreenHeight = (uint)GraphicsDriver.ScreenY;
            MouseManager.ScreenWidth = (uint)GraphicsDriver.ScreenX;
        }

        public static void HandleMouse()
        {
            X = (int)MouseManager.X;
            Y = (int)MouseManager.Y;
            State = MouseManager.MouseState;

            if (State == MouseState.Left)
            {
                foreach (LeftClick lc in LeftClicks)
                {
                    lc.Invoke(X, Y);
                }
            }
            if (State == MouseState.Right)
            {
                foreach (RightClick rc in RightClicks)
                {
                    rc.Invoke(X, Y);
                }
            }

            if (X >= GraphicsDriver.ScreenX)
            {
                X--;
                MouseManager.X = (uint)X--;
            }
            if (Y >= GraphicsDriver.ScreenY)
            {
                Y--;
                MouseManager.Y = (uint)Y--;
            }
            if (X < 0 ||
                Y < 0 ||
                X == PrevX || Y == PrevY)
                return;

            HideMouse();

            List<Tuple<int, int, Color>> outside = new List<Tuple<int, int, Color>>()
                {
                    new Tuple<int, int, Color>(X, Y, Color.White),
                    new Tuple<int, int, Color>(X, Y + 1, Color.White),
                    new Tuple<int, int, Color>(X, Y + 2, Color.White),
                    new Tuple<int, int, Color>(X, Y + 3, Color.White),
                    new Tuple<int, int, Color>(X, Y + 4, Color.White),
                    new Tuple<int, int, Color>(X, Y + 5, Color.White),
                    new Tuple<int, int, Color>(X, Y + 6, Color.White),
                    new Tuple<int, int, Color>(X, Y + 7, Color.White),
                    new Tuple<int, int, Color>(X, Y + 8, Color.White),
                    new Tuple<int, int, Color>(X, Y + 9, Color.White),
                    new Tuple<int, int, Color>(X, Y + 10, Color.White),
                    new Tuple<int, int, Color>(X + 1, Y + 9, Color.White),
                    new Tuple<int, int, Color>(X + 2, Y + 8, Color.White),
                    new Tuple<int, int, Color>(X + 1, Y + 1, Color.White),
                    new Tuple<int, int, Color>(X + 2, Y + 2, Color.White),
                    new Tuple<int, int, Color>(X + 3, Y + 3, Color.White),
                    new Tuple<int, int, Color>(X + 4, Y + 4, Color.White),
                    new Tuple<int, int, Color>(X + 5, Y + 5, Color.White),
                    new Tuple<int, int, Color>(X + 6, Y + 6, Color.White),
                    new Tuple<int, int, Color>(X + 7, Y + 7, Color.White),
                    new Tuple<int, int, Color>(X + 6, Y + 8, Color.White),
                    new Tuple<int, int, Color>(X + 5, Y + 8, Color.White),
                    new Tuple<int, int, Color>(X + 5, Y + 9, Color.White),
                    new Tuple<int, int, Color>(X + 6, Y + 10, Color.White),
                    new Tuple<int, int, Color>(X + 6, Y + 11, Color.White),
                    new Tuple<int, int, Color>(X + 5, Y + 12, Color.White),
                    new Tuple<int, int, Color>(X + 4, Y + 12, Color.White),
                    new Tuple<int, int, Color>(X + 4, Y + 11, Color.White),
                    new Tuple<int, int, Color>(X + 3, Y + 10, Color.White),
                    new Tuple<int, int, Color>(X + 3, Y + 9, Color.White),
                };
            List<Tuple<int, int, Color>> insideBorder = new List<Tuple<int, int, Color>>()
                {
                    new Tuple<int, int, Color>(X + 1, Y + 2, Color.Gray),
                    new Tuple<int, int, Color>(X + 2, Y + 3, Color.Gray),
                    new Tuple<int, int, Color>(X + 3, Y + 4, Color.Gray),
                    new Tuple<int, int, Color>(X + 4, Y + 5, Color.Gray),
                    new Tuple<int, int, Color>(X + 5, Y + 6, Color.Gray),
                    new Tuple<int, int, Color>(X + 6, Y + 7, Color.Gray),
                };
            List<Tuple<int, int, Color>> inside = new List<Tuple<int, int, Color>>()
                {
                    new Tuple<int, int, Color>(X + 1, Y + 3, Color.Black),
                    new Tuple<int, int, Color>(X + 1, Y + 4, Color.Black),
                    new Tuple<int, int, Color>(X + 2, Y + 4, Color.Black),
                    new Tuple<int, int, Color>(X + 1, Y + 5, Color.Black),
                    new Tuple<int, int, Color>(X + 2, Y + 5, Color.Black),
                    new Tuple<int, int, Color>(X + 3, Y + 5, Color.Black),
                    new Tuple<int, int, Color>(X + 1, Y + 6, Color.Black),
                    new Tuple<int, int, Color>(X + 2, Y + 6, Color.Black),
                    new Tuple<int, int, Color>(X + 3, Y + 6, Color.Black),
                    new Tuple<int, int, Color>(X + 4, Y + 6, Color.Black),
                    new Tuple<int, int, Color>(X + 1, Y + 7, Color.Black),
                    new Tuple<int, int, Color>(X + 2, Y + 7, Color.Black),
                    new Tuple<int, int, Color>(X + 3, Y + 7, Color.Black),
                    new Tuple<int, int, Color>(X + 4, Y + 7, Color.Black),
                    new Tuple<int, int, Color>(X + 5, Y + 7, Color.Black),
                    new Tuple<int, int, Color>(X + 1, Y + 8, Color.Black),
                    new Tuple<int, int, Color>(X + 3, Y + 8, Color.Black),
                    new Tuple<int, int, Color>(X + 4, Y + 8, Color.Black),
                    new Tuple<int, int, Color>(X + 4, Y + 9, Color.Black),
                    new Tuple<int, int, Color>(X + 4, Y + 10, Color.Black),
                    new Tuple<int, int, Color>(X + 5, Y + 10, Color.Black),
                    new Tuple<int, int, Color>(X + 5, Y + 11, Color.Black),
                };

            List<Tuple<int, int, Color>> cursor = new List<Tuple<int, int, Color>>();
            cursor.AddRange(outside);
            cursor.AddRange(insideBorder);
            cursor.AddRange(inside);

            foreach (Tuple<int, int, Color> c in cursor)
            {
                Color pix = GraphicsDriver.GetPoint(c.Item1, c.Item2);
                Tuple<int, int, Color> save = new Tuple<int, int, Color>(c.Item1, c.Item2, pix);
                SavedPixels.Add(save);
            }

            foreach (Tuple<int, int, Color> t in cursor)
            {
                GraphicsDriver.DrawPoint(t.Item1, t.Item2, t.Item3);
            }
            GraphicsDriver.SwapBuffers();

            PrevX = X;
            PrevY = Y;
            PrevState = State;
        }

        public static void HideMouse()
        {
            foreach (Tuple<int, int, Color> tuple in SavedPixels)
            {
                GraphicsDriver.DrawPoint(tuple.Item1, tuple.Item2, tuple.Item3);
            }
            SavedPixels.Clear();
            GraphicsDriver.SwapBuffers();
        }

        public delegate void LeftClick(int x, int y);
        public delegate void RightClick(int x, int y);
    }
}
