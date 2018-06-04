using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PPT
{
    public partial class EditSubjVisitDetails : System.Web.UI.Page
    {
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


        public void FillINV()
        {
            try
            {
                string Userid = Session["User_ID"].ToString();
                string strCmd;
                strCmd = "select INVID from User_Rights where User_ID = " + Userid;
                DataSet ds = new DataSet();
                ds = dal.GetRecordOpenCRF(strCmd);
                drpINVID.DataSource = ds;
                drpINVID.DataValueField = "INVID";
                drpINVID.DataBind();

                drpINVID.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void FillSUBJECT()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPTConnection"].ConnectionString);

                //SqlCommand cmd;
                //SqlDataAdapter adp;
                //DataSet ds = new DataSet();
                //cmd = new SqlCommand("Sub_List", con);
                //cmd.CommandType = CommandType.StoredProcedure;

                //string INVID = drpINVID.SelectedValue;
                //string strCmd;

                //cmd.Parameters.AddWithValue("@INVID", INVID);
                //cmd.Parameters.AddWithValue("@Project_ID", Session["PROJECTID"].ToString());

                // strCmd = "select SUBJID from SUB_DETAILS where INVID = " + INVID;
                // DataSet ds = new DataSet();
                // ds = dal.GetRecordOpenCRF(strCmd);


                SqlCommand cmd;
                SqlDataAdapter adp;
                DataSet ds = new DataSet();
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                string INVID = drpINVID.SelectedValue;            

                con.Open();
                cmd.Connection = con;


                cmd.CommandText = "SP_SubProgReport";
                cmd.Parameters.AddWithValue("@Action", "SUBLIST");
                cmd.Parameters.AddWithValue("@INVID", INVID);


                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
                con.Close();
                drpSubject.DataSource = ds;
                drpSubject.DataValueField = "SUBJID";
                drpSubject.DataBind();
                drpSubject.Items.Insert(0, new ListItem("--Select--", "0"));              
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void drpINVID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSUBJECT();
        }
        protected void Btn_GetData_Click(object sender, EventArgs e)
        {

            Session["INVID"] = drpINVID.SelectedValue;
            Session["SUBJID"] = drpSubject.SelectedValue;

            DataSet ds = new DataSet();
            ds = dal.InsertUpdatePPT(Action: "12",
                    Project_ID: Session["PROJECTID"].ToString(),
                    INVID: drpINVID.SelectedValue,
                    SUBJID: drpSubject.SelectedValue);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblDemograph.Visible = true;
                grdDemographData.DataSource = ds.Tables[0];
                grdDemographData.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                lblVisitData.Visible = true;
                grdVisitData.DataSource = ds.Tables[1];
                grdVisitData.DataBind();
            }
        }   
        protected void grdDemographData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    string GENDER = dr["GENDER"].ToString();

                    DropDownList btnEdit = (DropDownList)e.Row.FindControl("DRP_Gender");
                    btnEdit.Visible = true;
                    //  btnEdit.SelectedItem.Value = GENDER;
                    btnEdit.SelectedValue = GENDER;


                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
                throw;
            }
        }

        protected void grdVisitData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    string ACTUAL_DATE = dr["ACTUAL_DATE"].ToString();

                    if (ACTUAL_DATE == "")
                    {
                        TextBox txtActualDate = (TextBox)e.Row.FindControl("txt_VisitDate");
                        txtActualDate.Enabled = false;                     
                   }                
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message.ToString();
                throw;
            }
        }

    }
}