using HomeLoanCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HomeLoanCaseStudy.Controllers
{
    public class UsersController : Controller
    {
        private readonly HomeLoanDbContext db = new HomeLoanDbContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            bool Status = false;
            string message;

            if (ModelState.IsValid)
            {
                var isExist = IsEmailExist(user.EmailAddress);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email Already Exists");
                    return View(user);
                }

                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);

                db.Users.Add(user);
                db.SaveChanges();
                message = "Registration Done Successfully!";
                Status = true;
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user, string returnUrl)
        {
            var obj = db.Users.Where(u => u.EmailAddress.Equals(user.EmailAddress)).FirstOrDefault();
            if (obj != null)
            {
                if (string.Compare(Crypto.Hash(user.Password), obj.Password) == 0)
                {
                    FormsAuthentication.SetAuthCookie(user.EmailAddress, user.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.Message = "Wrong Password";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Email does not match with any existing user";
                return View();
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [NonAction]
        public bool IsEmailExist(string emailId)
        {
            var obj = db.Users.Where(u => u.EmailAddress.Equals(emailId)).FirstOrDefault();
            return obj != null;
        }
    }
}