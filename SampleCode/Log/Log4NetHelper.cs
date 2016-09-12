using System;
using System.Configuration;
using System.Diagnostics;

namespace Log
{
    public class Log4NetHelper
    {
        private static log4net.ILog logger;
        private static log4net.ILog PageUsageLogger;
        private static log4net.ILog LoginLogger;

        private static void init()
        {
            //1. 로거 생성
            if (logger == null)
            {
                //1-1. web.config에 특장값으로 되어있다면 그걸 사용
                if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["Log4netLogerName"]))
                {
                    logger = log4net.LogManager.GetLogger(ConfigurationManager.AppSettings["Log4netLogerName"]);
                }
                else//1-2. 아니면 스텍을 뒤져서 호출한 곳의 NameSpace + ClassName + MethodName으로 로그 생성
                {
                    StackTrace stackTrace = new StackTrace();           // get call stack
                    StackFrame[] stackFrames = stackTrace.GetFrames();
                    string MethodName = stackFrames[2].GetMethod().Name;
                    string ClassFullName = stackFrames[2].GetMethod().DeclaringType.FullName;
                    logger = log4net.LogManager.GetLogger(ClassFullName + "." + MethodName);
                    //logger = log4net.LogManager.GetLogger(typeof(Log4NetHelper));
                }
            }
            //if (PageUsageLogger == null)
            //{
            //    PageUsageLogger = log4net.LogManager.GetLogger("PageUsageLogger");
            //}
            //if (LoginLogger == null)
            //{
            //    LoginLogger = log4net.LogManager.GetLogger("LoginLogger");
            //}

            //2. 로깅 환경 설정
            if (!logger.Logger.Repository.Configured)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4netconf.xml");
                if (fi.Exists)
                {
                    log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4netconf.xml"));
                }
                else //로그 파일이 없는 경우 이벤트로그에 남긴다.
                {
                    try
                    {
                        EventLog.WriteEntry("Application", "log4netconf.xml not found - 로그 설정 파일을 찾을 수 없습니다.");
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                }

                //DB서버 FailOver된경우를 위해 ReconnectOnError true로 설정 한다
                foreach (log4net.Appender.IAppender apd in logger.Logger.Repository.GetAppenders())
                {
                    if (apd is log4net.Appender.AdoNetAppender)
                    {
                        ((log4net.Appender.AdoNetAppender)apd).ReconnectOnError = true;
                    }
                }
            }

            SetLogProperties();
        }


        private static void SetLogProperties()
        {
            log4net.ThreadContext.Properties["EmpID"] = CommonUtility.GetEmpID();
            log4net.ThreadContext.Properties["UserID"] = CommonUtility.GetUserID();
            log4net.ThreadContext.Properties["URL"] = CommonUtility.GetURL();
            log4net.ThreadContext.Properties["ClientIP"] = CommonUtility.GetClientIP();
            log4net.ThreadContext.Properties["ClientUserAgent"] = CommonUtility.GetClientBrowser();
            log4net.ThreadContext.Properties["ServerHost"] = System.Environment.MachineName;
            log4net.ThreadContext.Properties["SessionID"] = CommonUtility.GetSessionID();
        }
        public static void SetLogger(object Class)
        {
            logger = log4net.LogManager.GetLogger(Class.GetType());
        }

        public static void Info(object message)
        {
            init();
            logger.Info(message);
        }
        public static void Info(Exception message)
        {
            init();
            logger.Info("Info Exception", message);
        }
        public static void Warn(object message)
        {
            init();
            logger.Warn(message);
        }
        public static void Warn(Exception message)
        {
            init();
            logger.Warn("Warn Exception", message);
        }
        public static void Warn(object message, Exception exception)
        {
            init();
            logger.Warn(message, exception);
        }
        public static void Error(object message)
        {
            init();
            logger.Error(message);
        }
        public static void Error(Exception exception)
        {
            init();
            logger.Error("Error Exception", exception);
        }
        public static void Error(object message, Exception exception)
        {
            init();
            logger.Error(message, exception);
        }
        public static void Fatal(object message)
        {
            init();
            logger.Fatal(message);
        }
        public static void Fatal(Exception exception)
        {
            init();
            logger.Fatal("Fatal Exception", exception);
        }
        public static void Fatal(object message, Exception exception)
        {
            init();
            logger.Fatal(message, exception);
        }
    
        /// <summary>
        /// 사용로그 전용함수, BasePage 클래스이외 영역에서 사용을 금지합니다.
        /// </summary>
        public static void PageUsage()
        {
            init();
            PageUsageLogger.Info(String.Empty);
        }

        /// <summary>
        /// 로그인로그 전용함수, BasePage 클래스이외 영역에서 사용을 금지합니다.
        /// </summary>
        public static void LoginLog()
        {
            init();
            LoginLogger.Info(String.Empty);
        }
    }
}
