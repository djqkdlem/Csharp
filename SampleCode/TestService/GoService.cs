using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    public class GoService : ScheduleServiceBase //LoopServiceBase
    {
        // 스케쥴 서비스 상속
        public GoService(string serviceName, DateTime timeToSchedule)
            : base(serviceName, timeToSchedule)
        {
        }
        public GoService(string serviceName, DateTime timeToSchedule, TimeSpan timeBetweenCalls)
            : base(serviceName, timeToSchedule, timeBetweenCalls)
        {
        }
        override protected void Service()
        {
            //#if DEBUG

            //            System.Diagnostics.Debugger.Launch();

            //#endifpublic

            GOGO();
        }

        public static void GOGO()
        {
            Log4NetHelper.Info("Sss");
            // Insert
            using (TestBiz biz = new TestBiz())
            {
                TestType type = new TestType();
                type.Name = "가나다";
                type.Number = 100;
                biz.InsertTest(type);
            }
        }
    }
}
