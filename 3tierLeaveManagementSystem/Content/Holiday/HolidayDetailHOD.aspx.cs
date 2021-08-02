using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Holiday_HolidayDetailHOD : System.Web.UI.Page
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
            fillGridViewHoliday();
            upcomingHoliday();
        }
    }
    #endregion Load Page

    #region UpcomingHoliday
    private void upcomingHoliday()
    {
        HolidayBAL balHoliday = new HolidayBAL();
        HolidayENT entHoliday = new HolidayENT();
        DataTable dtHoliday = new DataTable();
        DateTime today = DateTime.Today;
        string strDate = "";
        string upcomingHoliday = "";
        string[] dateString;
        DateTime startdate;
        dtHoliday = balHoliday.SelectHolidayDate();

        foreach (DataRow row in dtHoliday.Rows)
        {
            strDate = row[0].ToString();
            dateString = strDate.Split('-');
            startdate = Convert.ToDateTime(dateString[0] + "-" + dateString[1] + "-" + dateString[2]);
            if (startdate > today)
            {
                upcomingHoliday = strDate;
                break;
            }
        }
        entHoliday = balHoliday.SelectByHolidayDate(upcomingHoliday);
        lblUpcomingHoliday.Text = entHoliday.Name.ToString() + " On " + entHoliday.Day.ToString() + " " + entHoliday.Date.ToString();
    }
    #endregion UpcomingHoliday

    #region FillGridViewHoliday
    private void fillGridViewHoliday()
    {
        DataTable dtHoliday = new DataTable();
        HolidayBAL balHoliday = new HolidayBAL();
        HolidayENT entHoliday = new HolidayENT();

        dtHoliday = balHoliday.SelectAll();

        if (dtHoliday != null && dtHoliday.Rows.Count > 0)
        {
            gvHoliday.DataSource = dtHoliday;
            gvHoliday.DataBind();
        }
        else if (dtHoliday.Rows.Count < 1)
        {
            gvHoliday.DataSource = null;
            gvHoliday.DataBind();
            PanelGV.Visible = false;
        }
        else
        {
            PanelErrorMesseage.Visible = true;
            lblErrorMesseage.Text = balHoliday.Message;
        }
    }
    #endregion FillGridViewHoliday

    #region Button: Logout
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Session["UserID"] = null;
        Session["Select"] = null;
        Response.Redirect("~/Content/Login.aspx");
    }
    #endregion Button: Logout
}