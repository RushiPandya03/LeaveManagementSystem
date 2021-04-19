using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DesignationENT
/// </summary>
/// 
namespace LeaveManagementSystem.ENT
{
    public class DesignationENT
    {
        #region Constructor
        public DesignationENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region DesignationID
        protected SqlInt32 _DesignationID;

        public SqlInt32 DesignationID
        {
            get
            {
                return _DesignationID;
            }
            set
            {
                _DesignationID = value;
            }
        }
        #endregion DesignationID

        #region DesignationName
        protected SqlString _DesignationName;

        public SqlString DesignationName
        {
            get
            {
                return _DesignationName;
            }
            set
            {
                _DesignationName = value;
            }
        }
        #endregion DesignationName
    }
}