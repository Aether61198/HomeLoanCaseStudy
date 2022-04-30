using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeLoanCaseStudy.Models
{
    public class User // CLASS TO DEFINE ALL DATA MEMBERS OF THE USER TABLE
    {
        [Required]
        public int Id { get; set; } //PRIMARY KEY

        //LOGIN DETAILS OF THE USER
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string EmailAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 Characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        // PERSONAL DETAILS OF THE USER

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name required")]
        public string LastName { get; set; }

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

        [Display(Name = "Eligible Loan Amount")]
        public int? MaxLoanAmount { get; set; } // MAX AMOUNT OF LOAN THE USER CAN AVAIL

        [Display(Name = "PAN")]
        public string PanNumber { get; set; }

        [Display(Name = "Monthly Salary")]
        public double? MonthlySalary { get; set; }

        [Display(Name = "Employement Type")]
        public string EmployementType { get; set; }

        [Display(Name = "Retirement Age")]
        public int? RetirementAge { get; set; }

        [Display(Name = "Organization Type")]
        public string OrganizationType { get; set; }

        [Display(Name = "Employer Name")]
        public string EmployerName { get; set; }

        [Display(Name = "Account Number")]
        public int? AccountNumber { get; set; } // GENERATED AFTER THE USER'S LOAN IS APPROVED

        // ASSOCIATION WITH LOAN TABLE
        public virtual Loan Loan { get; set; }
    }
}