using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLoanCaseStudy.Models
{
    public class UserViewModel
    {
        public IEnumerable<Users> Users { get; set; }
        public IEnumerable<UserDetails> UserDetails { get; set; }
        public IEnumerable <Loan> Loans { get; set; }
    }
}