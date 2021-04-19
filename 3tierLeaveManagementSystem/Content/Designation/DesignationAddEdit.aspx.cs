using LeaveManagementSystem.BAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Designation_DesignationAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["DesignationID"] != null)
            {
                fillControls(Convert.ToInt32(Request.QueryString["DesignationID"].ToString()));
                lblPageHeader.Text = "Designation Edit";
            }
            else
            {
                lblPageHeader.Text = "Designation Add";
            }
        }
    }
    #endregion Load Page

    #region Button: Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strError = "";

        if (txtDesignationName.Text.Trim() == "")
            strError += "Enter Designation +</br>";

        if (strError.Trim() != "")
        {
            PanelErrorMesseage.Visible = true;
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect Data
        DesignationENT entDesignation = new DesignationENT();

        if (txtDesignationName.Text.Trim() != "")
            entDesignation.DesignationName = txtDesignationName.Text.Trim();

        #endregion Collect Data

        DesignationBAL balDesignation = new DesignationBAL();

        if (Request.QueryString["DesignationID"] == null)
        {
            if (balDesignation.Insert(entDesignation))
            {
                clearSelection();
                PanelSuccess.Visible = true;
                lblSuccess.Text = "Data Inserted Succesfully";
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balDesignation.Message;
            }
        }
        else
        {
            entDesignation.DesignationID = Convert.ToInt32(Request.QueryString["DesignationID"].ToString().Trim());

            if (balDesignation.Update(entDesignation))
            {
                Response.Redirect("~/Content/Designation/DesignationList.aspx");
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balDesignation.Message;
            }
        }
    }
    #endregion Button: Save

    #region ClearSelection
    private void clearSelection()
    {
        txtDesignationName.Text = "";
    }
    #endregion ClearSelection

    #region Fill Controls
    private void fillControls(SqlInt32 DesignationID)
    {
        DesignationBAL balDesignation = new DesignationBAL();
        DesignationENT entDesignation = new DesignationENT();

        entDesignation = balDesignation.SelectByPK(DesignationID);

        if (!entDesignation.DesignationName.IsNull)
            txtDesignationName.Text = entDesignation.DesignationName.Value.ToString();
    }
    #endregion Fill Controls

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Designation/DesignationList.aspx");
    }
    #endregion Button: Cancel
}