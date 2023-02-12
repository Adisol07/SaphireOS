using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.Embed
{
	public static class Images
	{
		[ManifestResourceStream(ResourceName = "SaphireOS.Embed.Resources.rodeo-beach-marin-headlands-california-sunset-rocky-coast-1280x720-3824.bmp")]
		public static byte[] Background;

		[ManifestResourceStream(ResourceName = "SaphireOS.Embed.Resources.error_sad_saphireos.bmp")]
		public static byte[] SadError;
		[ManifestResourceStream(ResourceName = "SaphireOS.Embed.Resources.icons8_black_http_error_code_32.bmp")]
		public static byte[] BlackErrorCode;
		[ManifestResourceStream(ResourceName = "SaphireOS.Embed.Resources.icons8_http_error_code_32.bmp")]
		public static byte[] WhiteErrorCode;
	}
}
