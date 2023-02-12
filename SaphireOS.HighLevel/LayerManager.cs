using SaphireOS.SDK.Graphics;
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

        public static void RenderAll()
        {
            List<Layer> copyLayers = Layers;
            List<int> layersToDelete = new List<int>();
            int currentLevel = 0;
            int index = 0;
        again:
            if (copyLayers.Count == 0)
                goto end;
            foreach (Layer layer in copyLayers)
            {
                if (layer.Level == currentLevel)
                {
                    layer.Render();
                    layersToDelete.Add(index);
                }
                index++;
            }
            currentLevel++;
            index = 0;
            foreach (int itd in layersToDelete)
                copyLayers.RemoveAt(itd);
            goto again;
        end:;
        }
    }
}
