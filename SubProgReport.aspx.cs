using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.IO;
using System.Configuration;

namespace PPT
{
    public partial class SubProgReport : System.Web.UI.Page
    {
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack != true)
                {
                    FillINV();
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void getReport()
        {
            try
            {
                ReportViewer1.ShowExportControls = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.Reset();
                ReportViewer1.ShowPrintButton = true;


                SqlCommand cmd;
                DataTable dt;
                SqlConnection con;
                SqlDataAdapter adp;
                //lblError.Text = "";
                //validate specimen id or not
                cmd = new SqlCommand();
                con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PPTConnection"].ConnectionString.ToString());
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "SP_SubProgReport";
                cmd.Parameters.AddWithValue("@Action", "RPT");

                if (drpInvID.SelectedValue != "0")
                {
                    cmd.Parameters.AddWithValue("@INVID", drpInvID.SelectedValue);
                }

                if (drpSubject.SelectedValue != "0")
                {
                    cmd.Parameters.AddWithValue("@SUBJID", drpSubject.SelectedValue);
                }

                cmd.Parameters.AddWithValue("@USERID", Session["User_ID"].ToString());            

                dt = new DataTable();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rptSubProg.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void bntGetReport_Click(object sender, EventArgs e)
        {
            getReport();
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
                drpInvID.Items.Insert(0, new ListItem("--Select--", "0"));
                drpInvID.Items.Insert(1, new ListItem("ALL", "ALL"));

                
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

                SqlCommand cmd;
                SqlDataAdapter adp;
                DataSet ds = new DataSet();
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                string INVID = drpInvID.SelectedValue;
                string strCmd;

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
                drpSubject.Items.Insert(1, new ListItem("ALL", "ALL"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void drpInvID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                FillSUBJECT();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }
    }
}