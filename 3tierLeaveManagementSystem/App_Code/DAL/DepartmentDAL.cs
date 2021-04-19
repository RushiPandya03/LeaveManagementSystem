using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentDAL
/// </summary>
/// 
namespace LeaveManagementSystem.DAL
{
    public class DepartmentDAL : DatabaseConfig
    {
        #region Constructor
        public DepartmentDAL()
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
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Department_Insert";

                        objCmd.Parameters.Add("@DepartmentID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@DepartmentName", SqlDbType.VarChar).Value = entDepartment.DepartmentName;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@DepartmentID"] != null)
                            entDepartment.DepartmentID = Convert.ToInt32(objCmd.Parameters["@DepartmentID"].Value);
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
        public Boolean Update(DepartmentENT entDepartment)
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
                        objCmd.CommandText = "PR_Department_UpdateByPK";

                        objCmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = entDepartment.DepartmentID;
                        objCmd.Parameters.Add("@DepartmentName", SqlDbType.VarChar).Value = entDepartment.DepartmentName;
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
        public Boolean Delete(SqlInt32 DepartmentID)
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
                        objCmd.CommandText = "PR_Department_DeleteByPK";
                        objCmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
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
                        objCmd.CommandText = "PR_Department_SelectAll";
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
                        objCmd.CommandText = "PR_Department_SelectForDropDownList";
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
        public DepartmentENT SelectByPK(SqlInt32 DepartmentID)
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
                        objCmd.CommandText = "PR_Department_SelectByPK";
                        objCmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        DepartmentENT entDepartment = new DepartmentENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["DepartmentID"].Equals(DBNull.Value))
                                    entDepartment.DepartmentID = Convert.ToInt32(objSDR["DepartmentID"]);

                                if (!objSDR["DepartmentName"].Equals(DBNull.Value))
                                    entDepartment.DepartmentName = Convert.ToString(objSDR["DepartmentName"]);
                            }
                        }
                        return entDepartment;
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

        #endregion Select Operation
    }
}
