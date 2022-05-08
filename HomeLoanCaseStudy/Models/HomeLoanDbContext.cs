using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeLoanCaseStudy.Models
{
    public class HomeLoanDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}