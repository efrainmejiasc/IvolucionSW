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

namespace IvolucionWS
{
    public partial class IvolucionWinService : ServiceBase
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IvolucionWinService()
        {
            InitializeComponent();
        }

        private static IScheduler _scheduler;
        protected override void OnStart(string[] args)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler().Result;
            _scheduler.Start();
            AddJobs();
        }

        private void AddJobs()
        {
            AddJobSubmitNewCLNContents();
            AddJobGetRequestReportPatagonian();
            AddJobRequestScheduledVirtualAppointmentsDone();
        }

        public static void AddJobGetRequestReportPatagonian()
        {
           var trigger  = "PatagonianReports";
           var detail = "Solicitud API para reportes";
           var job = "JobRequestPatagonian";

            var myJob = new RequestReportPatagonian();
            var jobDetail = new JobDetailImpl(trigger + " " + job, detail, myJob.GetType());
                                                      
           // var trigger1 = new CronTriggerImpl(trigger,detail, "0 0 17 ? * FRI" ) {TimeZone = TimeZoneInfo.Utc };
            var trigger1 = new CronTriggerImpl(trigger, detail, "0 0 22 ? * FRI") { TimeZone = TimeZoneInfo.Utc };
            _scheduler.ScheduleJob(jobDetail, trigger1);

            var nextFireTime = trigger1.GetNextFireTimeUtc();
            if (nextFireTime != null)
                ToolClass.WriteLogReportPatagonian(detail + " " + trigger + " " + DateTime.Now.ToString());
        }


        public static void AddJobSubmitNewCLNContents()
        {
            var trigger = "SubmitNewCLNContents";
            var detail = "Servicio CLN New Contents";
            var job = "JobSubmitNewCLNContents";

            var myJob = new RequestJobSubmitNewCLNContents();
            var jobDetail = new JobDetailImpl(trigger + " " + job, detail, myJob.GetType());
            var trigger1 = new CronTriggerImpl(trigger, detail, "0 0 14 ? * MOD") { TimeZone = TimeZoneInfo.Utc };
            _scheduler.ScheduleJob(jobDetail, trigger1);

            var nextFireTime = trigger1.GetNextFireTimeUtc();
            if (nextFireTime != null)
                ToolClass.WriteLogSubmitNewCLNContents(detail + " " + trigger + " " + DateTime.Now.ToString());
        }

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

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            ToolClass.WriteLogReportPatagonian("Parando servicio: ON STOP " + DateTime.Now.ToString());
            ToolClass.WriteLogSubmitNewCLNContents("Parando servicio: ON STOP " + DateTime.Now.ToString());
            ToolClass.WriteLogScheduledVirtualAppointmentsDone("Parando servicio: ON STOP " + DateTime.Now.ToString());
        }

        public interface IDoJob : IJob
        {
      
        }
    }
}
