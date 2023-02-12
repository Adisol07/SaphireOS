using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.Embed
{
    public static class Fonts
    {
        [ManifestResourceStream(ResourceName = "SaphireOS.Embed.Resources.zap-light16.psf")]
        public static byte[] Zap_Light;
    }
}
