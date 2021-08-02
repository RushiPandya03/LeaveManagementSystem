using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Forgetpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UserENT entUser = new UserENT();
        UserBAL balUser = new UserBAL();
        DataTable dtUser = new DataTable();
        entUser = balUser.SelectUserNamePasswordByEmail(txtEmail.Text);

        dtUser = balUser.SelectUserEmail();

        foreach (DataRow row in dtUser.Rows)
        {
            if (txtEmail.Text == row[0].ToString())
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("rpcoder812@gmail.com");
                    mail.To.Add(txtEmail.Text);
                    mail.Subject = "LMS - Password Reset";
                    mail.Body =
                        "Dear " + Convert.ToString(entUser.UserName) + "," +
                        "<br><br>Your Password Is :- " + Convert.ToString(entUser.Password) +
                        "<br><br><i>Please don't reply, this is auto generated email</i>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("rpcoder812@gmail.com", "Rus@17416");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                Response.Redirect("~/Content/Login.aspx");
            }

        }
        lblErrorMesseage.Text = "Please enter registered Email address";
        txtEmail.Text = "";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Login.aspx");
    }
}