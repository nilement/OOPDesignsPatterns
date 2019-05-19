using System;

namespace Server.Loggers
{
    [Flags]
    public enum LogType
    {
        None = 0,
        File = 1,
        Console = 2,
        All = 3
    }
}
