using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PPT
{
    public partial class NewPatientEntry : System.Web.UI.Page
    {
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["INVID"] == null)
            {
                Response.Redirect("SessionExpired.aspx");
            }
            if (!Page.IsPostBack)
            {
                drpINVID.Items.Add(new ListItem(Session["INVID"].ToString()));
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {             
                string date1 = System.DateTime.Now.ToString("dd-MMM-yyyy");
                DateTime dt2 = Convert.ToDateTime(txt_DOB.Text);
                DateTime dt1 = Convert.ToDateTime(date1);
                TimeSpan span =  dt1 - dt2;
                if (9862 >= span.TotalDays)
                {
                    throw new Exception("Age should be greater than or equal to 27 years.");
                }           
   
                DataSet ds = new DataSet();
                ds = dal.InsertUpdatePPT(Action: "10", INVID: drpINVID.SelectedValue);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("Subject Id is not available.");
                }  
                string SubjID = ds.Tables[0].Rows[0][0].ToString();
                Session["SUBJID"] = ds.Tables[0].Rows[0][0].ToString();
                string ProjectID = Session["PROJECTID"].ToString();

                ds = dal.InsertUpdatePPT(
                Action: "2",
                INVID: drpINVID.SelectedValue,
                Project_ID: ProjectID,
                CONSENT_DATE: txt_DOC.Text,
                GENDER: drp_Gender.SelectedValue,
                DOB: txt_DOB.Text,
                SUBJID: SubjID,
                ENTEREDBY: Session["User_ID"].ToString()
                );
                Response.Redirect("ExistingPatientEntry.aspx");
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }           
    }
}