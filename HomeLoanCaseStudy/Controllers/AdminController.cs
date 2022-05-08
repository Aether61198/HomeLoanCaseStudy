using HomeLoanCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HomeLoanCaseStudy.Controllers
{
    [Authorize]
    [NoDirectAccess]
    public class AdminController : Controller
    {
        private readonly HomeLoanDbContext db = new HomeLoanDbContext();

        // GET: Admin
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var userObj = db.Users.Find(id);
                var userDetailsObj = db.UserDetails.Find(id);
                var loanObj = db.Loans.Find(id);

                var tables = new SingleUserViewModel
                {
                    User = userObj,
                    UserDetails = userDetailsObj,
                    Loan = loanObj,
                };

                return View(tables);
            }
        }

        public ActionResult AcceptApplication(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var loanObj = db.Loans.Find(id);
                loanObj.ApprovalStatus = "Approved";
                db.SaveChanges();
                return RedirectToAction("Index", new { id });
            }
        }

        public ActionResult RejectApplication()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RejectApplication(Loan loan, int? id)
        {
            bool Status = false;
            string message;

            if (loan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var loanObj = db.Loans.Find(id);
                loanObj.ApprovalStatus = "Rejected";
                loanObj.Comment = loan.Comment.Trim();
                db.SaveChanges();

                message = "Rejected Successfully!";
                Status = true;
                ViewBag.Message = message;
                ViewBag.Status = Status;
                return View(loan);
            }
        }

        public FileResult DisplayPDF(int id, string fileName)
        {
            string filepath = Server.MapPath(String.Format("~/App_Data/files/{0}/{1}", id, fileName));
            DisplayDocs displayDocs = new DisplayDocs();
            byte[] pdfByte = displayDocs.GetBytesFromFile(filepath);
            return File(pdfByte, "application/pdf");
        }
    }
}