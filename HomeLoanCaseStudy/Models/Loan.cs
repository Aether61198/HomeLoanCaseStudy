using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeLoanCaseStudy.Models
{
    public class Loan // CLASS TO DEFINE ALL DATA MEMBERS OF LOAN INFORMATION TABLE
    {
        [Key, ForeignKey("Users")]
        public int Id { get; set; }

        [Display(Name = "Approval Status")]
        public bool? IsApproved { get; set; } // FLAG FOR CHECKING IF THE LOAN IS APPROVED OR NOT

        [Display(Name = "Loan Amount")]
        public double? LoanAmount { get; set; } // THE AMOUNT OF LOAN HE HAS AVAILED (DIFFERENT FROM MAX LOAN AMOUNT)

        [Display(Name = "Interest Rate")]
        public float? InterestRate { get; set; }

        [Display(Name = "No of EMIs")]
        public int? NoOfEmi { get; set; } // NO OF EMIs THE USER HAS TO PAY

        [Display(Name = "Tenure (in years)")]
        public int? Tenure { get; set; } // TIME IN MONTHS FOR WHICH THE USER HAS TAKEN THE LOAN

        [Display(Name = "EMI Amount")]
        public double? EmiAmount { get; set; } // THE AMOUNT THAT THE USER HAS TO PAY AS EMI EVERY MONTH

        // ASSOCIATION WITH USER DETAILS TABLE
        [Required]
        public virtual Users Users { get; set; }
    }
}