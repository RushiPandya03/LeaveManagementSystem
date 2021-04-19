using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HolidayENT
/// </summary>
public class HolidayENT
{
    #region Constructor
    public HolidayENT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    #region HolidayID
    protected SqlInt32 _HolidayID;

    public SqlInt32 HolidayID
    {
        get
        {
            return _HolidayID;
        }
        set
        {
            _HolidayID = value;
        }
    }
    #endregion HolidayID

    #region Name
    protected SqlString _Name;

    public SqlString Name
    {
        get
        {
            return _Name;
        }
        set
        {
            _Name = value;
        }
    }
    #endregion Name

    #region Day
    protected SqlString _Day;

    public SqlString Day
    {
        get
        {
            return _Day;
        }
        set
        {
            _Day = value;
        }
    }
    #endregion Day

    #region Date
    protected SqlString _Date;

    public SqlString Date
    {
        get
        {
            return _Date;
        }
        set
        {
            _Date = value;
        }
    }
    #endregion Date
}