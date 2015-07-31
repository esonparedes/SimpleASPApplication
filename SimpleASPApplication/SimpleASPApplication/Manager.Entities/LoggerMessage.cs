using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleASPApplication.Helpers;

namespace SimpleASPApplication.Manager.Entities
{
    public class LoggerMessage
    {
        public string StackTrace { get; set; }
        public DateTime EncounteredDate { get; set; }
        public AppEnums.LoggerStatus Status { get; set; }
    }
}