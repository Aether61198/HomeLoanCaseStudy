using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLoanCaseStudy.Models
{
    public class Admin // CLASS TO DEFINE ALL DATA MEMBERS OF ADMIN TABLE
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}