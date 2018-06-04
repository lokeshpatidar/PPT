using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eCRF_Templete
{
    public partial class AjaxFunction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //Method for get  userid from session    
        [WebMethod(EnableSession = true)]
        public static string GetUserId()
        {
            try
            {
                return HttpContext.Current.Session["User_ID"].ToString();
            }
            catch (Exception ex)
            {
                //  return ex.ToString();
                throw;
            }
        }

        //Method for get  Project ID from session    
        [WebMethod(EnableSession = true)]
        public static string GetProjectId()
        {
            try
            {
                return HttpContext.Current.Session["PROJECTID"].ToString();
            }
            catch (Exception ex)
            {
                //return ex.ToString();
                throw;
            }
        }

        //Method for get  SUBJID from session    
        [WebMethod(EnableSession = true)]
        public static string GetSubjID()
        {
            try
            {
                return HttpContext.Current.Session["SUBJID"].ToString();
            }
            catch (Exception ex)
            {
                // return ex.ToString();
                throw;
            }
        }

        //Method for get  INV from session    
        [WebMethod(EnableSession = true)]
        public static string GetINVID()
        {
            try
            {
                return HttpContext.Current.Session["INVID"].ToString();
            }
            catch (Exception ex)
            {
                // return ex.ToString();
                throw;
            }
        }


        //Method for update data in table and audit trial    
        [System.Web.Services.WebMethod]
        public static string UpdateData(string VISITNUM, string FieldName, string OldValue, string NewValue, string Reason, string Comments, string ControlType)
        {
            SqlCommand cmd;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPTConnection"].ConnectionString);
            try
            {

                string Project_ID = GetProjectId();
                string UserId = GetUserId();
                string SUBJID = GetSubjID();
                string INVID = GetINVID();

                if (VISITNUM != "NULL")//for visitdate update and audit trail
                {
                    cmd = new SqlCommand("CHANGE_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "UPDATE_Sub_Visit_Data");
                    cmd.Parameters.AddWithValue("@Project_ID", Project_ID);
                    cmd.Parameters.AddWithValue("@INVID", Convert.ToInt32(INVID));
                    cmd.Parameters.AddWithValue("@SUBJID", SUBJID);
                    cmd.Parameters.AddWithValue("@VISITNUM", VISITNUM);
                    cmd.Parameters.AddWithValue("@FIELDNAME", FieldName);
                    cmd.Parameters.AddWithValue("@OLDVALUE", OldValue);
                    cmd.Parameters.AddWithValue("@NEWVALUE", NewValue);
                    cmd.Parameters.AddWithValue("@REASON", Reason);
                    cmd.Parameters.AddWithValue("@COMMENTS", Comments);
                    cmd.Parameters.AddWithValue("@CHANGEBY", UserId);
                    cmd.Parameters.AddWithValue("@ControlType", ControlType);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else//for demograph data and audit trail
                {
                    if (FieldName == "DOB")
                    {                       
                        string date1 = System.DateTime.Now.ToString("dd-MMM-yyyy");
                        DateTime dt2 = Convert.ToDateTime(NewValue);
                        DateTime dt1 = Convert.ToDateTime(date1);
                        TimeSpan span = dt1 - dt2;
                        if (9862 >= span.TotalDays)
                        {
                            throw new Exception("Age should be greater than or equal to 27 years.");
                        }
                    }
                    cmd = new SqlCommand("CHANGE_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    cmd.Parameters.AddWithValue("@Project_ID", Project_ID);
                    cmd.Parameters.AddWithValue("@INVID", Convert.ToInt32(INVID));
                    cmd.Parameters.AddWithValue("@SUBJID", SUBJID);
                    if (VISITNUM != "NULL")
                    {
                        cmd.Parameters.AddWithValue("@VISITNUM", VISITNUM);
                    }
                    cmd.Parameters.AddWithValue("@FIELDNAME", FieldName);
                    cmd.Parameters.AddWithValue("@OLDVALUE", OldValue);
                    cmd.Parameters.AddWithValue("@NEWVALUE", NewValue);
                    cmd.Parameters.AddWithValue("@REASON", Reason);
                    cmd.Parameters.AddWithValue("@COMMENTS", Comments);
                    cmd.Parameters.AddWithValue("@CHANGEBY", UserId);
                    cmd.Parameters.AddWithValue("@ControlType", ControlType);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }  
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
            finally
            {
                cmd = null;
            }
            return "Record Updated successfully.";
        }
    }
}