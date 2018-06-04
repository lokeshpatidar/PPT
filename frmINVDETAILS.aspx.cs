using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PPT
{
    public partial class frmINVDETAILS : System.Web.UI.Page
    {
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {               
                GetRecords();
            }
            Session["PVID"] = null;
        }

        protected void bntOK_Click(object sender, EventArgs e)
        {
           
        }
        public void GetRecords()
        {
            try
            {
                dal = new DAL();
                DataSet ds;
                ds = new DataSet();
                ds = dal.GetSetINVDETAILS(Action: "GET_DATA");
                INVDETAILS.DataSource = ds;
                INVDETAILS.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }

        }
        private void InsertUpdateINV(int rownum)
        {
            try
            {
                DAL dal;
                dal = new DAL();
                dal.GetSetINVDETAILS(
                Action: "INSERT",
                STUDYID: ((TextBox)INVDETAILS.Rows[rownum].FindControl("STUDYID")).Text,
                INVID: ((TextBox)INVDETAILS.Rows[rownum].FindControl("INVID")).Text,
                INVNAME: ((TextBox)INVDETAILS.Rows[rownum].FindControl("INVNAME")).Text,
                ADDRESS: ((TextBox)INVDETAILS.Rows[rownum].FindControl("ADDRESS")).Text,
                TELNO: ((TextBox)INVDETAILS.Rows[rownum].FindControl("TELNO")).Text,
                FAXNO: ((TextBox)INVDETAILS.Rows[rownum].FindControl("FAXNO")).Text,
                EMAILID: ((TextBox)INVDETAILS.Rows[rownum].FindControl("EMAILID")).Text,
                CCEMAILID: ((TextBox)INVDETAILS.Rows[rownum].FindControl("CCEMAILID")).Text,
                STATUS: ((TextBox)INVDETAILS.Rows[rownum].FindControl("STATUS")).Text,
                DEACTIVATEDON: ((TextBox)INVDETAILS.Rows[rownum].FindControl("DEACTIVATEDON")).Text,
                ENTEREDBY: Session["User_ID"].ToString()
                );
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
                throw;
            }

        }
        protected void bntSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                int rownum;
                for (rownum = 0; rownum < INVDETAILS.Rows.Count; rownum++)
                {                  
                    if ((((TextBox)INVDETAILS.Rows[rownum].FindControl("INVID")).Text != "") && (((TextBox)INVDETAILS.Rows[rownum].FindControl("INVNAME")).Text != ""))
                    {
                        if ((((TextBox)INVDETAILS.Rows[rownum].FindControl("EMAILID")).Text == "") || (((TextBox)INVDETAILS.Rows[rownum].FindControl("CCEMAILID")).Text == ""))
                        {
                            throw new Exception("Please Enter Email Id and CCEmail Id.");
                        }
                        InsertUpdateINV(rownum);
                    }                   
                }
                Response.Write("<script> alert('Record Updated successfully.');window.location='frmINVDETAILS.aspx'; </script>");
                GetRecords();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }
        }
        protected void bntAdd_Click(object sender, EventArgs e)
        {
            //if (((TextBox)INVDETAILS.Rows[INVDETAILS.Rows.Count-1].FindControl("INVID")).Text != "")
            {
                INVDETAILS.DataSource = dal.AddNewRowToGridInvDetails(INVDETAILS);
                INVDETAILS.DataBind();
            }
        }
        protected void INVDETAILS_RowDataBound(object sender, GridViewRowEventArgs e)
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