using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    public class TestDac : DacBase
    {
        private const string connectionStringName = "ConnHomePage";

        public TestDac()
            : base(connectionStringName)
        {
        }
        public TestDac(string _connectionStringName)
            : base(_connectionStringName)
        {
        }



        //public TestType SelectTestAll()
        //{
        //    Database db = DatabaseFactory.CreateDatabase(connectionStringName);
        //    DbCommand dbCommand = db.GetStoredProcCommand("up_AuthenticationSMSHistory_SelectByManagerID");

        //    //db.AddInParameter(dbCommand, "ManagerID", DbType.Guid, managerID);

        //    TestType testType = null;
        //    using (DataSet ds = db.ExecuteDataSet(dbCommand))
        //    {
        //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            testType = GetStoreTypeMapData(ds.Tables[0].Rows[0]);
        //        }
        //    }
        //    return testType;
        //}

        public List<TestType> SelectTestAll()
        {
            List<TestType> testList = new List<TestType>();
            Database db = DatabaseFactory.CreateDatabase(connectionStringName);
            DbCommand dbCommand = db.GetStoredProcCommand("up_Test_SelectAll");
            //db.AddInParameter(dbCommand, "ManagerID", DbType.Guid, managerID);
            using (DataSet ds = db.ExecuteDataSet(dbCommand))
            {
                if (ds != null && ds.Tables.Count > 0 )
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TestType testType = GetStoreTypeMapData(dr);
                        testList.Add(testType);
                    }
                }
            }
            return testList;
        }


        public void TestInsert(TestType testType)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionStringName);
            DbCommand dbCommand = db.GetStoredProcCommand("up_Test_Insert");


            db.AddInParameter(dbCommand, "Name", DbType.String, testType.Name);
            db.AddInParameter(dbCommand, "Number", DbType.Int32, testType.Number);

            //db.AddInParameter(dbCommand, "ManagerID", DbType.Guid, managerType.ManagerID);
            //db.AddInParameter(dbCommand, "CompanyID", DbType.Guid, managerType.CompanyID);
            //db.AddInParameter(dbCommand, "BusinessSegmentsID", DbType.Guid, managerType.BusinessSegmentsID);
            //db.AddInParameter(dbCommand, "InitLoginYN", DbType.String, managerType.InitLoginYN);
            //db.AddInParameter(dbCommand, "EmpID", DbType.String, managerType.EmpID ?? "");
            //db.AddInParameter(dbCommand, "UserID", DbType.String, managerType.UserID ?? "");
            //db.AddInParameter(dbCommand, "Name", DbType.String, managerType.Name);
            //db.AddInParameter(dbCommand, "Password", DbType.String, managerType.Password);
            //db.AddInParameter(dbCommand, "MobileTel", DbType.String, managerType.MobileTel);
            //db.AddInParameter(dbCommand, "EmailAddress", DbType.String, managerType.EmailAddress);
            ////db.AddInParameter(dbCommand, "ExpireDate", DbType.Date, managerType.ExpireDate);
            //db.AddInParameter(dbCommand, "ExpireYN", DbType.String, managerType.ExpireYN);
            ////db.AddInParameter(dbCommand, "DeletedYN", DbType.String, managerType.DeletedYN);

            db.ExecuteNonQuery(dbCommand);
        }


        private TestType GetStoreTypeMapData(DataRow dr)
        {
            TestType testType = new TestType();
            //if (dr.Table.Columns.Contains("ManagerID")) authenticationSMSHistoryType.ManagerID = (dr["ManagerID"] == DBNull.Value) ? Guid.Empty : dr.Field<Guid>("ManagerID");
            if (dr.Table.Columns.Contains("Name")) testType.Name= (dr["Name"] == DBNull.Value) ? null : dr.Field<string>("Name");
            if (dr.Table.Columns.Contains("Number")) testType.Number= (dr["Number"] == DBNull.Value) ? 0 : dr.Field<int>("Number");
            //if (dr.Table.Columns.Contains("CreatedDatetime")) authenticationSMSHistoryType.CreatedDatetime = (dr["CreatedDatetime"] == DBNull.Value) ? new DateTime(0) : dr.Field<DateTime>("CreatedDatetime");
            return testType;
        }
    }
}
