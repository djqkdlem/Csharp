using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using static Sample.Common;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Linq 
            // Linq ForEach
            Common.InfoList.ForEach((x) =>
            {
                Console.WriteLine(x.Name);
            });

            // Linq Find
            var info = Common.InfoList.Find(c => c.Name == "영희");
            Console.WriteLine(info.Name);

            // Linq Index
            int index = Common.InfoList.Select((item, i) => new { Item = item.Name, Index = i }).First(x => x.Item == "민수").Index;
            Console.WriteLine(index);

            // Group
            IEnumerable<IGrouping<string, Info>> groupList = Common.InfoList.GroupBy(x => x.Room, x => x);
            foreach (IGrouping<string, Info> group in groupList)
            {
                Console.WriteLine($" 키 - {group.Key}");
                foreach (var list in group)
                {
                    Console.WriteLine($"이름 - {list.Name}");
                }
            }
            // 범위로 항목 제거 
            Common.InfoList.RemoveRange(0, 1);
            #endregion

            #region Regex
            RegExr.EXEC();
            #endregion

            #region PasswordValidation
            Console.WriteLine(PasswordValidation.Union_Rule("123456Q$"));
            Console.WriteLine(PasswordValidation.Personal_Information("01093096116"));
            Console.WriteLine(PasswordValidation.oneString_Repetition("djqkdeeem"));
            Console.WriteLine(PasswordValidation.twoString_Repetition("123123"));
            Console.WriteLine(PasswordValidation.Keyboard_Continuity("12e45"));
            #endregion

            // 시간측정
            DateTime start = DateTime.Now;
            Console.WriteLine("측정시작");
            TimeSpan ts = DateTime.Now - start;
            Console.WriteLine($"소요시간 - {ts}");

            string location = Assembly.GetExecutingAssembly().Location;
            string directory = Path.GetDirectoryName(location);
            Console.WriteLine(directory);
            Console.WriteLine(Path.GetFullPath("Program.cs"));
            // Web
            // Server.MapPath("~/Sample.aspx");
        }
    }
}
