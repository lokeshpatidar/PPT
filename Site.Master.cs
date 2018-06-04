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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        DAL constr = new DAL();       
        public SiteMaster()
        {
            this.Load += new EventHandler(Page_PreInit);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                hdn_Value.Value = "";
                if (Session["User_ID"] == null)
                {
                    Response.Redirect("SessionExpired.aspx", false);
                }
                else
                {

                    if (!IsPostBack)
                    {

                        SqlConnection con = new SqlConnection(constr.getconstr());
                        SqlCommand cmd = new SqlCommand("Get_User_Info", con);
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@User_ID", Session["User_ID"].ToString());
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            Lbl_User_Info.Text = (sdr["User_Name"].ToString());
                            Lbl_User_Dept.Text = (sdr["UserGroup_Name"].ToString());
                            //Lbl_User_Country.Text = (sdr["INVNAME"].ToString());
                        }
                        con.Close();



                        string A = Session["PWDExpire"].ToString();

                        if (A != "0")
                        {

                            Lbl_PWD_Exp1.Visible = true;
                            Lbl_PWD_Exp1.Text = "Your Password will Expire in " + Session["NoofDays"].ToString() + " Days ||| ";

                        }
                       

                    }
                    Set_parentNode();
                    PopulateMenuControl();
                }
            }
            catch (Exception ex)
            {
                Lbl_User_Dept.Text = "";
                Lbl_User_Dept.Text = ex.Message;
            }
        }
        private void PopulateMenuControl()
        {
            string MyValue = Session["User_ID"] as string;

            DataSet ds = new DataSet();

            SqlConnection Sqlcon = new SqlConnection(constr.getconstr());
            Sqlcon.Open();

            SqlDataAdapter da = new SqlDataAdapter("spQry_01_UserFunction", Sqlcon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@UserId", Session["User_ID"].ToString());
            da.SelectCommand.Parameters.AddWithValue("@LevelID", "1");

            da.Fill(ds);
                    
           
            foreach (DataRow myRow in ds.Tables[0].Rows)
            {
                MenuItem parentItem = new MenuItem(myRow["FunctionName"].ToString());
                if (parentItem.Value == "Home")
                {
                    parentItem.NavigateUrl = myRow["NavigationURL"].ToString();
                }
                PopulateMenuControlChildItem(myRow["FunctionName"].ToString(), ref parentItem);
                NavigationMenu.Items.Add(parentItem);
            }
            Sqlcon.Close();
        }
        private void PopulateMenuControlChildItem(string strParentItem, ref MenuItem parentItem)
        {
            string MyValue = Session["User_ID"] as string;
            DataSet ds = new DataSet();
            SqlConnection Sqlcon = new SqlConnection(constr.getconstr());
            Sqlcon.Open();
            SqlDataAdapter da = new SqlDataAdapter("spQry_01_UserFunction", Sqlcon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@UserId", Session["User_ID"].ToString());
            da.SelectCommand.Parameters.AddWithValue("@Parent", strParentItem);

            da.Fill(ds);  
       
            foreach (DataRow myRow in ds.Tables[0].Rows)
            {
                MenuItem childrenItem = new MenuItem(myRow["FunctionName"].ToString());
                childrenItem.NavigateUrl = myRow["NavigationURL"].ToString();
                parentItem.ChildItems.Add(childrenItem);
                PopulateMenuControlChildItem(myRow["FunctionName"].ToString(), ref childrenItem);
            }
            Sqlcon.Close();
        }

        private void Set_parentNode()
        {
            
            TreeNode MainNode = new TreeNode("DiagnoSearch");
            string MyValue = Session["User_ID"] as string;
            DataSet parentDS = new DataSet();

            SqlConnection Sqlcon = new SqlConnection(constr.getconstr());
            Sqlcon.Open();

           SqlDataAdapter da = new SqlDataAdapter("spQry_01_UserFunction", Sqlcon);
           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.SelectCommand.Parameters.AddWithValue("@UserId", Session ["User_ID"].ToString ());
           da.SelectCommand.Parameters.AddWithValue("@LevelID", "1");

           da.Fill(parentDS);           
             
             
            string clmname;
            foreach (DataRow myrow in parentDS.Tables[0].Rows)
            {
                clmname = myrow["FunctionName"].ToString();
                TreeNode ParentNode = new TreeNode(clmname);
                SetchildNode(clmname, ref ParentNode);
                MainNode.ChildNodes.Add(ParentNode);
            }
            Sqlcon.Close();
        }

        private void SetchildNode(string str, ref TreeNode ParNode)
        {
            string MyValue = Session["User_ID"] as string;
            DataSet ChildDS = new DataSet();

            SqlConnection Sqlcon = new SqlConnection(constr.getconstr());
            Sqlcon.Open();

            SqlDataAdapter da = new SqlDataAdapter("spQry_01_UserFunction", Sqlcon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@UserId", Session["User_ID"].ToString());
            da.SelectCommand.Parameters.AddWithValue("@Parent", str);

            da.Fill(ChildDS);
                      
            //DataSet ChildDS = MyDB.Return_DataSet("Select * from Qry_01_UserFunction where Parent = '" + str + "' and UserId ='" + MyValue + "' ORDER BY SequenceID");
            foreach (DataRow myrow in ChildDS.Tables[0].Rows)
            {
                TreeNode ChildNode = new TreeNode(myrow["FunctionName"].ToString());
                ChildNode.NavigateUrl = myrow["NavigationURL"].ToString();
                ParNode.ChildNodes.Add(ChildNode);
                SetchildNode(myrow["FunctionName"].ToString(), ref ChildNode);
            }
            Sqlcon.Close();
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Request.UserAgent.IndexOf("AppleWebKit") > 0) || (Request.UserAgent.IndexOf("Unknown") > 0) || (Request.UserAgent.IndexOf("Chrome") > 0))
                {
                    Request.Browser.Adapters.Clear();
                }
            }
        }
        protected void LogOut_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr.getconstr());
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Connection = con;
            cmd3.CommandText = "Update_Alrdy_Log_IN";
            con.Open();
            cmd3.Parameters.AddWithValue("@Action", "LogOut");
            cmd3.Parameters.AddWithValue("@User_ID", Session["User_ID"].ToString());
            cmd3.ExecuteNonQuery();
            con.Close();
            Session["User_ID"] = null;
            Response.Redirect("Auth.aspx");
        }


    }   
}
