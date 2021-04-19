using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConfig
/// </summary>
/// 
namespace LeaveManagementSystem
{
    public class DatabaseConfig
    {
        #region Constuctor
        public DatabaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constuctor

        #region ConnectionString
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["LeaveManagementSystemConectionString"].ConnectionString;
        #endregion ConnectionString
    }
}
