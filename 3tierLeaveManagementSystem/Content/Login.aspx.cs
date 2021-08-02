using LeaveManagementSystem.BAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;

public partial class Content_Login : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (Session["Select"].ToString() == "HOD")
                Response.Redirect("~/Content/Home/HOD_Home.aspx");
            else if (Session["Select"].ToString() == "Employee")
                Response.Redirect("~/Content/Home/Employee_Home.aspx");
        }
    }
    #endregion Load Page

    #region Button: Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        fillSession();
    }
    #endregion Button: Login

    #region FillSession
    private void fillSession()
    {
        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();

        #region Local Variables
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        string strError = "";
        #endregion

        #region Server Side Validation
        if (txtUserName.Text.Trim() == "")
            strError += "Enter UserName </br>";

        if (txtPassword.Text.Trim() == "")
            strError += "Enter Password </br>";

        if (strError.Trim() != "")
        {
            lblErrorMesseage.Text = strError;
            return;
        }
        #endregion

        #region Read Form Value
        if (txtUserName.Text.Trim() != "")
            strUserName = txtUserName.Text.Trim();
        if (txtPassword.Text.Trim() != "")
            strPassword = txtPassword.Text.Trim();
        #endregion

        if (strUserName == "admin" && strPassword == "admin")
        {
            Session["Select"] = "Admin";
            Response.Redirect("~/Content/Institute/InstituteList.aspx");
            return;
        }

        entUser = balUser.SelectByUserNamePassword(strUserName, strPassword);

        if (entUser != null)
        {
            if (!entUser.UserID.IsNull)
                Session["UserID"] = entUser.UserID;
            if (!entUser.DisplayName.IsNull)
                Session["DisplayName"] = entUser.DisplayName;
            if (!entUser.PhotoPath.IsNull)
                Session["PhotoPath"] = entUser.PhotoPath;

            if (entUser.DesignationName == "HOD")
            {
                Session["Select"] = "HOD";
                Response.Redirect("~/Content/Home/HOD_Home.aspx");
            }
            else
            {
                Session["Select"] = "Employee";
                Response.Redirect("~/Content/Home/Employee_Home.aspx");
            }
        }
        else
        {
            lblErrorMesseage.Text = "Either Username Or PAssword Is Invalid";
        }
    }
    #endregion FillSession

    #region Button: Forgetpassword
    protected void btnForgetpassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Forgetpassword.aspx");
    }
    #endregion Button: Forgetpassword
}