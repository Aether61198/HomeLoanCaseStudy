using HomeLoanCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLoanCaseStudy.Controllers
{
    [Authorize]
    [NoDirectAccess]
    public class ApplicationController : Controller
    {
        private readonly HomeLoanDbContext db = new HomeLoanDbContext();

        // GET: Application
        public ActionResult Index()
        {
            var obj = db.Users.Where(u => u.EmailAddress.Equals(User.Identity.Name)).FirstOrDefault();
            if (obj.UserRole == "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            var userDetailsObj = db.UserDetails.Where(ud => ud.Id.Equals(obj.Id)).FirstOrDefault();
            if(userDetailsObj.AccountNumber == null)
            {
                return RedirectToAction("PropertyDetails");
            }

            return RedirectToAction("Index", "LoanTracker");
        }

        public ActionResult PropertyDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PropertyDetails(UserDetails userDetails)
        {
            var obj = db.Users.Where(u => u.EmailAddress.Equals(User.Identity.Name)).FirstOrDefault();
            if (obj != null)
            {
                var userObj = db.UserDetails.Where(ud => ud.Id.Equals(obj.Id)).FirstOrDefault();
                var loanObj = db.Loans.Where(l => l.Id.Equals(obj.Id)).FirstOrDefault();
                if (loanObj.ApprovalStatus.Equals("Pending"))
                {
                    userObj.PropertyLocation = userDetails.PropertyLocation;
                    userObj.PropertyName = userDetails.PropertyName;
                    userObj.PropertyEstimatedAmount = userDetails.PropertyEstimatedAmount;
                    db.SaveChanges();
                    return RedirectToAction("EmploymentDetails");
                }
            }
            return View(userDetails);
        }

        public ActionResult EmploymentDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmploymentDetails(UserDetails userDetails)
        {
            var obj = db.Users.Where(u => u.EmailAddress.Equals(User.Identity.Name)).FirstOrDefault();
            if (obj != null)
            {
                var userObj = db.UserDetails.Where(ud => ud.Id.Equals(obj.Id)).FirstOrDefault();

                userObj.EmploymentType = userDetails.EmploymentType;
                userObj.MonthlySalary = userDetails.MonthlySalary;
                userObj.RetirementAge = userDetails.RetirementAge;
                userObj.OrganizationType = userDetails.OrganizationType;
                userObj.EmployerName = userDetails.EmployerName;
                double eligibleAmount = 0.6 * 60 * (double)userDetails.MonthlySalary;
                eligibleAmount = Math.Round(eligibleAmount, 2);
                userObj.MaxLoanAmount = eligibleAmount;
                db.SaveChanges();
                return RedirectToAction("LoanDetails");
            }
            return View(userDetails);
        }

        public ActionResult LoanDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoanDetails(Loan loan)
        {
            var obj = db.Users.Where(u => u.EmailAddress.Equals(User.Identity.Name)).FirstOrDefault();
            if (obj != null)
            {
                var userDetailsObj = db.UserDetails.Find(obj.Id);
                var loanObj = db.Loans.Where(l => l.Id.Equals(obj.Id)).FirstOrDefault();

                if (loan.LoanAmount > userDetailsObj.MaxLoanAmount)
                {
                    ViewBag.Message = "Loan Amount entered exceeds the maximum approved loan limit!";
                }
                else
                {
                    loanObj.Tenure = loan.Tenure;
                    loanObj.LoanAmount = loan.LoanAmount;
                    db.SaveChanges();
                    return RedirectToAction("PersonalDetails");
                }
            }
            return View(loan);
        }

        public ActionResult PersonalDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalDetails(UserDetails userDetails)
        {
            var obj = db.Users.Where(u => u.EmailAddress.Equals(User.Identity.Name)).FirstOrDefault();
            if (obj != null)
            {
                var userObj = db.UserDetails.Where(ud => ud.Id.Equals(obj.Id)).FirstOrDefault();

                userObj.PhoneNumber = userDetails.PhoneNumber;
                userObj.DateOfBirth = userDetails.DateOfBirth;
                userObj.Gender = userDetails.Gender;
                userObj.PanNumber = userDetails.PanNumber;
                db.SaveChanges();
                return RedirectToAction("UploadDocuments");
            }
            return View(userDetails);
        }

        public ActionResult UploadDocuments()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadDocuments(HttpPostedFileBase[] file)
        {
            var obj = db.Users.Where(u => u.EmailAddress.Equals(User.Identity.Name)).FirstOrDefault();
            int id = obj.Id;
            string folder = Server.MapPath(string.Format("~/App_Data/files/{0}", id));
            string[] fileNames = new string[] { "PanCard", "SalarySlip", "LOA", "NOCfromBuilder", "AgreementToSale" };

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                //ViewBag.Message = "Folder " + id.ToString() + " created successfully!";

                for (int i = 0; i < file.Length; i++)
                {
                    HttpPostedFileBase fileItem = file[i];

                    if (fileItem != null && fileItem.ContentLength > 0)
                    {
                        try
                        {
                            string fileName = fileNames[i] + ".pdf";
                            string fullPath = Path.Combine(folder, fileName);
                            fileItem.SaveAs(fullPath);
                            ViewBag.Message = "Files uploaded successfully with id = " + id;
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Message = "ERROR:" + ex.Message.ToString();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "You have not uploaded all files.";
                    }
                }
                var userDetailsObj = db.UserDetails.Where(u => u.Id.Equals(obj.Id)).FirstOrDefault();
                var loanObj = db.Loans.Where(l => l.Id.Equals(obj.Id)).FirstOrDefault();
                userDetailsObj.AccountNumber = 1000 + Convert.ToInt32(obj.Id);
                loanObj.ApprovalStatus = "Tentative";
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Folder " + id.ToString() + "  already exists!";
            }

            return View();
        }
    }
}