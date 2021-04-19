using LeaveManagementSystem.DAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DesignationBAL
/// </summary>
/// 
namespace LeaveManagementSystem.BAL
{
    public class DesignationBAL
    {
        #region Constructor
        public DesignationBAL()
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
        public Boolean Insert(DesignationENT entDesignation)
        {
            DesignationDAL dalDesignation = new DesignationDAL();

            if (dalDesignation.Insert(entDesignation))
            {
                return true;
            }
            else
            {
                Message = dalDesignation.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(DesignationENT entDesignation)
        {
            DesignationDAL dalDesignation = new DesignationDAL();

            if (dalDesignation.Update(entDesignation))
            {
                return true;
            }
            else
            {
                Message = dalDesignation.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 DesignationID)
        {
            DesignationDAL dalDesignation = new DesignationDAL();

            if (dalDesignation.Delete(DesignationID))
            {
                return true;
            }
            else
            {
                Message = dalDesignation.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            DesignationDAL dalDesignation = new DesignationDAL();
            return dalDesignation.SelectAll();
        }

        #endregion SelectAll Operation

        #region SelectForDropDownList Operation
        public DataTable SelectForDropDownList()
        {
            DesignationDAL dalDesignation = new DesignationDAL();
            return dalDesignation.SelectForDropDownList();
        }
        #endregion SelectForDropDownList Operation

        #region SelectWithoutHODForDropDownList 
        public DataTable SelectWithoutHODForDropDownList()
        {
            DesignationDAL dalDesignation = new DesignationDAL();
            return dalDesignation.SelectWithoutHODForDropDownList();
        }
        #endregion SelectWithoutHODForDropDownList 

        #region SelectByPK Operation
        public DesignationENT SelectByPK(SqlInt32 DesignationID)
        {
            DesignationDAL dalDesignation = new DesignationDAL();
            return dalDesignation.SelectByPK(DesignationID);
        }
        #endregion SelectByPK Operation

        #endregion Select Operation
    }
}
