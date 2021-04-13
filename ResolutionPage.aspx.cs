using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceProjectDmitryKatkovFall2020
{
    public partial class ResolutionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            if (!IsPostBack)
            {
                // Ticket Number
                lblTicketNoDisplayed.Text = Session["TicketNumber"].ToString();
                // Problem Number
                lblProblemNoDisplayed.Text = Session["ProblemNumber"].ToString();

                int resolutionNumber = 1;
                lblResolutionNoDisplayed.Text = resolutionNumber.ToString();
              
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

        protected void btnReturnToOpenProblems_Click(object sender, EventArgs e)
        {
            Response.Redirect("OpenProblemPage.aspx");

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            lblErrorMessage.Text = "";
            txtResolution.Text = "";
            lblValidationResolution.Text = "";
            ddlTechnician.SelectedValue = "0";
            lblTechnician.Text = "";
            txtHours.Text = "";
            lblValidationHours.Text = "";
            txtMileage.Text = "";
            lblValidationMileage.Text = "";
            txtMilesCost.Text = "";
            lblValidationMilesCost.Text = "";
            txtSupplies.Text = "";
            lblValidationSupplies.Text = "";
            txtMisc.Text = "";
            lblValidationMisc.Text = "";
            txtDateFixed.Text = "";
            lblValidationDateFixed.Text = "";
            txtDateOnsite.Text = "";
            lblValidationDateOnSite.Text = "";
            chkNoCharge.Checked = false;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean DataIsValid = ResolutionFormDataValidation();

            lblErrorMessage.Text = "All Data Validated!";

            int chkNoChargeValue = 0;

            if (DataIsValid)
            {
                lblErrorMessage.Text = "";

                if (chkNoCharge.Checked == true)
                {
                    chkNoChargeValue = 1;
                }

                int ticketID = Convert.ToInt32(lblTicketNoDisplayed.Text);
                int problemNumber = Convert.ToInt32(lblProblemNoDisplayed.Text);
                int resolutionNumber = Convert.ToInt32(lblResolutionNoDisplayed.Text);

                int technicianID = Convert.ToInt32(ddlTechnician.SelectedValue);

                int returnValue = clsDatabase.InsertResolution( ticketID,
                                                                problemNumber,
                                                                resolutionNumber,
                                                                technicianID,
                                                                txtResolution.Text,                                                                  
                                                                txtHours.Text, 
                                                                txtMileage.Text, 
                                                                txtMilesCost.Text, 
                                                                txtSupplies.Text, 
                                                                txtMisc.Text, 
                                                                txtDateFixed.Text, 
                                                                txtDateOnsite.Text,
                                                                chkNoChargeValue);

                if (returnValue == -1)
                {
                    lblErrorMessage.Text = "Something went wrong! Resolution was not inserted!";
                }
                else
                {
                    ClearForm();
                    lblErrorMessage.Text = String.Format("Resolution {0} was inserted!", resolutionNumber);
                    lblResolutionNoDisplayed.Text = Convert.ToString(resolutionNumber++);
                }
            }
            else
            {
                lblErrorMessage.Text = "Enter valid data!";
            }

        }

        private Boolean ResolutionFormDataValidation()
        {
            Boolean blnDataIsValid = true;
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

            // Resolution field validation
            if (String.IsNullOrWhiteSpace(txtResolution.Text))
            {
                lblValidationResolution.Text = "Required field";
                blnDataIsValid = false;
            }
            else
            {
                lblValidationResolution.Text = "";
            }

            // Hours validation
            if (String.IsNullOrWhiteSpace(txtHours.Text))
            {
                lblValidationHours.Text = "Required field";
                blnDataIsValid = false;
            }
            else
            {
                if (!Decimal.TryParse(txtHours.Text, out Decimal decHours))
                {
                    lblValidationHours.Text = "Enter valid data";
                    blnDataIsValid = false;
                }
                else
                {
                    if (decHours <= 0)
                    {
                        lblValidationHours.Text = "Must be greater than 0";
                        blnDataIsValid = false;
                    }
                    else
                    {
                        lblValidationHours.Text = "";
                    }
                }
            }

                // Mileage validation
                if (!String.IsNullOrWhiteSpace(txtMileage.Text))
            {
                if (!Decimal.TryParse(txtMileage.Text, out Decimal decMileage))
                {
                    lblValidationMileage.Text = "Enter valid data";
                    blnDataIsValid = false;
                }
                else
                {
                    if (decMileage <= 0)
                    {
                        lblValidationMileage.Text = "Must be greater than 0";
                        blnDataIsValid = false;
                    }
                    else
                    {
                        lblValidationMileage.Text = "";
                    }
                }            
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(txtMilesCost.Text))
                {
                    lblValidationMileage.Text = "Required with Miles Cost";
                    blnDataIsValid = false;
                }
                else
                {
                    lblValidationMileage.Text = "";
                }
            }

            // Miles Cost validation
            if (!String.IsNullOrWhiteSpace(txtMilesCost.Text))
            {
                if (!Decimal.TryParse(txtMilesCost.Text, out Decimal decMilesCost))
                {
                    lblValidationMilesCost.Text = "Enter valid data";
                    blnDataIsValid = false;
                }
                else
                {
                    if (decMilesCost <= 0)
                    {
                        lblValidationMilesCost.Text = "Must be greater than 0";
                        blnDataIsValid = false;
                    }
                    else
                    {
                        lblValidationMilesCost.Text = "";
                    }
                }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(txtMileage.Text))
                {
                    lblValidationMilesCost.Text = "Required with Mileage";
                    blnDataIsValid = false;
                }
                else
                {
                    lblValidationMilesCost.Text = "";
                }
            }

            // Supplies validation
            if (!String.IsNullOrWhiteSpace(txtSupplies.Text))
            {
                if (!Decimal.TryParse(txtSupplies.Text, out Decimal decSupplies))
                {
                    lblValidationSupplies.Text = "Enter valid data";
                    blnDataIsValid = false;
                }
                else
                {
                    if (decSupplies <= 0)
                    {
                        lblValidationSupplies.Text = "Must be greater than 0";
                        blnDataIsValid = false;
                    }
                    else
                    {
                        lblValidationSupplies.Text = "";
                    }
                }
            }
            else
            {
                lblValidationSupplies.Text = "";
            }

            // Misc validation
            if (!String.IsNullOrWhiteSpace(txtMisc.Text))
            {
                if (!Decimal.TryParse(txtMisc.Text, out Decimal decMisc))
                {
                    lblValidationMisc.Text = "Enter valid data";
                    blnDataIsValid = false;
                }
                else
                {
                    if (decMisc <= 0)
                    {
                        lblValidationMisc.Text = "Must be greater than 0";
                        blnDataIsValid = false;
                    }
                    else
                    {
                        lblValidationMisc.Text = "";
                    }
                }
            }
            else
            {
                lblValidationMisc.Text = "";
            }

            // Date Fixed validation
            if (!String.IsNullOrWhiteSpace(txtDateFixed.Text))
            {
                if (Convert.ToDateTime(txtDateFixed.Text) > DateTime.Now)
                {
                    lblValidationDateFixed.Text = "Can't be a future date";
                    blnDataIsValid = false;
                }
                else
                {
                    lblValidationDateFixed.Text = "";
                }
            }
            else
            {
                lblValidationDateFixed.Text = "";
            }

            return blnDataIsValid;
        }
    }
}