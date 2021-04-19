using LeaveManagementSystem.DAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveBAL
/// </summary>
/// 
namespace LeaveManagementSystem.BAL
{
    public class LeaveStatusBAL
    {
        #region Constructor
        public LeaveStatusBAL()
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
        public Boolean Insert(LeaveStatusENT entLeave, SqlInt32 UserID)
        {
            LeaveStatusDAL dalLeaveStatus = new LeaveStatusDAL();

            if (dalLeaveStatus.Insert(entLeave, UserID))
            {
                return true;
            }
            else
            {
                Message = dalLeaveStatus.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean UpdateLeaveStatus(LeaveStatusENT entLeaveStatus)
        {
            LeaveStatusDAL dalLeaveStatus = new LeaveStatusDAL();

            if (dalLeaveStatus.UpdateLeaveStatus(entLeaveStatus))
            {
                return true;
            }
            else
            {
                Message = dalLeaveStatus.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation

        #region DeleteByPK
        public Boolean Delete(SqlInt32 LeaveID)
        {
            LeaveStatusDAL dalLeaveStatus = new LeaveStatusDAL();

            if (dalLeaveStatus.Delete(LeaveID))
            {
                return true;
            }
            else
            {
                Message = dalLeaveStatus.Message;
                return false;
            }
        }
        #endregion DeleteByPK

        #region DeleteAll
        public Boolean DeleteAll(SqlInt32 UserID)
        {
            LeaveStatusDAL dalLeaveStatus = new LeaveStatusDAL();

            if (dalLeaveStatus.DeleteAll(UserID))
            {
                return true;
            }
            else
            {
                Message = dalLeaveStatus.Message;
                return false;
            }
        }
        #endregion DeleteAll
        #endregion Delete Operation
        
        #region SelectAll Operation

        public DataTable SelectAll()
        {
            LeaveStatusDAL dalLeaveStatus = new LeaveStatusDAL();
            DataTable dt = new DataTable();
            dt = dalLeaveStatus.SelectAll();
            if (dt == null)
            {
                Message = dalLeaveStatus.Message;
                return null;
            }
            else
            {
                return dt;
            }
        }

        #endregion SelectAll Operation
    }
}
