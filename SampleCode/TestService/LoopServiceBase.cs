using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestService
{
    public abstract class LoopServiceBase : IDisposable
    {
        protected int startDelay;
        protected int interval = 60;
        protected string ServiceName;
        protected Thread ServiceThread;
        protected AutoResetEvent ScheduleEvent;
        static protected ManualResetEvent m_ShutdownEvent;
        protected Timer ScheduleTimer;

        /// <summary>
        /// 서비스 중지 이밴트
        /// </summary>
        static public ManualResetEvent ShutdownEvent
        {
            get
            {
                return m_ShutdownEvent;
            }
            set
            {
                m_ShutdownEvent = value;
            }
        }
        /// <summary>
        /// 루프 서비스를 초기화 합니다
        /// </summary>
        /// <param name="svcName">서비스 이름</param>
        /// <param name="startDelay">지연 시작 초</param>
        public LoopServiceBase(string svcName, int startDelay)
            : this(svcName, startDelay, 60)
        {
        }
        /// <summary>
        /// 루프 서비스를 초기화 합니다
        /// </summary>
        /// <param name="svcName">서비스 이름</param>
        /// <param name="startDelay">지연 시작 초</param>
        /// <param name="interval">실행 간격 초</param>
        public LoopServiceBase(string svcName, int startDelay, int interval)
        {
            this.ServiceName = svcName;

            this.ServiceThread = new Thread(new ThreadStart(ServiceMain));
            this.ScheduleEvent = new AutoResetEvent(false);

            this.startDelay = (int)startDelay;
            this.interval = interval;
        }

        protected LoopServiceBase() { }

        protected void ServiceMain()
        {
            //SKN.Common.Util.Log4NetHelper.Info(ServiceName + " LoopServiceMain START");
            while (true)
            {
                ScheduleEvent.WaitOne();
                if (ShutdownEvent.WaitOne(0)) break;

                //SKN.Common.Util.Log4NetHelper.Info(ServiceName + " Service execution START");
                try
                {
                    Service();
                }
                catch (Exception ex)
                {

                   //Log4NetHelper.Error("Exception in " + ServiceName, ex);
                }
                finally
                {
                    //Log4NetHelper.Info(ServiceName + " Service execution END");
                }
            }

            //SKN.Common.Util.Log4NetHelper.Info(ServiceName + " LoopServiceMain stopped");
        }

        virtual public void Start()
        {
            this.ServiceThread.Start();

            //SKN.Common.Util.Log4NetHelper.Info(ServiceName + " startDelay=" + startDelay.ToString());
            this.ScheduleTimer = new Timer(new TimerCallback(ScheduleTimerCallback), null, startDelay * 1000, interval * 1000);
        }

        public void Join()
        {
            this.ScheduleTimer.Change(Timeout.Infinite, Timeout.Infinite);
            this.ScheduleEvent.Set();
            this.ServiceThread.Join();
        }

        public void ScheduleTimerCallback(object state)
        {
            this.ScheduleEvent.Set();
        }

        abstract protected void Service();

        /// <summary>
        /// 서비스 테스트 즉시 실행
        /// </summary>
        public void ServiceTest()
        {
            Service();
        }

        /// <summary>
        /// 관리되지 않는 리소스 해제
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            this.ScheduleTimer.Dispose();
            this.ScheduleEvent.Dispose();
        }

        /// <summary>
        /// 관리되지 않는 리소스 해제
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
