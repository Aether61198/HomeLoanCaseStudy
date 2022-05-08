using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeLoanCaseStudy.Models
{
    public class UserDetails // CLASS TO DEFINE ALL DETAILS OF THE USERS
    {
        [Key, ForeignKey("Users")]
        public int Id { get; set; } //PRIMARY KEY AND FOREIGN KEY

        // PERSONAL DETAILS OF THE USER

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public long? PhoneNumber { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime? DateOfBirth { get; set; }

        // DETAILS RELATED TO THE LOAN APPLICATION

        [Display(Name = "Property Location")]
        public string PropertyLocation { get; set; }

        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }

        [Display(Name = "Estimated Amount")]
        public double? PropertyEstimatedAmount { get; set; }

        [Display(Name = "Eligible Loan Amount")]
        public double? MaxLoanAmount { get; set; } // MAX AMOUNT OF LOAN THE USER CAN AVAIL

        [Display(Name = "PAN")]
        public string PanNumber { get; set; }

        [Display(Name = "Monthly Salary")]
        public double? MonthlySalary { get; set; }

        [Display(Name = "Employment Type")]
        public string EmploymentType { get; set; }

        [Display(Name = "Retirement Age")]
        public int? RetirementAge { get; set; }

        [Display(Name = "Organization Type")]
        public string OrganizationType { get; set; }

        [Display(Name = "Employer Name")]
        public string EmployerName { get; set; }

        [Display(Name = "Account Number")]
        public int? AccountNumber { get; set; } // GENERATED AFTER THE USER'S LOAN IS APPROVED

        // ASSOCIATION WITH USER TABLE
        [Required]
        public virtual Users Users { get; set; }
    }
}