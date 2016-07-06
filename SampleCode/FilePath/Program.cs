using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePath
{
    class Program
    {
        static void Main(string[] args)
        {
            //string assemblyFilePath = Assembly.GetExecutingAssembly().Location;
            //string assemblyDirPath = Path.GetDirectoryName(assemblyFilePath);
            //string configFilePath = assemblyDirPath + "\\A\\B\\AuthInfoMailForm.html";
            ////Server.MapPath("A");
            //System.Console.WriteLine(configFilePath);

            //string configFilePath = assemblyDirPath + "\\Common\\MailForm\\AuthInfoMailForm.html";
            //string htmlContent = System.IO.File.ReadAllText(configFilePath);
            //string fileName = Server.MapPath("MailForm") + "\\RegistrationRequestMailForm.html";
            //string fullPath = Path.GetFullPath(configFilePath);
            //System.Console.WriteLine(fullPath);
            //var a = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //System.Console.WriteLine(a[2]);

            //폴더 경로가져오는거
            //string htmlContent = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Common/MailForm/RegistrationApprovalMailForm.html"));


            //ConfigurationManager.AppSettings["LocalHostPIMM"] + "/Common/Pages/Login.aspx";
        }
    }
}
