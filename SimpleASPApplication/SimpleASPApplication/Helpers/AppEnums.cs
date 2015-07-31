using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleASPApplication.Helpers
{
    public class AppEnums
    {
        public enum LoggerStatus
        {
            Successful = 0,
            Failed = 1
        }

        public enum SqlTransactionType
        { 
            Insert = 0,
            Update = 1,
            Delete = 2,
            Select = 3
        }
    }
}