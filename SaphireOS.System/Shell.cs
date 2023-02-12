using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaphireOS.System
{
    public class Shell
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public Dictionary<int, LogPart[]> Logs { get; set; } = new Dictionary<int, LogPart[]>();
        public List<LogAdd> WhenLogAdded { get; set; } = new List<LogAdd>();

        public void Log(params LogPart[] parts)
        {
            Logs.Add(Logs.Count, parts);
            foreach (LogAdd la in WhenLogAdded)
                la.Invoke(parts);
        }

		public delegate void LogAdd(LogPart[] parts);

		public static void CPULog(params LogPart[] parts)
        {
            Console.ForegroundColor = ConsoleColor.White;

            foreach (LogPart part in parts)
            {
                Console.ForegroundColor = part.Color;
                Console.Write(part.Content);
            }

            Console.Write('\n');
            Console.ResetColor();
        }
        public static void CPULogC(params LogPart[] parts)
        {
            Console.ForegroundColor = ConsoleColor.White;

            foreach (LogPart part in parts)
            {
                Console.ForegroundColor = part.Color;
                Console.Write(part.Content);
            }

            Console.ResetColor();
        }
        public static string CPUGetString()
        {
            return Console.ReadLine();
        }
        public static ConsoleKeyInfo CPUGetKey()
        {
            return Console.ReadKey();
        }
    }
    public class LogPart
    {
        public string Content { get; set; }
        public ConsoleColor Color { get; set; }

        public LogPart(string c, ConsoleColor clr)
        { Content = c; Color = clr; }
    }
}
