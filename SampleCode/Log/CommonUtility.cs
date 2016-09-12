using System.Net;
using System.Net.Sockets;
using System.Web;

namespace Log
{
    public static class CommonUtility
    {
        /// <summary>
        /// 로그인 ID얻기
        /// </summary>
        /// <returns></returns>
        public static string GetLoginID()
        {
            string loginID = GetEmpID();
            if (string.IsNullOrEmpty(loginID))
            {
                loginID = GetUserID();
            }

            return loginID;
        }

        /// <summary>
        /// 사번 얻기
        /// </summary>
        /// <returns></returns>
        public static string GetEmpID()
        {
            //HttpContext chc = System.Web.HttpContext.Current;
            //if (chc == null)
            //    return string.Empty;

            string EmpID = string.Empty;

            //// 테스트 서버이면 Context User Identity를 임시로 사용
            //if (CommonUtility.IsTestServer())
            //{
            //    if (chc.User != null)
            //    {
            //        EmpID = chc.User.Identity.Name;//string.Empty;
            //        if (EmpID.Contains("\\\\"))
            //        {
            //            EmpID = EmpID.Split(new string[] { "\\\\" }, StringSplitOptions.None)[1];
            //        }
            //        else if (EmpID.Contains("\\"))
            //        {
            //            EmpID = EmpID.Split(new string[] { "\\" }, StringSplitOptions.None)[1];
            //        }
            //        else { }
            //    }
            //}

            //HTTP Context User Identity
            //if (chc.User != null)
            //{
            //    UserID = chc.User.Identity.Name;//string.Empty;
            //    if (UserID.Contains("\\\\"))
            //    {
            //        UserID = UserID.Split(new string[] { "\\\\" }, StringSplitOptions.None)[1];
            //    }
            //    else if (UserID.Contains("\\"))
            //    {
            //        UserID = UserID.Split(new string[] { "\\" }, StringSplitOptions.None)[1];
            //    }
            //    else { }
            //}
            //SSO Cookie
            //if (!string.IsNullOrEmpty(chc.Request["GWP_USER_ID"]))
            //{
            //    UserID = chc.Request["GWP_USER_ID"];
            //    if (UserID.Contains("skn."))
            //    {
            //        UserID = UserID.Split('.')[1];
            //    }
            //}
            //자체 Cookie
            //if (string.IsNullOrEmpty(EmpID) && !string.IsNullOrEmpty(chc.Request[HttpUtility.UrlEncode("SKN_EMP_ID")]) && chc.Session != null)
            //{
            //    string SKN_SessionID = chc.Request["SKN_SessionID"] ?? string.Empty;
            //    if (SKN_SessionID == CryptoHelper.GetSHA256(chc.Session.SessionID).Substring(0, 7))
            //    {
            //        EmpID = chc.Request["SKN_EMP_ID"];
            //        if (EmpID.Contains("skn."))
            //        {
            //            EmpID = EmpID.Split('.')[1];
            //        }
            //    }
            //}
            ////Session
            //if (string.IsNullOrEmpty(EmpID))
            //{
            //    if (chc.Session != null && chc.Session["EmpID"] != null)
            //    {
            //        EmpID = chc.Session["EmpID"].ToString();
            //    }
            //}

            return EmpID;
        }

        /// <summary>
        /// 사용자 ID얻기
        /// </summary>
        /// <returns></returns>
        public static string GetUserID()
        {
            //HttpContext chc = System.Web.HttpContext.Current;
            //if (chc == null)
            //    return string.Empty;

            string UserID = string.Empty;
            //HTTP Context User Identity
            //if (chc.User != null)
            //{
            //    UserID = chc.User.Identity.Name;//string.Empty;
            //    if (UserID.Contains("\\\\"))
            //    {
            //        UserID = UserID.Split(new string[] { "\\\\" }, StringSplitOptions.None)[1];
            //    }
            //    else if (UserID.Contains("\\"))
            //    {
            //        UserID = UserID.Split(new string[] { "\\" }, StringSplitOptions.None)[1];
            //    }
            //    else { }
            //}
            //SSO Cookie
            //if (!string.IsNullOrEmpty(chc.Request["GWP_USER_ID"]))
            //{
            //    UserID = chc.Request["GWP_USER_ID"];
            //    if (UserID.Contains("skn."))
            //    {
            //        UserID = UserID.Split('.')[1];
            //    }
            //}
            //자체 Cookie
            //if (string.IsNullOrEmpty(UserID) && !string.IsNullOrEmpty(chc.Request[HttpUtility.UrlEncode("SKN_USER_ID")]) && chc.Session != null)
            //{
            //    string SKN_SessionID = chc.Request["SKN_SessionID"] ?? string.Empty;
            //    if (SKN_SessionID == CryptoHelper.GetSHA256(chc.Session.SessionID).Substring(0, 7))
            //    {
            //        UserID = chc.Request["SKN_USER_ID"];
            //        if (UserID.Contains("skn."))
            //        {
            //            UserID = UserID.Split('.')[1];
            //        }
            //    }
            //}
            ////Session
            //if (string.IsNullOrEmpty(UserID))
            //{
            //    if (chc.Session != null && chc.Session["UserID"] != null)
            //    {
            //        UserID = chc.Session["UserID"].ToString();
            //    }
            //}

            return UserID;
        }

        public static string GetSessionID()
        {
            HttpContext chc = System.Web.HttpContext.Current;
            if (chc == null)
                return string.Empty;
            if (chc.Session == null)
                return string.Empty;
            return chc.Session.SessionID.ToString();
        }

        /// <summary>
        /// 현재 URL얻기
        /// </summary>
        /// <returns></returns>
        public static string GetURL()
        {
            HttpContext chc = System.Web.HttpContext.Current;
            if (chc == null)
                return string.Empty;
            return /*"[" + chc.Server.MachineName + "] " + */chc.Request.Url.ToString();
        }

        /// <summary>
        /// 클라이언트 IP얻기
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            HttpContext chc = System.Web.HttpContext.Current;
            if (chc == null)
                return string.Empty;

            string ipList = chc.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return chc.Request.ServerVariables["REMOTE_ADDR"];
        }

        /// <summary>
        /// 클라이언트 Browser정보 얻기
        /// </summary>
        /// <returns></returns>
        public static string GetClientBrowser()
        {
            HttpContext chc = System.Web.HttpContext.Current;
            if (chc == null)
                return string.Empty;

            return chc.Request.Browser.Capabilities[""] != null ? chc.Request.Browser.Capabilities[""].ToString() : chc.Request.Browser.Browser + chc.Request.Browser.Version;
        }

        /// <summary>
        /// 로컬IP정보 얻기
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            string localIP = string.Empty;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return localIP;
        }
       
    }
}
