using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Insert
            using (TestBiz biz = new TestBiz())
            {
                TestType type = new TestType();
                type.Name = "가나다";
                type.Number = 100;
                biz.InsertTest(type);
            }


            // Select
            List<TestType> testList = null;
            using (TestBiz biz = new TestBiz())
            {
                testList = biz.SelectTestList();
            }

            foreach (var i in testList)
            {
                Console.WriteLine(i.Name + "  " + i.Number);
            }



        }
    }
}
