using LeaveManagementSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
public class CommonFillMethods
{
    #region Constructor
    public CommonFillMethods()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    #region Dropdown Department
    public static void fillDropDownListDepartment(DropDownList ddl)
    {
        DepartmentBAL balDepartment = new DepartmentBAL();
        ddl.DataSource = balDepartment.SelectForDropDownList();
        ddl.DataValueField = "DepartmentID";
        ddl.DataTextField = "DepartmentName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem(" --Select Department--", "-1"));
    }
    #endregion Dropdown Department

    #region Dropdown Designation
    public static void fillDropDownListDesignation(DropDownList ddl)
    {
        DesignationBAL balDesignation = new DesignationBAL();
        ddl.DataSource = balDesignation.SelectForDropDownList();
        ddl.DataValueField = "DesignationID";
        ddl.DataTextField = "DesignationName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem(" --Select Designation--", "-1"));
    }
    #endregion Dropdown Designation

    #region Dropdown Designation Without HOD
    public static void SelectWithoutHODForDropDownList(DropDownList ddl)
    {
        DesignationBAL balDesignation = new DesignationBAL();
        ddl.DataSource = balDesignation.SelectWithoutHODForDropDownList();
        ddl.DataValueField = "DesignationID";
        ddl.DataTextField = "DesignationName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem(" --Select Designation--", "-1"));
    }
    #endregion Dropdown Designation Without HOD

    #region Dropdown Institute
    public static void fillDropDownListInstitute(DropDownList ddl)
    {
        InstituteBAL balInstitute = new InstituteBAL();
        ddl.DataSource = balInstitute.SelectForDropDownList();
        ddl.DataValueField = "InstituteID";
        ddl.DataTextField = "InstituteName";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem(" --Select Institute--", "-1"));
    }
    #endregion Dropdown Institute

    #region Dropdown LeaveType
    public static void fillDropDownListLeaveType(DropDownList ddl)
    {
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
        ddl.DataSource = balLeaveType.SelectForDropDownList();
        ddl.DataValueField = "LeaveTypeID";
        ddl.DataTextField = "LeaveType";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem(" --Select LeaveType--", "-1"));
    }
    #endregion Dropdown LeaveType
}