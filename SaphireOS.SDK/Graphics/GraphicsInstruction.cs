using Cosmos.System.Graphics.Fonts;
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
	public class LineGraphicsInstruction : GraphicsInstruction
	{
		public Vector2 StartPosition { get; set; }
		public Vector2 EndPosition { get; set; }
		public Color Color { get; set; }

		public LineGraphicsInstruction(Vector2 startPosition, Vector2 endPosition, Color color)
		{
			StartPosition = startPosition;
			EndPosition = endPosition;
			Color = color;
		}

		public void Render()
		{
			GraphicsDriver.DrawLine(StartPosition.X, StartPosition.Y, EndPosition.X, EndPosition.Y, Drawing.Color.FromArgb(Color.A, Color.R, Color.G, Color.B));
		}
	}
	public class ImageGraphicsInstruction : GraphicsInstruction
	{
		public Vector2 Position { get; set; }
		public Image Image { get; set; }

		public ImageGraphicsInstruction(Vector2 position, Image image)
		{
			Position = position;
			Image = image;
		}

		public void Render()
		{
			int cWidth = 0;
			int cHeight = 0;
			foreach (Color pix in Image.Pixels)
			{
				Drawing.Color underColor = GraphicsDriver.GetPoint(cWidth, cHeight);
				Color final = pix;
				if (pix.A < 255)
					final = pix - new Color(underColor.A, underColor.R, underColor.G, underColor.B);
				GraphicsDriver.DrawPoint(cWidth, cHeight, Drawing.Color.FromArgb(final.A, final.R, final.G, final.B));

				cWidth++;
				if (cWidth == Image.Width)
				{
					cWidth = 0;
					cHeight++;
				}
			}
		}
	}
	public class TextGraphicsInstruction : GraphicsInstruction
	{
		public string Text { get; set; }
		public Font Font { get; set; }
		public Vector2 Position { get; set; }
		public Color ForegroundColor { get; set; }

		public TextGraphicsInstruction(Vector2 pos, string text, Font font, Color foreColor)
		{
			Position = pos;
			ForegroundColor = foreColor;
			Text = text;
			Font = font;
		}
		[Obsolete("Don't quite work! Use Vector2 version")]
		public TextGraphicsInstruction(Align align, string text, Font font, Color foreColor)
		{
			Text = text;
			Font = font;
			ForegroundColor = foreColor;
			if (align == Align.Center)
			{
				Position = new Vector2((GraphicsDriver.ScreenX / 2) - (text.Length * font.Width), GraphicsDriver.ScreenY / 2);
			}
			else if (align == Align.Bottom)
			{
				Position = new Vector2((GraphicsDriver.ScreenX / 2) - (text.Length * font.Width), GraphicsDriver.ScreenY);
			}
			else if (align == Align.Top)
			{
				Position = new Vector2((GraphicsDriver.ScreenX / 2) - (text.Length * font.Width), 0);
			}
			else if (align == Align.Left)
			{
				Position = new Vector2(0, GraphicsDriver.ScreenY / 2);
			}
			else if (align == Align.Right)
			{
				Position = new Vector2(GraphicsDriver.ScreenX - (text.Length * font.Width), 0);
			}
			else if (align == Align.TopLeft)
			{
				Position = new Vector2(0, 0);
			}
			else if (align == Align.TopRight)
			{
				Position = new Vector2(GraphicsDriver.ScreenX - (text.Length * font.Width), 0);
			}
			else if (align == Align.BottomLeft)
			{
				Position = new Vector2(0, GraphicsDriver.ScreenY - font.Height);
			}
			else if (align == Align.BottomRight)
			{
				Position = new Vector2(GraphicsDriver.ScreenX - (text.Length * font.Width), GraphicsDriver.ScreenY - font.Height);
			}
			else
			{
				Position = new Vector2(0, 0);
			}
		}

		public void Render()
		{
			GraphicsDriver.DrawString(Position.X, Position.Y, Text, Font, Drawing.Color.FromArgb(ForegroundColor.A, ForegroundColor.R, ForegroundColor.G, ForegroundColor.B));
		}
	}
}
