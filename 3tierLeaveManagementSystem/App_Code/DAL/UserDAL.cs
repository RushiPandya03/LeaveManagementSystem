using LeaveManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDAL
/// </summary>
/// 
namespace LeaveManagementSystem.DAL
{
    public class UserDAL : DatabaseConfig
    {
        #region Constuctor
        public UserDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constuctor

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
        public Boolean Insert(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_Insert";

                        objCmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entUser.UserName;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = entUser.Password;
                        objCmd.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = entUser.DisplayName;
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = entUser.MobileNo;
                        objCmd.Parameters.Add("@DOB", SqlDbType.VarChar).Value = entUser.DOB;
                        objCmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = entUser.Gender;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entUser.Email;
                        objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = entUser.City;
                        objCmd.Parameters.Add("@Qualification", SqlDbType.VarChar).Value = entUser.Qualification;
                        objCmd.Parameters.Add("@Experience", SqlDbType.VarChar).Value = entUser.Experience;
                        objCmd.Parameters.Add("@DesignationID", SqlDbType.Int).Value = entUser.DesignationID;
                        objCmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = entUser.DepartmentID;
                        objCmd.Parameters.Add("@InstituteID", SqlDbType.Int).Value = entUser.InstituteID;
                        objCmd.Parameters.Add("@PhotoPath", SqlDbType.VarChar).Value = entUser.PhotoPath;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@UserID"] != null)
                            entUser.UserID = Convert.ToInt32(objCmd.Parameters["@UserID"].Value);
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
        public Boolean Update(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_UpdateByPK";

                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entUser.UserID;
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entUser.UserName;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = entUser.Password;
                        objCmd.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = entUser.DisplayName;
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = entUser.MobileNo;
                        objCmd.Parameters.Add("@DOB", SqlDbType.VarChar).Value = entUser.DOB;
                        objCmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = entUser.Gender;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entUser.Email;
                        objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = entUser.City;
                        objCmd.Parameters.Add("@Qualification", SqlDbType.VarChar).Value = entUser.Qualification;
                        objCmd.Parameters.Add("@Experience", SqlDbType.VarChar).Value = entUser.Experience;
                        objCmd.Parameters.Add("@DesignationID", SqlDbType.Int).Value = entUser.DesignationID;
                        objCmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = entUser.DepartmentID;
                        objCmd.Parameters.Add("@InstituteID", SqlDbType.Int).Value = entUser.InstituteID;
                        objCmd.Parameters.Add("@PhotoPath", SqlDbType.VarChar).Value = entUser.PhotoPath;
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
        public Boolean Delete(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_User_DeleteByPK";
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
                        objCmd.CommandText = "PR_User_SelectAll";
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

        #region SelectUserCount
        public UserENT SelectUserCount()
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
                        objCmd.CommandText = "PR_User_SelectUserCount";
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["Usercount"].Equals(DBNull.Value))
                                        entUser.Usercount = Convert.ToInt32(objSDR["Usercount"]);
                                    
                                }
                                return entUser;
                            }
                            else
                            {
                                return null;
                            }
                        }

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
        #endregion SelectUserCount

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
                        objCmd.CommandText = "PR_User_SelectForDropDownList";
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
        public UserENT SelectByPK(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_User_SelectByPK";
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["UserName"].Equals(DBNull.Value))
                                        entUser.UserName = Convert.ToString(objSDR["UserName"]);

                                    if (!objSDR["Password"].Equals(DBNull.Value))
                                        entUser.Password = Convert.ToString(objSDR["Password"]);

                                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                        entUser.DisplayName = Convert.ToString(objSDR["DisplayName"]);

                                    if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                        entUser.MobileNo = Convert.ToString(objSDR["MobileNo"]);

                                    if (!objSDR["DOB"].Equals(DBNull.Value))
                                        entUser.DOB = Convert.ToString(objSDR["DOB"]);

                                    if (!objSDR["Gender"].Equals(DBNull.Value))
                                        entUser.Gender = Convert.ToString(objSDR["Gender"]);

                                    if (!objSDR["Email"].Equals(DBNull.Value))
                                        entUser.Email = Convert.ToString(objSDR["Email"]);

                                    if (!objSDR["Experience"].Equals(DBNull.Value))
                                        entUser.Experience = Convert.ToString(objSDR["Experience"]);

                                    if (!objSDR["Qualification"].Equals(DBNull.Value))
                                        entUser.Qualification = Convert.ToString(objSDR["Qualification"]);

                                    if (!objSDR["City"].Equals(DBNull.Value))
                                        entUser.City = Convert.ToString(objSDR["City"]);

                                    if (!objSDR["DepartmentID"].Equals(DBNull.Value))
                                        entUser.DepartmentID = Convert.ToInt32(objSDR["DepartmentID"]);

                                    if (!objSDR["DesignationID"].Equals(DBNull.Value))
                                        entUser.DesignationID = Convert.ToInt32(objSDR["DesignationID"]);

                                    if (!objSDR["InstituteID"].Equals(DBNull.Value))
                                        entUser.InstituteID = Convert.ToInt32(objSDR["InstituteID"]);

                                    if (!objSDR["DepartmentName"].Equals(DBNull.Value))
                                        entUser.DepartmentName = Convert.ToString(objSDR["DepartmentName"]);

                                    if (!objSDR["DesignationName"].Equals(DBNull.Value))
                                        entUser.DesignationName = Convert.ToString(objSDR["DesignationName"]);

                                    if (!objSDR["InstituteName"].Equals(DBNull.Value))
                                        entUser.InstituteName = Convert.ToString(objSDR["InstituteName"]);

                                    if (!objSDR["PhotoPath"].Equals(DBNull.Value))
                                        entUser.PhotoPath = Convert.ToString(objSDR["PhotoPath"]);
                                }
                                return entUser;
                            }
                            else
                            {
                                return null;
                            }
                        }
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

        #region SelectByUserNamePassword
        public UserENT SelectByUserNamePassword(SqlString UserName, SqlString Password)
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
                        objCmd.CommandText = "PR_User_SelectByUserNamePassword";
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if(objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entUser.UserID = Convert.ToInt32(objSDR["UserID"]);

                                if (!objSDR["DesignationName"].Equals(DBNull.Value))
                                    entUser.DesignationName = Convert.ToString(objSDR["DesignationName"]);

                                if (!objSDR["DesignationID"].Equals(DBNull.Value))
                                    entUser.DesignationID = Convert.ToInt32(objSDR["DesignationID"]);

                                if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                    entUser.DisplayName = Convert.ToString(objSDR["DisplayName"]);

                                if (!objSDR["PhotoPath"].Equals(DBNull.Value))
                                    entUser.PhotoPath = Convert.ToString(objSDR["PhotoPath"]);
                                }
                                return entUser;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        
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
        #endregion SelectByUserNamePassword

        #region SelectUserNameByUserID
        public UserENT SelectUserName(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_User_SelectUserNameByUserID";
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                        #endregion Prepare Command

                        #region Read Data and Set Controls
                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserName"].Equals(DBNull.Value))
                                    entUser.UserName = Convert.ToString(objSDR["UserName"]);
                            }
                        }
                        return entUser;
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
        #endregion SelectUserNameByUserID

        #endregion Select Operation
    }
}

