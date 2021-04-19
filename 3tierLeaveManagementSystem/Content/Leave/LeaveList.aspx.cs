using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Web.UI.WebControls;
using LeaveManagementSystem.ENT;

public partial class Content_Leave_LeaveList : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User

        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Content/Login.aspx");
            return;
        }
        #endregion

        PanelErrorMesseage.Visible = false;

        if (Session["DisplayName"] != null)
            lblDisplayname.Text = Session["DisplayName"].ToString().Trim();

        if (Session["PhotoPath"] != null)
            Image.ImageUrl = Session["PhotoPath"].ToString().Trim();

        

        if (!Page.IsPostBack)
        {
            FillGridViewLeave();
        }
    }
    #endregion Load Page

    #region fillGridView Leave
    private void FillGridViewLeave()
    {
        LeaveBAL balLeave = new LeaveBAL();
        DataTable dtLeave = new DataTable();

        dtLeave = balLeave.SelectAllByUserID(Convert.ToInt32(Session["UserID"].ToString().Trim()));

        if (dtLeave != null && dtLeave.Rows.Count > 0)
        {
            gvLeave.DataSource = dtLeave;
            gvLeave.DataBind();
        }
        else if (dtLeave.Rows.Count < 1)
        {
            gvLeave.DataSource = null;
            gvLeave.DataBind();
            PanelGV.Visible = false;
        }
        else
        {
            PanelErrorMesseage.Visible = true;
            lblErrorMesseage.Text = balLeave.Message;
        }
    }
    #endregion fillGridView Leave

    #region Button: Delete Edit Record
    protected void gvLeave_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        LeaveBAL balLeave = new LeaveBAL();
        LeaveENT entLeave = new LeaveENT();
        LeaveStatusBAL balLeaveStatus = new LeaveStatusBAL();

        entLeave = balLeave.SelectLeaveStatusByPK(Convert.ToInt32(e.CommandArgument.ToString().Trim()));

        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                if (balLeaveStatus.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    if (!balLeave.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"].ToString().Trim())))
                        lblErrorMesseage.Text = balLeave.Message;

                    FillGridViewLeave();
                }
                else
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMesseage.Text = balLeaveStatus.Message;
                }
            }
        }
        else if (e.CommandName == "EditRecord")
        {
            if (entLeave.LeaveResponseBy != "Pending" && entLeave.LeaveStatus != "Pending")
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMesseage.Text = "You can not edit leave after Responsed";
            }
            else
            {
                if (e.CommandArgument != null)
                    Response.Redirect("~/Content/Leave/LeaveAddEdit.aspx?LeaveID=" + e.CommandArgument.ToString().Trim());
            }
        }
    }
    #endregion Button: Delete Edit Record

    #region Button: Add
    protected void btnAddLeave_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Leave/LeaveAddEdit.aspx");
    }
    #endregion Button: Add

    #region Button: Logout
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Login.aspx");
    }
    #endregion Button: Logout
}