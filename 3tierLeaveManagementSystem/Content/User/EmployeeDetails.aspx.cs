using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_User_EmployeeDetails : System.Web.UI.Page
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
            fillGridViewEmployee();
        }
    }
    #endregion Load Page

    #region FillGridView Employee
    private void fillGridViewEmployee()
    {
        DataTable dtUser = new DataTable();
        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();

        entUser = balUser.SelectUserCount();
        lblTotalEmployee.Text = entUser.Usercount.ToString();
        lblPendingLeave.Text = Session["PendingLeaveRequest"].ToString();

        dtUser = balUser.SelectAll();

        if (dtUser != null && dtUser.Rows.Count > 0)
        {
            gvEmployeeDetails.DataSource = dtUser;
            gvEmployeeDetails.DataBind();
        }
        else if (dtUser.Rows.Count < 1)
        {
            gvEmployeeDetails.DataSource = null;
            gvEmployeeDetails.DataBind();
            PanelGV.Visible = false;
        }
        else
        {
            PanelErrorMesseage.Visible = true;
            lblErrorMesseage.Text = balUser.Message;
        }
    }
    #endregion FillGridViewEmployee

    #region Button: Logout
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Session["UserID"] = null;
        Session["Select"] = null;
        Response.Redirect("~/Content/Login.aspx");
    }
    #endregion Button: Logout
    
}