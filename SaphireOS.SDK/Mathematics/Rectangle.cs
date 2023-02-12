using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.SDK.Mathematics
{
	public class Rectangle
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public Rectangle() { }
		public Rectangle(int width, int height)
		{
			Width = width;
			Height = height;
		}
	}
}
