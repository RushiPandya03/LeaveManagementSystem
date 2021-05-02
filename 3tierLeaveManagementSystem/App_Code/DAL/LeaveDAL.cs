using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveDAL
/// </summary>
/// 
namespace LeaveManagementSystem.DAL
{
    public class LeaveDAL : DatabaseConfig
    {
        #region Constructor
        public LeaveDAL()
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
        public Boolean Insert(LeaveENT entLeave, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Leave_InsertByUserID";

                        objCmd.Parameters.Add("@LeaveID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Value = entLeave.LeaveTypeID;
                        objCmd.Parameters.Add("@LeaveReason", SqlDbType.VarChar).Value = entLeave.LeaveReason;
                        objCmd.Parameters.Add("@LeaveStartDate", SqlDbType.VarChar).Value = entLeave.LeaveStartDate;
                        objCmd.Parameters.Add("@LeaveEndDate", SqlDbType.VarChar).Value = entLeave.LeaveEndDate;
                        objCmd.Parameters.Add("@LeaveDuration", SqlDbType.VarChar).Value = entLeave.LeaveDuration;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@LeaveID"] != null)
                            entLeave.LeaveID = Convert.ToInt32(objCmd.Parameters["@LeaveID"].Value);
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
        #region Update 
        public Boolean Update(LeaveENT entLeave, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Leave_UpdateByPKUserID";

                        objCmd.Parameters.Add("@LeaveID", SqlDbType.Int).Value = entLeave.LeaveID;
                        objCmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Value = entLeave.LeaveTypeID;
                        objCmd.Parameters.Add("@LeaveReason", SqlDbType.VarChar).Value = entLeave.LeaveReason;
                        objCmd.Parameters.Add("@LeaveStartDate", SqlDbType.VarChar).Value = entLeave.LeaveStartDate;
                        objCmd.Parameters.Add("@LeaveEndDate", SqlDbType.VarChar).Value = entLeave.LeaveEndDate;
                        objCmd.Parameters.Add("@LeaveDuration", SqlDbType.VarChar).Value = entLeave.LeaveDuration;
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
        #endregion Update 

        #region Update UpdateLeaveStatusInLeave
        public Boolean UpdateLeaveStatusInLeave(LeaveENT entLeave, SqlInt32 LeaveID)
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
                        objCmd.CommandText = "PR_Leave_UpdateLeaveStatusByPK";

                        objCmd.Parameters.Add("@LeaveResponseBy", SqlDbType.VarChar).Value = entLeave.LeaveResponseBy;
                        objCmd.Parameters.Add("@LeaveStatus", SqlDbType.VarChar).Value = entLeave.LeaveStatus;
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
        #endregion Update UpdateLeaveStatusInLeave
        #endregion Update Operation

        #region Delete operation
        #region DeleteByLeaveIDUserID
        public Boolean Delete(SqlInt32 LeaveID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Leave_DeleteByPKUserID";
                        objCmd.Parameters.Add("@LeaveID", SqlDbType.Int).Value = LeaveID;
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
        #endregion DeleteByLeaveIDUserID

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
                        objCmd.CommandText = "PR_Leave_DeleteAllByUserID";
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
        #endregion Delete operation

        #region Select Operation

        #region SelectAllByUserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Leave_SelectAllbyUserID";

                        objCmd.Parameters.Add("@UserID",SqlDbType.Int).Value = UserID;
                        
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
        #endregion SelectAllByUserID

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
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
                        objCmd.CommandText = "PR_Leave_SelectForDropDownList";
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
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
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
        #endregion SelectForDropDownList

        #region SelectByPK
        public LeaveENT SelectByPK(SqlInt32 LeaveID,SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Leave_SelectByPKUserID";
                        objCmd.Parameters.Add("@LeaveID", SqlDbType.Int).Value = LeaveID;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        LeaveENT entLeave = new LeaveENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["LeaveID"].Equals(DBNull.Value))
                                    entLeave.LeaveID = Convert.ToInt32(objSDR["LeaveID"]);

                                if (!objSDR["LeaveTypeID"].Equals(DBNull.Value))
                                    entLeave.LeaveTypeID = Convert.ToInt32(objSDR["LeaveTypeID"]);

                                if (!objSDR["LeaveReason"].Equals(DBNull.Value))
                                    entLeave.LeaveReason = Convert.ToString(objSDR["LeaveReason"]);

                                if (!objSDR["LeaveDuration"].Equals(DBNull.Value))
                                    entLeave.LeaveDuration = Convert.ToString(objSDR["LeaveDuration"]);

                                if (!objSDR["LeaveEndDate"].Equals(DBNull.Value))
                                    entLeave.LeaveEndDate = Convert.ToString(objSDR["LeaveEndDate"]);

                                if (!objSDR["LeaveStartDate"].Equals(DBNull.Value))
                                    entLeave.LeaveStartDate = Convert.ToString(objSDR["LeaveStartDate"]);
                            }
                        }
                        return entLeave;
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
        #endregion SelectByPK
        
        #region SelectLeaveStatusByPK
        public LeaveENT SelectLeaveStatusByPK(SqlInt32 LeaveID)
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
                        objCmd.CommandText = "PR_Leave_SelectLeaveStatusLeaveTypeIDByPK";
                        objCmd.Parameters.Add("@LeaveID", SqlDbType.Int).Value = LeaveID;
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        LeaveENT entLeave = new LeaveENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["LeaveResponseBy"].Equals(DBNull.Value))
                                    entLeave.LeaveResponseBy = Convert.ToString(objSDR["LeaveResponseBy"]);

                                if (!objSDR["LeaveStatus"].Equals(DBNull.Value))
                                    entLeave.LeaveStatus = Convert.ToString(objSDR["LeaveStatus"]);

                                if (!objSDR["LeaveTypeID"].Equals(DBNull.Value))
                                    entLeave.LeaveTypeID = Convert.ToInt32(objSDR["LeaveTypeID"]);
                            }
                        }
                        return entLeave;
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
        #endregion SelectLeaveStatusByPK

        #region SelectTotalDaysByLeaveTypeIDUserID
        public LeaveENT SelectTotalDaysByLeaveTypeIDUserID(SqlInt32 LeaveTypeID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Leave_SelectLeaveTotalDaysByLeaveTypeIDUserID";
                        objCmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Value = LeaveTypeID;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        LeaveENT entLeave = new LeaveENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["TotalDays"].Equals(DBNull.Value))
                                    entLeave.TotalDays = Convert.ToInt32(objSDR["TotalDays"]);
                            }
                        }
                        return entLeave;
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
        #endregion SelectTotalDaysByLeaveTypeIDUserID

        #endregion Select Operation
    }
}
