using CodeService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IvolucionWS
{
    public partial class IvolucionWinService : ServiceBase
    {
        private Thread serviceThread;

        public IvolucionWinService()
        {
            InitializeComponent();
        }


        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            Temporizador.Interval = 10000;
            Temporizador.Start();
        }

        protected override void OnStop()
        {
            this.serviceThread = null;
            Temporizador.Stop();
        }

        private void Temporizador_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Temporizador.Stop();

            this.serviceThread = new Thread(ServiceStart);
            this.serviceThread.Start();

            Temporizador.Interval = (200000000);
            Temporizador.Start();
        }

        private void ServiceStart()
        {
            var service = new ProccesService();
           _ = service.InitProcessServiceAsync();
        }
    }
}
