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

    #region ddlLeaveType - Selected Index Changed

    protected void ddlLeaveType_SelectedIndexChanged(object sender, EventArgs e)
    {

        LeaveTypeENT entLeaveType = new LeaveTypeENT();
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

        if (Request.QueryString["LeaveID"] != null)
        {
            entLeaveType = balLeaveType.SelectByPK(Convert.ToInt32(Session["LeaveTypeID"].ToString()));
            entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());

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
            if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balLeaveType.Message;
            }


            entLeaveType = balLeaveType.SelectByPK(Convert.ToInt32(ddlLeaveType.SelectedValue));

            entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
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
            if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balLeaveType.Message;
            }
        }
    }
    #endregion ddlLeaveType - Selected Index Changed

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
            if(startdate < today)
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
            if(entLeaveType.LeaveType == "Casual Leave")
            {
                if(entLeaveType.TotalDays < 1)
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
                            entLeaveStatus.LeaveID = entLeave.LeaveID;
                        clearSelection();

                        entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
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
                        if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
                        {
                            PanelErrorMesseage.Visible = true;
                            lblErrorMessage.Text = balLeaveType.Message;
                        }

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
            else if(entLeaveType.LeaveType == "Medical Leave")
            {
                if (entLeaveType.TotalDays < 1)
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
                            entLeaveStatus.LeaveID = entLeave.LeaveID;
                        clearSelection();

                        entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
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
                        if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
                        {
                            PanelErrorMesseage.Visible = true;
                            lblErrorMessage.Text = balLeaveType.Message;
                        }

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
            else if(entLeaveType.LeaveType == "LOP")
            {
                if (entLeaveType.TotalDays < 1)
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
                            entLeaveStatus.LeaveID = entLeave.LeaveID;
                        clearSelection();

                        entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
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
                        if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
                        {
                            PanelErrorMesseage.Visible = true;
                            lblErrorMessage.Text = balLeaveType.Message;
                        }

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
            else if(entLeaveType.LeaveType == "Other Leave")
            {
                if (entLeaveType.TotalDays < 1)
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
                            entLeaveStatus.LeaveID = entLeave.LeaveID;
                        clearSelection();

                        entLeaveType.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
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
                        if (!balLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
                        {
                            PanelErrorMesseage.Visible = true;
                            lblErrorMessage.Text = balLeaveType.Message;
                        }

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

            if (balLeave.Update(entLeave, Convert.ToInt32(Session["UserID"].ToString().Trim())))
                lblErrorMessage.Text = balLeave.Message;

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
    private void fillControls(SqlInt32 LeaveID,SqlInt32 UserID)
    {
        LeaveBAL balLeave = new LeaveBAL();
        LeaveENT entLeave = new LeaveENT();

        entLeave = balLeave.SelectByPK(LeaveID,UserID);

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