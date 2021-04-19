using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HolidayDAL
/// </summary>
/// 
namespace LeaveManagementSystem.DAL
{
    public class HolidayDAL : DatabaseConfig
    {
        #region Constructor
        public HolidayDAL()
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
        public Boolean Insert(HolidayENT entHoliday)
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
                        objCmd.CommandText = "PR_Holiday_Insert";
                        
                        objCmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = entHoliday.Name;
                        objCmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = entHoliday.Date;
                        objCmd.Parameters.Add("@Day", SqlDbType.VarChar).Value = entHoliday.Day;
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
        public Boolean Update(HolidayENT entHoliday)
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
                        objCmd.CommandText = "PR_Holiday_UpdateByPK";

                        objCmd.Parameters.Add("@HolidayID", SqlDbType.Int).Value = entHoliday.HolidayID;
                        objCmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = entHoliday.Name;
                        objCmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = entHoliday.Date;
                        objCmd.Parameters.Add("@Day", SqlDbType.VarChar).Value = entHoliday.Day;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
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
        public Boolean Delete(SqlInt32 HolidayID)
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
                        objCmd.CommandText = "PR_Holiday_DeleteByPK";
                        objCmd.Parameters.Add("@HolidayID", SqlDbType.Int).Value = HolidayID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
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
        #endregion Delete Operation

        #region Select Operation

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
                        objCmd.CommandText = "PR_Holiday_SelectAll";
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
        #endregion SelectAll

        #region SelectHolidayDate
        public DataTable SelectHolidayDate()
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
                        objCmd.CommandText = "PR_Holiday_SelectHolidayDate";
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
        #endregion SelectHolidayDate

        #region SelectByPK
        public HolidayENT SelectByPK(SqlInt32 HolidayID)
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
                        objCmd.CommandText = "PR_Holiday_SelectByPK";
                        objCmd.Parameters.Add("@HolidayID", SqlDbType.Int).Value = HolidayID;
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        HolidayENT entHoliday = new HolidayENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["HolidayID"].Equals(DBNull.Value))
                                    entHoliday.HolidayID = Convert.ToInt32(objSDR["HolidayID"]);

                                if (!objSDR["Name"].Equals(DBNull.Value))
                                    entHoliday.Name = Convert.ToString(objSDR["Name"]);

                                if (!objSDR["Day"].Equals(DBNull.Value))
                                    entHoliday.Day = Convert.ToString(objSDR["Day"]);

                                if (!objSDR["Date"].Equals(DBNull.Value))
                                    entHoliday.Date = Convert.ToString(objSDR["Date"]);
                            }
                        }
                        return entHoliday;
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
        #endregion SelectByPK

        #region SelectByHolidayDate
        public HolidayENT SelectByHolidayDate(SqlString Date)
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
                        objCmd.CommandText = "PR_Holiday_SelectByHolidayDate";
                        objCmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = Date;
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        HolidayENT entHoliday = new HolidayENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["Name"].Equals(DBNull.Value))
                                    entHoliday.Name = Convert.ToString(objSDR["Name"]);

                                if (!objSDR["Day"].Equals(DBNull.Value))
                                    entHoliday.Day = Convert.ToString(objSDR["Day"]);

                                if (!objSDR["Date"].Equals(DBNull.Value))
                                    entHoliday.Date = Convert.ToString(objSDR["Date"]);
                            }
                        }
                        return entHoliday;
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
        #endregion SelectByHolidayDate

        #endregion Select Operation
    }
}