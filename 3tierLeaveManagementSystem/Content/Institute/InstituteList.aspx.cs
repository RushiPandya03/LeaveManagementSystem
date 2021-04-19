using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Institute_InstituteList : System.Web.UI.Page
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
            FillGridViewInstitute();
        }
    }
    #endregion Load Page

    #region fillGridView Institute
    private void FillGridViewInstitute()
    {
        InstituteBAL balInstitute = new InstituteBAL();
        DataTable dtInstitute = new DataTable();

        dtInstitute = balInstitute.SelectAll();

        if (dtInstitute != null && dtInstitute.Rows.Count > 0)
        {
            gvInstitute.DataSource = dtInstitute;
            gvInstitute.DataBind();
        }
    }
    #endregion fillGridView Institute

    #region Button: Delete Edit Record
    protected void gvInstitute_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                InstituteBAL balInstitute = new InstituteBAL();
                if (balInstitute.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridViewInstitute();
                }
                else
                {
                    PanelErrorMesseage.Visible = true;
                    lblErrorMesseage.Text = balInstitute.Message;
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
    protected void btnAddInstitute_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Institute/InstituteAddEdit.aspx");
    }
    #endregion Button: Add
}