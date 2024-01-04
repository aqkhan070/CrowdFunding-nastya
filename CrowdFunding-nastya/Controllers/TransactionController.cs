using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class TransactionController : Controller
    {
        CrowdfundingnastyaEntities DB = new CrowdfundingnastyaEntities();
        // GET: Transaction
        [HttpPost]
        public ActionResult AddDonation()
        {
            tblUser Data = new tblUser();
            try
            {
                //HttpCookie cookieObj = Request.Cookies["User"];
                //int UserId = Int32.Parse(cookieObj["UserId"]);
                //int RoleId = Int32.Parse(cookieObj["RoleId"]);
                return View();
            }
            catch (DbEntityValidationException dbEx)
            {
                string ErrorString = "";
                // Handle DbEntityValidationException
                foreach (var item in dbEx.EntityValidationErrors)
                {
                    foreach (var item1 in item.ValidationErrors)
                    {
                        ErrorString += item1.ErrorMessage + " ,";
                    }
                }

                return RedirectToAction("Index", new { Error = ErrorString });
            }
            catch (Exception ex)
            {
                string Error = ex.InnerException != null && ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : ex.Message;
                return RedirectToAction("Index", new { Error = Error });
            }
        }
    }
}