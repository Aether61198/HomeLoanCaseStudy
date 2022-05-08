using HomeLoanCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLoanCaseStudy.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeLoanDbContext db = new HomeLoanDbContext();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var obj = db.Users.Where(u => u.EmailAddress.Equals(User.Identity.Name)).FirstOrDefault();
                if (obj.UserRole == "Admin")
                {
                    return RedirectToAction("Admin");
                }
                else
                {
                    var userDetailsObj = db.UserDetails.Where(ud => ud.Id.Equals(obj.Id)).FirstOrDefault();
                    var loanObj = db.Loans.Where(l => l.Id.Equals(obj.Id)).FirstOrDefault();

                    var tables = new SingleUserViewModel
                    {
                        User = obj,
                        UserDetails = userDetailsObj,
                        Loan = loanObj,
                    };

                    return View(tables);
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Admin()
        {
            if (User.Identity.IsAuthenticated)
            {
                var obj = db.Users.Where(u => u.EmailAddress.Equals(User.Identity.Name)).FirstOrDefault();
                if (obj.UserRole == "Admin")
                {
                    var tables = new UserViewModel
                    {
                        Users = db.Users.ToList(),
                        UserDetails = db.UserDetails.ToList(),
                        Loans = db.Loans.ToList()
                    };

                    return View(tables);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}