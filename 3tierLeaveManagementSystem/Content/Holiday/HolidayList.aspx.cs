using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Holiday_HolidayList : System.Web.UI.Page
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
            FillGridViewHoliday();
        }
    }
    #endregion Load Page

    #region fillGridView Holiday
    private void FillGridViewHoliday()
    {
        HolidayBAL balHoliday = new HolidayBAL();
        DataTable dtHoliday = new DataTable();

        dtHoliday = balHoliday.SelectAll();

        if (dtHoliday != null && dtHoliday.Rows.Count > 0)
        {
            gvHoliday.DataSource = dtHoliday;
            gvHoliday.DataBind();
        }
    }
    #endregion fillGridView Department

    #region Button: Delete Edit Record
    protected void gvHoliday_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                HolidayBAL balHoliday = new HolidayBAL();
                if (balHoliday.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridViewHoliday();
                }
                else
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMesseage.Text = balHoliday.Message;
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
    protected void btnAddHoliday_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Holiday/HolidayAddEdit.aspx");
    }
    #endregion Button: Add
}