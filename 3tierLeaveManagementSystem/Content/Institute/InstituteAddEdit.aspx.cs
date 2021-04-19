using LeaveManagementSystem.BAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_Institute_InstituteAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["InstituteID"] != null)
            {
                fillControls(Convert.ToInt32(Request.QueryString["InstituteID"].ToString()));
                lblHeadContent.Text = "Institute Edit";
            }
            else
            {
                lblHeadContent.Text = "Institute Add";
            }
        }
    }
    #endregion Load Page

    #region Button: Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strError = "";

        if (txtInstituteName.Text.Trim() == "")
            strError += "Enter Institute +</br>";

        if (strError.Trim() != "")
        {
            PanelErrorMesseage.Visible = true;
            lblErrorMesseage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect Data
        InstituteENT entInstitute = new InstituteENT();

        if (txtInstituteName.Text.Trim() != "")
            entInstitute.InstituteName = txtInstituteName.Text.Trim();

        #endregion Collect Data

        InstituteBAL balInstitute = new InstituteBAL();

        if (Request.QueryString["InstituteID"] == null)
        {
            if (balInstitute.Insert(entInstitute))
            {
                clearSelection();
                PanelSuccess.Visible = true;
                lblSuccess.Text = "Data Inserted Successfully";
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMesseage.Text = balInstitute.Message;
            }
        }
        else
        {
            entInstitute.InstituteID = Convert.ToInt32(Request.QueryString["InstituteID"].ToString().Trim());

            if (balInstitute.Update(entInstitute))
            {
                Response.Redirect("~/Content/Institute/InstituteList.aspx");
            }
            else
            {
                PanelErrorMesseage.Visible = true;
                lblErrorMesseage.Text = balInstitute.Message;
            }
        }

    }
    #endregion Button: Save

    #region ClearSelection
    private void clearSelection()
    {
        txtInstituteName.Text = "";
    }
    #endregion ClearSelection

    #region FillControls
    private void fillControls(SqlInt32 InstituteID)
    {
        InstituteBAL balInstitute = new InstituteBAL();
        InstituteENT entInstitute = new InstituteENT();

        entInstitute = balInstitute.SelectByPK(InstituteID);

        if (!entInstitute.InstituteName.IsNull)
            txtInstituteName.Text = entInstitute.InstituteName.Value.ToString();
    }
    #endregion FillControls

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Institute/InstituteList.aspx");
    }
    #endregion Button: Cancel
}