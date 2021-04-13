using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceProjectDmitryKatkovFall2020
{
    public partial class ProblemEntryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            if (!IsPostBack)
            {
                // Ticket Number
                if(Session["TicketNumber"] != null)
                {
                    lblTicketNoDisplayed.Text = Session["TicketNumber"].ToString();
                }
                
                // Problem Number
                int problemNumber = 1;
                lblProblemNoDisplayed.Text = problemNumber.ToString();

                // Client Name
                if(Session["ClientName"] != null)
                {
                    lblClientDisplayed.Text = Session["ClientName"].ToString();
                }
                
                // load Product dropdown list
                LoadProducts();

                // load Technician dropdown list
                LoadTechnicians();
            }            
        }       

        private void LoadTechnicians()
        {
            DataSet dsData;

            dsData = clsDatabase.GetTechnicianList();

            if (dsData == null)
            {
                lblErrorMessage.Text = "Error retrieving Technicians list";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblErrorMessage.Text = "Error retrieving Technicians list";
                dsData.Dispose();
            }
            else
            {
                ddlTechnician.Items.Clear();
                ddlTechnician.AppendDataBoundItems = true;
                ddlTechnician.Items.Add(new ListItem(" --Select Technician--", "0"));
                ddlTechnician.DataSource = dsData.Tables[0];
                ddlTechnician.DataTextField = "TechName";
                ddlTechnician.DataValueField = "TechnicianID";
                ddlTechnician.DataBind();

                dsData.Dispose();
            }
        }

        private void LoadProducts()
        {
            DataSet dsData;

            dsData = clsDatabase.GetProductList();

            if (dsData == null)
            {
                lblErrorMessage.Text = "Error retrieving Products list";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblErrorMessage.Text = "Error retrieving Products list";
                dsData.Dispose();
            }
            else
            {
                ddlProduct.Items.Clear();
                ddlProduct.AppendDataBoundItems = true;
                ddlProduct.Items.Add(new ListItem(" --Select Product--", "0"));
                ddlProduct.DataSource = dsData.Tables[0];
                ddlProduct.DataTextField = "ProductDesc";
                ddlProduct.DataValueField = "ProductID";
                ddlProduct.DataBind();

                dsData.Dispose();
            }
        }

        protected void btnReturnToService_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceEventPage.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            ddlProduct.SelectedValue = "0";
            txtProblem.Text = "";
            ddlTechnician.SelectedValue = "0";
            lblValidationProduct.Text = "";
            lblValidationProblemDescription.Text = "";
            lblValidationTechnician.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int intReturnValue;

            Boolean DataIsValid = ProblemEntryDataValidation();

            if (DataIsValid)
            {
                lblErrorMessage.Text = "";

                int ticketNumber = Convert.ToInt32(lblTicketNoDisplayed.Text);
                int problemNumber = Convert.ToInt32(lblProblemNoDisplayed.Text);
                string problemDescription = txtProblem.Text.Trim();
                string productID = ddlProduct.SelectedValue.ToString();
                int technicianID = Convert.ToInt32(ddlTechnician.SelectedValue);

                try
                {
                    intReturnValue = clsDatabase.InsertProblem(ticketNumber,
                                                                              problemNumber,
                                                                              problemDescription,
                                                                              productID,
                                                                              technicianID);

                    if (intReturnValue == 0) // 0 (success) or -1 (fail) is returned from clsDatabase
                    {                        
                        lblErrorMessage.Text = "Problem was successfully entered";

                        lblProblemNoDisplayed.Text = (Convert.ToInt32(lblProblemNoDisplayed.Text) + 1).ToString();

                        ClearFields();
                    }
                    else
                    {
                        lblErrorMessage.Text = "Problem was not saved in the database";
                    }
                }
                catch
                {
                    lblErrorMessage.Text = "Problem was not saved in the database";
                }              
            }
        }

        private Boolean ProblemEntryDataValidation()
        {
            Boolean blnDataIsValid = true;

            // Product dropdown validation
            if (ddlProduct.SelectedValue == "0")
            {
                lblValidationProduct.Text = "Choose product";
                blnDataIsValid = false;
            }
            else
            {
                lblValidationProduct.Text = "";
            }

            // Technician dropdown validation
            if (ddlTechnician.SelectedValue == "0")
            {
                lblValidationTechnician.Text = "Choose technician";
                blnDataIsValid = false;
            }
            else
            {
                lblValidationTechnician.Text = "";
            }

            // Problem Description field validation
            if (String.IsNullOrWhiteSpace(txtProblem.Text))
            {
                lblValidationProblemDescription.Text = "Required field";
                blnDataIsValid = false;
            }
            else
            {
                lblValidationProblemDescription.Text = "";
            }
            return blnDataIsValid;
        }
    }
}