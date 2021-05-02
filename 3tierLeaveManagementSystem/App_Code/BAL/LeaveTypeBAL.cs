using LeaveManagementSystem.DAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveTypeBAL
/// </summary>
/// 
namespace LeaveManagementSystem.BAL
{
    public class LeaveTypeBAL
    {
        #region Constructor
        public LeaveTypeBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Local variables
        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion Local variables

        #region Insert Operation
        public Boolean Insert(LeaveTypeENT entLeaveType)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();

            if (dalLeaveType.Insert(entLeaveType))
            {
                return true;
            }
            else
            {
                Message = dalLeaveType.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation

        #region UpdateTotalDaysByLeaveType Operation
        public Boolean UpdateTotalDaysByLeaveType(LeaveTypeENT entLeaveType)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();

            if (dalLeaveType.UpdateTotalDaysByLeaveType(entLeaveType))
            {
                return true;
            }
            else
            {
                Message = dalLeaveType.Message;
                return false;
            }
        }
        #endregion UpdateTotalDaysByLeaveType Operation

        #region Update Operation
        public Boolean Update(LeaveTypeENT entLeaveType)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();

            if (dalLeaveType.Update(entLeaveType))
            {
                return true;
            }
            else
            {
                Message = dalLeaveType.Message;
                return false;
            }
        }
        #endregion Update Operation

        #endregion Update Operation

        #region Delete Operation

        #region DeleteAllByUserID Operation
        public Boolean DeleteAllByUserID(SqlInt32 UserID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();

            if (dalLeaveType.DeleteAllByUserID(UserID))
            {
                return true;
            }
            else
            {
                Message = dalLeaveType.Message;
                return false;
            }
        }
        #endregion DeleteAllByUserID Operation

        #region DeleteByPK Operation
        public Boolean Delete(SqlInt32 LeaveTypeID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();

            if (dalLeaveType.Delete(LeaveTypeID))
            {
                return true;
            }
            else
            {
                Message = dalLeaveType.Message;
                return false;
            }
        }
        #endregion DeleteByPK Operation

        #endregion Delete Operation

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            return dalLeaveType.SelectAll();
        }

        #endregion SelectAll Operation

        #region SelectByUserID Operation

        public DataTable SelectByUserID(SqlInt32 UserID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            return dalLeaveType.SelectByUserID(UserID);
        }

        #endregion SelectAll Operation

        #region SelectForDropDownList Operation
        public DataTable SelectForDropDownListByUserID(SqlInt32 UserID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            return dalLeaveType.SelectForDropDownListByUserID(UserID);
        }
        #endregion SelectForDropDownList Operation

        #region SelectByPK Operation
        public LeaveTypeENT SelectByPK(SqlInt32 LeaveTypeID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            return dalLeaveType.SelectByPK(LeaveTypeID);
        }
        #endregion SelectByPK Operation

        #endregion Select Operation
    }
}
