using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PPT
{
    public partial class frmPROJDETAILS : System.Web.UI.Page
    {

        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["PVID"] = null;
            if (!this.IsPostBack)
            {             
                GetRecords();            
            }
        }
        public void GetRecords()
        {
            try
            {
                dal = new DAL();
                DataSet ds;
                ds = new DataSet();
                ds = dal.GetSetPROJECTDETAILS(Action: "GET_DATA");             
                PROJDETAILS.DataSource = ds;
                PROJDETAILS.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }
        }
        private void InsertUpdatePROJECTDETAILS()
        {
                try
                {
                    DAL dal;
                    dal = new DAL();
                    int rowindex = 0;
                    dal.GetSetPROJECTDETAILS(
                    Action: "INSERT",
                    Project_ID: Convert.ToInt16(((TextBox)PROJDETAILS.Rows[0].FindControl("Project_ID")).Text),
                    STUDYID: ((TextBox)PROJDETAILS.Rows[0].FindControl("STUDYID")).Text,
                    PROJNAME: ((TextBox)PROJDETAILS.Rows[0].FindControl("PROJNAME")).Text,
                    SPONSOR: ((TextBox)PROJDETAILS.Rows[0].FindControl("SPONSOR")).Text,
                    PROJSTDAT: ((TextBox)PROJDETAILS.Rows[0].FindControl("PROJSTDAT")).Text,
                    PROJDUR: ((TextBox)PROJDETAILS.Rows[0].FindControl("PROJDUR")).Text,
                    ENTEREDBY: Session["User_ID"].ToString()
                    );
                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text = ex.Message.ToString();
                }
        }  
        protected void bntSave_Click(object sender, EventArgs e)
        {
            try
            {              
                    if (((TextBox)PROJDETAILS.Rows[0].FindControl("Project_ID")).Text == "")
                    {
                        lblErrorMsg.Text = "Please enter Project Id.";
                    }
                    else if (((TextBox)PROJDETAILS.Rows[0].FindControl("STUDYID")).Text == "")
                    {
                        lblErrorMsg.Text = "Please enter Study Id.";
                    }
                    else if (((TextBox)PROJDETAILS.Rows[0].FindControl("PROJNAME")).Text == "")
                    {
                        lblErrorMsg.Text = "Please enter Project Name.";
                    }
                    else
                    {
                        InsertUpdatePROJECTDETAILS();
                    }
               
                Response.Write("<script> alert('Record Updated successfully.');window.location='frmPROJDETAILS.aspx'; </script>");
            }

            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }
        }
        protected void PROJDETAILS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = e.Row.DataItem as DataRowView;
                string ProjectId = dr["Project_ID"].ToString();
                if (ProjectId != "")
                {
                    e.Row.Cells[0].Enabled = false;
                }
            }         
        }   
    }
}