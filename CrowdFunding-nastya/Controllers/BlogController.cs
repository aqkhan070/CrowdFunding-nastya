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
    [FilterConfig.NoDirectAccess]
    public class BlogController : Controller
    {
        CrowdfundingnastyaEntities _dbContext = new CrowdfundingnastyaEntities();
        // GET: Blog
        public ActionResult Index(string Success, string Update, string Error)
        {
            var blogUser = _dbContext.tblBlogs.Where(x=>x.IsDeleted!=true).ToList();
            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Error = Error;
            return View(blogUser);
        }

        [HttpGet]
        public ActionResult add(int id = 0)
        {
            var priorityList = _dbContext.tblPriorities.ToList();
            ViewBag.PriorityList = new SelectList(priorityList, "PriorityId", "Priority");
            var categoryList = _dbContext.tblCategories.Where(x => x.isActive == true).ToList();
            ViewBag.CategoryList = new SelectList(categoryList, "CategoryId", "CategoryName");
            var blogTypeList = _dbContext.tblTypes.ToList();
            ViewBag.BlogTypeList = new SelectList(blogTypeList, "BlogTypeId", "BlogTypeName");
            tblBlog blog = new tblBlog();
            if (id > 0)
            {
                // Edit operation

                 blog = _dbContext.tblBlogs.FirstOrDefault(model => model.BlogId == id);

                return View(blog);
            }
            else
            {
                blog.PublishDate = DateTime.Now;
                blog.ThumbnailImage = "/assets/admin/images/faq-img.png";
                return View(blog);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult add(tblBlog tblBlog, HttpPostedFileBase ThumbnailImage, List<HttpPostedFileBase> BlogAttachedFiles)
        {
            if (tblBlog.BlogId > 0)
            {
                // Update operation
                var existingBlog = _dbContext.tblBlogs.FirstOrDefault(model => model.BlogId == tblBlog.BlogId);
                if (existingBlog != null)
                {
                    // Update existing blog properties here
                    if (ThumbnailImage != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(ThumbnailImage.FileName);
                        string extension = Path.GetExtension(ThumbnailImage.FileName);
                        fileName = fileName + extension;
                        tblBlog.ThumbnailImage = "/Uploading/Blog/" + fileName;
                        fileName = Path.Combine(Server.MapPath("/Uploading/Blog/"), fileName);
                        ThumbnailImage.SaveAs(fileName);
                    }

                    if (BlogAttachedFiles != null && BlogAttachedFiles.Count > 0)
                    {
                        foreach (var file in BlogAttachedFiles)
                        {
                            if (file != null && file.ContentLength > 0)
                            {
                                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                                string extension = Path.GetExtension(file.FileName);
                                fileName = fileName + extension;

                                string filePath = "/Uploading/Blog/" + fileName;
                                fileName = Path.Combine(Server.MapPath("/Uploading/Blog/"), fileName);
                                file.SaveAs(fileName);

                                // Assuming _dbContextContext is your Entity Framework _dbContextContext
                                var attachment = new tblBlogAttachedFile
                                {
                                    BlogId = tblBlog.BlogId, // Assuming you have the BlogID available
                                    AttachedFiles = filePath,
                                    EditDate = DateTime.Now,
                                    //FileName = fileName,
                                    //ContentType = file.ContentType,
                                    // ... other properties you may want to store
                                };

                                _dbContext.tblBlogAttachedFiles.AddOrUpdate(attachment);

                            }
                        }
                    }

                    existingBlog.EditDate = DateTime.Now;
                    existingBlog.BlogTitle = tblBlog.BlogTitle;
                    existingBlog.BlogDescription = tblBlog.BlogDescription;
                    existingBlog.ThumbnailImage = tblBlog.ThumbnailImage;
                    existingBlog.PriorityId = tblBlog.PriorityId;
                    existingBlog.IsActive = tblBlog.IsActive;
                    existingBlog.CategoryId = tblBlog.CategoryId;
                    //existingBlog.BlogTypeId = tblBlog.BlogTypeId;

                    _dbContext.tblBlogs.AddOrUpdate(existingBlog);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index", "Blog", new { Update = "Record has been successfully updated." });
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
                    tblBlog.ThumbnailImage = "/Uploading/Blog/" + fileName;
                    fileName = Path.Combine(Server.MapPath("/Uploading/Blog/"), fileName);
                    ThumbnailImage.SaveAs(fileName);
                }

                if (BlogAttachedFiles != null && BlogAttachedFiles.Count > 0)
                {
                    foreach (var file in BlogAttachedFiles)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            fileName = fileName + extension;

                            string filePath = "/Uploading/Blog/" + fileName;
                            fileName = Path.Combine(Server.MapPath("/Uploading/Blog/"), fileName);
                            file.SaveAs(fileName);

                            // Assuming _dbContextContext is your Entity Framework _dbContextContext
                            var attachment = new tblBlogAttachedFile
                            {
                                BlogId = tblBlog.BlogId, // Assuming you have the BlogID available
                                AttachedFiles = filePath,
                                CreatedDate = DateTime.Now,
                                //FileName = fileName,
                                //ContentType = file.ContentType,
                                // ... other properties you may want to store
                            };

                            _dbContext.tblBlogAttachedFiles.Add(attachment);

                        }
                    }
                }

                //tblBlog.CreatedDate = DateTime.Now;
                _dbContext.tblBlogs.Add(tblBlog);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Blog", new { Success = "Record has been successfully added." });
            }

            return View();
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var checkUser = _dbContext.tblBlogs.Where(model => model.BlogId.Equals(id)).FirstOrDefault();
            if (checkUser != null)
            {
                _dbContext.Entry(checkUser).State = EntityState.Modified;
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
    }
}