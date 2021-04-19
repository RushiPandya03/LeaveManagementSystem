using LeaveManagementSystem.BAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Leave_LeaveStatus : System.Web.UI.Page
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
        #endregion Check Valid User

        PanelErrorMesseage.Visible = false;

        if (Session["DisplayName"] != null)
            lblDisplayname.Text = Session["DisplayName"].ToString().Trim();

        if (Session["PhotoPath"] != null)
            Image.ImageUrl = Session["PhotoPath"].ToString().Trim();

        
        if (!Page.IsPostBack)
        {
            PanelErrorMesseage.Visible = false;
            FillGridViewLeave();
        }
    }
    #endregion Load Page

    #region fillGridView Leave
    private void FillGridViewLeave()
    {
        LeaveStatusBAL balLeaveStatus = new LeaveStatusBAL();
        DataTable dtLeaveStatus = new DataTable();
        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();

        entUser = balUser.SelectUserCount();
        lblTotalEmployee.Text = entUser.Usercount.ToString();

        dtLeaveStatus = balLeaveStatus.SelectAll();
        Session["PendingLeaveRequest"] = dtLeaveStatus.Rows.Count;

        if (dtLeaveStatus != null && dtLeaveStatus.Rows.Count > 0)
        {
            lblPendingLeave.Text = dtLeaveStatus.Rows.Count.ToString();
            gvLeaveStatus.DataSource = dtLeaveStatus;
            gvLeaveStatus.DataBind();
        }
        else if(dtLeaveStatus.Rows.Count < 1)
        {
            lblPendingLeave.Text = 0.ToString();
            gvLeaveStatus.DataSource = null;
            gvLeaveStatus.DataBind();
            PanelGV.Visible = false;
        }
        else
        {
            PanelErrorMesseage.Visible = true;
            lblErrorMesseage.Text = balLeaveStatus.Message;
        }
    }
    #endregion fillGridView Leave

    #region Button: Logout
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Login.aspx");
    }
    #endregion Button: Logout

    #region Button: Approve Reject Record
    protected void gvLeaveStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        LeaveBAL balLeave = new LeaveBAL();
        LeaveENT entLeave = new LeaveENT();
        LeaveStatusBAL balLeaveStatus = new LeaveStatusBAL();
        UserENT entUser = new UserENT();
        UserBAL balUser = new UserBAL();

        entUser = balUser.SelectUserName(Convert.ToInt32(Session["UserID"].ToString().Trim()));
        
        if (e.CommandName == "Approved")
        {
            if (e.CommandArgument != null)
            {
                #region Collect Data
                entLeave.LeaveStatus = e.CommandName.ToString().Trim();
                entLeave.LeaveResponseBy = entUser.UserName;
                #endregion Collect Data

                if (!balLeave.UpdateLeaveStatusInLeave(entLeave, Convert.ToInt32(e.CommandArgument)))
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMesseage.Text = balLeave.Message;
                }
            }
        }
        else if (e.CommandName == "Rejected")
        {
            if (e.CommandArgument != null)
            {
                #region Collect Data
                entLeave.LeaveStatus = e.CommandName.ToString().Trim();
                entLeave.LeaveResponseBy = entUser.UserName;
                #endregion Collect Data

                if(!balLeave.UpdateLeaveStatusInLeave(entLeave, Convert.ToInt32(e.CommandArgument)))
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMesseage.Text = balLeave.Message;
                }
            }
        }
        balLeaveStatus.Delete(Convert.ToInt32(e.CommandArgument));
        FillGridViewLeave();
    }
    #endregion Button: Approve Reject Record
}