using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveENT
/// </summary>
/// 
namespace LeaveManagementSystem.ENT
{
    public class LeaveStatusENT
    {
        #region Constructor
        public LeaveStatusENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region LeaveStatusID
        protected SqlInt32 _LeaveStatusID;

        public SqlInt32 LeaveStatusID
        {
            get
            {
                return _LeaveStatusID;
            }
            set
            {
                _LeaveStatusID = value;
            }
        }
        #endregion LeaveStatusID

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

        #region LeaveID
        protected SqlInt32 _LeaveID;

        public SqlInt32 LeaveID
        {
            get
            {
                return _LeaveID;
            }
            set
            {
                _LeaveID = value;
            }
        }
        #endregion LeaveID

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
}