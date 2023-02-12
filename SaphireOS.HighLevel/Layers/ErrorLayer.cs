using Cosmos.System.Graphics.Fonts;
using SaphireOS.SDK.Graphics;
using SaphireOS.SDK.Mathematics;
using SaphireOS.System.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.HighLevel.Layers
{
	public class ErrorLayer : Layer
	{
		public override int Level => 0;
		public override bool IsVisible => true;

		public ErrorLayer(string msg, string code, string source, bool advScreen = false)
		{
			Font fnt = PCScreenFont.LoadFont(SaphireOS.Embed.Fonts.Zap_Light);
			Graphics graphics = new Graphics(this);
			if (advScreen == false)
			{
				graphics.Clear(new Color(26, 86, 190));
				graphics.DrawImage(new Vector2(0, 0), new Image(SaphireOS.Embed.Images.WhiteErrorCode));
				graphics.DrawText(new Vector2(36, 11), "Error!", Color.White, fnt);
				graphics.DrawText(new Vector2(15, 38), "Code: " + (char)34 + code + (char)34, Color.White, fnt);
				graphics.DrawText(new Vector2(15, 54), "Message: " + (char)34 + msg + (char)34, Color.White, fnt);
				graphics.DrawText(new Vector2(15, 66), "Source: " + (char)34 + source + (char)34, Color.White, fnt);
			}
			else if (advScreen)
			{
				graphics.Clear(new Color(26, 86, 190));
				graphics.DrawImage(new Vector2(0, 0), new Image(SaphireOS.Embed.Images.SadError));
				graphics.DrawText(new Vector2(15, 72), "Code: " + (char)34 + code + (char)34, Color.White, fnt);
				graphics.DrawText(new Vector2(15, 90), "Message: " + (char)34 + msg + (char)34, Color.White, fnt);
				graphics.DrawText(new Vector2(15, 108), "Source: " + (char)34 + source + (char)34, Color.White, fnt);
			}
			string usPrs = "Press ANY key to restart your computer";
			graphics.DrawText(new Vector2((GraphicsDriver.ScreenX / 2) - (usPrs.Length * (fnt.Width + 2)), GraphicsDriver.ScreenY - fnt.Height - 5), usPrs, Color.Yellow, fnt);

			NeedUpdate = true; LayerManager.Layers.Clear(); 
		}
	}
}
