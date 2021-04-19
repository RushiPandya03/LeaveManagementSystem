using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_LeaveType_LeaveTypeList : System.Web.UI.Page
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

        if (!Page.IsPostBack)
        {
            FillGridViewLeaveType();
        }
    }
    #endregion Load Page

    #region fillGridView LeaveType
    private void FillGridViewLeaveType()
    {
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
        DataTable dtLeaveType = new DataTable();

        dtLeaveType = balLeaveType.SelectAll();

        if (dtLeaveType != null && dtLeaveType.Rows.Count > 0)
        {
            gvLeaveType.DataSource = dtLeaveType;
            gvLeaveType.DataBind();
        }
    }
    #endregion fillGridView LeaveType

    #region Button: Delete Edit Record
    protected void gvLeaveType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
                if (balLeaveType.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridViewLeaveType();
                }
                else
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMesseage.Text = balLeaveType.Message;
                }
            }
        }
        else if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
                Response.Redirect(e.CommandArgument.ToString().Trim());
        }
    }
    #endregion Button: Delete Edit Record

    #region Button: Add
    protected void btnAddLeaveType_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/LeaveType/LeaveTypeAddEdit.aspx");
    }
    #endregion Button: Add
}