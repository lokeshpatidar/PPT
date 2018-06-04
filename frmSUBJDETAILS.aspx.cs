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
   
    public partial class frmSUBJDETAILS : System.Web.UI.Page
    {
        DAL dal;
        DAL constr = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {              
                fill_Inv();
                GetRecords();
            }
            Session["PVID"] = null;
        }

        public void GetRecords()
        {
            try
            {
                dal = new DAL();
                DataSet ds;
                ds = new DataSet();
                ds = dal.GetSetSUBJECTDETAILS(Action: "GET_DATA", INVID: drp_InvID.SelectedValue);
                SUBJDETAILS.DataSource = ds;
                SUBJDETAILS.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }
        }
        private void addNewRecord(int rownum)
        {
            try
            {
                lblErrorMsg.Text = "";
                if (((TextBox)SUBJDETAILS.Rows[rownum].FindControl("SUBJID")).Text != "")
                {
                    DAL dal;
                    dal = new DAL();
                    dal.GetSetSUBJECTDETAILS(
                    Action: "INSERT",
                    STUDYID: ((TextBox)SUBJDETAILS.Rows[rownum].FindControl("STUDYID")).Text,
                    INVID: drp_InvID.SelectedValue,
                    SUBJID: ((TextBox)SUBJDETAILS.Rows[rownum].FindControl("SUBJID")).Text,
                    ENTEREDBY: Session["User_ID"].ToString()
                    );
                }
                else
                {
                   // lblErrorMsg.Text = "Enter Subject ID";
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();   
            }
        }       
        protected void bntSave_Click(object sender, EventArgs e)
        {
            int rownum, UPDATE_FLAG;
            for (rownum = 0; rownum < SUBJDETAILS.Rows.Count; rownum++)
            {
                UPDATE_FLAG = Convert.ToInt16(((TextBox)SUBJDETAILS.Rows[rownum].FindControl("UPDATE_FLAG")).Text);
                if (UPDATE_FLAG == 0)
                {
                    addNewRecord(rownum);
                }              
            }
            GetRecords();
        }
        private void fill_Inv()
        {
            using (SqlConnection con = new SqlConnection(constr.getconstr()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT INVID FROM INVDETAILS"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    drp_InvID.DataSource = cmd.ExecuteReader();
                    drp_InvID.DataValueField = "INVID";
                    drp_InvID.DataBind();
                    con.Close();
                }
            }
            drp_InvID.Items.Insert(0, new ListItem("--Select Inv ID--", "0"));
        }
        protected void drp_InvID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRecords();
        }

        protected void bntAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Table Structure
                DataRow drCurrentRow = null;
                DataTable dtCurrentTable;
                int rowIndex = 0;
                int i;
                dtCurrentTable = new DataTable();
                dtCurrentTable.Columns.Add(new DataColumn("STUDYID", typeof(string)));
                dtCurrentTable.Columns.Add(new DataColumn("SUBJID", typeof(string)));            
                dtCurrentTable.Columns.Add(new DataColumn("UPDATE_FLAG", typeof(string)));

                if (SUBJDETAILS.Rows.Count > 0)
                {
                    for (i = 0; i < SUBJDETAILS.Rows.Count; i++)
                    {
                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["STUDYID"] = ((TextBox)SUBJDETAILS.Rows[rowIndex].FindControl("STUDYID")).Text;
                        drCurrentRow["SUBJID"] = ((TextBox)SUBJDETAILS.Rows[rowIndex].FindControl("SUBJID")).Text;                      
                        drCurrentRow["UPDATE_FLAG"] = ((TextBox)SUBJDETAILS.Rows[rowIndex].FindControl("UPDATE_FLAG")).Text;
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        rowIndex++;
                    }

                    //Add Empty Row
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["STUDYID"] = "";
                    drCurrentRow["SUBJID"] = "";                 
                    drCurrentRow["UPDATE_FLAG"] = "0";
                    dtCurrentTable.Rows.Add(drCurrentRow);
                }            
                SUBJDETAILS.DataSource = dtCurrentTable;
                SUBJDETAILS.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
            }
        }

    }
}