using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HomeLoanCaseStudy.AdminDatabaseSeed;

namespace HomeLoanCaseStudy.Models
{
    public class HomeLoanDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}