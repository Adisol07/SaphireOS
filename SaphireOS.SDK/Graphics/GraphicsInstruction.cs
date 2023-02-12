using SaphireOS.SDK.Mathematics;
using SaphireOS.System.Drivers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing = System.Drawing;

namespace SaphireOS.SDK.Graphics
{
	public interface GraphicsInstruction
	{
		void Render();
	}
	public class SetPointGraphicsInstruction : GraphicsInstruction
	{
		public Vector2 Position { get; set; }
		public Color Color { get; set; }

		public SetPointGraphicsInstruction(Vector2 position, Color color)
		{
			Position = position;
			Color = color;
		}

		public void Render()
		{
			GraphicsDriver.DrawPoint(Position.X, Position.Y, Drawing.Color.FromArgb(Color.A, Color.R, Color.G, Color.B));
		}
	}
	public class FillGraphicsInstruction : GraphicsInstruction
	{
		public Color Color { get; set; }

		public FillGraphicsInstruction(Color color)
		{
			Color = color;
		}

		public void Render()
		{
			GraphicsDriver.Clear(Drawing.Color.FromArgb(Color.A, Color.R, Color.G, Color.B));
		}
	}
	public class RectangleGraphicsInstruction : GraphicsInstruction
	{
		public Vector2 Position { get; set; }
		public Mathematics.Rectangle Rectangle { get; set; }
		public Color Color { get; set; }

		public RectangleGraphicsInstruction(Vector2 pos, Mathematics.Rectangle rectangle, Color color)
		{
			Position = pos;
			Rectangle = rectangle;
			Color = color;
		}

		public void Render()
		{
			GraphicsDriver.DrawRectangle(Position.X, Position.Y, Rectangle.Width, Rectangle.Height, Drawing.Color.FromArgb(Color.A, Color.R, Color.G, Color.B));
		}
	}
	public class FilledRectangleGraphicsInstruction : GraphicsInstruction
	{
		public Vector2 Position { get; set; }
		public Mathematics.Rectangle Rectangle { get; set; }
		public Color Color { get; set; }

		public FilledRectangleGraphicsInstruction(Vector2 pos, Mathematics.Rectangle rectangle, Color color)
		{
			Position = pos;
			Rectangle = rectangle;
			Color = color;
		}

		public void Render()
		{
			GraphicsDriver.FillRectangle(Position.X, Position.Y, Rectangle.Width, Rectangle.Height, Drawing.Color.FromArgb(Color.A, Color.R, Color.G, Color.B));
		}
	}
}
