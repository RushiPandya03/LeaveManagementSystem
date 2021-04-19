using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Department_DepartmentList : System.Web.UI.Page
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
            FillGridViewDepartment();
        }
    }
    #endregion Load Page

    #region fillGridView Department
    private void FillGridViewDepartment()
    {
        DepartmentBAL balDepartment = new DepartmentBAL();
        DataTable dtDepartment = new DataTable();

        dtDepartment = balDepartment.SelectAll();

        if (dtDepartment != null && dtDepartment.Rows.Count > 0)
        {
            gvDepartment.DataSource = dtDepartment;
            gvDepartment.DataBind();
        }
    }
    #endregion fillGridView Department

    #region Button: Delete Edit Record
    protected void gvDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DepartmentBAL balDepartment = new DepartmentBAL();
                if (balDepartment.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridViewDepartment();
                }
                else
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMesseage.Text = balDepartment.Message;
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
    protected void btnAddDepartment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Department/DepartmentAddEdit.aspx");
    }
    #endregion Button: Add
}