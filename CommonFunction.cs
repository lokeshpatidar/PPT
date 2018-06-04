using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Net.Configuration;
using System.Web.Configuration;

namespace PPT
{
    public class CommonFunction
    {
        public DropDownList BindDropDown(DropDownList ddl, DataTable dt)
        {
            ddl.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                    ddl.DataSource = dt;
                    ddl.DataTextField = "Text";
                    ddl.DataValueField = "Value";
                    ddl.DataBind();                                  
            }
           ddl.Items.Insert(0, new ListItem("--All--", "-1"));
           return ddl;
        }

        public bool Email_Users(string EmailAddress, string CCEmailAddress, string subject, string body)
        {
            bool _output = false;
            string _FromID = "landmarc_helpdesk@diagnosearch.com";
            string _PWD = "Diagno*456";


            try
            {

                MailMessage MailMsg = new MailMessage();
                MailMsg.From = new MailAddress(_FromID, "Helpdesk", System.Text.Encoding.UTF8);
                //MailMsg.To.Add(EmailAddress);
                char t = ';';
                if (!string.IsNullOrEmpty(EmailAddress))
                {
                    string[] _CCList = EmailAddress.Split(t);
                    for (int j = 0; j < _CCList.Length; j++)
                    {
                        MailMsg.To.Add(_CCList[j].ToString());
                    }
                }
                if (!string.IsNullOrEmpty(CCEmailAddress))
                {
                    string[] _CCList = CCEmailAddress.Split(t);
                    for (int j = 0; j < _CCList.Length; j++)
                    {
                        MailMsg.CC.Add(_CCList[j].ToString());
                    }
                }
                MailMsg.Body = body;
                MailMsg.Subject = subject;
                MailMsg.IsBodyHtml = true;
                MailMsg.Priority = MailPriority.High;
                SmtpClient mSmtpClient = new SmtpClient("mail.diagnosearch.com");
                NetworkCredential basicCredential = new NetworkCredential(_FromID, _PWD);
                mSmtpClient.Credentials = basicCredential;
                mSmtpClient.EnableSsl = true;
                mSmtpClient.Port = 587;
                mSmtpClient.Send(MailMsg);
                _output = true;
            }
            catch (Exception ex)
            {
                _output = false;
                throw new Exception(ex.Message);
            }
            return _output;
        }
    }
}