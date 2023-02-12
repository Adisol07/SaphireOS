using SaphireOS.System.Drivers;
using SaphireOS.System;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Drawing = System.Drawing;
using SaphireOS.HighLevel;
using SaphireOS.SDK.Graphics;
using System.Threading;
using SaphireOS.SDK;
using SaphireOS.HighLevel.Layers;
using Cosmos.HAL;

namespace SaphireOS
{
	public class Kernel : Sys.Kernel
	{
		//Loading of everything
		protected override void BeforeRun()
		{
			//Shell loading, error catching
			try
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
			}
			catch (Exception ex)
			{
				Shell.CPULog(new LogPart("[Critical_Error]: ", ConsoleColor.Red), 
							 new LogPart((char)34 + ex.Message + (char)34, ConsoleColor.White));
				Shell.CPULog(new LogPart("[User] ", ConsoleColor.Yellow),
							 new LogPart("Press ANY key to shutdown your computer", ConsoleColor.White));
				Shell.CPUGetKey();
				Stop();
			}
			//Layering loading, error catching
			try
			{
				throw new Exception("Example error");
			}
			catch (Exception ex)
			{
				ErrorLayer errorLayer = new ErrorLayer(ex.Message, "000-000-000 -> Example", "Loading: Basic Layers", true);
				LayerManager.Layers.Add(errorLayer);
				KeyboardDriver.KeyPresses.Add(new KeyboardDriver.KeyPress((key) =>
				{
					Restart();
				}));
			}
		}

		//Main loop
		protected override void Run()
		{
			//Main Loop, error catching
			try
			{
				LayerManager.HandleLayers();
				KeyboardDriver.HandleKeyboard();
				MouseDriver.HandleMouse();
				Cosmos.Core.Memory.Heap.Collect();
			}
			catch (Exception ex)
			{
				ErrorLayer errorLayer = new ErrorLayer(ex.Message, "000-000-000", "Main Loop", false);
				LayerManager.Layers.Add(errorLayer);
				LayerManager.HandleLayers();
				Shell.CPUGetKey();
				Restart();
			}
		}
	}
}
