using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Loggers
{
    public class FileLogger : Logger
    {
        private readonly String logFile;
        private static Logger _logger;
        private static readonly object LockObj = new object(); 

        protected override void WriteMessage(string message)
        {
            using (StreamWriter writer = File.AppendText(logFile))
            {
                writer.WriteLine(message);
            }
        }

        public FileLogger()
        {
            _logMask = LogType.File;
            logFile = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
        }

        public static Logger GetLogger()
        {
            lock (LockObj)
            {
                if (_logger != null)
                {
                    return _logger;
                }

                _logger = new FileLogger();
                return _logger;
            }
        }
    }
}
