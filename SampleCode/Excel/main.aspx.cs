using System;
using System.Data;
using System.Web.UI;

namespace Excel
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();

            //using (HandlingPersonBiz biz = new HandlingPersonBiz())
            //{
            //    int totalCount = 0;

                //ds = biz.SelectHandlingPersonList(out totalCount, 1, 0, hdAccessYN.Value, hdSearchType.Value, hdSearchKeyword.Value, companyID, businessSegmentsID, deletedYN);

            //ds
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                    dr["MobileTel"] = "ssssss";   /*CommonUtility.GetPrivateMobileTel(dr["MobileTel"]);*/
                    }
                }

                ExcelHelper.CreateExcelReport(Server.MapPath("PrivacyInfoDeletedPersonDataForExcel.xsl"), ds, Page.Response, "PrivacyInfoDeletedPersonList_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls", "", true);
            
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
