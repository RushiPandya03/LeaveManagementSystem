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
    public class LeaveBAL
    {
        #region Constructor
        public LeaveBAL()
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
        public Boolean Insert(LeaveENT entLeave,SqlInt32 UserID)
        {
            LeaveDAL dalLeave = new LeaveDAL();

            if (dalLeave.Insert(entLeave,UserID))
            {
                return true;
            }
            else
            {
                Message = dalLeave.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        #region Update 
        public Boolean Update(LeaveENT entLeave, SqlInt32 UserID)
        {
            LeaveDAL dalLeave = new LeaveDAL();

            if (dalLeave.Update(entLeave,UserID))
            {
                return true;
            }
            else
            {
                Message = dalLeave.Message;
                return false;
            }
        }
        #endregion Update 

        #region UpdateLeaveStatusInLeave
        public Boolean UpdateLeaveStatusInLeave(LeaveENT entLeave, SqlInt32 LeaveID)
        {
            LeaveDAL dalLeave = new LeaveDAL();

            if (dalLeave.UpdateLeaveStatusInLeave(entLeave, LeaveID))
            {
                return true;
            }
            else
            {
                Message = dalLeave.Message;
                return false;
            }
        }
        #endregion UpdateLeaveStatusInLeave
        #endregion Update Operation

        #region Delete Operation
        #region DeleteByLeaveIDUserID
        public Boolean Delete(SqlInt32 LeaveID, SqlInt32 UserID)
        {
            LeaveDAL dalLeave = new LeaveDAL();

            if (dalLeave.Delete(LeaveID,UserID))
            {
                return true;
            }
            else
            {
                Message = dalLeave.Message;
                return false;
            }
        }
        #endregion DeleteByLeaveIDUserID

        #region DeleteAll
        public Boolean DeleteAll(SqlInt32 UserID)
        {
            LeaveDAL dalLeave = new LeaveDAL();

            if (dalLeave.DeleteAll(UserID))
            {
                return true;
            }
            else
            {
                Message = dalLeave.Message;
                return false;
            }
        }
        #endregion DeleteAll
        #endregion Delete Operation

        #region Select Operation

        #region SelectAllByUserID Operation

        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            LeaveDAL dalLeave = new LeaveDAL();
            DataTable dt = new DataTable();
            dt = dalLeave.SelectAllByUserID(UserID);
            if (dt == null)
            {
                Message = dalLeave.Message;
                return null;
            }
            else
            {
                return dt;
            }   
        }

        #endregion SelectAllByUserID Operation
        
        #region SelectForDropDownList Operation
        public DataTable SelectForDropDownList()
        {
            LeaveDAL dalLeave = new LeaveDAL();
            return dalLeave.SelectForDropDownList();
        }
        #endregion SelectForDropDownList Operation

        #region SelectByPK Operation
        public LeaveENT SelectByPK(SqlInt32 LeaveID,SqlInt32 UserID)
        {
            LeaveDAL dalLeave = new LeaveDAL();
            return dalLeave.SelectByPK(LeaveID,UserID);
        }
        #endregion SelectByPK Operation

        #region SelectLeaveStatusByPK Operation
        public LeaveENT SelectLeaveStatusByPK(SqlInt32 LeaveID)
        {
            LeaveDAL dalLeave = new LeaveDAL();
            return dalLeave.SelectLeaveStatusByPK(LeaveID);
        }
        #endregion SelectLeaveStatusByPK Operation

        #endregion Select Operation
    }
}
