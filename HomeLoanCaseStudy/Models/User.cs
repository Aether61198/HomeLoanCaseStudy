using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeLoanCaseStudy.Models
{
    public class User // CLASS TO DEFINE ALL DATA MEMBERS OF THE USER TABLE
    {
        // PERSONAL DETAILS OF THE USER
        [Required]
        public int Id { get; set; } //PRIMARY KEY
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? PhoneNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // DETAILS RELATED TO THE LOAN APPLICATION
        public int? MaxLoanAmount { get; set; } // MAX AMOUNT OF LOAN THE USER CAN AVAIL
        public string PanNumber { get; set; }
        public double? MonthlySalary { get; set; }
        public string EmployementType { get; set; }
        public int? RetirementAge { get; set; }
        public string OrganizationType { get; set; }
        public string EmployerName { get; set; }
        public int? AccountNumber { get; set; } // GENERATED AFTER THE USER'S LOAN IS APPROVED

        // ASSOCIATION WITH LOAN TABLE
        [Required]
        public virtual Loan Loan { get; set; }
    }
}