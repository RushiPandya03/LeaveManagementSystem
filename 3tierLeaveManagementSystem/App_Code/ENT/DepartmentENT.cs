using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentENT
/// </summary>
/// 
namespace LeaveManagementSystem.ENT
{
    public class DepartmentENT
    {
        #region Constructor
        public DepartmentENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region DepartmentID
        protected SqlInt32 _DepartmentID;

        public SqlInt32 DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                _DepartmentID = value;
            }
        }
        #endregion DepartmentID

        #region DepartmentName
        protected SqlString _DepartmentName;

        public SqlString DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }
        #endregion DepartmentName
    }
}