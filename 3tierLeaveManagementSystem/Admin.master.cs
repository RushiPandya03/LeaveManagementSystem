using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.MasterPage
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.ImageUrl = "~/Content/assets/images/AdminLTELogo.png";
    }
    #endregion Load Page

    #region Button: Logout
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Login.aspx");
    }
    #endregion Button: Logout

    #region Button: CreateNewUser
    protected void lbCreateNewUser_Click(object sender, EventArgs e)
    {
        Session["UserID"] = null;
        Session["Select"] = "Admin";
        Response.Redirect("~/Content/Registration.aspx");
    }
    #endregion Button: CreateNewUser
}
