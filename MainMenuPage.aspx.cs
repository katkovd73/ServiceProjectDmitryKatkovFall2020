using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceProjectDmitryKatkovFall2020
{
    public partial class MainMenuPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnService_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceEventPage.aspx");
        }

        protected void btnProblem_Click(object sender, EventArgs e)
        {
            Response.Redirect("OpenProblemPage.aspx");
        }       

        protected void btnReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportsMenu.aspx");
        }

        protected void btnTechnicians_Click(object sender, EventArgs e)
        {
            Response.Redirect("TechnicianPage.aspx");
        }
    }
}