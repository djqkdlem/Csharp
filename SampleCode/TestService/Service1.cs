using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.ServiceProcess;
using System.Threading;
namespace TestService
{
    public partial class Service1 : ServiceBase
    {
        ArrayList UnitServices;
        ManualResetEvent ShutdownEvt;



        public Service1()
        {
            InitializeComponent();

            this.AutoLog = false;

            ShutdownEvt = new ManualResetEvent(false);
            LoopServiceBase.ShutdownEvent = ShutdownEvt;

            #region 단위서비스 추가

#if DEBUG
            
            System.Diagnostics.Debugger.Launch();
#endif

            string MailingServiceStartTime = ConfigurationManager.AppSettings["MailingServiceStartTime"] ?? DateTime.Now.AddSeconds(1).ToString("yyyyMMddHHmmss");
            DateTime timeToSchedule = DateTime.ParseExact(MailingServiceStartTime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            //시작할 일정이 지났으면 내일로
            if (DateTime.Now > timeToSchedule)
                timeToSchedule = DateTime.Today.AddMilliseconds(3000);



            //DateTime timeToSchedule = DateTime.Now;

            UnitServices = new ArrayList();
            //UnitServices.Add(new ManagerMailService("ManagerMailService", timeToSchedule));
            //UnitServices.Add(new HandlingPersonSMSService("HandlingPersonSMSService", timeToSchedule));
            //UnitServices.Add(new RefreshService("RefreshService", timeToSchedule));

            //// 모니터링 시스템 테이블에 사용자의 접근 권한 유무 업데이트 해주기 (주기는 일단 데일리)
            UnitServices.Add(new GoService("GoService", timeToSchedule));

            #endregion 단위서비스 추가
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                foreach (LoopServiceBase service in UnitServices)
                {
                    service.Start();
                }

            }
            catch (Exception ex)
            {
                Log4NetHelper.Fatal("Exception in OnStart", ex);
            }
        }

        protected override void OnStop()
        {
            try
            {
                ShutdownEvt.Set();

                foreach (LoopServiceBase service in UnitServices)
                {
                    service.Join();
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Fatal("Exception in OnStop", ex);
            }
        }
    }
}
