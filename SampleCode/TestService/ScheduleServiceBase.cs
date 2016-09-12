using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestService
{
    public abstract class ScheduleServiceBase : LoopServiceBase
    {
        /// <summary>
        /// 서비스 시작을 예약할 시간
        /// </summary>
        protected DateTime timeToSchedule;

        /// <summary>
        ///     <para>반복 시간 간격</para>
        ///     <para>Default : 24시간,  new TimeSpan(24, 0, 0)</para>
        /// </summary>
        protected TimeSpan timeBetweenCalls = new TimeSpan(24, 0, 0);

        /// <summary>
        /// 테스트는 서비스 시작하자마자 한번은 실행
        /// </summary>
        protected bool firstStart = true;
        //protected int tempTimeBetweenCallsMilliseconds = 0;
        //protected int tempTimeToFirstExecution = 0;

        /// <summary>
        /// ScheduleService를 초기화 합니다.
        /// </summary>
        /// <param name="svcName">서비스 이름</param>
        /// <param name="timeToSchedule">서비스 시작 예약 시간</param>
        public ScheduleServiceBase(string svcName, DateTime timeToSchedule)
            : this(svcName, timeToSchedule, new TimeSpan(24, 0, 0))
        {
        }

        /// <summary>
        /// ScheduleService를 초기화 합니다
        /// </summary>
        /// <param name="svcName">서비스 이름</param>
        /// <param name="timeToSchedule">서비스 시작 예약 시간</param>
        /// <param name="timeBetweenCalls">서비스 재실행 간격</param>
        public ScheduleServiceBase(string svcName, DateTime timeToSchedule, TimeSpan timeBetweenCalls)
        {
            this.ServiceName = svcName;

            this.ServiceThread = new Thread(new ThreadStart(ServiceMain));
            this.ScheduleEvent = new AutoResetEvent(false);

            this.timeToSchedule = (DateTime)timeToSchedule;
            this.timeBetweenCalls = timeBetweenCalls;
        }

        protected new void ServiceMain()
        {
            Log4NetHelper.Info(ServiceName + " ScheduleServiceMain START");
            while (true)
            {
                ScheduleEvent.WaitOne();
                DateTime ndt = DateTime.Now + timeBetweenCalls;
                DateTime sdt = DateTime.Now;
                if (ShutdownEvent.WaitOne(0)) break;

                Log4NetHelper.Info(ServiceName + " Service execution START");
                try
                {
                    Service();
                }
                catch (Exception ex)
                {
                    Log4NetHelper.Error("Exception in " + ServiceName, ex);
                }
                finally
                {
                    string finallylog = ServiceName + " Service execution END"
                        + "\n executionTime is [" + (DateTime.Now - sdt).ToString("hh':'mm':'ss':'ffff") + "]"
                        + "\n Next executionTime is [" + ndt.ToString() + "]";
                    Log4NetHelper.Info(finallylog);
                }
            }
            Log4NetHelper.Info(ServiceName + " ScheduleServiceMain stopped");
        }

        override public void Start()
        {
            this.ServiceThread.Start();

           Log4NetHelper.Info(ServiceName + " Service Scheduled [" + timeToSchedule.ToString() + "]");

            int timeToFirstExecution = (int)timeToSchedule.Subtract(DateTime.Now).TotalMilliseconds;

            // 최초 서비스 한번 실행하기
            if (this.firstStart)
            {
                string ServiceFirstStartYN = ConfigurationManager.AppSettings["ServiceFirstStartYN"] ?? "Y";
                if (ServiceFirstStartYN.ToUpper().Equals("Y"))
                {
                    ServiceTest();
                }
            }

            this.firstStart = false;

            this.ScheduleTimer = new Timer(new TimerCallback(ScheduleTimerCallback), null, timeToFirstExecution, (int)timeBetweenCalls.TotalMilliseconds);
        }

    }
}
