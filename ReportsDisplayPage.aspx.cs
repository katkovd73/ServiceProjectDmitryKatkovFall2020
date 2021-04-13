using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceProjectDmitryKatkovFall2020
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string storedProcedure;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["ReportStoredProcedure"] != null)
                {
                    storedProcedure = Session["ReportStoredProcedure"].ToString();
                }

                if (Session["ReportName"] != null)
                {
                    lblReportName.Text = Session["ReportName"].ToString();
                }

                DataSet dsReport;
                dsReport = clsDatabase.GetReport(storedProcedure);

                if (dsReport == null)
                {
                    lblError.Text = "Something went wrong";
                }
                else
                {
                    gvReport.DataSource = dsReport.Tables[0];
                    gvReport.DataBind();
                }
            }
        }

        protected void btnReturnToService_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportsMenu.aspx");
        }

        // change header text in gridview dynamically
        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                switch (storedProcedure)
                {
                    case "uspProblemsByInstitution":
                        e.Row.Cells[0].Text = "Number of Problems";
                        e.Row.Cells[2].Text = "Total Expense";
                        e.Row.Cells[3].Text = "Average Expense";
                        break;
                    case "uspProblemsByClient":
                        e.Row.Cells[0].Text = "Number of Problems";
                        e.Row.Cells[3].Text = "Total Expense";
                        e.Row.Cells[4].Text = "Average Expense";
                        break;
                    case "uspProblemsByProduct":
                        e.Row.Cells[0].Text = "Number of Problems";
                        e.Row.Cells[1].Text = "Product ID";
                        e.Row.Cells[3].Text = "Total Expense";
                        e.Row.Cells[4].Text = "Average Expense";
                        break;
                    case "uspProblemsByTechnician":
                        e.Row.Cells[0].Text = "Number of Problems";
                        e.Row.Cells[1].Text = "Technician ID";
                        e.Row.Cells[2].Text = "Technician Name";
                        e.Row.Cells[3].Text = "Total Expense";
                        e.Row.Cells[4].Text = "Average Expense";
                        break;
                }                
            }
        }
    }
}