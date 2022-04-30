using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLoanCaseStudy.Controllers
{
    [Authorize]
    public class LoggedInUserController : Controller
    {
        // GET: LoggedInUser
        public ActionResult Index()
        {
            return View();
        }
    }
}