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
    public partial class Delete_User_Group : System.Web.UI.Page
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
        protected void Btn_Get_UG_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(constr.getconstr());
                SqlCommand cmd = new SqlCommand("Get_UG_User_Count", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Project_Name", Drp_Project_Name.SelectedValue);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                ad.Fill(ds);
                Grd_User_List.DataSource = ds.Tables[0];
                Grd_User_List.DataBind();
             }

            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }
        protected void Bth_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                Int16 i;

                SqlConnection con = new SqlConnection(constr.getconstr());

                for (i = 0; i < Grd_User_List .Rows.Count; i++)
                {

                    SqlCommand cmd = new SqlCommand("Add_Upd_UserGroups", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    CheckBox ChAction;
                    ChAction = (CheckBox)Grd_User_List.Rows[i].FindControl("Chk_UG");

                    if (ChAction.Checked)
                    {
                        TextBox UG_Name;
                        UG_Name = (TextBox)Grd_User_List.Rows[i].FindControl("txt_UG_Name");

                        cmd.Parameters.AddWithValue("@Action", "Delete");
                        cmd.Parameters.AddWithValue("@Project_Name", Drp_Project_Name.SelectedValue);
                        cmd.Parameters.AddWithValue("@UserGroup_Name", (UG_Name.Text));

                        con.Open();
                        cmd.ExecuteNonQuery();

                        con.Close();
                        
                    }

                }
                Response.Write("<script> alert('Record Deleted successfully.');window.location='Delete_User_Group.aspx'; </script>");
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
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

        }
      
    }
}