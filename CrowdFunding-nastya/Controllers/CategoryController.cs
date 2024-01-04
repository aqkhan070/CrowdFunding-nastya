using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class CategoryController : Controller
    {
        CrowdfundingnastyaEntities _dbContext = new CrowdfundingnastyaEntities();
        public ActionResult Index(string Success, string Update, string Error)
        {
            try
            {
                ViewBag.CategoryList = _dbContext.tblCategories.ToList();
                ViewBag.Success = Success;
                ViewBag.Update = Update;
                ViewBag.Error = Error;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Action", new { message = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Create(int ID, string Name, bool? IsActive)
        {
            try
            {
                HttpCookie cookieObj = Request.Cookies["User"];
                byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
                string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                int UserID = Int32.Parse(decrypted);

                tblCategory category = new tblCategory();
                    if (Convert.ToInt32(ID) > 0)
                    {
                        category = _dbContext.tblCategories.Where(x => x.CategoryId == ID).FirstOrDefault();
                        category.CategoryName = Name;
                    category.isActive = IsActive;
                    category.EditBy = UserID;
                        category.EditDate = DateTime.Now;
                        _dbContext.Entry(category).State = EntityState.Modified;
                        _dbContext.SaveChanges();
                        return RedirectToAction("Index", new { Update = "Record has been updated successfully." });
                    }
                    else
                    {
                        category.CategoryName = Name;
                    category.isActive = IsActive;
                    category.CreatedBy = UserID;
                        category.CreatedDate = DateTime.Now;
                        _dbContext.tblCategories.Add(category);
                        _dbContext.SaveChanges();
                        return RedirectToAction("Index", new { Success = "Record has been added successfully." });
                    }

                
            }
            catch (Exception ex)
            {
                
                    return RedirectToAction("Index", new { Error = ex.Message });
                
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int? ID)
        {
            try
            {

                using (var context = new CrowdfundingnastyaEntities())
                {
                    var br = context.tblCategories.First(x => x.CategoryId == ID);
                    context.tblCategories.Remove(br);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", new {  Error = "Record has been deleted successfully." });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new {  Error = ex.Message });
                throw;
            }

        }
    }
}