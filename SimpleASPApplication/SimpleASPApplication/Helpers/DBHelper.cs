using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using SimpleASPApplication.App_GlobalResources;
using SimpleASPApplication.Manager;
using SimpleASPApplication.Manager.Entities;
using SimpleASPApplication.Customer.Entities;

namespace SimpleASPApplication.Helpers
{
    public class DBHelper
    {
        public static DBHelper Instance
        {
            get { return Nested.DBHelper; }
        }

        private class Nested
        {
            internal static readonly DBHelper DBHelper;

            static Nested()
            {
                DBHelper = new DBHelper();
            }
        }


        public static string ConnString = ConfigurationManager.ConnectionStrings[Constants.CONNECTION_NAME].ConnectionString;
        private SqlConnection con;
        public void InitiateDBConnection()
        {
            try
            {
                con = new SqlConnection(ConnString);
                con.Open();
            }
            catch (SqlException sqlEx)
            {
                LoggerManager.Instance.ExceptionLogger(sqlEx.StackTrace, DateTime.Now, AppEnums.LoggerStatus.Failed);
                throw sqlEx;
            }
        }

        /// <summary>
        /// Inserts data to DB based on the stored procedure given.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool RunSqlTransaction(string storedProcedureName, object message)
        {
            bool isSuccessful = false;
            InitiateDBConnection();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedureName;

                switch (storedProcedureName)
                {
                    case Constants.SP_INSERT_CUST_INFO:
                        CustomerInfoMessage msg = (CustomerInfoMessage)message;
                        cmd.Parameters.AddWithValue("@LastName", msg.LastName);
                        cmd.Parameters.AddWithValue("@FirstName", msg.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", msg.MiddleName);
                        cmd.Parameters.AddWithValue("@BirthDay", msg.BirthDay);
                        cmd.Parameters.AddWithValue("@Address", msg.Address);
                        cmd.ExecuteNonQuery();

                        isSuccessful = true;
                        LoggerManager.Instance.ExceptionLogger("Successfull Creation of Customer", DateTime.Now, AppEnums.LoggerStatus.Successful);
                        break;
                    default:
                        isSuccessful = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Instance.ExceptionLogger(ex.StackTrace, DateTime.Now, AppEnums.LoggerStatus.Failed);
                throw;
            }
            TerminateDBConnection();

            return isSuccessful;
        }

        public void TerminateDBConnection()
        {
            try
            {
                con = new SqlConnection(ConnString);
                con.Close();
            }
            catch (SqlException sqlEx)
            {
                LoggerManager.Instance.ExceptionLogger(sqlEx.StackTrace, DateTime.Now, AppEnums.LoggerStatus.Failed);
                throw sqlEx;
            }
        }

        /// <summary>
        /// Inserts log to database for tracing purposes.
        /// </summary>
        /// <param name="logMsg"></param>
        public void RunExceptionLogger(LoggerMessage logMsg)
        {
            InitiateDBConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Constants.SP_INSERT_EXCEPTION_LOGGER;
                cmd.Parameters.Add("@StackTrace", logMsg.StackTrace);
                cmd.Parameters.Add("@EncounteredDate", logMsg.EncounteredDate);
                cmd.Parameters.Add("@Status", Convert.ToBoolean(logMsg.Status));

                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            TerminateDBConnection();
        }
    }
}