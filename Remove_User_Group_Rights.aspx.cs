using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PPT
{
    public partial class Remove_User_Group_Rights : System.Web.UI.Page
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
        protected void Btn_Get_Fun_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(constr.getconstr());
                SqlCommand cmd = new SqlCommand("Get_UG_Functions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Project_Name", Drp_Project_Name.SelectedValue);
                cmd.Parameters.AddWithValue("@UserGroup_Name", Drp_User_Group.SelectedValue);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }

            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }


        }
        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                Int16 i;

                SqlConnection con = new SqlConnection(constr.getconstr());

                for (i = 0; i < GridView1.Rows.Count; i++)
                {

                    SqlCommand cmd = new SqlCommand("Add_Up_Del_User_Group_Fun", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    CheckBox ChAction;
                    ChAction = (CheckBox)GridView1.Rows[i].FindControl("Chk_Sel_Fun");

                    if (ChAction.Checked)
                    {
                        TextBox Fn_ID;
                        Fn_ID = (TextBox)GridView1.Rows[i].FindControl("txt_Fun_ID");

                        cmd.Parameters.AddWithValue("@Action", "Delete");

                        cmd.Parameters.AddWithValue("@Project_Name", Drp_Project_Name.SelectedValue);

                        cmd.Parameters.AddWithValue("@UserGroup_Name", Drp_User_Group.SelectedValue);

                        cmd.Parameters.AddWithValue("@FunctionID", Convert.ToInt32(Fn_ID.Text));

                        cmd.Parameters.AddWithValue("@EnteredBy", Session["User_ID"].ToString ());

                        con.Open();
                        cmd.ExecuteNonQuery();

                        con.Close();
                        
                    }

                }
                Response.Write("<script> alert('Record Deleted successfully.');window.location='Remove_User_Group_Rights.aspx'; </script>");
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }
        protected void Drp_Project_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_drpdwn_User_Group_ID();
        }
    }
}