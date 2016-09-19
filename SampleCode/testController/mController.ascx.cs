using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testController
{
    public partial class mController : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (TestContext tc = new TestContext())
            {
                rpt_AllMemberList.DataSource = tc.SelectInfo();
                rpt_AllMemberList.DataBind();
            }
        }

        public void GreetingBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (TestContext tc = new TestContext())
                {
                    tc.InsertInfo(ipt.Value);
                    rpt_AllMemberList.DataSource= tc.SelectInfo();
                    rpt_AllMemberList.DataBind();
                }

                
            }
            catch (Exception ex)
            {
                ipt.Value = ex.Message;
            }


        }
    }
}