using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PPT
{
    public partial class Resend_Credentails : System.Web.UI.Page
    {
        DAL constr = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                fill_drpdwn();
            }
            Session["PVID"] = null;
        }

        private void fill_drpdwn()
        {

            using (SqlConnection con = new SqlConnection(constr.getconstr()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT PROJNAME FROM PROJDETAILS"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    Drp_Project_Name.DataSource = cmd.ExecuteReader();
                    Drp_Project_Name.DataValueField = "PROJNAME";
                    Drp_Project_Name.DataBind();
                    con.Close();
                }
            }
            Drp_Project_Name.Items.Insert(0, new ListItem("--Select Project--", "0"));
            Drp_User_Group.Items.Insert(0, new ListItem("--Select User Group--", "0"));
            Drp_User.Items.Insert(0, new ListItem("--Select User--", "0"));
        }
        private void fill_drpdwn_User_Group_ID()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr.getconstr());
                SqlCommand cmd = new SqlCommand("Get_User_Group_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Project_Name", Drp_Project_Name.SelectedValue);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                Drp_User_Group.DataSource = ds.Tables[0];
                Drp_User_Group.DataValueField = "UserGroup_Name";
                Drp_User_Group.DataBind();
                con.Close();
                Drp_User_Group.Items.Insert(0, new ListItem("--Select User Group--", "0"));
            }

            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }
        private void fill_drpdwn_User_ID()
        {
            try
            {

                SqlConnection con = new SqlConnection(constr.getconstr());
                SqlCommand cmd = new SqlCommand("Get_User_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Project_Name", Drp_Project_Name.SelectedValue);
                cmd.Parameters.AddWithValue("@UserGroup_Name", Drp_User_Group.SelectedValue);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                Drp_User.DataSource = ds.Tables[0];
                Drp_User.DataValueField = "User_Name";
                Drp_User.DataBind();
                con.Close();
                Drp_User.Items.Insert(0, new ListItem("--Select User--", "0"));
            }

            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }
        protected void Drp_User_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_drpdwn_User_ID();
            if (Drp_User.SelectedValue != "0")
            {
                getdata();
                btnUnLock.Visible = true;
                btnResendC.Visible = true;
                btnResetPass.Visible = true;
               

            }
            else
            {
                btnUnLock.Visible = false;
                btnResendC.Visible = false;
                btnResetPass.Visible = false;
                txtEmail.Text = "";
                lblErrorMsg2.Text = "";
               
            }
        }
      
       
        protected void Drp_Project_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_drpdwn_User_Group_ID();
            fill_drpdwn_User_ID();
            if (Drp_User.SelectedValue != "0")
            {
                getdata();
                btnUnLock.Visible = true;
                btnResendC.Visible = true;
                btnResetPass.Visible = true;

            }
            else
            {
                btnUnLock.Visible = false;
                btnResendC.Visible = false;
                btnResetPass.Visible = false;
                txtEmail.Text = "";
                lblErrorMsg2.Text = "";
            }
        }

        private void getdata()
        {
            try
            {
                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.Get_LockUnlock(Action: "LockUnlock", User_Name: Drp_User.SelectedValue.ToString());
                if (ds.Tables.Count > 0)
                {
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email_ID"].ToString();
                    if (ds.Tables[0].Rows[0]["Locked"].ToString() == "True")
                    {
                       
                        btnUnLock.Visible = true;
                        btnUnLock.Text = "Unlock";
                    }
                    else
                    {
                        btnUnLock.Visible = true;

                        btnUnLock.Text = "Lock";
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }

        }

        protected void Drp_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Drp_User.SelectedValue != "0")
            {
                getdata();
                btnUnLock.Visible = true;
                btnResendC.Visible = true;
                btnResetPass.Visible = true;

            }
            else
            {
                btnUnLock.Visible = false;
                btnResendC.Visible = false;
                btnResetPass.Visible = false;
                txtEmail.Text = "";
                lblErrorMsg2.Text = "";
            }
        }

        protected void btnUnLock_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnUnLock.Text == "Unlock")
                {
                    DAL dal = new DAL();
                    DataSet ds = new DataSet();
                    ds = dal.Get_LockUnlock(Action: "Unlock", User_Name: Drp_User.SelectedValue.ToString());

                    lblLock.Text = "The Account has be Successfully Unlocked";
                    btnUnLock.Text = "Lock";
                }
                else if (btnUnLock.Text == "Lock")
                {
                    DAL dal = new DAL();
                    DataSet ds = new DataSet();
                    ds = dal.Get_LockUnlock(Action: "Lock", User_Name: Drp_User.SelectedValue.ToString());

                    lblLock.Text = "The Account has be Successfully Locked";
                    btnUnLock.Text = "Unlock";
                }


            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }
        }

        protected void SendEmail(string User_Name, string Email_ID)
        {
            try
            {
                string EmailAdd = "helpdesk@diagnosearch.com";
                string CCEmailAddress = "";
                string E_Sub = "";
                string E_Body = "";
                CommonFunction commFun = new CommonFunction();

                SqlConnection con = new SqlConnection(constr.getconstr());

                string UID = "";
                string PWD = "";

                SqlCommand cmd3 = new SqlCommand();
                SqlDataReader myReader;
                con = new SqlConnection(constr.getconstr());

                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Connection = con;
                con.Open();

                cmd3.CommandText = "GetPassword";
                cmd3.Parameters.AddWithValue("@User_Name", User_Name);

                myReader = cmd3.ExecuteReader();

                while (myReader.Read())
                {
                    UID = myReader["User_ID"].ToString();
                    PWD = myReader["PWD"].ToString();
                }
                con.Close();


                // Send User ID in Email
                SqlCommand cmd4 = new SqlCommand();
                SqlDataReader myReader1;
                con = new SqlConnection(constr.getconstr());

                cmd4.CommandType = CommandType.StoredProcedure;
                cmd4.Connection = con;
                con.Open();

                cmd4.CommandText = "Get_Email_Details";
                cmd4.Parameters.AddWithValue("@ID", 5);

                CCEmailAddress = "";
                E_Sub = "";
                E_Body = "";
                EmailAdd = Email_ID;

                myReader1 = cmd4.ExecuteReader();
                while (myReader1.Read())
                {
                    //CCEmailAddress = myReader1["E_CC"].ToString();
                    E_Sub = myReader1["E_Sub"].ToString();
                    E_Body = myReader1["E_Body"].ToString() + " " + UID.ToString();
                }
                con.Close();

                commFun.Email_Users(EmailAdd, CCEmailAddress, E_Sub, E_Body);

                //Send PWD in Email

                SqlCommand cmd5 = new SqlCommand();
                SqlDataReader myReader2;

                cmd5.CommandType = CommandType.StoredProcedure;
                cmd5.Connection = con;
                con.Open();

                cmd5.CommandText = "Get_Email_Details";
                cmd5.Parameters.AddWithValue("@ID", 6);

                CCEmailAddress = "";
                E_Sub = "";
                E_Body = "";
                EmailAdd = Email_ID;

                myReader2 = cmd5.ExecuteReader();
                while (myReader2.Read())
                {
                    //CCEmailAddress = myReader2["E_CC"].ToString();
                    E_Sub = myReader2["E_Sub"].ToString();
                    E_Body = myReader2["E_Body"].ToString() + " " + PWD.ToString();
                }
                con.Close();

                commFun.Email_Users(EmailAdd, CCEmailAddress, E_Sub, E_Body);

                //Response.Write("<script> alert('Record Updated successfully.'); </script>");
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
                throw;

            }
        }


        protected void ResetPassword(string User_Name, string Email_ID)
        {
            try
            {
                string EmailAdd = "helpdesk@diagnosearch.com";
                string CCEmailAddress = "";
                string E_Sub = "";
                string E_Body = "";
                CommonFunction commFun = new CommonFunction();

                SqlConnection con = new SqlConnection(constr.getconstr());

                string UID = "";
                string PWD = "";

                SqlCommand cmd3 = new SqlCommand();
                SqlDataReader myReader;
                con = new SqlConnection(constr.getconstr());

                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Connection = con;
                con.Open();

                cmd3.CommandText = "GetPassword";
                cmd3.Parameters.AddWithValue("@User_Name", User_Name);

                myReader = cmd3.ExecuteReader();

                while (myReader.Read())
                {
                    UID = myReader["User_ID"].ToString();
                    PWD = myReader["PWD"].ToString();
                }
                con.Close();


                //Send PWD in Email

                SqlCommand cmd5 = new SqlCommand();
                SqlDataReader myReader2;

                cmd5.CommandType = CommandType.StoredProcedure;
                cmd5.Connection = con;
                con.Open();

                cmd5.CommandText = "Get_Email_Details";
                cmd5.Parameters.AddWithValue("@ID", 4);

                CCEmailAddress = "";
                E_Sub = "";
                E_Body = "";
                EmailAdd = Email_ID;

                myReader2 = cmd5.ExecuteReader();
                while (myReader2.Read())
                {
                    //CCEmailAddress = myReader2["E_CC"].ToString();
                    E_Sub = myReader2["E_Sub"].ToString();
                    E_Body = myReader2["E_Body"].ToString() + " " + PWD.ToString();
                }
                con.Close();

                commFun.Email_Users(EmailAdd, CCEmailAddress, E_Sub, E_Body);

              //  Response.Write("<script> alert('Password Reset successfully.');window.location='Resend_Credentails.aspx'; </script>");
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
                throw;

            }
        }
        protected void btnResendC_Click(object sender, EventArgs e)
        {
            try
            {
                SendEmail(Drp_User.SelectedValue, txtEmail.Text);

               
                lblErrorMsg2.Text = "Resend Credentials Successfully";
                btnResendC.Visible = false;
                
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }
        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            try
            {
                ResetPassword(Drp_User.SelectedValue, txtEmail.Text);

               
                lblErrorMsg2.Text = "Password Reset Successfully";
                btnResetPass.Visible = false;
               
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }
        }
    }
}