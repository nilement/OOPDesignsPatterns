namespace Server.Loggers
{
    public abstract class Logger
    {
        protected LogType _logMask;
        protected Logger _next;

        public void Message(string msg, LogType severity)
        {
            if ((severity & _logMask) != 0) //True only if all logMask bits are set in severity
            {
                WriteMessage(msg);
            }

            _next?.Message(msg, severity);
        }

        protected abstract void WriteMessage(string message);

        public Logger SetNext(Logger logger)
        {
            _next = logger;
            return logger;
        }
    }
}
