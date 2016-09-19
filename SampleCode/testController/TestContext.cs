using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace testController
{
    public class TestContext : ContextBase
    {
        private const string connectionStringName = "ConnBJWDB";

        public TestContext() : base(connectionStringName) { }

        public TestContext(string connectionString) : base(connectionString) { }

        public void InsertInfo(string name)
        {
            DbCommand dbCommand = Db.GetStoredProcCommand("up_text_Insert");
            Db.AddInParameter(dbCommand, "@name", DbType.String, name);
            Db.ExecuteNonQuery(dbCommand);
        }

        public List<TestType> SelectInfo()
        {
            List<TestType> listHandlingPersonType = new List<TestType>();
            Database db = DatabaseFactory.CreateDatabase(connectionStringName);
            DbCommand dbCommand = db.GetStoredProcCommand("up_text_Select");

            using (DataSet ds = db.ExecuteDataSet(dbCommand))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TestType handlingPersonType = new TestType(dr);
                        listHandlingPersonType.Add(handlingPersonType);
                    }
                }
            }
            return listHandlingPersonType;
        }
    }
}