using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            DateTime yesterday = today.AddDays(-1);
            DateTime result = today.AddYears(1).AddDays(-1);

            Console.WriteLine(result);

            string A = "6.16144E+13";

            Console.WriteLine(Convert.ToInt64(A));
        }
    }
}

