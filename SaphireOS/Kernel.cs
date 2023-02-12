using SaphireOS.System.Drivers;
using SaphireOS.System;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Drawing = System.Drawing;
using SaphireOS.HighLevel;
using SaphireOS.SDK.Graphics;

namespace SaphireOS
{
	public class Kernel : Sys.Kernel
	{
		//Loading of everything
		protected override void BeforeRun()
		{
			Console.Clear();
			Shell.CPULog(new LogPart("[Loading]", ConsoleColor.DarkYellow),
						 new LogPart(" Loading SaphireOS..", ConsoleColor.Gray));
			Shell.CPULog(new LogPart("[Loading]", ConsoleColor.DarkYellow),
						 new LogPart(" Loading FileSystem Driver.. ", ConsoleColor.Gray),
						 new LogPart("\n\\SaphireOS.System.Drivers.FileSystemDriver\\", ConsoleColor.DarkGray));
			FileSystemDriver.Initialize();
			Shell.CPULog(new LogPart("[Loading]", ConsoleColor.DarkYellow),
						 new LogPart(" Loading Graphics Driver.. ", ConsoleColor.Gray),
						 new LogPart("\n\\SaphireOS.System.Drivers.GraphicsDriver\\", ConsoleColor.DarkGray));
			GraphicsDriver.Initialize();
			Shell.CPULog(new LogPart("[Loading]", ConsoleColor.DarkYellow),
						 new LogPart(" Loading Input Drivers.. ", ConsoleColor.Gray),
						 new LogPart("\n\\SaphireOS.System.Drivers.MouseDriver\\\n\\SaphireOS.System.Drivers.KeyboardDriver\\", ConsoleColor.DarkGray));
			MouseDriver.Initialize();
			KeyboardDriver.Initialize();
			Shell.CPULog(new LogPart("[Loading]", ConsoleColor.DarkGreen),
						 new LogPart(" Loading from ", ConsoleColor.Gray),
						 new LogPart("\\BeforeRun\\", ConsoleColor.DarkGray),
						 new LogPart(" is ", ConsoleColor.Gray),
						 new LogPart("done", ConsoleColor.Green),
						 new LogPart("!", ConsoleColor.Gray));

			Layer loadingLayer = new Layer();
			loadingLayer.Level = 0;
			loadingLayer.IsVisible = true;

			Graphics loadingGraphics = new Graphics(loadingLayer);
			loadingGraphics.Fill(Color.Green);

			LayerManager.Layers.Add(loadingLayer);
		}

		//Main loop
		protected override void Run()
		{
			GraphicsDriver.Clear(Drawing.Color.Black);
			LayerManager.RenderAll();
			KeyboardDriver.HandleKeyboard();
			MouseDriver.HandleMouse();
			Cosmos.Core.Memory.Heap.Collect();
		}
	}
}
