using HomeLoanCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLoanCaseStudy.Controllers
{
    [Authorize]
    [NoDirectAccess]
    public class LoanTrackerController : Controller
    {
        private readonly HomeLoanDbContext db = new HomeLoanDbContext();

        // GET: LoanTracker
        public ActionResult Index()
        {
            var userObj = db.Users.Where(u => u.EmailAddress.Equals(User.Identity.Name)).FirstOrDefault();
            var userDetailsObj = db.UserDetails.Where(ud => ud.Id.Equals(userObj.Id)).FirstOrDefault();
            var loanObj = db.Loans.Where(l => l.Id.Equals(userObj.Id)).FirstOrDefault();

            var tables = new SingleUserViewModel
            {
                User = userObj,
                UserDetails = userDetailsObj,
                Loan = loanObj,
            };

            return View(tables);
        }
    }
}