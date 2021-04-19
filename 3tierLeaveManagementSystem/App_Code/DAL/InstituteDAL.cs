using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InstituteDAL
/// </summary>
/// 
namespace LeaveManagementSystem.DAL
{
    public class InstituteDAL : DatabaseConfig
    {
        #region Constructor
        public InstituteDAL()
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
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Institute_Insert";

                        objCmd.Parameters.Add("@InstituteID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@InstituteName", SqlDbType.VarChar).Value = entInstitute.InstituteName;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@InstituteID"] != null)
                            entInstitute.InstituteID = Convert.ToInt32(objCmd.Parameters["@InstituteID"].Value);
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
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(InstituteENT entInstitute)
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
                        objCmd.CommandText = "PR_Institute_UpdateByPK";

                        objCmd.Parameters.Add("@InstituteID", SqlDbType.Int).Value = entInstitute.InstituteID;
                        objCmd.Parameters.Add("@InstituteName", SqlDbType.VarChar).Value = entInstitute.InstituteName;
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
        public Boolean Delete(SqlInt32 InstituteID)
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
                        objCmd.CommandText = "PR_Institute_DeleteByPK";
                        objCmd.Parameters.Add("@InstituteID", SqlDbType.Int).Value = InstituteID;
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
                        objCmd.CommandText = "PR_Institute_SelectAll";
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
                        objCmd.CommandText = "PR_Institute_SelectForDropDownList";
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
        public InstituteENT SelectByPK(SqlInt32 InstituteID)
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
                        objCmd.CommandText = "PR_Institute_SelectByPK";
                        objCmd.Parameters.Add("@InstituteID", SqlDbType.Int).Value = InstituteID;
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        InstituteENT entInstitute = new InstituteENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["InstituteID"].Equals(DBNull.Value))
                                    entInstitute.InstituteID = Convert.ToInt32(objSDR["InstituteID"]);

                                if (!objSDR["InstituteName"].Equals(DBNull.Value))
                                    entInstitute.InstituteName = Convert.ToString(objSDR["InstituteName"]);
                            }
                        }
                        return entInstitute;
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

        #endregion Select Operation
    }
}
