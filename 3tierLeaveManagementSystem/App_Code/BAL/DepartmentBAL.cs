using LeaveManagementSystem.DAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentBAL
/// </summary>
/// 
namespace LeaveManagementSystem.BAL
{
    public class DepartmentBAL
    {
        #region Constructor
        public DepartmentBAL()
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
        public Boolean Insert(DepartmentENT entDepartment)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();

            if (dalDepartment.Insert(entDepartment))
            {
                return true;
            }
            else
            {
                Message = dalDepartment.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(DepartmentENT entDepartment)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();

            if (dalDepartment.Update(entDepartment))
            {
                return true;
            }
            else
            {
                Message = dalDepartment.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 DepartmentID)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();

            if (dalDepartment.Delete(DepartmentID))
            {
                return true;
            }
            else
            {
                Message = dalDepartment.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            return dalDepartment.SelectAll();
        }

        #endregion SelectAll Operation

        #region SelectForDropDownList Operation
        public DataTable SelectForDropDownList()
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            return dalDepartment.SelectForDropDownList();
        }
        #endregion SelectForDropDownList Operation

        #region SelectByPK Operation
        public DepartmentENT SelectByPK(SqlInt32 DepartmentID)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            return dalDepartment.SelectByPK(DepartmentID);
        }
        #endregion SelectByPK Operation

        #endregion Select Operation
    }
}
