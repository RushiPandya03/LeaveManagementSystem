using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveTypeENT
/// </summary>
public class LeaveTypeENT
{
    #region Constructor
    public LeaveTypeENT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    #region LeaveTypeID
    protected SqlInt32 _LeaveTypeID;

    public SqlInt32 LeaveTypeID
    {
        get
        {
            return _LeaveTypeID;
        }
        set
        {
            _LeaveTypeID = value;
        }
    }
    #endregion LeaveTypeID

    #region LeaveType
    protected SqlString _LeaveType;

    public SqlString LeaveType
    {
        get
        {
            return _LeaveType;
        }
        set
        {
            _LeaveType = value;
        }
    }
    #endregion LeaveType
    
    #region TotalDays
    protected SqlInt32 _TotalDays;

    public SqlInt32 TotalDays
    {
        get
        {
            return _TotalDays;
        }
        set
        {
            _TotalDays = value;
        }
    }
    #endregion TotalDays

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
}