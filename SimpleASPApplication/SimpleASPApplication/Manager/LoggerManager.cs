using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleASPApplication.Helpers;
using SimpleASPApplication.Manager.Entities;

namespace SimpleASPApplication.Manager
{
    public class LoggerManager
    {
        public static LoggerManager Instance
        {
            get { return Nested.LoggerManager; }
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            internal static readonly LoggerManager LoggerManager;

            static Nested()
            {
                LoggerManager = new LoggerManager();
            }
        }

        public void ExceptionLogger(string stackTrace, DateTime encounteredDate, AppEnums.LoggerStatus status)
        {
            try
            {
                LoggerMessage _logMessage = new LoggerMessage();
                _logMessage.StackTrace = stackTrace;
                _logMessage.EncounteredDate = encounteredDate;
                _logMessage.Status = status;

                DBHelper.Instance.RunExceptionLogger(_logMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}