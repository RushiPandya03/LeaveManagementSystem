using LeaveManagementSystem.BAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Leave_LeaveAddEdit : System.Web.UI.Page
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
        PanelSuccess.Visible = false;

        if (Session["DisplayName"] != null)
            lblDisplayname.Text = Session["DisplayName"].ToString().Trim();

        if (Session["PhotoPath"] != null)
            Image.ImageUrl = Session["PhotoPath"].ToString().Trim();


        if (!Page.IsPostBack)
        {
            fillDropdownList();
            if (Request.QueryString["LeaveID"] != null)
            {
                fillControls(Convert.ToInt32(Request.QueryString["LeaveID"].ToString()), Convert.ToInt32(Session["UserID"].ToString().Trim()));
                addLeave();
                lblHeadContent.Text = "Leave Edit";
            }
            else
            {
                lblHeadContent.Text = "Leave Add";
            }

        }
    }
    #endregion Load Page

    #region Button: FullLeave
    protected void rbFullLeave_CheckedChanged(object sender, EventArgs e)
    {
        if (rbFullLeave.Checked == true)
        {
            lblLeaveStartDate.Text = "Leave StartDate";
            txtLeaveEndDate.Text = "";
            panelLeaveEndDate.Visible = true;
        }
    }
    #endregion Button: FullLeave

    #region Button: HalfLeave
    protected void rbHalfLeave_CheckedChanged(object sender, EventArgs e)
    {
        if (rbHalfLeave.Checked == true)
        {
            lblLeaveStartDate.Text = "Leave Date";
            txtLeaveEndDate.Text = "";
            panelLeaveEndDate.Visible = false;
        }
    }
    #endregion Button: HalfLeave

    #region Fill Dropdown
    private void fillDropdownList()
    {
        CommonFillMethods.fillDropDownListLeaveType(ddlLeaveType, Convert.ToInt32(Session["UserID"].ToString().Trim()));
    }
    #endregion Fill Dropdown

    #region Add Leave
    private void addLeave()
    {
        LeaveBAL balLeave = new LeaveBAL();
        LeaveENT entLeave = new LeaveENT();
        LeaveTypeENT entLeaveType = new LeaveTypeENT();
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

        entLeave = balLeave.SelectByPK(Convert.ToInt32(Request.QueryString["LeaveID"]), Convert.ToInt32(Session["UserID"].ToString().Trim()));

        if (Request.QueryString["LeaveID"] != null)
        {
            if (entLeave.LeaveEndDate != "")
            {
                string strStartDate = entLeave.LeaveStartDate.ToString();
                string[] StartDateString = strStartDate.Split('-');
                DateTime startdate = Convert.ToDateTime(StartDateString[0] + "-" + StartDateString[1] + "-" + StartDateString[2]);

                string strEndDate = entLeave.LeaveEndDate.ToString();
                string[] EndDateString = strEndDate.Split('-');
                DateTime enddate = Convert.ToDateTime(EndDateString[0] + "-" + EndDateString[1] + "-" + EndDateString[2]);

                entLeaveType = balLeaveType.SelectByPK(entLeave.LeaveTypeID);
                if (entLeaveType.LeaveType == "Casual Leave")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays + Convert.ToInt32((enddate - startdate).TotalDays) + 1;
                    Session["Casual Leave"] = entLeaveType.TotalDays;
                }
                else if (entLeaveType.LeaveType == "Medical Leave")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays + Convert.ToInt32((enddate - startdate).TotalDays) + 1;
                    Session["Medical Leave"] = entLeaveType.TotalDays;
                }
                else if (entLeaveType.LeaveType == "LOP")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays + Convert.ToInt32((enddate - startdate).TotalDays) + 1;
                    Session["LOP"] = entLeaveType.TotalDays;
                }
                else if (entLeaveType.LeaveType == "Other Leave")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays + Convert.ToInt32((enddate - startdate).TotalDays) + 1;
                    Session["Other Leave"] = entLeaveType.TotalDays;
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
            if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balLeaveType.Message;
            }
        }
    }
    #endregion Add Leave

    #region Button: Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Collect Data
        LeaveENT entLeave = new LeaveENT();
        LeaveBAL balLeave = new LeaveBAL();
        LeaveStatusENT entLeaveStatus = new LeaveStatusENT();
        LeaveStatusBAL balLeaveStatus = new LeaveStatusBAL();
        LeaveTypeENT entLeaveType = new LeaveTypeENT();
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

        if (ddlLeaveType.SelectedIndex > 0)
        {
            entLeave.LeaveTypeID = Convert.ToInt32(ddlLeaveType.SelectedValue);
            entLeaveStatus.LeaveTypeID = Convert.ToInt32(ddlLeaveType.SelectedValue);
            entLeaveType.LeaveTypeID = Convert.ToInt32(ddlLeaveType.SelectedValue);
        }
        entLeaveType = balLeaveType.SelectByPK(entLeaveType.LeaveTypeID);

        if (entLeave.LeaveID > 0)
            entLeaveStatus.LeaveID = entLeave.LeaveID;

        if (txtLeaveReason.Text.Trim() != "")
            entLeave.LeaveReason = txtLeaveReason.Text.Trim();

        if (rbHalfLeave.Checked != false)
            entLeave.LeaveDuration = rbHalfLeave.Text.Trim();

        if (rbFullLeave.Checked != false)
            entLeave.LeaveDuration = rbFullLeave.Text.Trim();

        if (txtLeaveStartDate.Text.Trim() != "")
        {
            DateTime today = DateTime.Today;
            string strDate = txtLeaveStartDate.Text.Trim();
            string[] dateString = strDate.Split('-');
            DateTime startdate = Convert.ToDateTime(dateString[0] + "-" + dateString[1] + "-" + dateString[2]);
            if (startdate < today)
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = "Leavedate must not be in past";
                txtLeaveStartDate.Focus();
                return;
            }
            else
            {
                PanelErrorMesseage.Visible = false;
                entLeave.LeaveStartDate = txtLeaveStartDate.Text.Trim();
            }
        }

        if (txtLeaveEndDate.Text.Trim() != "")
            entLeave.LeaveEndDate = txtLeaveEndDate.Text.Trim();
        #endregion Collect Data

        if (Request.QueryString["LeaveID"] == null)
        {
            string strStartDate = txtLeaveStartDate.Text.Trim();
            string[] StartDateString = strStartDate.Split('-');
            DateTime startdate = Convert.ToDateTime(StartDateString[0] + "-" + StartDateString[1] + "-" + StartDateString[2]);
            
            
            if (entLeaveType.LeaveType == "Casual Leave")
            {
                entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());

                if (rbHalfLeave.Checked == true)
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (rbFullLeave.Checked == true)
                {
                    string strEndDate = txtLeaveEndDate.Text.Trim();
                    string[] EndDateString = strEndDate.Split('-');
                    DateTime enddate = Convert.ToDateTime(EndDateString[0] + "-" + EndDateString[1] + "-" + EndDateString[2]);
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32((enddate - startdate).TotalDays) - 1;
                }
                
                if (entLeaveType.TotalDays < 0)
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMessage.Text = "You Can't Add More Casual Leave Because You Had Already Use It";
                    return;
                }
                else
                {
                    if (balLeave.Insert(entLeave, Convert.ToInt32(Session["UserID"].ToString().Trim())))
                    {
                        if (entLeave.LeaveID > 0)
                        {
                            entLeaveStatus.LeaveID = entLeave.LeaveID;
                        }
                        if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
                        {
                            PanelErrorMesseage.Visible = true;
                            lblErrorMessage.Text = balLeaveType.Message;
                        }
                        clearSelection();
                        PanelSuccess.Visible = true;
                        lblSuccess.Text = "Data Inserted Successfully";
                    }
                    else
                    {
                        PanelErrorMesseage.Visible = true;
                        lblErrorMessage.Text = balLeave.Message;
                    }

                    if (!balLeaveStatus.Insert(entLeaveStatus, Convert.ToInt32(Session["UserID"].ToString().Trim())))
                    {
                        PanelErrorMesseage.Visible = true;
                        lblErrorMessage.Text = balLeaveStatus.Message;
                    }
                }
            }
            else if (entLeaveType.LeaveType == "Medical Leave")
            {
                entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());

                if (rbHalfLeave.Checked == true)
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (rbFullLeave.Checked == true)
                {
                    string strEndDate = txtLeaveEndDate.Text.Trim();
                    string[] EndDateString = strEndDate.Split('-');
                    DateTime enddate = Convert.ToDateTime(EndDateString[0] + "-" + EndDateString[1] + "-" + EndDateString[2]);
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32((enddate - startdate).TotalDays) - 1;
                }

                if (entLeaveType.TotalDays < 0)
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMessage.Text = "You Can't Add More Medical Leave Because You Had Already Use It";
                    return;
                }
                else
                {
                    if (balLeave.Insert(entLeave, Convert.ToInt32(Session["UserID"].ToString().Trim())))
                    {
                        if (entLeave.LeaveID > 0)
                        {
                            entLeaveStatus.LeaveID = entLeave.LeaveID;
                        }
                        if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
                        {
                            PanelErrorMesseage.Visible = true;
                            lblErrorMessage.Text = balLeaveType.Message;
                        }
                        clearSelection();
                        PanelSuccess.Visible = true;
                        lblSuccess.Text = "Data Inserted Successfully";
                    }
                    else
                    {
                        PanelErrorMesseage.Visible = true;
                        lblErrorMessage.Text = balLeave.Message;
                    }

                    if (!balLeaveStatus.Insert(entLeaveStatus, Convert.ToInt32(Session["UserID"].ToString().Trim())))
                    {
                        PanelErrorMesseage.Visible = true;
                        lblErrorMessage.Text = balLeaveStatus.Message;
                    }
                }
            }
            else if (entLeaveType.LeaveType == "LOP")
            {
                entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());

                if (rbHalfLeave.Checked == true)
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (rbFullLeave.Checked == true)
                {
                    string strEndDate = txtLeaveEndDate.Text.Trim();
                    string[] EndDateString = strEndDate.Split('-');
                    DateTime enddate = Convert.ToDateTime(EndDateString[0] + "-" + EndDateString[1] + "-" + EndDateString[2]);
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32((enddate - startdate).TotalDays) - 1;
                }

                if (entLeaveType.TotalDays < 0)
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMessage.Text = "You Can't Add More LOP Because You Had Already Use It";
                    return;
                }
                else
                {
                    if (balLeave.Insert(entLeave, Convert.ToInt32(Session["UserID"].ToString().Trim())))
                    {
                        if (entLeave.LeaveID > 0)
                        {
                            entLeaveStatus.LeaveID = entLeave.LeaveID;
                        }
                        if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
                        {
                            PanelErrorMesseage.Visible = true;
                            lblErrorMessage.Text = balLeaveType.Message;
                        }
                        clearSelection();
                        PanelSuccess.Visible = true;
                        lblSuccess.Text = "Data Inserted Successfully";
                    }
                    else
                    {
                        PanelErrorMesseage.Visible = true;
                        lblErrorMessage.Text = balLeave.Message;
                    }

                    if (!balLeaveStatus.Insert(entLeaveStatus, Convert.ToInt32(Session["UserID"].ToString().Trim())))
                    {
                        PanelErrorMesseage.Visible = true;
                        lblErrorMessage.Text = balLeaveStatus.Message;
                    }
                }
            }
            else if (entLeaveType.LeaveType == "Other Leave")
            {
                entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());

                if (rbHalfLeave.Checked == true)
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (rbFullLeave.Checked == true)
                {
                    string strEndDate = txtLeaveEndDate.Text.Trim();
                    string[] EndDateString = strEndDate.Split('-');
                    DateTime enddate = Convert.ToDateTime(EndDateString[0] + "-" + EndDateString[1] + "-" + EndDateString[2]);
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32((enddate - startdate).TotalDays) - 1;
                }

                if (entLeaveType.TotalDays < 0)
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMessage.Text = "You Can't Add More Other Leave Because You Had Already Use It";
                    return;
                }
                else
                {
                    if (balLeave.Insert(entLeave, Convert.ToInt32(Session["UserID"].ToString().Trim())))
                    {
                        if (entLeave.LeaveID > 0)
                        {
                            entLeaveStatus.LeaveID = entLeave.LeaveID;
                        }
                        if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
                        {
                            PanelErrorMesseage.Visible = true;
                            lblErrorMessage.Text = balLeaveType.Message;
                        }
                        clearSelection();
                        PanelSuccess.Visible = true;
                        lblSuccess.Text = "Data Inserted Successfully";
                    }
                    else
                    {
                        PanelErrorMesseage.Visible = true;
                        lblErrorMessage.Text = balLeave.Message;
                    }

                    if (!balLeaveStatus.Insert(entLeaveStatus, Convert.ToInt32(Session["UserID"].ToString().Trim())))
                    {
                        PanelErrorMesseage.Visible = true;
                        lblErrorMessage.Text = balLeaveStatus.Message;
                    }
                }
            }
        }
        else
        {
            entLeave.LeaveID = Convert.ToInt32(Request.QueryString["LeaveID"].ToString().Trim());
            entLeaveStatus.LeaveID = Convert.ToInt32(Request.QueryString["LeaveID"].ToString().Trim());
            string strStartDate = txtLeaveStartDate.Text.Trim();
            string[] StartDateString = strStartDate.Split('-');
            DateTime startdate = Convert.ToDateTime(StartDateString[0] + "-" + StartDateString[1] + "-" + StartDateString[2]);

            if (entLeaveType.LeaveType == "Casual Leave")
            {
                entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());

                if (rbHalfLeave.Checked == true)
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (rbFullLeave.Checked == true)
                {
                    string strEndDate = txtLeaveEndDate.Text.Trim();
                    string[] EndDateString = strEndDate.Split('-');
                    DateTime enddate = Convert.ToDateTime(EndDateString[0] + "-" + EndDateString[1] + "-" + EndDateString[2]);
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32((enddate - startdate).TotalDays) - 1;
                }

                if (entLeaveType.TotalDays < 0)
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMessage.Text = "You Can't Add More Casual Leave Because You Had Already Use It";
                    return;
                }
            }
            else if (entLeaveType.LeaveType == "Medical Leave")
            {
                entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());

                if (rbHalfLeave.Checked == true)
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (rbFullLeave.Checked == true)
                {
                    string strEndDate = txtLeaveEndDate.Text.Trim();
                    string[] EndDateString = strEndDate.Split('-');
                    DateTime enddate = Convert.ToDateTime(EndDateString[0] + "-" + EndDateString[1] + "-" + EndDateString[2]);
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32((enddate - startdate).TotalDays) - 1;
                }

                if (entLeaveType.TotalDays < 0)
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMessage.Text = "You Can't Add More Medical Leave Because You Had Already Use It";
                    return;
                }
            }
            else if (entLeaveType.LeaveType == "LOP")
            {
                entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());

                if (rbHalfLeave.Checked == true)
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (rbFullLeave.Checked == true)
                {
                    string strEndDate = txtLeaveEndDate.Text.Trim();
                    string[] EndDateString = strEndDate.Split('-');
                    DateTime enddate = Convert.ToDateTime(EndDateString[0] + "-" + EndDateString[1] + "-" + EndDateString[2]);
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32((enddate - startdate).TotalDays) - 1;
                }

                if (entLeaveType.TotalDays < 0)
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMessage.Text = "You Can't Add More LOP Leave Because You Had Already Use It";
                    return;
                }
            }
            else if (entLeaveType.LeaveType == "Other Leave")
            {
                entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());

                if (rbHalfLeave.Checked == true)
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (rbFullLeave.Checked == true)
                {
                    string strEndDate = txtLeaveEndDate.Text.Trim();
                    string[] EndDateString = strEndDate.Split('-');
                    DateTime enddate = Convert.ToDateTime(EndDateString[0] + "-" + EndDateString[1] + "-" + EndDateString[2]);
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32((enddate - startdate).TotalDays) - 1;
                }

                if (entLeaveType.TotalDays < 0)
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMessage.Text = "You Can't Add More Other Leave Because You Had Already Use It";
                    return;
                }
            }

            entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
            if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balLeaveType.Message;
            }
            if (!balLeave.Update(entLeave, Convert.ToInt32(Session["UserID"].ToString().Trim())))
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balLeave.Message;
            }

            if (balLeaveStatus.UpdateLeaveStatus(entLeaveStatus))
            {
                Response.Redirect("~/Content/Leave/LeaveList.aspx");
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balLeaveStatus.Message;
            }
        }
    }
    #endregion Button: Save

    #region ClearSelection
    private void clearSelection()
    {
        txtLeaveReason.Text = "";
        txtLeaveStartDate.Text = "";
        txtLeaveEndDate.Text = "";
        rbFullLeave.Checked = false;
        rbHalfLeave.Checked = false;
        ddlLeaveType.SelectedIndex = -1;
    }
    #endregion ClearSelection

    #region Fill Controls
    private void fillControls(SqlInt32 LeaveID, SqlInt32 UserID)
    {
        LeaveBAL balLeave = new LeaveBAL();
        LeaveENT entLeave = new LeaveENT();

        entLeave = balLeave.SelectByPK(LeaveID, UserID);

        if (!entLeave.LeaveTypeID.IsNull)
        {
            ddlLeaveType.SelectedValue = entLeave.LeaveTypeID.Value.ToString();
            Session["LeaveTypeID"] = entLeave.LeaveTypeID.Value.ToString();
        }

        if (!entLeave.LeaveReason.IsNull)
            txtLeaveReason.Text = entLeave.LeaveReason.Value.ToString();

        if (!entLeave.LeaveDuration.IsNull)
        {
            if (entLeave.LeaveDuration == "HalfLeave")
            {
                rbHalfLeave.Checked = true;
                lblLeaveStartDate.Text = "Leave Date";
                txtLeaveEndDate.Text = "";
                panelLeaveEndDate.Visible = false;
            }
            if (entLeave.LeaveDuration == "FullLeave")
            {
                rbFullLeave.Checked = true;
                lblLeaveStartDate.Text = "Leave StartDate";
                txtLeaveEndDate.Text = "";
                panelLeaveEndDate.Visible = true;
            }
        }

        if (!entLeave.LeaveStartDate.IsNull)
            txtLeaveStartDate.Text = entLeave.LeaveStartDate.Value.ToString();

        if (!entLeave.LeaveEndDate.IsNull)
            txtLeaveEndDate.Text = entLeave.LeaveEndDate.Value.ToString();
    }
    #endregion Fill Controls

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        LeaveENT entLeave = new LeaveENT();
        LeaveBAL balLeave = new LeaveBAL();
        LeaveTypeENT entLeaveType = new LeaveTypeENT();
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

        if (Request.QueryString["LeaveID"] != null)
        {
            entLeave = balLeave.SelectByPK(Convert.ToInt32(Request.QueryString["LeaveID"]), Convert.ToInt32(Session["UserID"].ToString().Trim()));
            entLeaveType = balLeaveType.SelectByPK(entLeave.LeaveTypeID);
            if (entLeave.LeaveEndDate != "")
            {
                if (entLeaveType.LeaveType == "Casual Leave")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32(Session["Casual Leave"].ToString().Trim()) - 2;
                    Session["Casual Leave"] = null;
                }
                else if (entLeaveType.LeaveType == "Medical Leave")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32(Session["Medical Leave"].ToString().Trim()) - 2;
                    Session["Medical Leave"] = null;
                }
                else if (entLeaveType.LeaveType == "LOP")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32(Session["LOP"].ToString().Trim()) - 2;
                    Session["LOP"] = null;
                }
                else if (entLeaveType.LeaveType == "Other Leave")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - Convert.ToInt32(Session["Other Leave"].ToString().Trim()) - 2;
                    Session["Other Leave"] = null;
                }
            }
            else
            {
                if (entLeaveType.LeaveType == "Casual Leave")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (entLeaveType.LeaveType == "Medical Leave")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (entLeaveType.LeaveType == "LOP")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
                else if (entLeaveType.LeaveType == "Other Leave")
                {
                    entLeaveType.TotalDays = entLeaveType.TotalDays - 1;
                }
            }
            entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
            if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balLeaveType.Message;
            }
        }
        Response.Redirect("~/Content/Leave/LeaveList.aspx");
    }
    #endregion Button: Cancel

    #region Button: Logout
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Login.aspx");
    }
    #endregion Button: Logout
}