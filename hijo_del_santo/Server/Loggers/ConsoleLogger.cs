using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Loggers
{
    public class ConsoleLogger : Logger
    {
        private static Logger _logger;
        private static readonly object LockObj = new object(); 

        protected override void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public ConsoleLogger()
        {
            _logMask = LogType.Console;
        }

        public static Logger GetLogger()
        {
            lock (LockObj)
            {
                if (_logger != null)
                {
                    return _logger;
                }

                _logger = new ConsoleLogger();
                return _logger;
            }
        }
    }
}
