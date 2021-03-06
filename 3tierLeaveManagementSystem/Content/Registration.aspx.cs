using LeaveManagementSystem.BAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Registration : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillDropdownList();
            if (Session["UserID"] != null )
            {
                if(Session["Select"].ToString() == "Employee")
                    CommonFillMethods.SelectWithoutHODForDropDownList(ddlDesignation);
                else if(Session["Select"].ToString() == "HOD")
                    CommonFillMethods.fillDropDownListDesignation(ddlDesignation);

                fillControls(Convert.ToInt32(Session["UserID"].ToString().Trim()));
                lblHeadeing.Text = "User Edit Details";
            }
            else
            {
                PanelHOD.Visible = false;
                CommonFillMethods.fillDropDownListDesignation(ddlDesignation);
                lblHeadeing.Text = "New User Registration";
            }
        }
    }
    #endregion Load Page

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if(Session["Select"] != null)
        {
            if (Session["Select"].ToString() == "Employee")
                Response.Redirect("~/Content/Home/Employee_Home.aspx");
            else if (Session["Select"].ToString() == "HOD")
                Response.Redirect("~/Content/Home/HOD_Home.aspx");
            else if (Session["Select"].ToString() == "Admin")
                Response.Redirect("~/Content/Institute/InstituteList.aspx");
        }
        else
        {
            Response.Redirect("~/Content/Login.aspx");
        }
        
    }
    #endregion Button: Cancel

    #region FillDropdownList
    private void fillDropdownList()
    {
        CommonFillMethods.fillDropDownListDepartment(ddlDepartment);
        CommonFillMethods.fillDropDownListInstitute(ddlInstitute);
    }
    #endregion FillDropdownList

    #region Button: Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Collect Data
        UserENT entUser = new UserENT();
        LeaveTypeENT entLeaveType = new LeaveTypeENT();
        DesignationENT entDesignation = new DesignationENT();

        if (ddlDepartment.SelectedIndex > 0)
            entUser.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);

        if (ddlInstitute.SelectedIndex > 0)
            entUser.InstituteID = Convert.ToInt32(ddlInstitute.SelectedValue);

        if (ddlDesignation.SelectedIndex > 0)
        {
            entUser.DesignationID = Convert.ToInt32(ddlDesignation.SelectedValue);
            entDesignation.DesignationID = Convert.ToInt32(ddlDesignation.SelectedValue);
        }

        if (rbFemale.Checked != false)
            entUser.Gender = rbFemale.Text.Trim();

        if (rbMale.Checked != false)
            entUser.Gender = rbMale.Text.Trim();

        if (txtUsername.Text.Trim() != "")
            entUser.UserName = txtUsername.Text.Trim();

        if (txtPassword.Text.Trim() != "")
            entUser.Password = txtPassword.Text.Trim();

        if (txtDisplayName.Text.Trim() != "")
            entUser.DisplayName = txtDisplayName.Text.Trim();

        if (txtMobileNo.Text.Trim() != "")
            entUser.MobileNo = txtMobileNo.Text.Trim();

        if (txtDOB.Text.Trim() != "")
            entUser.DOB = txtDOB.Text.Trim();

        if (txtEmail.Text.Trim() != "")
            entUser.Email = txtEmail.Text.Trim();

        if (txtExperience.Text.Trim() != "")
            entUser.Experience = txtExperience.Text.Trim();

        if (txtQualification.Text.Trim() != "")
            entUser.Qualification = txtQualification.Text.Trim();

        if (txtCity.Text.Trim() != "")
            entUser.City = txtCity.Text.Trim();

        if (fuStaffPhoto.HasFile)
        {
            string strFileLocationSave = "~/Content/assets/images/";
            string strPhysicalPath = "";

            strPhysicalPath = Server.MapPath(strFileLocationSave);
            strPhysicalPath += fuStaffPhoto.FileName;
            strFileLocationSave += fuStaffPhoto.FileName;

            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }

            fuStaffPhoto.SaveAs(strPhysicalPath);
            entUser.PhotoPath = strFileLocationSave;
        }
        #endregion Collect Data

        UserBAL balUser = new UserBAL();
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
        DesignationBAL balDesignation = new DesignationBAL();

        entDesignation = balDesignation.SelectByPK(entDesignation.DesignationID);

        if (Session["UserID"] == null)
        {
            if(entDesignation.DesignationName == "HOD")
            {
                balUser.Insert(entUser);
                entUser = balUser.SelectByPK(entUser.UserID); 

                clearSelection();
                lblSuccess.Text = "Data Inserted Successfully";
            }
            else if(entDesignation.DesignationName != "HOD")
            {
                balUser.Insert(entUser);

                if (entUser.UserID > 0)
                {
                    entLeaveType.UserID = entUser.UserID;
                    entUser = balUser.SelectByPK(entUser.UserID);
                }
                else
                {
                    lblErrorMessage.Text = "empty";
                    return;
                }

                entLeaveType.LeaveType = "Casual Leave";
                entLeaveType.TotalDays = 25;
                balLeaveType.Insert(entLeaveType);

                entLeaveType.LeaveType = "Medical Leave";
                entLeaveType.TotalDays = 15;
                balLeaveType.Insert(entLeaveType);

                entLeaveType.LeaveType = "LOP";
                entLeaveType.TotalDays = 10;
                balLeaveType.Insert(entLeaveType);

                entLeaveType.LeaveType = "Other Leave";
                entLeaveType.TotalDays = 5;
                balLeaveType.Insert(entLeaveType);

                clearSelection();
                lblSuccess.Text = "Data Inserted Successfully";
            }
            else
            {
                lblErrorMessage.Text = balUser.Message;
            }
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("xyz@gmail.com");
                mail.To.Add(entUser.Email.ToString());
                mail.Subject = "User Created Successfully !!";
                mail.Body = "<h3>You can now login into Leave management system</h3><br>" +
                    "Your Username Is :- " + Convert.ToString(entUser.UserName) +
                    "<br>Your Password Is :- " + Convert.ToString(entUser.Password) +
                    "<br><br><i>Please don't reply, this is auto generated email</i>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("xyz@gmail.com", "password");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
        else
        {
            entUser.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());

            if (balUser.Update(entUser))
            {
                if (Session["Select"].ToString() == "Employee")
                    Response.Redirect("~/Content/Home/Employee_Home.aspx");
                else if (Session["Select"].ToString() == "HOD")
                    Response.Redirect("~/Content/Home/HOD_Home.aspx");
            }
            else
            {
                lblErrorMessage.Text = balUser.Message;
            }
        }

    }
    #endregion Button: Save

    #region ClearSelection
    private void clearSelection()
    {
        rbFemale.Checked = false;
        ddlDepartment.SelectedIndex = -1;
        ddlDesignation.SelectedIndex = -1;
        ddlInstitute.SelectedIndex = -1;
        txtUsername.Text = "";
        txtPassword.Text = "";
        txtDisplayName.Text = "";
        txtMobileNo.Text = "";
        txtDOB.Text = "";
        txtEmail.Text = "";
        txtExperience.Text = "";
        txtQualification.Text = "";
        txtCity.Text = "";
    }
    #endregion ClearSelection

    #region FillControls
    private void fillControls(SqlInt32 UserID)
    {
        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();

        entUser = balUser.SelectByPK(Convert.ToInt32(Session["UserID"].ToString().Trim()));

        if (entUser != null)
        {
            if (!entUser.DepartmentID.IsNull)
                ddlDepartment.SelectedValue = entUser.DepartmentID.ToString().Trim();

            if (Session["Select"].ToString() == "Employee")
            {
                if (!entUser.DesignationID.IsNull)
                    ddlDesignation.SelectedValue = entUser.DesignationID.ToString().Trim();
                PanelHOD.Visible = false;
            }
            else if (Session["Select"].ToString() == "HOD")
            {
                PanelEmployee.Visible = false;
                lblHOD.Text = "HOD";

                ddlDesignation.SelectedValue = entUser.DesignationID.ToString().Trim();
            }

            if (!entUser.InstituteID.IsNull)
                ddlInstitute.SelectedValue = entUser.InstituteID.ToString().Trim();

            if (!entUser.Gender.IsNull)
            {
                if (entUser.Gender.ToString().Trim() == "Male")
                    rbMale.Checked = true;

                if (entUser.Gender.ToString().Trim() == "Female")
                    rbFemale.Checked = true;
            }

            if (!entUser.UserName.IsNull)
                txtUsername.Text = entUser.UserName.ToString().Trim();

            if (!entUser.Password.IsNull)
                txtPassword.Text = entUser.Password.ToString().Trim();

            if (!entUser.DisplayName.IsNull)
                txtDisplayName.Text = entUser.DisplayName.ToString().Trim();

            if (!entUser.MobileNo.IsNull)
                txtMobileNo.Text = entUser.MobileNo.ToString().Trim();

            if (!entUser.DOB.IsNull)
                txtDOB.Text = entUser.DOB.ToString().Trim();

            if (!entUser.Email.IsNull)
                txtEmail.Text = entUser.Email.ToString().Trim();

            if (!entUser.Experience.IsNull)
                txtExperience.Text = entUser.Experience.ToString().Trim();

            if (!entUser.Qualification.IsNull)
                txtQualification.Text = entUser.Qualification.ToString().Trim();

            if (!entUser.City.IsNull)
                txtCity.Text = entUser.City.ToString().Trim();
        }
        else
        {
            lblErrorMessage.Text = "missing data";
        }
    }
    #endregion FillControls
}