using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace Excel
{
    public partial class main : System.Web.UI.Page
    {
        private List<AccessRecordType> accessRecordList = new List<AccessRecordType>()
        {
          new AccessRecordType{ RowNum = "1", SystemName = "메일링", UserName = "BJW", UserID = "BJW", ActionUrl = "www.ABC.com", ActionName = "Download", ActionStateText = "다운", PersonalInformationYN = "Y", ActionDateTime = "2016.09.12" },
        new AccessRecordType{ RowNum = "2", SystemName = "모니터링", UserName = "BJW", UserID = "BJW", ActionUrl = "www.ABC.com", ActionName = "Download", ActionStateText = "다운", PersonalInformationYN = "Y", ActionDateTime = "2016.09.12" },
        new AccessRecordType{ RowNum = "3", SystemName = "웹", UserName = "BJW", UserID = "BJW", ActionUrl = "www.ABC.com", ActionName = "Download", ActionStateText = "다운", PersonalInformationYN = "Y", ActionDateTime = "2016.09.12" },
        new AccessRecordType{ RowNum = "4", SystemName = "포탈", UserName = "BJW", UserID = "BJW", ActionUrl = "www.ABC.com", ActionName = "Download", ActionStateText = "다운", PersonalInformationYN = "Y", ActionDateTime = "2016.09.12" }
             };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }

        }
        private void BindList()
        {
            this.rptAccessRecordList.DataSource = accessRecordList;
            this.rptAccessRecordList.DataBind();
        }

        protected void btnExcelDownload_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            ds = ToDataSet(accessRecordList);
            ExcelHelper.CreateExcelReport(Server.MapPath("AccessRecordDataForExcel.xsl"), ds, Page.Response, "AccessRecordInfo.xls", "", true);
        }

        public static DataSet ToDataSet<T>(IList<T> list)
        {

            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                t.Columns.Add(propInfo.Name, propInfo.PropertyType);
            }
            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null);
                }
                //This line was missing:
                t.Rows.Add(row);
            }
            return ds;
        }
    }
}


//public DataTable GetHandlingPersonListFromExcel(List<HandlingPersonType> typeList)
//{
//    DataTable sourceTable = new DataTable();
//    sourceTable.Columns.Add("TargetID", typeof(Guid));
//    sourceTable.Columns.Add("Name", typeof(string));
//    sourceTable.Columns.Add("MobileTel", typeof(string));
//    sourceTable.Columns.Add("FinalEducationDate", typeof(DateTime));

//    foreach (HandlingPersonType type in typeList)
//    {
//        sourceTable.Rows.Add(type.targetID, type.Name, type.MobileTel, type.FinalEducationDate);
//    }
//    return sourceTable;
//}
