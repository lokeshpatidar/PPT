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
    public partial class DataEntry : System.Web.UI.Page
    {
        CommonFunction commFun = new CommonFunction();
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] == null)
            {
                Response.Redirect("SessionExpired.aspx");
            }
            if (!Page.IsPostBack)
            {
                try
                {
                    FillINV();
                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text = "";
                    lblErrorMsg.Text = ex.Message;
                }
            }        
        }
        protected void btn_New_Click(object sender, EventArgs e)
        {
            Session["INVID"] = drpInvID.SelectedItem.Value;
            Response.Redirect("NewPatientEntry.aspx");
        }
        protected void btnExist_Click(object sender, EventArgs e)
        {
            Session["SUBJID"] = null;
            Session["INVID"] = drpInvID.SelectedItem.Value;

            Response.Redirect("ExistingPatientEntry.aspx");
        }

        public void FillINV()
        {
            try
            {
                string Userid = Session["User_ID"].ToString();
                string strCmd;
                strCmd = "select INVID from User_Rights where User_ID = " + Userid;
                DataSet ds = new DataSet();
                ds = dal.GetRecordOpenCRF(strCmd);
                drpInvID.DataSource = ds;
                drpInvID.DataValueField = "INVID";
                drpInvID.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }        
        }    
    }
}