using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPT;
using System.Data.SqlClient;
using System.Data;

namespace eCRF_Templete
{
    public partial class HomePage : System.Web.UI.Page
    {
        DAL dal = new DAL();
        CommonFunction commFun = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["PVID"] = null;
        }

        protected void cmdSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string EmailAdd, CCEmailAddress, E_Sub, E_Body;
                SqlConnection con = new SqlConnection(dal.getconstr());
                SqlCommand cmd = new SqlCommand();
                SqlDataReader myReader;
                Boolean sendEmailYN = false;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandText = "Get_Email_ID";
                con.Open();

                myReader = cmd.ExecuteReader();
                EmailAdd = "";
                CCEmailAddress = "";
                while (myReader.Read())
                {
                    //Write logic to process data for the first result.

                    EmailAdd = "";
                    CCEmailAddress = "";
                    E_Sub = "";
                    E_Body = "";

                    EmailAdd = myReader["EMAILID"].ToString();
                    CCEmailAddress = myReader["CCEMAIL"].ToString();
                    E_Sub = myReader["Email_SUB"].ToString();
                    E_Body = myReader["Email_BODY"].ToString();

                    sendEmailYN = commFun.Email_Users(EmailAdd, CCEmailAddress, E_Sub, E_Body);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }


        }
    }
}