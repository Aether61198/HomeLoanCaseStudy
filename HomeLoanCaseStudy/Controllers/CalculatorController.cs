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

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_post()
        {
            double ROI = 8.5;
            ROI /= (12 * 100);
            double loanamount = Convert.ToDouble(Request["LoanAmt"].ToString());

            int tenure = Convert.ToInt32(Request["tenure"].ToString()) * 12;

            double emi = loanamount * ROI * (Math.Pow((1 + ROI), tenure)) / (Math.Pow((1 + ROI), tenure) - 1); // Formula for calculating Emi

            StringBuilder sbInterest = new StringBuilder();
            sbInterest.Append("<b>loanAmount :</b> " + loanamount + "<br/>");
            sbInterest.Append("<b>loanTenure :</b> " + (tenure / 12) + "<br/>");
            sbInterest.Append("<b>emi :</b> " + emi);
            return Content(sbInterest.ToString());
        }
    }
}