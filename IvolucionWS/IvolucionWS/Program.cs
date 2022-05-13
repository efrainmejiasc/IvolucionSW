using System;
using System.Diagnostics;
using System.ServiceProcess;


namespace IvolucionWS
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 

        
            private static void Main(string[] args)
            {
#if DEBUG
            var service1 = new IvolucionWinService();
            service1.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                  new IvolucionWinService()
                };
                ServiceBase.Run(ServicesToRun);
#endif
            }
    }
}
