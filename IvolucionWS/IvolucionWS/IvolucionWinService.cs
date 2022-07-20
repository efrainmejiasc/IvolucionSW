using CodeService;
using CodeService.Helpers;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using CodeService.Services;

namespace IvolucionWS
{
    public partial class IvolucionWinService : ServiceBase
    {
        private static IScheduler _scheduler;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IvolucionWinService()
        {
            InitializeComponent();
        }

        #region SERVICIO
        protected override void OnStart(string[] args)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler().Result;
            _scheduler.Start();
            AddJobs();
        }


        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            ToolClass.WriteLogReportPatagonian("Parando servicio: ON STOP " + DateTime.Now.ToString());
            ToolClass.WriteLogSubmitNewCLNContents("Parando servicio: ON STOP " + DateTime.Now.ToString());
            ToolClass.WriteLogScheduledVirtualAppointmentsDone("Parando servicio: ON STOP " + DateTime.Now.ToString());
            ToolClass.WriteLogOffers("Parando servicio: ON STOP " + DateTime.Now.ToString());
            ToolClass.WriteLogAlerts("Parando servicio: ON STOP " + DateTime.Now.ToString());
        }

        #endregion 

        private void AddJobs()
        {
            AddJobSubmitNewCLNContents();
            AddJobGetRequestReportPatagonian();
            AddJobRequestScheduledVirtualAppointmentsDone();
        }

        public interface IDoJob : IJob
        {

        }


        #region REPORTES PATAGONIAN

        public static void AddJobGetRequestReportPatagonian()
        {
           var trigger  = "PatagonianReports";
           var detail = "Solicitud API para reportes";
           var job = "JobRequestPatagonian";

            var myJob = new RequestReportPatagonian();
            var jobDetail = new JobDetailImpl(trigger + " " + job, detail, myJob.GetType());
                                                      
            var trigger1 = new CronTriggerImpl(trigger, detail, "0 0 22 ? * FRI") { TimeZone = TimeZoneInfo.Utc };
            _scheduler.ScheduleJob(jobDetail, trigger1);

            var nextFireTime = trigger1.GetNextFireTimeUtc();
            if (nextFireTime != null)
                ToolClass.WriteLogReportPatagonian(detail + " " + trigger + " " + DateTime.Now.ToString());
        }

        public class RequestReportPatagonian : IDoJob
        {

            Task IJob.Execute(IJobExecutionContext context)
            {
                Task taskA = new Task(() => ServiceStart());
                taskA.Start();
                return taskA;
            }

            private void ServiceStart()
            {
                var service = new ProccesService();
                _ = service.InitProcessServiceAsync();
            }
        }

        #endregion


        #region ENVIOS DE NOTICIAS PATAGONIAN

        public static void AddJobSubmitNewCLNContents()
        {
            var trigger = "SubmitNewCLNContents";
            var detail = "Servicio CLN New Contents";
            var job = "JobSubmitNewCLNContents";

            var myJob = new RequestJobSubmitNewCLNContents();
            var jobDetail = new JobDetailImpl(trigger + " " + job, detail, myJob.GetType());
            var trigger1 = new CronTriggerImpl(trigger, detail, "0 0 14 ? * MON") { TimeZone = TimeZoneInfo.Utc };
            _scheduler.ScheduleJob(jobDetail, trigger1);

            var nextFireTime = trigger1.GetNextFireTimeUtc();
            if (nextFireTime != null)
                ToolClass.WriteLogSubmitNewCLNContents(detail + " " + trigger + " " + DateTime.Now.ToString());
        }

        public class RequestJobSubmitNewCLNContents : IDoJob
        {
            Task IJob.Execute(IJobExecutionContext context)
            {
                Task taskA = new Task(() => ServiceStart());
                taskA.Start();
                return taskA;
            }

            private void ServiceStart()
            {
                var service = new ProccesService();
                _ = service.InitProcessService2Async();
            }
        }

        #endregion


        #region  ACTUALIZACION DE ESTADO CITAS VIRTUALES

        public static void AddJobRequestScheduledVirtualAppointmentsDone()
        {
            var trigger = "ScheduledVirtualAppointmentsDone";
            var detail = "Servicio Citas de negocios virtuales realizadas";
            var job = "JobRequestScheduledVirtualAppointmentsDone";

            var myJob = new RequestScheduledVirtualAppointmentsDone();
            var jobDetail = new JobDetailImpl(trigger + " " + job, detail, myJob.GetType());
            var trigger1 = new CronTriggerImpl(trigger, detail, "0 0 10 ? * *") { TimeZone = TimeZoneInfo.Utc };
            _scheduler.ScheduleJob(jobDetail, trigger1);

            var nextFireTime = trigger1.GetNextFireTimeUtc();
            if (nextFireTime != null)
                ToolClass.WriteLogScheduledVirtualAppointmentsDone(detail + " " + trigger + " " + DateTime.Now.ToString());
        }

        public class RequestScheduledVirtualAppointmentsDone : IDoJob
        {
            Task IJob.Execute(IJobExecutionContext context)
            {
                Task taskA = new Task(() => ServiceStart());
                taskA.Start();
                return taskA;
            }

            private void ServiceStart()
            {
                var service = new ProccesService();
                _ = service.InitProcessService3Async();
            }
        }

        #endregion


        #region ENVIO DE ALERTS CLN
        public static void AddJobRequestAlerts()
        {
            var trigger = "Alerts";
            var detail = "Servicio de alertas CLN";
            var job = "RequestAlerts";

            var myJob = new RequestAlerts();
            var jobDetail = new JobDetailImpl(trigger + " " + job, detail, myJob.GetType());
            var trigger1 = new CronTriggerImpl(trigger, detail, "0 0/6 * * * ?") { TimeZone = TimeZoneInfo.Utc };
            _scheduler.ScheduleJob(jobDetail, trigger1);

            var nextFireTime = trigger1.GetNextFireTimeUtc();
            if (nextFireTime != null)
                ToolClass.WriteLogScheduledVirtualAppointmentsDone(detail + " " + trigger + " " + DateTime.Now.ToString());
        }

        public class RequestAlerts : IDoJob
        {
            Task IJob.Execute(IJobExecutionContext context)
            {
                Task taskA = new Task(() => ServiceStart());
                taskA.Start();
                return taskA;
            }

            private void ServiceStart()
            {
                var service = new ProccesService();
                _ = service.InitProcessService4Async();
            }
        }

        #endregion


        #region ENVIO DE OFERTAS CLN

        public static void AddJobRequestOffers()
        {
            var trigger = "Offers";
            var detail = "Servicio de ofertas CLN";
            var job = "RequestOffers";

            var myJob = new RequestOffers();
            var jobDetail = new JobDetailImpl(trigger + " " + job, detail, myJob.GetType());
            var trigger1 = new CronTriggerImpl(trigger, detail, "0 0/12 * * * ?") { TimeZone = TimeZoneInfo.Utc };
            _scheduler.ScheduleJob(jobDetail, trigger1);

            var nextFireTime = trigger1.GetNextFireTimeUtc();
            if (nextFireTime != null)
                ToolClass.WriteLogScheduledVirtualAppointmentsDone(detail + " " + trigger + " " + DateTime.Now.ToString());
        }

        public class RequestOffers : IDoJob
        {
            Task IJob.Execute(IJobExecutionContext context)
            {
                Task taskA = new Task(() => ServiceStart());
                taskA.Start();
                return taskA;
            }

            private void ServiceStart()
            {
                var service = new ProccesService();
                _ = service.InitProcessService5Async();
            }
        }

        #endregion


    }
}
