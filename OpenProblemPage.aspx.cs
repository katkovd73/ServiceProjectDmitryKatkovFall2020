using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceProjectDmitryKatkovFall2020
{
    public partial class OpenProblemPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)        
        {
                lblErrorMessage.Text = "";
                LoadOpenProblems();           
        }

        private void LoadOpenProblems()
        {
            DataSet dsData;

            lblErrorMessage.Text = "";

            dsData = clsDatabase.GetOpenProblemList();
            if (dsData == null)
            {
                lblErrorMessage.Text = "Error retrieving Product list";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblErrorMessage.Text = "Error retrieving Product list";
                dsData.Dispose();
            }
            else
            {
                dgvOpenProblems.DataSource = dsData.Tables[0];
                dgvOpenProblems.DataBind();

                dsData.Dispose();
            }
        }

        protected void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuPage.aspx");
        }

        protected void dgvOpenProblems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;
            String strTicketNumber = "";
            String strProblemNumber = "";

            lblErrorMessage.Text = "";

            if (e.CommandName.Trim().ToUpper() == "SELECT")
            {
                try
                {
                    strTicketNumber = dgvOpenProblems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.ToString();
                    strProblemNumber = dgvOpenProblems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.ToString();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    lblErrorMessage.Text = "Unable to access ticket or problem number";
                }

                if (!blnErrorOccurred)
                {
                    //** Using SESSION variables
                    Session.Contents["TicketNumber"] = strTicketNumber;
                    Session.Contents["ProblemNumber"] = strProblemNumber;

                    Response.Redirect("./ResolutionPage.aspx");                    
                }
            }
        }

        protected void dgvOpenProblems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex <= dgvOpenProblems.PageCount)
            {
                dgvOpenProblems.PageIndex = e.NewPageIndex;
            }
        }
    }
}