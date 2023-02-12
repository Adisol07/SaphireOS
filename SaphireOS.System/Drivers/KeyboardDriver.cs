using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.System.Drivers
{
    public static class KeyboardDriver
    {
        public static List<KeyPress> KeyPresses { get; set; }

        public static void Initialize()
        {
            KeyPresses = new List<KeyPress>();
        }

        public static void HandleKeyboard()
        {
            KeyEvent ke;
            if (KeyboardManager.TryReadKey(out ke))
            {
                foreach (KeyPress kp in KeyPresses)
                {
                    kp.Invoke(ke);
                }
            }
        }

        public delegate void KeyPress(KeyEvent k);
    }
}
