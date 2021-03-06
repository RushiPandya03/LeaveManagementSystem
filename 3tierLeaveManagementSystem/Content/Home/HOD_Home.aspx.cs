using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Home_Home_After_Login : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null || Session["Select"].ToString() == "Employee")
        {
            Response.Redirect("~/Content/Login.aspx");
            return;
        }
        else
        {
            fillLabel(Convert.ToInt32(Session["UserID"].ToString().Trim()));
        }
        #endregion Check Valid User

        PanelErrorMesseage.Visible = false;

        if (Session["DisplayName"] != null)
            lblDisplayname.Text = Session["DisplayName"].ToString().Trim();

        if (Session["PhotoPath"] != null)
            Image.ImageUrl = Session["PhotoPath"].ToString().Trim();
    }
    #endregion Load Page

    #region Button: Logout
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Session["UserID"] = null;
        Session["Select"] = null;
        Response.Redirect("~/Content/Login.aspx");
    }
    #endregion Button: Logout

    #region fill Label
    private void fillLabel(SqlInt32 UserID)
    {
        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();

        entUser = balUser.SelectByPK(Convert.ToInt32(Session["UserID"].ToString().Trim()));

        if (entUser != null)
        {
            if (!entUser.DepartmentName.IsNull)
                lblDepartment.Text = entUser.DepartmentName.ToString().Trim();

            if (!entUser.DesignationName.IsNull)
                lblDesignation.Text = entUser.DesignationName.ToString().Trim();

            if (!entUser.InstituteName.IsNull)
                lblInstitute.Text = entUser.InstituteName.ToString().Trim();

            if (!entUser.Gender.IsNull)
            {
                if (entUser.Gender.ToString().Trim() == "Male")
                    lblGender.Text = "Male";

                if (entUser.Gender.ToString().Trim() == "Female")
                    lblGender.Text = "Female";
            }

            if (!entUser.UserName.IsNull)
                lblUsername.Text = entUser.UserName.ToString().Trim();

            if (!entUser.DisplayName.IsNull)
                lblDisplayname.Text = entUser.DisplayName.ToString().Trim();

            if (!entUser.MobileNo.IsNull)
                lblMobileno.Text = entUser.MobileNo.ToString().Trim();

            if (!entUser.DOB.IsNull)
                lblDOB.Text = entUser.DOB.ToString().Trim();

            if (!entUser.Email.IsNull)
                lblEmail.Text = entUser.Email.ToString().Trim();

            if (!entUser.Experience.IsNull)
                lblExperience.Text = entUser.Experience.ToString().Trim();

            if (!entUser.Qualification.IsNull)
                lblQualification.Text = entUser.Qualification.ToString().Trim();

            if (!entUser.City.IsNull)
                lblCity.Text = entUser.City.ToString().Trim();

            if (!entUser.PhotoPath.IsNull)
                img.ImageUrl = entUser.PhotoPath.ToString().Trim();
                
        }
        else
        {
            PanelErrorMesseage.Visible = true;
            lblErrorMessage.Text = "missing data";
        }
    }
    #endregion fill Label

    #region Button: EditProfile
    protected void btnEditProfile_Click(object sender, EventArgs e)
    {
        Session["Select"] = "HOD";
        Response.Redirect("~/Content/Registration.aspx");
    }
    #endregion Button: EditProfile
}