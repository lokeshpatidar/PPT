using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PPT
{
    public partial class ExistingPatientEntry : System.Web.UI.Page
    {
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["INVID"] == null)
            {
                Response.Redirect("SessionExpired.aspx");
            }
            try
            {
                if (!Page.IsPostBack)
                {
                    drpINVID.Items.Add(new ListItem(Session["INVID"].ToString()));
                    if (Session["SUBJID"] != null)
                    {
                        DivEligible.Visible = true;                      
                        drpSubject.Items.Add(new ListItem(Session["SUBJID"].ToString()));
                        txtVisitNo.Text = "1";
                    }
                    else
                    {
                        FillSUBJECT();
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                if (drpEligible.SelectedItem.Value == "YES")
                {
                    if (txtVisitDate.Text == "")
                    {
                        throw new Exception("Please Enter Visit Date");
                    }
                    ds = dal.InsertUpdatePPT(Action: "4",
                    Project_ID: Session["PROJECTID"].ToString(),
                    INVID: drpINVID.SelectedValue,
                    SUBJID: drpSubject.SelectedValue,
                    VISITNUM: "1",
                    IS_ELIGIBLE: "True",
                    ACTUAL_DATE: txtVisitDate.Text,
                    ENTEREDBY: Session["User_ID"].ToString());

                    ds = dal.InsertUpdatePPT(Action: "6",
                    Project_ID: Session["PROJECTID"].ToString(),
                    INVID: drpINVID.SelectedValue,
                    SUBJID: drpSubject.SelectedValue,
                    VISITNUM: "1",
                    ENTEREDBY: Session["User_ID"].ToString());

                    ds = dal.InsertUpdatePPT(Action: "7",
                   Project_ID: Session["PROJECTID"].ToString(),
                   INVID: drpINVID.SelectedValue,
                   SUBJID: drpSubject.SelectedValue,
                   VISITNUM: "1",
                   ACTUAL_DATE: txtVisitDate.Text,
                   ENTEREDBY: Session["User_ID"].ToString());
                }
                else
                {
                    if (drpReasonNotElig.SelectedValue == "0")
                    {
                        throw new Exception("Please Select Reason");
                    }
                    ds = dal.InsertUpdatePPT(Action: "4",
                        Project_ID: Session["PROJECTID"].ToString(),
                        INVID: drpINVID.SelectedValue,
                        SUBJID: drpSubject.SelectedValue,
                        VISITNUM: "1",
                        IS_ELIGIBLE: "False",
                        REAS_ELIGIBLE: drpReasonNotElig.SelectedValue,
                        REAS_ELIGIBLE_OTHER: txtReasonNotElig.Text,
                        ENTEREDBY: Session["User_ID"].ToString());

                }
                Response.Write("<script> alert('Record Updated successfully.');window.location='DataEntry.aspx'; </script>");
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }
        protected void btnSaveVisitOther_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                string IS_ARRIVE = "True";

                // when last visit of patient 
                if (txtVisitNo.Text == "7")
                {
                    if (drpIsArrive.SelectedValue == "YES")
                    {
                        if (txtActualDate.Text == "")
                        {
                            throw new Exception("Please Enter Actual Date");
                        }
                        ds = dal.InsertUpdatePPT(Action: "4",
                        Project_ID: Session["PROJECTID"].ToString(),
                        INVID: drpINVID.SelectedValue,
                        SUBJID: drpSubject.SelectedValue,
                        VISITNUM: txtVisitNo.Text,
                        IS_ARRIVE: IS_ARRIVE,
                        SUB_WITHDRAW: "False",
                        ACTUAL_DATE: txtActualDate.Text,
                        ENTEREDBY: Session["User_ID"].ToString());
                    }
                    else
                    {
                        ds = dal.InsertUpdatePPT(Action: "4",
                        Project_ID: Session["PROJECTID"].ToString(),
                        INVID: drpINVID.SelectedValue,
                        SUBJID: drpSubject.SelectedValue,
                        VISITNUM: txtVisitNo.Text,
                        IS_ARRIVE: "False",
                        SUB_WITHDRAW: "False",
                        ENTEREDBY: Session["User_ID"].ToString());
                    }
                    Response.Write("<script> alert('Record Updated successfully.');window.location='ExistingPatientEntry.aspx'; </script>");
                }
                else
                {
                    //on others visit of patient
                    if (drpSubjectCont.SelectedItem.Value == "YES")
                    {
                        if (drpIsArrive.SelectedValue == "YES")
                        {
                            if (txtActualDate.Text == "")
                            {
                                throw new Exception("Please Enter Actual Date");
                            }
                        }
                        if (drpIsArrive.SelectedValue == "NO")
                        {
                            IS_ARRIVE = "False";
                        }
                        ds = dal.InsertUpdatePPT(Action: "4",
                        Project_ID: Session["PROJECTID"].ToString(),
                        INVID: drpINVID.SelectedValue,
                        SUBJID: drpSubject.SelectedValue,
                        VISITNUM: txtVisitNo.Text,
                        IS_ARRIVE: IS_ARRIVE,
                        SUB_WITHDRAW: "False",
                        ACTUAL_DATE: txtActualDate.Text,
                        ENTEREDBY: Session["User_ID"].ToString());

                    }
                    else
                    {
                        if (txtETDate.Text == "")
                        {
                            throw new Exception("Please Enter Early Termination Date");
                        }
                        if (drpNotContReason.SelectedValue == "0")
                        {
                            throw new Exception("Please Select Reason");
                        }
                        if (drpIsArrive.SelectedValue == "YES")
                        {
                            if (txtActualDate.Text == "")
                            {
                                throw new Exception("Please Enter Actual Date");
                            }
                        }
                        if (drpIsArrive.SelectedValue == "NO")
                        {
                            IS_ARRIVE = "False";
                        }
                        ds = dal.InsertUpdatePPT(Action: "4",
                        Project_ID: Session["PROJECTID"].ToString(),
                        INVID: drpINVID.SelectedValue,
                        SUBJID: drpSubject.SelectedValue,
                        VISITNUM: txtVisitNo.Text,
                        IS_ARRIVE: IS_ARRIVE,
                        SUB_WITHDRAW: "True",
                        REAS_WITHDRAW: drpNotContReason.SelectedValue,
                        ET_DATE: txtETDate.Text,
                        REAS_WITHDRAW_OTHER: txtNotContReason.Text,
                        ENTEREDBY: Session["User_ID"].ToString());
                    }
                    Response.Write("<script> alert('Record Updated successfully.');window.location='ExistingPatientEntry.aspx'; </script>");
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
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
                cmd = new SqlCommand("Sub_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
              

                string INVID = drpINVID.SelectedValue;
                string strCmd;

                cmd.Parameters.AddWithValue("@INVID", INVID);
                cmd.Parameters.AddWithValue("@Project_ID", Session["PROJECTID"].ToString());

               // strCmd = "select SUBJID from SUB_DETAILS where INVID = " + INVID;
               // DataSet ds = new DataSet();
               // ds = dal.GetRecordOpenCRF(strCmd);

                con.Open();
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

        protected void drpEligible_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpEligible.SelectedItem.Value == "YES")
                {
                    Visit1date.Visible = true;
                    divReason.Visible = false;
                }
                if (drpEligible.SelectedItem.Value == "NO")
                {
                    divReason.Visible = true;
                    Visit1date.Visible = false;
                }
                divSaveVisit1.Visible = true;
                lblErrorMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }


        }
        protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpSubject.SelectedValue != "0")
                {
                    divVisitNo.Visible = true;

                    DataSet ds = new DataSet();
                    ds = dal.InsertUpdatePPT(Action: "11",
                           Project_ID: Session["PROJECTID"].ToString(),
                           INVID: drpINVID.SelectedValue,
                           SUBJID: drpSubject.SelectedValue);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        divIsArrive.Visible = true;
                        DivScheDate.Visible = true;
                        divSubjectContinue.Visible = true;
                        drpIsArrive.SelectedIndex = drpIsArrive.Items.IndexOf(drpIsArrive.Items.FindByValue("0"));
                        drpSubjectCont.SelectedIndex = drpSubjectCont.Items.IndexOf(drpSubjectCont.Items.FindByValue("0"));

                        divNotContReason.Visible = false;
                        divOtherWith.Visible = false;
                        DivEligible.Visible = false;
                        divSaveVisit1.Visible = false;
                        divSaveVisitother.Visible = false;
                        divReason.Visible = false;
                        divReasonOther.Visible = false;
                        DivActualDate.Visible = false;

                        txtVisit.Text = ds.Tables[0].Rows[0]["VISIT"].ToString();
                        txtVisitNo.Text = ds.Tables[0].Rows[0]["VISITNUM"].ToString();
                        txtScheduleDate.Text = ds.Tables[0].Rows[0]["FROM_SCH_DT"].ToString();
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            grdVisitDetail.Visible = true;
                            grdVisitDetail.DataSource = ds.Tables[1];
                            grdVisitDetail.DataBind();
                        }
                    }
                    else
                    {
                        divSubjectContinue.Visible = false;
                        divNotContReason.Visible = false;
                        divOtherWith.Visible = false;
                        divSaveVisitother.Visible = false;
                        DivScheDate.Visible = false;
                        DivActualDate.Visible = false;

                        DivEligible.Visible = true;                      
                        txtVisitNo.Text = "1";
                        txtVisit.Text = "Baseline Visit";
                        grdVisitDetail.Visible = false;

                    }
                }
                lblErrorMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }
        protected void drpSubjectCont_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpSubjectCont.SelectedItem.Value == "YES")
                {
                 //   DivScheDate.Visible = true;
                   // DivActualDate.Visible = true;
                    divNotContReason.Visible = false;
                    divSaveVisitother.Visible = true;
                    DivEtDate.Visible = false;
                }
                else
                {
                    DivEtDate.Visible = true;
                    divNotContReason.Visible = true;
                   // DivScheDate.Visible = false;
                  //  DivActualDate.Visible = false;
                    divSaveVisitother.Visible = true;
                }
                lblErrorMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }
       
        protected void drpReasonNotElig_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpReasonNotElig.SelectedItem.Value == "Other")
                {
                    divReasonOther.Visible = true;
                }
                else
                {
                    divReasonOther.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }
        protected void drpNotContReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpNotContReason.SelectedItem.Value == "Other")
                {
                    divOtherWith.Visible = true;
                }
                else
                {
                    divOtherWith.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void drpIsArrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpIsArrive.SelectedItem.Value == "YES")
                {
                    DivScheDate.Visible = true;
                    DivActualDate.Visible = true;
                   // divNotContReason.Visible = false;
                 //   divSaveVisitother.Visible = true;
                    if (txtVisitNo.Text == "7")
                    {
                        divSaveVisitother.Visible = true;
                        divSubjectContinue.Visible = false;
                    }
                }
                else
                {
                 //   divNotContReason.Visible = true;
                    //DivScheDate.Visible = false;
                    DivActualDate.Visible = false;
                   // divSaveVisitother.Visible = true;
                    if (txtVisitNo.Text == "7")
                    {
                        divSaveVisitother.Visible = true;
                        divSubjectContinue.Visible = true;
                        drpSubjectCont.Items.Clear();
                        drpSubjectCont.Items.Add(new ListItem("NO", "NO"));

                    }
                }
                lblErrorMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }
    }
}