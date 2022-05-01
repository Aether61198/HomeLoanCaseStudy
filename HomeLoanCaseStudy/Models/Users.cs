using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeLoanCaseStudy.Models
{
    public class Users // CLASS TO DEFINE ALL DATA MEMBERS OF THE USER TABLE
    {
        [Required]
        public int Id { get; set; } //PRIMARY KEY

        //LOGIN DETAILS OF THE USER

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name required")]
        public string LastName { get; set; }

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

        [Display(Name = "User Role")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Role required")]
        public string UserRole { get; set; }

        // ASSOCIATION WITH USER DETAILS TABLE
        public virtual UserDetails UserDetails { get; set; }

        // ASSOCIATION WITH LOAN TABLE
        public virtual Loan Loan { get; set; }
    }
}