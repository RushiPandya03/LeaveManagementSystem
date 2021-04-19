using LeaveManagementSystem.DAL;
using LeaveManagementSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HolidayBAL
/// </summary>
/// 
namespace LeaveManagementSystem.BAL
{
    public class HolidayBAL
    {
        #region Constructor
        public HolidayBAL()
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
            HolidayDAL dalHoliday = new HolidayDAL();

            if (dalHoliday.Insert(entHoliday))
            {
                return true;
            }
            else
            {
                Message = dalHoliday.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(HolidayENT entHoliday)
        {
            HolidayDAL dalHoliday = new HolidayDAL();

            if (dalHoliday.Update(entHoliday))
            {
                return true;
            }
            else
            {
                Message = dalHoliday.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 HolidayID)
        {
            HolidayDAL dalHoliday = new HolidayDAL();

            if (dalHoliday.Delete(HolidayID))
            {
                return true;
            }
            else
            {
                Message = dalHoliday.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            HolidayDAL dalHoliday = new HolidayDAL();
            return dalHoliday.SelectAll();
        }

        #endregion SelectAll Operation
        
        #region SelectByPK Operation
        public HolidayENT SelectByPK(SqlInt32 HolidayID)
        {
            HolidayDAL dalHoliday = new HolidayDAL();
            return dalHoliday.SelectByPK(HolidayID);
        }
        #endregion SelectByPK Operation

        #region SelectHolidayDate Operation

        public DataTable SelectHolidayDate()
        {
            HolidayDAL dalHoliday = new HolidayDAL();
            return dalHoliday.SelectHolidayDate();
        }

        #endregion SelectHolidayDate Operation

        #region SelectByHolidayDate Operation
        public HolidayENT SelectByHolidayDate(SqlString Date)
        {
            HolidayDAL dalHoliday = new HolidayDAL();
            return dalHoliday.SelectByHolidayDate(Date);
        }
        #endregion SelectByHolidayDate Operation

        #endregion Select Operation
    }
}
