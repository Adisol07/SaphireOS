using SaphireOS.SDK.Graphics;
using SaphireOS.System.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.HighLevel
{
    public static class LayerManager
    {
        public static List<Layer> Layers { get; set; } = new List<Layer>();

        public static void HandleLayers()
        {
            foreach (var layer in Layers)
            {
                if (layer.NeedUpdate)
                {
                    RenderAll(Sort());
                    break;
                }
            }
        }

        public static List<Layer> Sort()
        {
            List<Layer> result = new List<Layer>();

            int currentLevel = 0;
        again:
            if (result.Count == Layers.Count)
                return result;
            foreach (Layer layer in Layers)
            {
                if (layer.Level == currentLevel)
                {
					result.Add(layer);
                }
            }
            currentLevel++;
            goto again;
        }
        public static void RenderAll(List<Layer> layers)
        {
            int index = 0;
            foreach (Layer layer in layers)
            {
				layer.Render();
                layer.NeedUpdate = false;
				index++;
            }
        }
    }
}
