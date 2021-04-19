using LeaveManagementSystem;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveStatusDAL
/// </summary>
/// 
namespace LeaveManagementSystem.DAL
{
    public class LeaveStatusDAL : DatabaseConfig
    {
        #region Constructor
        public LeaveStatusDAL()
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
        public Boolean Insert(LeaveStatusENT entLeaveStatus, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LeaveStatus_InsertByUserID";

                        objCmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Value = entLeaveStatus.LeaveTypeID;
                        objCmd.Parameters.Add("@LeaveID", SqlDbType.Int).Value = entLeaveStatus.LeaveID;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean UpdateLeaveStatus(LeaveStatusENT entLeaveStatus)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LeaveStatus_UpdateByLeaveID";

                        objCmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Value = entLeaveStatus.LeaveTypeID;
                        objCmd.Parameters.Add("@LeaveID", SqlDbType.Int).Value = entLeaveStatus.LeaveID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion Update Operation

        #region Delete Operation

        #region DeleteByPK
        public Boolean Delete(SqlInt32 LeaveID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LeaveStatus_DeleteByLeaveID";
                        objCmd.Parameters.Add("@LeaveID", SqlDbType.Int).Value = LeaveID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion DeleteByPK
        
        #region DeleteAll
        public Boolean DeleteAll(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LeaveStatus_DeleteAllByUserID";
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion DeleteAll

        #endregion Delete Operation
        
        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LeaveStatus_SelectAll";

                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion Read Data and Set Controls
                    }
                    catch (SqlException ex)
                    {
                        Message = ex.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion SelectAll
    }
}