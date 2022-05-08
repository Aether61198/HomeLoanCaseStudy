using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLoanCaseStudy.Models
{
    public class SingleUserViewModel
    {
        public Users User { get; set; }
        public UserDetails UserDetails { get; set; }
        public Loan Loan { get; set; }
    }
}