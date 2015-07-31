using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleASPApplication.Customer.Entities
{
    public class CustomerInfoMessage
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
    }
}