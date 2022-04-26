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
        [Key, ForeignKey("User")]
        public int ID { get; set; }
        public bool? IsApproved { get; set; } // FLAG FOR CHECKING IF THE LOAN IS APPROVED OR NOT
        public double? LoanAmount { get; set; } // THE AMOUNT OF LOAN HE HAS AVAILED (DIFFERENT FROM MAX LOAN AMOUNT)
        public int? NoOfEmi { get; set; } // NO OF EMIs THE USER HAS TO PAY
        public int? Tenure { get; set; } // TIME IN MONTHS FOR WHICH THE USER HAS TAKEN THE LOAN
        public double? EmiAmount { get; set; } // THE AMOUNT THAT THE USER HAS TO PAY AS EMI EVERY MONTH
        public bool? IsLoanCompleted { get; set; } // FLAG FOR CHECKING IF THE USER HAS PAID ALL THE EMIs

        // ASSOCIATION WITH USER TABLE
        [Required]
        public virtual User User { get; set; }
    }
}