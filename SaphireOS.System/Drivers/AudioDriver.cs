using Cosmos.HAL.Drivers.PCI.Audio;
using Cosmos.System.Audio;
using Cosmos.System.Audio.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.System.Drivers
{
    public static class AudioDriver
    {
        public static void Play(byte[] bytes)
        {
            var mixer = new AudioMixer();
            var audioStream = MemoryAudioStream.FromWave(bytes);
            var driver = AC97.Initialize((ushort)bytes.Length);
            mixer.Streams.Add(audioStream);

            var audioManager = new AudioManager()
            {
                Stream = mixer,
                Output = driver,
            };
            audioManager.Enable();
        }
    }
}
