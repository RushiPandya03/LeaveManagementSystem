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
            displayRemainingLeave();
            FillGridViewLeave();
        }
    }
    #endregion Load Page

    #region Display Remaining Leave

    private void displayRemainingLeave()
    {
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
        LeaveTypeENT entLeaveType = new LeaveTypeENT();
        DataTable dtLeaveType = new DataTable();
        string leavetype = "";
        string totaldays = "";

        dtLeaveType = balLeaveType.SelectByUserID(Convert.ToInt32(Session["UserID"].ToString().Trim()));
        
        if (dtLeaveType.Rows.Count > 0)
        {
            DataColumn LeaveType = dtLeaveType.Columns["LeaveType"];
            DataColumn TotalDays = dtLeaveType.Columns["TotalDays"];
            foreach (DataRow row in dtLeaveType.Rows)
            {
                leavetype = row[LeaveType].ToString();
                foreach (DataRow rows in dtLeaveType.Rows)
                {
                    totaldays = row[TotalDays].ToString();
                    if (leavetype == "Casual Leave")
                    {
                        lblCasualLeave.Text = totaldays;
                    }
                    else if(leavetype == "Medical Leave")
                    {
                        lblMedicalLeave.Text = totaldays;
                    }
                    else if(leavetype == "LOP")
                    {
                        lblLOP.Text = totaldays;
                    }
                    else if(leavetype == "Other Leave")
                    {
                        lblOtherLeave.Text = totaldays;
                    }
                }
            }
        }
    }
    #endregion Display Remaining Leave

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
        LeaveENT entLeaveforRemainingLeave = new LeaveENT();
        LeaveStatusBAL balLeaveStatus = new LeaveStatusBAL();
        LeaveTypeENT entLeaveType = new LeaveTypeENT();
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

        entLeave = balLeave.SelectLeaveStatusByPK(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
        
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                entLeaveforRemainingLeave = balLeave.SelectByPK(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"].ToString()));
                if (balLeaveStatus.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {

                    if (!balLeave.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"].ToString().Trim())))
                        lblErrorMesseage.Text = balLeave.Message;

                    FillGridViewLeave();
                    displayRemainingLeave();
                }
                else
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMesseage.Text = balLeaveStatus.Message;
                }
                if(entLeave.LeaveResponseBy == "Pending" && entLeave.LeaveStatus == "Pending")
                {
                    if (entLeaveforRemainingLeave.LeaveEndDate != "")
                    {
                        string strStartDate = entLeaveforRemainingLeave.LeaveStartDate.ToString();
                        string[] StartDateString = strStartDate.Split('-');
                        DateTime startdate = Convert.ToDateTime(StartDateString[0] + "-" + StartDateString[1] + "-" + StartDateString[2]);

                        string strEndDate = entLeaveforRemainingLeave.LeaveEndDate.ToString();
                        string[] EndDateString = strEndDate.Split('-');
                        DateTime enddate = Convert.ToDateTime(EndDateString[0] + "-" + EndDateString[1] + "-" + EndDateString[2]);

                        entLeaveType = balLeaveType.SelectByPK(entLeave.LeaveTypeID);
                        if (entLeaveType.LeaveType == "Casual Leave")
                        {
                            entLeaveType.TotalDays = entLeaveType.TotalDays + Convert.ToInt32((enddate - startdate).TotalDays) + 1;
                        }
                        else if (entLeaveType.LeaveType == "Medical Leave")
                        {
                            entLeaveType.TotalDays = entLeaveType.TotalDays + Convert.ToInt32((enddate - startdate).TotalDays) + 1;
                        }
                        else if (entLeaveType.LeaveType == "LOP")
                        {
                            entLeaveType.TotalDays = entLeaveType.TotalDays + Convert.ToInt32((enddate - startdate).TotalDays) + 1;
                        }
                        else if (entLeaveType.LeaveType == "Other Leave")
                        {
                            entLeaveType.TotalDays = entLeaveType.TotalDays + Convert.ToInt32((enddate - startdate).TotalDays) + 1;
                        }
                    }
                    else
                    {
                        entLeaveType = balLeaveType.SelectByPK(entLeave.LeaveTypeID);
                        if (entLeaveType.LeaveType == "Casual Leave")
                        {
                            entLeaveType.TotalDays = entLeaveType.TotalDays + 1;
                        }
                        else if (entLeaveType.LeaveType == "Medical Leave")
                        {
                            entLeaveType.TotalDays = entLeaveType.TotalDays + 1;
                        }
                        else if (entLeaveType.LeaveType == "LOP")
                        {
                            entLeaveType.TotalDays = entLeaveType.TotalDays + 1;
                        }
                        else if (entLeaveType.LeaveType == "Other Leave")
                        {
                            entLeaveType.TotalDays = entLeaveType.TotalDays + 1;
                        }
                    }
                    entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
                    if (balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
                    {
                        displayRemainingLeave();
                    }
                    else
                    {
                        PanelErrorMesseage.Visible = true;
                        lblErrorMesseage.Text = balLeaveType.Message;
                    }
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
        Session["UserID"] = null;
        Session["Select"] = null;
        Response.Redirect("~/Content/Login.aspx");
    }
    #endregion Button: Logout
}