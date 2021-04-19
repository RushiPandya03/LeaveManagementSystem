using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserENT
/// </summary>
public class UserENT
{
    #region Constructor
    public UserENT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor
    
    #region UserID
    protected SqlInt32 _UserID;

    public SqlInt32 UserID
    {
        get
        {
            return _UserID;
        }
        set
        {
            _UserID = value;
        }
    }
    #endregion UserID

    #region Usercount
    protected SqlInt32 _Usercount;

    public SqlInt32 Usercount
    {
        get
        {
            return _Usercount;
        }
        set
        {
            _Usercount = value;
        }
    }
    #endregion Usercount

    #region UserName
    protected SqlString _UserName;

    public SqlString UserName
    {
        get
        {
            return _UserName;
        }
        set
        {
            _UserName = value;
        }
    }
    #endregion UserName

    #region Password
    protected SqlString _Password;

    public SqlString Password
    {
        get
        {
            return _Password;
        }
        set
        {
            _Password = value;
        }
    }
    #endregion Password

    #region DisplayName
    protected SqlString _DisplayName;

    public SqlString DisplayName
    {
        get
        {
            return _DisplayName;
        }
        set
        {
            _DisplayName = value;
        }
    }
    #endregion DisplayName

    #region MobileNo
    protected SqlString _MobileNo;

    public SqlString MobileNo
    {
        get
        {
            return _MobileNo;
        }
        set
        {
            _MobileNo = value;
        }
    }
    #endregion MobileNo

    #region DOB
    protected SqlString _DOB;

    public SqlString DOB
    {
        get
        {
            return _DOB;
        }
        set
        {
            _DOB = value;
        }
    }
    #endregion DOB

    #region Gender
    protected SqlString _Gender;

    public SqlString Gender
    {
        get
        {
            return _Gender;
        }
        set
        {
            _Gender = value;
        }
    }
    #endregion Gender

    #region City
    protected SqlString _City;

    public SqlString City
    {
        get
        {
            return _City;
        }
        set
        {
            _City = value;
        }
    }
    #endregion City

    #region Experience
    protected SqlString _Experience;

    public SqlString Experience
    {
        get
        {
            return _Experience;
        }
        set
        {
            _Experience = value;
        }
    }
    #endregion Experience

    #region Qualification
    protected SqlString _Qualification;

    public SqlString Qualification
    {
        get
        {
            return _Qualification;
        }
        set
        {
            _Qualification = value;
        }
    }
    #endregion Qualification

    #region Email
    protected SqlString _Email;

    public SqlString Email
    {
        get
        {
            return _Email;
        }
        set
        {
            _Email = value;
        }
    }
    #endregion Email

    #region InstituteID
    protected SqlInt32 _InstituteID;

    public SqlInt32 InstituteID
    {
        get
        {
            return _InstituteID;
        }
        set
        {
            _InstituteID = value;
        }
    }
    #endregion InstituteID
    
    #region InstituteName
    protected SqlString _InstituteName;

    public SqlString InstituteName
    {
        get
        {
            return _InstituteName;
        }
        set
        {
            _InstituteName = value;
        }
    }
    #endregion InstituteName

    #region DesignationID
    protected SqlInt32 _DesignationID;

    public SqlInt32 DesignationID
    {
        get
        {
            return _DesignationID;
        }
        set
        {
            _DesignationID = value;
        }
    }
    #endregion DesignationID

    #region DesignationName
    protected SqlString _DesignationName;

    public SqlString DesignationName
    {
        get
        {
            return _DesignationName;
        }
        set
        {
            _DesignationName = value;
        }
    }
    #endregion DesignationName

    #region DepartmentID
    protected SqlInt32 _DepartmentID;

    public SqlInt32 DepartmentID
    {
        get
        {
            return _DepartmentID;
        }
        set
        {
            _DepartmentID = value;
        }
    }
    #endregion DepartmentID

    #region DepartmentName
    protected SqlString _DepartmentName;

    public SqlString DepartmentName
    {
        get
        {
            return _DepartmentName;
        }
        set
        {
            _DepartmentName = value;
        }
    }
    #endregion DepartmentName

    #region PhotoPath
    protected SqlString _PhotoPath;

    public SqlString PhotoPath
    {
        get
        {
            return _PhotoPath;
        }
        set
        {
            _PhotoPath = value;
        }
    }
    #endregion PhotoPath
}