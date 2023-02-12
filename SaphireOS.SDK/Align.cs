using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.SDK
{
	[Obsolete("Don't quite work! Use Vector2 for positions")]
	public enum Align
	{
		None = 0,
		Center = 1,
		Top = 2,
		Bottom = 3,
		Left = 4,
		Right = 5,
		TopLeft = 6,
		BottomLeft = 7,
		BottomRight = 8,
		TopRight = 9,
	}
}
