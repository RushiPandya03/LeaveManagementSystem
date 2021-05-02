using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_LeaveType_LeaveTypeAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["LeaveTypeID"] != null)
            {
                fillControls(Convert.ToInt32(Request.QueryString["LeaveTypeID"].ToString()));

                lblHeadComponent.Text = "LeaveType Edit";
            }
            else
            {
                lblHeadComponent.Text = "LeaveType Add";
            }
        }
    }
    #endregion Load Page

    #region Button: Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strError = "";

        if (txtLeaveType.Text.Trim() == "")
            strError += "Enter LeaveType +</br>";

        if (strError.Trim() != "")
        {
            PanelErrorMesseage.Visible = true;
            lblErrorMesseage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect Data
        LeaveTypeENT entLeaveType = new LeaveTypeENT();

        if (txtLeaveType.Text.Trim() != "")
            entLeaveType.LeaveType = txtLeaveType.Text.Trim();

        if (txtTotalDays.Text.Trim() != "")
            entLeaveType.TotalDays = Convert.ToInt32(txtTotalDays.Text.Trim());

        #endregion Collect Data

        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

        if (Request.QueryString["LeaveTypeID"] == null)
        {
            if (balLeaveType.Insert(entLeaveType))
            {
                clearSelection();
                PanelSuccess.Visible = true;
                lblSuccess.Text = "Data Inserted Successfully";
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMesseage.Text = balLeaveType.Message;
            }
        }
        else
        {
            entLeaveType.LeaveTypeID = Convert.ToInt32(Request.QueryString["LeaveTypeID"].ToString().Trim());

            if (balLeaveType.Update(entLeaveType))
            {
                Response.Redirect("~/Content/LeaveType/LeaveTypeList.aspx");
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMesseage.Text = balLeaveType.Message;
            }
        }

    }
    #endregion Button: Save

    #region ClearSelection
    private void clearSelection()
    {
        txtLeaveType.Text = "";
        txtTotalDays.Text = "";
    }
    #endregion ClearSelection

    #region FillControls
    private void fillControls(SqlInt32 LeaveTypeID)
    {
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
        LeaveTypeENT entLeaveType = new LeaveTypeENT();

        entLeaveType = balLeaveType.SelectByPK(LeaveTypeID);

        if (!entLeaveType.LeaveType.IsNull)
            txtLeaveType.Text = entLeaveType.LeaveType.Value.ToString();

        if (!entLeaveType.TotalDays.IsNull)
            txtTotalDays.Text = entLeaveType.TotalDays.Value.ToString();
    }
    #endregion FillControls

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/LeaveType/LeaveTypeList.aspx");
    }
    #endregion Button: Cancel
}