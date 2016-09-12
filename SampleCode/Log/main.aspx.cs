using System;

namespace Log
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log4NetHelper.Info("하하하");
        }
    }
}