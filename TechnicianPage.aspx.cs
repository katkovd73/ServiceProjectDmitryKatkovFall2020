using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceProjectDmitryKatkovFall2020
{
    public partial class TechnicianPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblErrorMessage.Text = "";
                btnCancel.Enabled = false;
                LoadTechnicians();
            }
        }

        // Loading Technicians in the dropdown list
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

        protected void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuPage.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {            
            // setting ddlTechnicians to--Select Technicians--
            ddlTechnician.SelectedValue = "0";

            ClearTechnicianForm();
        }

        private void ClearTechnicianForm()
        {
            txtFirstName.Text = "";
            txtMiddleInitial.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtDepartment.Text = "";
            txtPhone.Text = "";
            txtHourlyRate.Text = "";
            lblErrorMessage.Text = "";
            lblValidationFirstName.Text = "";
            lblValidationLastName.Text = "";
            lblValidationPhone.Text = "";
            lblValidationHourlyRate.Text = "";
        }

        protected void ddlTechnician_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            if (ddlTechnician.SelectedValue == "0")
            {
                ClearTechnicianForm();
            }
            else
            {
                DisplayTechnicianData(ddlTechnician.SelectedValue.ToString());
            }
        }

        // filling text boxes for selected Technician
        private void DisplayTechnicianData(string strTechnicianID)
        {
            DataSet dsData;

            dsData = clsDatabase.GetTechnicianByID(strTechnicianID);

            if (dsData == null)
            {
                lblErrorMessage.Text = "Error retrieving Technician";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblErrorMessage.Text = "Error retrieving Technician";
                dsData.Dispose();
            }
            else
            {
                // required fields
                txtFirstName.Text = dsData.Tables[0].Rows[0]["FName"].ToString();
                txtLastName.Text = dsData.Tables[0].Rows[0]["LName"].ToString();
                txtPhone.Text = dsData.Tables[0].Rows[0]["Phone"].ToString();
                string strHourlyRate = dsData.Tables[0].Rows[0]["HRate"].ToString();
                decimal HourlyRate = Convert.ToDecimal(strHourlyRate);
                txtHourlyRate.Text = HourlyRate.ToString("F2");

                // optional fields

                // Middle Inotial
                if (dsData.Tables[0].Rows[0]["MInit"] == DBNull.Value)
                {
                    txtMiddleInitial.Text = "";
                }
                else
                {
                    txtMiddleInitial.Text = dsData.Tables[0].Rows[0]["MInit"].ToString();
                }
                // Email
                if (dsData.Tables[0].Rows[0]["EMail"] == DBNull.Value)
                {
                    txtEmail.Text = "";
                }
                else
                {
                    txtEmail.Text = dsData.Tables[0].Rows[0]["Email"].ToString();
                }
                // Department
                if (dsData.Tables[0].Rows[0]["Dept"] == DBNull.Value)
                {
                    txtDepartment.Text = "";
                }
                else
                {
                    txtDepartment.Text = dsData.Tables[0].Rows[0]["Dept"].ToString();
                }
            }
        }

        // button New Technicion
        protected void btnNewTechnician_Click(object sender, EventArgs e)
        {
            // setting ddlTechnicians to--Select Technicians--
            ddlTechnician.SelectedValue = "0";

            ClearTechnicianForm();

            NewTechnicianMode();
        }

        private void NewTechnicianMode()
        {
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnNewTechnician.Enabled = false;
            ddlTechnician.Enabled = false;
            txtHourlyRate.Text = "50.00";
        }

        private void ExistingTechnicianMode()
        {
            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
            btnNewTechnician.Enabled = true;
            ClearTechnicianForm();
            ddlTechnician.Enabled = true;
        }

        // button Cancel
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ExistingTechnicianMode();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {           
            
                if (ddlTechnician.SelectedValue == "0" && btnNewTechnician.Enabled == true)
                {
                    lblErrorMessage.Text = "There is no data to save!";
                }
                else
                {
                Boolean DataIsValid = TechnicianDataValidation();
                if (DataIsValid)
                    {
                        InsertTechnician();
                    }
                    else
                    {
                        lblErrorMessage.Text = "Enter valid data!";
                    }
                }
        }

        private Boolean TechnicianDataValidation()
        {
            Boolean blnDataIsValid = true;
            // First Name validation
            if (String.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                lblValidationFirstName.Text = "Required field";
                blnDataIsValid = false;
            }
            else
            {
                lblValidationFirstName.Text = "";
            }

            // Last Name validation
            if (String.IsNullOrWhiteSpace(txtLastName.Text))
            {
                lblValidationLastName.Text = "Required field";
                blnDataIsValid = false;
            }
            else
            {
                lblValidationLastName.Text = "";
            }

            // Hourly Rate validation
            if (String.IsNullOrWhiteSpace(txtHourlyRate.Text))
            {
                lblValidationHourlyRate.Text = "Required field";
                blnDataIsValid = false;
            }
            else
            {
                if (!Decimal.TryParse(txtHourlyRate.Text, out decimal decHourlyRate))
                {
                    lblValidationHourlyRate.Text = "Invalid entry";
                    blnDataIsValid = false;
                }
                else
                {
                    if (Convert.ToDecimal(txtHourlyRate.Text) <= 0)
                    {
                        lblValidationHourlyRate.Text = "Invalid entry";
                        blnDataIsValid = false;
                    }
                    else
                    {
                        lblValidationHourlyRate.Text = "";
                    }
                }
            }

            // Phone Validation
            if (String.IsNullOrWhiteSpace(txtPhone.Text))
            {
                lblValidationPhone.Text = "Required field";
                blnDataIsValid = false;
            }
            else
            {
                if(txtPhone.Text.Length !=10)
                {
                    lblValidationPhone.Text = "Must have 10 digits";
                    blnDataIsValid = false;
                }
                else
                {
                    string strFirstNumber = txtPhone.Text.Substring(0, 1);

                    if (strFirstNumber == "0")
                    {
                        lblValidationPhone.Text = "First number cannot be zero";
                        blnDataIsValid = false;
                    }
                    else
                    {
                        if (!Int64.TryParse(txtPhone.Text, out Int64 intPhone))
                        {
                            lblValidationPhone.Text = "Enter valid numbers";
                            blnDataIsValid = false;
                        }
                        else
                        {
                            lblValidationPhone.Text = "";

                        }
                    }
                }
                       
            }

            return blnDataIsValid;
        }

        private void InsertTechnician()
        {
            Int32 intReturnValue;

            // Hourly Rate Validation
            if (!decimal.TryParse(txtHourlyRate.Text.Trim(), out decimal decHourlyRate))
            {
                lblErrorMessage.Text = "Enter Valid Number for Hourly Rate";
                lblValidationHourlyRate.Text = "Invalid value";
            }
            else
            {
                if (ddlTechnician.SelectedValue == "0")
                {
                    intReturnValue = clsDatabase.InsertTechnician(txtFirstName.Text.Trim(),
                                                                  txtLastName.Text.Trim(),
                                                                  txtPhone.Text.Trim(),
                                                                  decHourlyRate,
                                                                  txtMiddleInitial.Text.Trim(),
                                                                  txtEmail.Text.Trim(),
                                                                  txtDepartment.Text.Trim());
                }
                else
                {
                    Int32 TechnicianID = Convert.ToInt32(ddlTechnician.SelectedValue);
                    intReturnValue = clsDatabase.UpdateTechnician(TechnicianID,
                                                                  txtFirstName.Text.Trim(),
                                                                  txtLastName.Text.Trim(),
                                                                  txtPhone.Text.Trim(),
                                                                  decHourlyRate,
                                                                  txtMiddleInitial.Text.Trim(),
                                                                  txtEmail.Text.Trim(),
                                                                  txtDepartment.Text.Trim());
                }

                if (intReturnValue == 0) // 0 (success) or -1 (fail) is returned from clsDatabase
                {
                    LoadTechnicians();
                    ExistingTechnicianMode();
                    lblErrorMessage.Text = "Technician was successfully saved";
                }
                else
                {
                    lblErrorMessage.Text = "Technician was not saved";
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 intReturnValue = 0;

            if (ddlTechnician.SelectedValue != "0")
            {
                if (Int32.TryParse(ddlTechnician.SelectedValue, out Int32 TechnicianID))
                {
                    intReturnValue = clsDatabase.DeleteTechnician(TechnicianID);
                }
            }
            if (intReturnValue == 0)
            {
                LoadTechnicians();
                ExistingTechnicianMode();
                lblErrorMessage.Text = "Technician was successfully deleted";
            }
            else
            {
                lblErrorMessage.Text = "Something went wrong!";
            }
        }
    }
}