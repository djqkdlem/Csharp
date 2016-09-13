using System.IO;
using System.Reflection;

namespace FilePath
{
    class Program
    {
        static void Main(string[] args)
        {
            //Web
            //Server.MapPath("A");

            //string htmlContent = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Common/MailForm/RegistrationApprovalMailForm.html"));

            string assemblyFilePath = Assembly.GetExecutingAssembly().Location;
            string assemblyDirPath = Path.GetDirectoryName(assemblyFilePath);
            string imgFilePath = assemblyDirPath + "\\img\\example.PNG";
            string excelFilePath = assemblyDirPath + "\\excel\\example.xlsx";

            System.Console.WriteLine(assemblyFilePath);
            //  E:\Git\C#\SampleCode\FilePath\bin\Debug\FilePath.exe
            System.Console.WriteLine(assemblyDirPath);
            //  E:\Git\C#\SampleCode\FilePath\bin\Debug
            System.Console.WriteLine(imgFilePath);      
            //  E:\Git\C#\SampleCode\FilePath\bin\Debug\img\example.PNG
            System.Console.WriteLine(excelFilePath);        
            //  E:\Git\C#\SampleCode\FilePath\bin\Debug\excel\example.xlsx
            System.Console.WriteLine(Path.GetFullPath("example.xlsx"));
            //  E:\Git\C#\SampleCode\FilePath\bin\Debug\example.xlsx
            
            string path1 = @"html";
            string path2 = @"\html";
            System.Console.WriteLine(Path.GetFullPath(path1));
            //  E:\Git\C#\SampleCode\FilePath\bin\Debug\html
            System.Console.WriteLine(Path.GetFullPath(path2));
            //  E:\html
            string path3 = @"\Git\C#\SampleCode\FilePath\html\example.html";
            System.Console.WriteLine(Path.GetFullPath(path3));

            string htmlContent = File.ReadAllText(Path.GetFullPath(path3));
            System.Console.WriteLine(htmlContent);

           

            //ConfigurationManager.AppSettings["LocalHostPIMM"] + "/Common/Pages/Login.aspx";
        }
    }
}
