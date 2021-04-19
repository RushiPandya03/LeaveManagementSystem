using LeaveManagementSystem.BAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Department_DepartmentAddEdit : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["Select"] == null)
        {
            Response.Redirect("~/Content/Login.aspx");
            return;
        }
        #endregion

        PanelErrorMesseage.Visible = false;
        PanelSuccess.Visible = false;

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["DepartmentID"] != null)
            {
                fillControls(Convert.ToInt32(Request.QueryString["DepartmentID"].ToString()));
                lblHeadContent.Text = "Department Edit";
            }
            else
            {
                lblHeadContent.Text = "Department Add"; 
            }
        }
    }
    #endregion Load Page

    #region Button: Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strError = "";

        if (txtDepartmentName.Text.Trim() == "")
            strError += "Enter Department +</br>";

        if (strError.Trim() != "")
        {
            PanelErrorMesseage.Visible = true;
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect Data
        DepartmentENT entDepartment = new DepartmentENT();

        if (txtDepartmentName.Text.Trim() != "")
            entDepartment.DepartmentName = txtDepartmentName.Text.Trim();

        #endregion Collect Data

        DepartmentBAL balDepartment = new DepartmentBAL();

        if (Request.QueryString["DepartmentID"] == null)
        {
            if (balDepartment.Insert(entDepartment))
            {
                clearSelection();
                PanelSuccess.Visible = true;
                lblSuccess.Text = "Data Inserted Successfully";
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balDepartment.Message;
            }
        }
        else
        {
            entDepartment.DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"].ToString().Trim());

            if (balDepartment.Update(entDepartment))
            {
                Response.Redirect("~/Content/Department/DepartmentList.aspx");
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balDepartment.Message;
            }
        }

    }
    #endregion Button: Save

    #region ClearSelection
    private void clearSelection()
    {
        txtDepartmentName.Text = "";
    }
    #endregion ClearSelection

    #region Fill Controls
    private void fillControls(SqlInt32 DepartmentID)
    {
        DepartmentBAL balDepartment = new DepartmentBAL();
        DepartmentENT entDepartment = new DepartmentENT();

        entDepartment = balDepartment.SelectByPK(DepartmentID);

        if (!entDepartment.DepartmentName.IsNull)
            txtDepartmentName.Text = entDepartment.DepartmentName.Value.ToString();
    }
    #endregion Fill Controls

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Department/DepartmentList.aspx");
    }
    #endregion Button: Cancel
}