using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Designation_DesignationList : System.Web.UI.Page
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
            FillGridViewDesignation();
        }
    }
    #endregion Load Page

    #region FillGridView Designation
    private void FillGridViewDesignation()
    {
        DesignationBAL balDesignation = new DesignationBAL();
        DataTable dtDesignation = new DataTable();

        dtDesignation = balDesignation.SelectAll();

        if (dtDesignation != null && dtDesignation.Rows.Count > 0)
        {
            gvDesignation.DataSource = dtDesignation;
            gvDesignation.DataBind();
        }
    }
    #endregion FillGridView Designation

    #region Button: Delete Edit Record
    protected void gvDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DesignationBAL balDesignation = new DesignationBAL();
                if (balDesignation.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridViewDesignation();
                }
                else
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMesseage.Text = balDesignation.Message;
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
    protected void btnAddDesignation_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Designation/DesignationAddEdit.aspx");
    }
    #endregion Button: Add
}