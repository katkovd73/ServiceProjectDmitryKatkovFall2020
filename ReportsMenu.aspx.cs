using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceProjectDmitryKatkovFall2020
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ConfigurationManager.AppSettings["ReportsAppTitle"] != null)
                {
                    Page.Title = ConfigurationManager.AppSettings["ReportsAppTitle"].ToString();
                }
            }
        }       

        protected void btnProblems_Click(object sender, EventArgs e)
        {
            string storedProcedure = "";
            string reportName = "";

            Button btn = (Button)sender;

            switch (btn.ID)
            {
                case "btnProblemsbyInstitution":
                    storedProcedure = "uspProblemsByInstitution";
                    reportName = "Problems by Institution";
                    break;
                case "btnProblemsbyClients":
                    storedProcedure = "uspProblemsByClient";
                    reportName = "Problems by Client";
                    break;
                case "btnProblemsbyProduct":
                    storedProcedure = "uspProblemsByProduct";
                    reportName = "Problems by Product";
                    break;
                case "btnProblemsbyTechnicians":
                    storedProcedure = "uspProblemsByTechnician";
                    reportName = "Problems by Technician";
                    break;
            }

            Session["ReportStoredProcedure"] = storedProcedure;
            Session["ReportName"] = reportName;

            Response.Redirect("ReportsDisplayPage.aspx");
        }

        protected void btnReturnToService_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuPage.aspx");
        }
    }
}