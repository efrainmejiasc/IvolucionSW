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
        private Thread serviceThread;

        private const string Group1 = "BusinessTasks";
        private const string Job = "Job";
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static IScheduler _scheduler;

        public IvolucionWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = (IScheduler)schedulerFactory.GetScheduler();
            _scheduler.Start();

            ToolClass.WriteLogReportPatagonian("Inicio de servicio: " + DateTime.Now.ToString());

            AddJobs();
        }

        private void AddJobs()
        {
            AddJobGetRequestReportPatagonian();
        }

        public static void AddJobGetRequestReportPatagonian()
        {
            const string trigger1 = "RequestReportPatagonian";

            IDoJob myJob = new RequestReportPatagonian();
            var jobDetail = new JobDetailImpl(trigger1 + Job, Group1, myJob.GetType());
                                                            /* every 10 minutes */
            var trigger = new CronTriggerImpl(trigger1,Group1,"0 0/4 * * * ?" ) {TimeZone = TimeZoneInfo.Utc };
            _scheduler.ScheduleJob(jobDetail, trigger);

            var nextFireTime = trigger.GetNextFireTimeUtc();
            if (nextFireTime != null)
                ToolClass.WriteLogReportPatagonian(Group1 + " " + trigger1 + " " + new Exception(nextFireTime.Value.ToString("u")));
        }

        public class RequestReportPatagonian : IDoJob
        {
            public void Execute(IJobExecutionContext context)
            {
                ServiceStart();
            }

            Task IJob.Execute(IJobExecutionContext context)
            {
                throw new NotImplementedException();
            }
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            ToolClass.WriteLogReportPatagonian("Final de servicio: " + DateTime.Now.ToString());
        }


        private static void ServiceStart()
        {
            var service = new ProccesService();
           _ = service.InitProcessServiceAsync();
        }

        public interface IDoJob : IJob
        {
            new void Execute(IJobExecutionContext context);
        }
    }
}
