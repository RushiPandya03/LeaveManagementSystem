using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InstituteENT
/// </summary>
/// 
namespace LeaveManagementSystem.ENT
{
    public class InstituteENT
    {
        #region Constructor
        public InstituteENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region InstituteID
        protected SqlInt32 _InstituteID;

        public SqlInt32 InstituteID
        {
            get
            {
                return _InstituteID;
            }
            set
            {
                _InstituteID = value;
            }
        }
        #endregion InstituteID

        #region InstituteName
        protected SqlString _InstituteName;

        public SqlString InstituteName
        {
            get
            {
                return _InstituteName;
            }
            set
            {
                _InstituteName = value;
            }
        }
        #endregion InstituteName
    }
}