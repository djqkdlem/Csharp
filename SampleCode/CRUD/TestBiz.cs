using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class TestBiz : BizBase
    {
        public List<TestType> SelectTestList()
        {
            List<TestType> testList = null;
            using (TestDac dac = new TestDac())
            {
                testList = dac.SelectTestAll();
            }
            return testList;
        }

        public void InsertTest(TestType testType)
        {
            using (TestDac dac = new TestDac())
            {
                dac.TestInsert(testType);
            }
        }
    }
}
