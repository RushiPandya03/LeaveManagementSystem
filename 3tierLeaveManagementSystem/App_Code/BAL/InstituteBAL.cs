using LeaveManagementSystem.DAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InstituteBAL
/// </summary>
/// 
namespace LeaveManagementSystem.BAL
{
    public class InstituteBAL
    {
        #region Constructor
        public InstituteBAL()
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
        public Boolean Insert(InstituteENT entInstitute)
        {
            InstituteDAL dalInstitute = new InstituteDAL();

            if (dalInstitute.Insert(entInstitute))
            {
                return true;
            }
            else
            {
                Message = dalInstitute.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(InstituteENT entInstitute)
        {
            InstituteDAL dalInstitute = new InstituteDAL();

            if (dalInstitute.Update(entInstitute))
            {
                return true;
            }
            else
            {
                Message = dalInstitute.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 InstituteID)
        {
            InstituteDAL dalInstitute = new InstituteDAL();

            if (dalInstitute.Delete(InstituteID))
            {
                return true;
            }
            else
            {
                Message = dalInstitute.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            InstituteDAL dalInstitute = new InstituteDAL();
            return dalInstitute.SelectAll();
        }

        #endregion SelectAll Operation

        #region SelectForDropDownList Operation
        public DataTable SelectForDropDownList()
        {
            InstituteDAL dalInstitute = new InstituteDAL();
            return dalInstitute.SelectForDropDownList();
        }
        #endregion SelectForDropDownList Operation

        #region SelectByPK Operation
        public InstituteENT SelectByPK(SqlInt32 InstituteID)
        {
            InstituteDAL dalInstitute = new InstituteDAL();
            return dalInstitute.SelectByPK(InstituteID);
        }
        #endregion SelectByPK Operation

        #endregion Select Operation
    }
}
