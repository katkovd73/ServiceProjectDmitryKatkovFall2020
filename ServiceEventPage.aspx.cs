using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceProjectDmitryKatkovFall2020
{
    public partial class ServiceEventPage : System.Web.UI.Page
    {
        //string newTicketNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblErrorMessage.Text = "";
                lblEventDateDisplayed.Text = DateTime.Now.ToString("M/d/yyyy");
                LoadClients();
            }
        }

        protected void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuPage.aspx");
        }

        private void LoadClients()
        {
            DataSet dsData;

            dsData = clsDatabase.GetClientsList();

            if (dsData == null)
            {
                lblErrorMessage.Text = "Error retrieving Clients list";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblErrorMessage.Text = "Error retrieving Clients list";
                dsData.Dispose();
            }
            else
            {
                ddlClient.Items.Clear();
                ddlClient.AppendDataBoundItems = true;
                ddlClient.Items.Add(new ListItem(" --Select Client--", "0"));
                ddlClient.DataSource = dsData.Tables[0];
                ddlClient.DataTextField = "ClientName";
                ddlClient.DataValueField = "ClientID";
                ddlClient.DataBind();

                dsData.Dispose();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
                Boolean DataIsValid = ServiceEventDataValidation();
                if (DataIsValid)
                {
                    lblErrorMessage.Text = "";

                    int clientID = Convert.ToInt32(ddlClient.SelectedValue);

                    string newTicketNumber = clsDatabase.CreateServiceEvent(clientID, txtContact.Text, txtPhone.Text);

                    if(newTicketNumber == "")
                    {
                        lblErrorMessage.Text = "Ticket is not created!";
                    }
                    else
                    {
                        lblErrorMessage.Text = "";
                        Session["ClientName"] = ddlClient.SelectedItem;
                        Session["TicketNumber"] = newTicketNumber;
                        Response.Redirect("ProblemEntryPage.aspx");
                    }                    
                }
                else
                {
                    lblErrorMessage.Text = "Enter valid data!";
                }            
        }

        private Boolean ServiceEventDataValidation()
        {
            Boolean blnDataIsValid = true;
            // Client dropdown validation
            if (ddlClient.SelectedValue == "0")
            {
                lblValidationClient.Text = "Choose client";
                blnDataIsValid = false;
            }
            else
            {
                lblValidationClient.Text = "";
            }

            // Contact field validation
            if (String.IsNullOrWhiteSpace(txtContact.Text))
            {
                lblValidationContact.Text = "Required field";
                blnDataIsValid = false;
            }
            else
            {
                lblValidationContact.Text = "";
            }
            
            // Phone validation
            if (String.IsNullOrWhiteSpace(txtPhone.Text))
            {
                lblValidationPhone.Text = "Required field";
                blnDataIsValid = false;
            }
            else
            {
                if (txtPhone.Text.Length != 10)
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            lblValidationClient.Text = "";
            lblValidationContact.Text = "";
            lblValidationPhone.Text = "";
            ddlClient.SelectedValue = "0";
            txtContact.Text = "";
            txtPhone.Text = "";
        }
    }
}