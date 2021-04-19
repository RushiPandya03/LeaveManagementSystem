using LeaveManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBAL
/// </summary>
/// 
namespace LeaveManagementSystem.BAL
{
    public class UserBAL
    {
        #region Constructor
        public UserBAL()
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
        public Boolean Insert(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.Insert(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.Update(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.Delete(UserID))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectAll();
        }

        #endregion SelectAll Operation

        #region SelectUserCount Operation

        public UserENT SelectUserCount()
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectUserCount();
        }

        #endregion SelectUserCount Operation

        #region SelectForDropDownList Operation
        public DataTable SelectForDropDownList()
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectForDropDownList();
        }
        #endregion SelectForDropDownList Operation

        #region SelectByPK Operation
        public UserENT SelectByPK(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByPK(UserID);
        }
        #endregion SelectByPK Operation

        #region SelectByUserNamePassword Operation
        public UserENT SelectByUserNamePassword(SqlString UserName,SqlString Password)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByUserNamePassword(UserName, Password);
        }
        #endregion SelectByUserNamePassword Operation

        #region SelectUserNameByPK Operation
        public UserENT SelectUserName(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectUserName(UserID);
        }
        #endregion SelectUserNameByPK Operation

        #endregion Select Operation
    }
}
