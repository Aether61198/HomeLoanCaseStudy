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
                    return View(userDetailsObj);
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
                    return View(db.Users.ToList());
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