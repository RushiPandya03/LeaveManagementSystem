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
    public class LeaveENT
    {
        #region Constructor
        public LeaveENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

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

        #region LeaveReason
        protected SqlString _LeaveReason;

        public SqlString LeaveReason
        {
            get
            {
                return _LeaveReason;
            }
            set
            {
                _LeaveReason = value;
            }
        }
        #endregion LeaveReason

        #region LeaveStartDate
        protected SqlString _LeaveStartDate;

        public SqlString LeaveStartDate
        {
            get
            {
                return _LeaveStartDate;
            }
            set
            {
                _LeaveStartDate = value;
            }
        }
        #endregion LeaveStartDate

        #region LeaveEndDate
        protected SqlString _LeaveEndDate;

        public SqlString LeaveEndDate
        {
            get
            {
                return _LeaveEndDate;
            }
            set
            {
                _LeaveEndDate = value;
            }
        }
        #endregion LeaveEndDate

        #region LeaveDuration
        protected SqlString _LeaveDuration;

        public SqlString LeaveDuration
        {
            get
            {
                return _LeaveDuration;
            }
            set
            {
                _LeaveDuration = value;
            }
        }
        #endregion LeaveDuration

        #region LeaveStatus
        protected SqlString _LeaveStatus;

        public SqlString LeaveStatus
        {
            get
            {
                return _LeaveStatus;
            }
            set
            {
                _LeaveStatus = value;
            }
        }
        #endregion LeaveStatus

        #region LeaveResponseBy
        protected SqlString _LeaveResponseBy;

        public SqlString LeaveResponseBy
        {
            get
            {
                return _LeaveResponseBy;
            }
            set
            {
                _LeaveResponseBy = value;
            }
        }
        #endregion LeaveResponseBy

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