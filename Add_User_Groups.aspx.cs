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
    public partial class Add_User_Groups : System.Web.UI.Page
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
            
            using (SqlConnection con = new SqlConnection(constr.getconstr ()))
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
        protected void Add_User_Group_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection con = new SqlConnection(constr.getconstr());
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Add_Upd_UserGroups";
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@Project_Name", Drp_Project_Name.SelectedItem.Text);                
                cmd.Parameters.AddWithValue("@UserGroup_Name", txt_User_Group.Text);
                cmd.Parameters.AddWithValue("@EnteredBy", Session["User_ID"].ToString());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script> alert('Record Updated successfully.');window.location='Add_User_Groups.aspx'; </script>");
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;                
            }


        }
    }
}