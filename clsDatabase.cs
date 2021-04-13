using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ServiceProjectDmitryKatkovFall2020
{
    public class clsDatabase
    {
        //***** AcquireConnection()
        private static SqlConnection AcquireConnection()
        {
            SqlConnection cnSQL = null;
            Boolean blnErrorOccurred = false;

            if (ConfigurationManager.ConnectionStrings["ServiceCenter"] != null)
            {
                cnSQL = new SqlConnection();
                cnSQL.ConnectionString = ConfigurationManager.ConnectionStrings["ServiceCenter"].ToString();

                try
                {
                    cnSQL.Open();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return cnSQL;
            }
        }

        //***** GetTechnicianByID()
        public static DataSet GetTechnicianByID(string strTechID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            if (strTechID.Trim().Length > 0)
            {
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    blnErrorOccurred = true;
                }
                else
                {
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "uspGetTechnicianByID";

                    cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.NVarChar, 10));
                    cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@TechnicianID"].Value = strTechID;

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    dsSQL = new DataSet();
                    try
                    {
                        daSQL = new SqlDataAdapter(cmdSQL);
                        intRetCode = daSQL.Fill(dsSQL);
                        daSQL.Dispose();
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                        dsSQL.Dispose();
                    }
                    finally
                    {
                        cmdSQL.Parameters.Clear();
                        cmdSQL.Dispose();
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        //***** GetTechnicianList()
        public static DataSet GetTechnicianList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetTechnicianList";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        // Insert New Technician
        public static int InsertTechnician(string FirstName,
                                            string LastName,
                                            string Phone,
                                            decimal HourlyRate,
                                            string MidInitial,
                                            string Email,
                                            string Department)
        {
            SqlConnection cnSQL;
            SqlCommand cmdInsertTechnician;
            Boolean blnErrorOccurred = false;
            int intResult = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdInsertTechnician = new SqlCommand();
                cmdInsertTechnician.Connection = cnSQL;
                cmdInsertTechnician.CommandType = CommandType.StoredProcedure;
                cmdInsertTechnician.CommandText = "uspInsertTechnician";

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@NewTechnicianID", SqlDbType.Int));
                cmdInsertTechnician.Parameters["@NewTechnicianID"].Direction = ParameterDirection.Output;

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar));
                cmdInsertTechnician.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdInsertTechnician.Parameters["@LName"].Value = LastName;

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar));
                cmdInsertTechnician.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdInsertTechnician.Parameters["@FName"].Value = FirstName;

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@MInit", SqlDbType.NChar));
                cmdInsertTechnician.Parameters["@MInit"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(MidInitial))
                {
                    cmdInsertTechnician.Parameters["@MInit"].Value = DBNull.Value;
                }
                else
                {
                    cmdInsertTechnician.Parameters["@MInit"].Value = MidInitial;
                }

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar));
                cmdInsertTechnician.Parameters["@EMail"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(Email))
                {
                    cmdInsertTechnician.Parameters["@EMail"].Value = DBNull.Value;
                }
                else
                {
                    cmdInsertTechnician.Parameters["@EMail"].Value = Email;
                }

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar));
                cmdInsertTechnician.Parameters["@Dept"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(Department))
                {
                    cmdInsertTechnician.Parameters["@Dept"].Value = DBNull.Value;
                }
                else
                {
                    cmdInsertTechnician.Parameters["@Dept"].Value = Department;
                }

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar));
                cmdInsertTechnician.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdInsertTechnician.Parameters["@Phone"].Value = Phone;

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@HRate", SqlDbType.Money));
                cmdInsertTechnician.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdInsertTechnician.Parameters["@HRate"].Value = HourlyRate;

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdInsertTechnician.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    cmdInsertTechnician.ExecuteNonQuery();
                    intResult = 0;
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    intResult = -1;
                }
                finally
                {
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            return intResult;
        }

        // Update Technician Information
        public static int UpdateTechnician(int TechnicianID,
                                           string FirstName,
                                           string LastName,
                                           string Phone,
                                           decimal HourlyRate,
                                           string MidInitial,
                                           string Email,
                                           string Department)
        {
            SqlConnection cnSQL;
            SqlCommand cmdUpdateTechnician;
            Boolean blnErrorOccurred = false;
            int intResult = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdUpdateTechnician = new SqlCommand();
                cmdUpdateTechnician.Connection = cnSQL;
                cmdUpdateTechnician.CommandType = CommandType.StoredProcedure;
                cmdUpdateTechnician.CommandText = "uspUpdateTechnician";

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.Int));
                cmdUpdateTechnician.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdUpdateTechnician.Parameters["@TechnicianID"].Value = TechnicianID;

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar));
                cmdUpdateTechnician.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdUpdateTechnician.Parameters["@LName"].Value = LastName;

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar));
                cmdUpdateTechnician.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdUpdateTechnician.Parameters["@FName"].Value = FirstName;

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@MInit", SqlDbType.NChar));
                cmdUpdateTechnician.Parameters["@MInit"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(MidInitial))
                {
                    cmdUpdateTechnician.Parameters["@MInit"].Value = DBNull.Value;
                }
                else
                {
                    cmdUpdateTechnician.Parameters["@MInit"].Value = MidInitial;
                }

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar));
                cmdUpdateTechnician.Parameters["@EMail"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(Email))
                {
                    cmdUpdateTechnician.Parameters["@EMail"].Value = DBNull.Value;
                }
                else
                {
                    cmdUpdateTechnician.Parameters["@EMail"].Value = Email;
                }

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar));
                cmdUpdateTechnician.Parameters["@Dept"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(Department))
                {
                    cmdUpdateTechnician.Parameters["@Dept"].Value = DBNull.Value;
                }
                else
                {
                    cmdUpdateTechnician.Parameters["@Dept"].Value = Department;
                }

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar));
                cmdUpdateTechnician.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdUpdateTechnician.Parameters["@Phone"].Value = Phone;

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@HRate", SqlDbType.Money));
                cmdUpdateTechnician.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdUpdateTechnician.Parameters["@HRate"].Value = HourlyRate;

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdUpdateTechnician.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    cmdUpdateTechnician.ExecuteNonQuery();
                    intResult = 0;
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    intResult = -1;
                }
                finally
                {
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            return intResult;
        }

        // Delete Technician
        public static int DeleteTechnician(int TechnicianID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdInsertTechnician;
            Boolean blnErrorOccurred = false;
            int intResult = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdInsertTechnician = new SqlCommand();
                cmdInsertTechnician.Connection = cnSQL;
                cmdInsertTechnician.CommandType = CommandType.StoredProcedure;
                cmdInsertTechnician.CommandText = "uspDeleteTechnician";

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.NVarChar));
                cmdInsertTechnician.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdInsertTechnician.Parameters["@TechnicianID"].Value = TechnicianID;

                cmdInsertTechnician.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdInsertTechnician.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    cmdInsertTechnician.ExecuteNonQuery();
                    intResult = 0;
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    intResult = -1;
                }
                finally
                {
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            return intResult;
        }

        //***** GetTechnicianList()
        public static DataSet GetClientsList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetClientList";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        //***** GetProductList()
        public static DataSet GetProductList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetProductList";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        //***** Create New Ticket (Service Event) and return its number
        public static string CreateServiceEvent(int ClientID, string Contact, string Phone)
        {
            SqlConnection cnSQL;
            SqlCommand cmdUpdateTechnician;
            Boolean blnErrorOccurred = false;
            string newTicketNimber = "";

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdUpdateTechnician = new SqlCommand();
                cmdUpdateTechnician.Connection = cnSQL;
                cmdUpdateTechnician.CommandType = CommandType.StoredProcedure;
                cmdUpdateTechnician.CommandText = "uspInsertServiceEvent";

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@ClientID", SqlDbType.Int));
                cmdUpdateTechnician.Parameters["@ClientID"].Direction = ParameterDirection.Input;
                cmdUpdateTechnician.Parameters["@ClientID"].Value = ClientID;

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@Contact", SqlDbType.NVarChar));
                cmdUpdateTechnician.Parameters["@Contact"].Direction = ParameterDirection.Input;
                cmdUpdateTechnician.Parameters["@Contact"].Value = Contact;

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar));
                cmdUpdateTechnician.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdUpdateTechnician.Parameters["@Phone"].Value = Phone;

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@EventDate", SqlDbType.DateTime));
                cmdUpdateTechnician.Parameters["@EventDate"].Direction = ParameterDirection.Input;
                cmdUpdateTechnician.Parameters["@EventDate"].Value = DateTime.Now;

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@NewTicketID", SqlDbType.Int));
                cmdUpdateTechnician.Parameters["@NewTicketID"].Direction = ParameterDirection.Output;                

                cmdUpdateTechnician.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdUpdateTechnician.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    cmdUpdateTechnician.ExecuteNonQuery();
                    newTicketNimber = cmdUpdateTechnician.Parameters["@NewTicketID"].Value.ToString();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    newTicketNimber = "";
                }
                finally
                {
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            return newTicketNimber;
        }

        // Insert New Problem
        public static int InsertProblem(int ticketID,
                                         int problemNumber,
                                         string problemDescription,
                                         string productID,
                                         int technicianID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdInsertProblem;
            Boolean blnErrorOccurred = false;
            int intResult = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdInsertProblem = new SqlCommand();
                cmdInsertProblem.Connection = cnSQL;
                cmdInsertProblem.CommandType = CommandType.StoredProcedure;
                cmdInsertProblem.CommandText = "uspInsertProblem";

                cmdInsertProblem.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int));
                cmdInsertProblem.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                cmdInsertProblem.Parameters["@TicketID"].Value = ticketID;

                cmdInsertProblem.Parameters.Add(new SqlParameter("@IncidentNo", SqlDbType.Int));
                cmdInsertProblem.Parameters["@IncidentNo"].Direction = ParameterDirection.Input;
                cmdInsertProblem.Parameters["@IncidentNo"].Value = problemNumber;

                cmdInsertProblem.Parameters.Add(new SqlParameter("@ProbDesc", SqlDbType.NVarChar));
                cmdInsertProblem.Parameters["@ProbDesc"].Direction = ParameterDirection.Input;
                cmdInsertProblem.Parameters["@ProbDesc"].Value = problemDescription;

                cmdInsertProblem.Parameters.Add(new SqlParameter("@TechID", SqlDbType.Int));
                cmdInsertProblem.Parameters["@TechID"].Direction = ParameterDirection.Input;
                cmdInsertProblem.Parameters["@TechID"].Value = technicianID;

                cmdInsertProblem.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.NVarChar));
                cmdInsertProblem.Parameters["@ProductID"].Direction = ParameterDirection.Input;
                cmdInsertProblem.Parameters["@ProductID"].Value = productID;

                cmdInsertProblem.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdInsertProblem.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    cmdInsertProblem.ExecuteNonQuery();
                    intResult = 0;
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    intResult = -1;
                }
                finally
                {
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            return intResult;
        }

        //***** GetOpenProblemList()
        public static DataSet GetOpenProblemList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetOpenProblems";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        // Insert Resolution
        public static int InsertResolution(int ticketID,
                                           int incidentNumber,
                                           int resolutionNumber,
                                           int technicianID,
                                           string Resolution,
                                           string Hours,
                                           string Mileage,
                                           string MilesCost,
                                           string Supplies,
                                           string Misc,
                                           string DateFixed,
                                           string DateOnsite,
                                           int chkNoChargeValue)
        {
            SqlConnection cnSQL;
            SqlCommand cmdInsertResolution;
            Boolean blnErrorOccurred = false;
            int intResult = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdInsertResolution = new SqlCommand();
                cmdInsertResolution.Connection = cnSQL;
                cmdInsertResolution.CommandType = CommandType.StoredProcedure;
                cmdInsertResolution.CommandText = "uspInsertResolution";

                // Ticket ID
                cmdInsertResolution.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int));
                cmdInsertResolution.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                cmdInsertResolution.Parameters["@TicketID"].Value = ticketID;

                // Incident (Problem) Number
                cmdInsertResolution.Parameters.Add(new SqlParameter("@IncidentNo", SqlDbType.Int));
                cmdInsertResolution.Parameters["@IncidentNo"].Direction = ParameterDirection.Input;
                cmdInsertResolution.Parameters["@IncidentNo"].Value = incidentNumber;

                // Resolution Number
                cmdInsertResolution.Parameters.Add(new SqlParameter("@ResNo", SqlDbType.Int));
                cmdInsertResolution.Parameters["@ResNo"].Direction = ParameterDirection.Input;
                cmdInsertResolution.Parameters["@ResNo"].Value = resolutionNumber;

                // Resolution Description
                cmdInsertResolution.Parameters.Add(new SqlParameter("@ResDesc", SqlDbType.NVarChar));
                cmdInsertResolution.Parameters["@ResDesc"].Direction = ParameterDirection.Input;
                cmdInsertResolution.Parameters["@ResDesc"].Value = Resolution;

                // Date (and Time) when problem is fixed
                cmdInsertResolution.Parameters.Add(new SqlParameter("@DateFix", SqlDbType.DateTime));
                cmdInsertResolution.Parameters["@DateFix"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(DateFixed))
                {
                    cmdInsertResolution.Parameters["@DateFix"].Value = DBNull.Value;
                }
                else
                {
                    cmdInsertResolution.Parameters["@DateFix"].Value = DateFixed;
                }

                // Date (and Time) on site
                cmdInsertResolution.Parameters.Add(new SqlParameter("@DateOnsite", SqlDbType.DateTime));
                cmdInsertResolution.Parameters["@DateOnsite"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(DateOnsite))
                {
                    cmdInsertResolution.Parameters["@DateOnsite"].Value = DBNull.Value;
                }
                else
                {
                    cmdInsertResolution.Parameters["@DateOnsite"].Value = DateOnsite;
                }

                // Technician ID
                cmdInsertResolution.Parameters.Add(new SqlParameter("@TechID", SqlDbType.Int));
                cmdInsertResolution.Parameters["@TechID"].Direction = ParameterDirection.Input;
                cmdInsertResolution.Parameters["@TechID"].Value = technicianID;

                // Hours
                cmdInsertResolution.Parameters.Add(new SqlParameter("@Hours", SqlDbType.Decimal));
                cmdInsertResolution.Parameters["@Hours"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(Hours))
                {
                    cmdInsertResolution.Parameters["@Hours"].Value = DBNull.Value;
                }
                else
                {
                    cmdInsertResolution.Parameters["@Hours"].Value = Convert.ToDecimal(Hours);
                }

                // Mileage
                cmdInsertResolution.Parameters.Add(new SqlParameter("@Mileage", SqlDbType.Decimal));
                cmdInsertResolution.Parameters["@Mileage"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(Mileage))
                {
                    cmdInsertResolution.Parameters["@Mileage"].Value = DBNull.Value;
                }
                else
                {
                    cmdInsertResolution.Parameters["@Mileage"].Value = Convert.ToDecimal(Mileage);
                }

                // CostMiles
                cmdInsertResolution.Parameters.Add(new SqlParameter("@CostMiles", SqlDbType.Money));
                cmdInsertResolution.Parameters["@CostMiles"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(MilesCost))
                {
                    cmdInsertResolution.Parameters["@CostMiles"].Value = DBNull.Value;
                }
                else
                {
                    cmdInsertResolution.Parameters["@CostMiles"].Value = Convert.ToDecimal(MilesCost);
                }

                // Supplies
                cmdInsertResolution.Parameters.Add(new SqlParameter("@Supplies", SqlDbType.Money));
                cmdInsertResolution.Parameters["@Supplies"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(Supplies))
                {
                    cmdInsertResolution.Parameters["@Supplies"].Value = DBNull.Value;
                }
                else
                {
                    cmdInsertResolution.Parameters["@Supplies"].Value = Convert.ToDecimal(Supplies);
                }

                // Misc
                cmdInsertResolution.Parameters.Add(new SqlParameter("@Misc", SqlDbType.Money));
                cmdInsertResolution.Parameters["@Misc"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(Misc))
                {
                    cmdInsertResolution.Parameters["@Misc"].Value = DBNull.Value;
                }
                else
                {
                    cmdInsertResolution.Parameters["@Misc"].Value = Convert.ToDecimal(Misc);
                }

                // No charge text box
                cmdInsertResolution.Parameters.Add(new SqlParameter("@NoCharge", SqlDbType.Int));
                cmdInsertResolution.Parameters["@NoCharge"].Direction = ParameterDirection.Input;
                cmdInsertResolution.Parameters["@NoCharge"].Value = chkNoChargeValue;

                // ErrCode
                cmdInsertResolution.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdInsertResolution.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    cmdInsertResolution.ExecuteNonQuery();
                    intResult = 0;
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    intResult = -1;
                }
                finally
                {
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            return intResult;
        }

        //***** GetReport()
        public static DataSet GetReport(string storedProcedure)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = storedProcedure;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }
    }
}
