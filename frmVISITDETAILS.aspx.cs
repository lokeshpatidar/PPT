using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PPT
{
    public partial class frmVISITDETAILS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            if (!this.IsPostBack)
            {              
                GetRecords();
            }
            Session["PVID"] = null;//for query details grid will be not shown
        }
        public void GetRecords()
        {
            try
            {
                DAL dal = new DAL();
                DataSet ds;
                ds = new DataSet();
                ds = dal.GetSetVISITDETAILS(Action: "GET_DATA");           
                VISITDETAILS.DataSource = ds;
                VISITDETAILS.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }
        }
        private void InsertUpdateVisitDetails(int rownum)
        {
            try
            {
                DAL dal;
                dal = new DAL();
                dal.GetSetVISITDETAILS(
                Action: "INSERT",
                STUDYID: ((TextBox)VISITDETAILS.Rows[rownum].FindControl("STUDYID")).Text,
                VISITNUM: Convert.ToInt16 (((TextBox)VISITDETAILS.Rows[rownum].FindControl("VISITNUM")).Text),
                VISIT: ((TextBox)VISITDETAILS.Rows[rownum].FindControl("VISIT")).Text,
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
            int rownum;
            for (rownum = 0; rownum < VISITDETAILS.Rows.Count; rownum++)
            {                  
              InsertUpdateVisitDetails(rownum);                   
            }                       
            Response.Write("<script> alert('Record Updated successfully.');window.location='frmVISITDETAILS.aspx'; </script>");          
        }
        protected void bntAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DAL dal = new DAL();
                VISITDETAILS.DataSource = dal.AddNewRowToGridVisitDetails(VISITDETAILS);
                VISITDETAILS.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }
        }
        protected void VISITDETAILS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "UPDATE_FLAG").ToString().Trim() == "1")
                {
                    e.Row.Cells[1].Enabled = false;
                }
            }
        }
    }
}