using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class CareerController : Controller
    {
        CrowdfundingnastyaEntities dbEntities = new CrowdfundingnastyaEntities();
        public ActionResult Index(string Success, string Update, string Error)
        {
            var allCareer = dbEntities.tblCareers.ToList();
            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Error = Error;
            return View(allCareer);
        }

      

        [HttpGet]
        public ActionResult career(int id = 0)
        {
            var priorityList = dbEntities.tblPriorities.ToList();
            ViewBag.PriorityList = new SelectList(priorityList, "PriorityId", "Priority");
            var categoryList = dbEntities.tblCategories.ToList();
            ViewBag.CategoryList = new SelectList(categoryList, "CategoryId", "CategoryName");
            var blogTypeList = dbEntities.tblTypes.ToList();
            ViewBag.BlogTypeList = new SelectList(blogTypeList, "BlogTypeId", "BlogTypeName");
            tblCareer career = new tblCareer();
            if (id > 0)
            {
                // Edit operation
                career = dbEntities.tblCareers.FirstOrDefault(model => model.CareerId == id);
                return View(career);
            }
            else
            {
                // Add operation
                career.PublishDate = DateTime.Now;
                career.CareerThumbnailImage = "/assets/admin/images/faq-img.png";
                return View(career);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Career(tblCareer tblCareer, HttpPostedFileBase ThumbnailImage)
        {
            if (tblCareer.CareerId > 0)
            {
                // Update operation
                var existingCareer = dbEntities.tblCareers.FirstOrDefault(model => model.CareerId == tblCareer.CareerId);
                if (existingCareer != null)
                {
                    // Update existing blog properties here
                    if (ThumbnailImage != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(ThumbnailImage.FileName);
                        string extension = Path.GetExtension(ThumbnailImage.FileName);
                        fileName = fileName + extension;
                        tblCareer.CareerThumbnailImage = "/assets/assets/img/" + fileName;
                        fileName = Path.Combine(Server.MapPath("/assets/assets/img/"), fileName);
                        ThumbnailImage.SaveAs(fileName);
                    }

                    existingCareer.EditDate = DateTime.Now;
                    existingCareer.CareerTitle = tblCareer.CareerTitle;
                    existingCareer.CareerDescription = tblCareer.CareerDescription;
                    existingCareer.CareerThumbnailImage = tblCareer.CareerThumbnailImage;
                    existingCareer.PriorityId = tblCareer.PriorityId;
                    existingCareer.IsActive = tblCareer.IsActive;
                    //existingCareer.CategoryId = tblCareer.CategoryId;
                    //existingCareer.BlogTypeId = tblCareer.BlogTypeId;
                    existingCareer.PublishDate = existingCareer.PublishDate;

                    dbEntities.tblCareers.AddOrUpdate(existingCareer);
                    dbEntities.SaveChanges();
                    return RedirectToAction("Index", "Career" ,new { Update = "Record has been successfully updated." });
                }
            }
            else
            {
                // Add operation
                if (ThumbnailImage != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ThumbnailImage.FileName);
                    string extension = Path.GetExtension(ThumbnailImage.FileName);
                    fileName = fileName + extension;
                    tblCareer.CareerThumbnailImage = "/assets/assets/img/" + fileName;
                    fileName = Path.Combine(Server.MapPath("/assets/assets/img/"), fileName);
                    ThumbnailImage.SaveAs(fileName);
                }

                tblCareer.CreatedDate = DateTime.Now;
                dbEntities.tblCareers.Add(tblCareer);
                dbEntities.SaveChanges(); 
                return RedirectToAction("Index", "Career", new { Update = "Record has been successfully added." });
            }

            return View();
        }
        [HttpGet]
        public ActionResult careerDelete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult careerDelete(int CareerId)
        {
            var checkCareer = dbEntities.tblCareers.Where(model => model.CareerId.Equals(CareerId)).FirstOrDefault();
            if (checkCareer != null)
            {
                checkCareer.IsDeleted = true;
                dbEntities.Entry(checkCareer).State = EntityState.Modified;
                int a = dbEntities.SaveChanges();
                if (a > 0)
                {
                    return Json(new { success = true });
                }
            }
            else
            {
                return Json(new { success = false });
            }
            return View();
        }
    }
}