﻿using CrowdFunding_nastya.Models;
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
    public class HomeController : Controller
    {
        CrowdfundingnastyaEntities _dbContext = new CrowdfundingnastyaEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult works()
        {
            return View();
        }
        public ActionResult faqs()
        {
            return View();
        }
    
        public ActionResult privacy()
        {
            return View();
        }
        public ActionResult legal()
        {
            return View();
        }
        [HttpGet]
        public ActionResult careerList()
        {
            var careerList = _dbContext.tblCareers.ToList();
            return View(careerList);
        }

        [HttpGet]
        public ActionResult career(int id = 0)
        {
            var priorityList = _dbContext.tblBlogPriorities.ToList();
            ViewBag.PriorityList = new SelectList(priorityList, "PriorityId", "Priority");
            var categoryList = _dbContext.tblBlogCategories.ToList();
            ViewBag.CategoryList = new SelectList(categoryList, "CategoryId", "CategoryName");
            var blogTypeList = _dbContext.tblBlogTypes.ToList();
            ViewBag.BlogTypeList = new SelectList(blogTypeList, "BlogTypeId", "BlogTypeName");

            if (id > 0)
            {
                // Edit operation
                var CareerToEdit = _dbContext.tblCareers.FirstOrDefault(model => model.CareerId == id);
                return View(CareerToEdit);
            }
            else
            {
                // Add operation
                return View(new tblCareer());
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Career(tblCareer tblCareer , HttpPostedFileBase ThumbnailImage)
        {
            if (tblCareer.CareerId > 0)
            {
                // Update operation
                var existingCareer = _dbContext.tblCareers.FirstOrDefault(model => model.CareerId == tblCareer.CareerId);
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
                    //existingCareer.CareerTitle = tblCareer.CareerTitle;
                    //existingCareer.CareerDescription = tblCareer.CareerDescription;
                    //existingCareer.CareerThumbnailImage = tblCareer.CareerThumbnailImage;
                    //existingCareer.PriorityId = tblCareer.PriorityId;
                    //existingCareer.IsActive = tblCareer.IsActive;
                    //existingCareer.CategoryId = tblCareer.CategoryId;
                    //existingCareer.BlogTypeId = tblCareer.BlogTypeId;
                    //existingCareer.PublishDate = existingCareer.PublishDate;

                    _dbContext.tblCareers.AddOrUpdate(existingCareer);
                    _dbContext.SaveChanges();
                    return RedirectToAction("careerList", "Home");
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
                _dbContext.tblCareers.Add(tblCareer);
                _dbContext.SaveChanges();
                return RedirectToAction("careerList", "Home");
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
            var checkCareer = _dbContext.tblBlogs.Where(model => model.BlogId.Equals(CareerId)).FirstOrDefault();
            if (checkCareer != null)
            {
                checkCareer.IsDeleted = true;
                _dbContext.Entry(checkCareer).State = EntityState.Modified;
                int a = _dbContext.SaveChanges();
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
        [HttpGet]
        public ActionResult careerAllList()
        {
            var allCareer = _dbContext.tblCareers.ToList();
            return View(allCareer);
        }
        [HttpGet]
        public ActionResult careerDetail(int id)
        {
            var careerPre = _dbContext.tblCareers.SingleOrDefault(model => model.CareerId == id);
            if (careerPre != null)
            {
                return View(careerPre);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult blogs()
        {
            var blogs = _dbContext.tblBlogs.ToList();
            return View(blogs);
        }
        public ActionResult blog_detail(int id)
        {
            var blogsPre = _dbContext.tblBlogs.SingleOrDefault(model => model.BlogId == id);
            if (blogsPre != null)
            {
                return View(blogsPre);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult cases()
        {
            return View();
        }
        public ActionResult case_detail ()
        {
            return View();
        }
        public ActionResult preview()
        {
            return View();
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