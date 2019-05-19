using System;
using System.IO;
using System.Net;
using System.Threading;
using Objects;
using Objects.PveOpponent.Opponents;
using Server.Loggers;

namespace Server
{
    class Program
    {
        private static SessionStore _store;

        static void Setup()
        {
            _store = SessionStore.GetSessionStore();
        }
        static void Main(string[] args)
        {
            var ws = new WebServer();
            ws.Run();

            Console.ReadKey();
            ws.Stop();
        }

    }

    public class WebServer
    {
        private readonly HttpListener _listener;
        private readonly Router _router;
        private readonly string _absolutePath;

        private static Logger _consoleLogger;

        // Jei meta, kad access denied exceptioną
        // netsh http add urlacl url=http://192.168.88.232:8080/ user=Justas, ten kur user - jūsų useris (net user parodo visus esamus userius)
        public WebServer()
        {
            _router = new Router();
            _listener = new HttpListener();
            //_absolutePath = "http://10.151.11.128:8080/";
            _absolutePath = "http://192.168.88.232:8080/";

            _consoleLogger = ConsoleLogger.GetLogger();
            _consoleLogger.SetNext(FileLogger.GetLogger());
            _consoleLogger.Message($"Server has been started on path {_absolutePath} at {DateTime.Now}", LogType.All);
            _listener.Prefixes.Add(_absolutePath);
            _listener.Start();
        }


        public void Run()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem(c =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                var requestData = new byte[ctx.Request.ContentLength64];
                                new StreamReader(ctx.Request.InputStream).BaseStream.Read(requestData, 0, (int)ctx.Request.ContentLength64);
                                var response = _router.RouteByPath(ctx.Request.Url.LocalPath, requestData);

                                var buf = Utils.ObjectToByteArray(response);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch (Exception ex)
                            {
                                _consoleLogger.Message(ex.Message, LogType.All);
                                // ignored
                            } // suppress any exceptions
                            finally
                            {
                                ctx?.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch (Exception ex)
                {
                      _consoleLogger.Message(ex.Message, LogType.All);
                }
            });
        }

        public void Stop()
        {
            _consoleLogger.Message($"Server has been turned off at {DateTime.Now}.", LogType.All);
            _listener.Stop();
            _listener.Close();
        }
    }

}
