using LeaveManagementSystem.BAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Holiday_HolidayAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["HolidayID"] != null)
            {
                fillControls(Convert.ToInt32(Request.QueryString["HolidayID"].ToString()));
                lblHeadContent.Text = "Holiday Edit";
            }
            else
            {
                lblHeadContent.Text = "Holiday Add";
            }
        }
    }
    #endregion Load Page

    #region Button: Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strError = "";

        if (txtHoliday.Text.Trim() == "")
            strError += "Enter Holiday +</br>";

        if (strError.Trim() != "")
        {
            PanelErrorMesseage.Visible = true;
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect Data
        HolidayENT entHoliday = new HolidayENT();

        if (txtHoliday.Text.Trim() != "")
            entHoliday.Name = txtHoliday.Text.Trim();

        if (txtDay.Text.Trim() != "")
            entHoliday.Day = txtDay.Text.Trim();

        if (txtDate.Text.Trim() != "")
            entHoliday.Date = txtDate.Text.Trim();

        #endregion Collect Data

        HolidayBAL balHoliday = new HolidayBAL();

        if (Request.QueryString["HolidayID"] == null)
        {
            if (balHoliday.Insert(entHoliday))
            {
                clearSelection();
                PanelSuccess.Visible = true;
                lblSuccess.Text = "Data Inserted Successfully";
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balHoliday.Message;
            }
        }
        else
        {
            entHoliday.HolidayID = Convert.ToInt32(Request.QueryString["HolidayID"].ToString().Trim());

            if (balHoliday.Update(entHoliday))
            {
                Response.Redirect("~/Content/Holiday/HolidayList.aspx");
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMessage.Text = balHoliday.Message;
            }
        }

    }
    #endregion Button: Save

    #region ClearSelection
    private void clearSelection()
    {
        txtHoliday.Text = "";
        txtDay.Text = "";
        txtDate.Text = "";
    }
    #endregion ClearSelection

    #region Fill Controls
    private void fillControls(SqlInt32 DepartmentID)
    {
        HolidayBAL balHoliday = new HolidayBAL();
        HolidayENT entHoliday = new HolidayENT();

        entHoliday = balHoliday.SelectByPK(DepartmentID);

        if (!entHoliday.Name.IsNull)
            txtHoliday.Text = entHoliday.Name.Value.ToString();

        if (!entHoliday.Date.IsNull)
            txtDate.Text = entHoliday.Date.Value.ToString();

        if (!entHoliday.Day.IsNull)
            txtDay.Text = entHoliday.Day.Value.ToString();
    }
    #endregion Fill Controls

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Holiday/HolidayList.aspx");
    }
    #endregion Button: Cancel
}