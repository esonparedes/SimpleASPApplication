using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleASPApplication.Manager;
using SimpleASPApplication.Customer.Entities;
using SimpleASPApplication.App_GlobalResources;

namespace SimpleASPApplication.Helpers
{
    public class DataAccessHelper
    {
        public static DataAccessHelper Instance
        {
            get { return Nested.DataAccessHelper; }
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            internal static readonly DataAccessHelper DataAccessHelper;

            static Nested()
            {
                DataAccessHelper = new DataAccessHelper();
            }
        }


        /// <summary>
        /// Insert Customer Information to database.
        /// </summary>
        /// <param name="CustInfo"></param>
        public bool InsertCustomerInfo(CustomerInfoMessage CustInfo)
        {
            try
            {
                return DBHelper.Instance.RunSqlTransaction(Constants.SP_INSERT_CUST_INFO, CustInfo);
            }
            catch (Exception ex)
            {
                LoggerManager.Instance.ExceptionLogger(ex.StackTrace, DateTime.Now, AppEnums.LoggerStatus.Failed);
                throw;
            }
        }
    }
}