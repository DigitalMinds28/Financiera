using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LBManager_Click(object sender, EventArgs e)
        {
            Response.Redirect("WFManager.aspx");
        }

        protected void LBAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("WFAccount.aspx");
        }

        protected void LBControlAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("WFAdminControl.aspx");
        }

        protected void LBCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("WFCustomer.aspx");
        }

        protected void LBLocation_Click(object sender, EventArgs e)
        {
            Response.Redirect("WFLocation.aspx");
        }

        protected void LBTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("WFTransaction.aspx");
        }

        protected void LBInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index1.aspx");
        }
    }
}