using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HomeLoanCaseStudy.Controllers
{
    [NoDirectAccess]
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Eligibility()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Eligibility(string monthlyIncome)
        {
            if (monthlyIncome != "")
            {
                int mI = Convert.ToInt32(monthlyIncome);

                double eligibleAmount = 0.6 * 60 * mI;
                eligibleAmount = Math.Round(eligibleAmount, 2);

                ViewData["MonthlyIncome"] = monthlyIncome;
                ViewData["InterestRate"] = 8.5;
                ViewData["EligibleAmount"] = eligibleAmount;

                return View();
            }
            else
            {
                ViewBag.Message = "Enter Monthly Salary";
                return View();
            }
        }

        [HttpGet]
        public ActionResult EmiCal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmiCal(string loanAmount, string tenure)
        {
            if (loanAmount != "" && tenure != "")
            {
                double ROI = 8.5;
                ROI /= (12 * 100);

                int lA = Convert.ToInt32(loanAmount);
                int tE = Convert.ToInt32(tenure) * 12;

                double emi = lA * ROI * (Math.Pow((1 + ROI), tE)) / (Math.Pow((1 + ROI), tE) - 1); // Formula for calculating Emi
                emi = Math.Round(emi, 2);

                ViewData["LoanAmount"] = loanAmount;
                ViewData["Tenure"] = tenure;
                ViewData["InterestRate"] = 8.5;
                ViewData["EMI"] = emi;

                return View();
            }
            else
            {
                ViewBag.Message = "Enter Loan Salary / Tenure";
                return View();
            }
        }
    }
}