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
    public class BlogController : Controller
    {
        CrowdfundingnastyaEntities _dbContext = new CrowdfundingnastyaEntities();
        // GET: Blog
        public ActionResult Index()
        {
            var blogUser = _dbContext.tblBlogs.ToList();
            return View(blogUser);
        }

        [HttpGet]
        public ActionResult add(int id = 0) 
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

                var blogToEdit = _dbContext.tblBlogs.FirstOrDefault(model => model.BlogId == id);
                return View(blogToEdit);
            }
            else
            {
                // Add operation
                return View(new tblBlog());
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult add(tblBlog tblBlog)
        {
            if (tblBlog.BlogId > 0)
            {
                // Update operation
                var existingBlog = _dbContext.tblBlogs.FirstOrDefault(model => model.BlogId == tblBlog.BlogId);
                if (existingBlog != null)
                {
                    // Update existing blog properties here
                    if (tblBlog.BlogThumbnailImage != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(tblBlog.BlogThumbnailImage.FileName);
                        string extension = Path.GetExtension(tblBlog.BlogThumbnailImage.FileName);
                        fileName = fileName + extension;
                        tblBlog.ThumbnailImage = "/assets/assets/img/" + fileName;
                        fileName = Path.Combine(Server.MapPath("/assets/assets/img/"), fileName);
                        tblBlog.BlogThumbnailImage.SaveAs(fileName);
                    }

                    if (tblBlog.BlogAttachedFiles != null && tblBlog.BlogAttachedFiles.Count > 0)
                    {
                        foreach (var file in tblBlog.BlogAttachedFiles)
                        {
                            if (file != null && file.ContentLength > 0)
                            {
                                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                                string extension = Path.GetExtension(file.FileName);
                                fileName = fileName + extension;

                                string filePath = "/assets/assets/img/" + fileName;
                                fileName = Path.Combine(Server.MapPath("/assets/assets/img/"), fileName);
                                file.SaveAs(fileName);

                                // Assuming _dbContextContext is your Entity Framework _dbContextContext
                                var attachment = new tblBlogAttachedFile
                                {
                                    BlogId = tblBlog.BlogId, // Assuming you have the BlogID available
                                    AttachedFiles = filePath,
                                    //FileName = fileName,
                                    //ContentType = file.ContentType,
                                    // ... other properties you may want to store
                                };

                                _dbContext.tblBlogAttachedFiles.AddOrUpdate(attachment);

                            }
                        }
                    }

                    existingBlog.BlogTitle = tblBlog.BlogTitle;
                    existingBlog.BlogDescription = tblBlog.BlogDescription;
                    existingBlog.ThumbnailImage = tblBlog.ThumbnailImage;
                    existingBlog.PriorityId = tblBlog.PriorityId;
                    existingBlog.IsActive = tblBlog.IsActive;
                    existingBlog.CategoryId = tblBlog.CategoryId;
                    existingBlog.BlogTypeId = tblBlog.BlogTypeId;

                    _dbContext.tblBlogs.AddOrUpdate(existingBlog);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index", "Blog");
                }
            }
            else
            {
                // Add operation
                if (tblBlog.BlogThumbnailImage != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(tblBlog.BlogThumbnailImage.FileName);
                    string extension = Path.GetExtension(tblBlog.BlogThumbnailImage.FileName);
                    fileName = fileName + extension;
                    tblBlog.ThumbnailImage = "/assets/assets/img/" + fileName;
                    fileName = Path.Combine(Server.MapPath("/assets/assets/img/"), fileName);
                    tblBlog.BlogThumbnailImage.SaveAs(fileName);
                }

                if (tblBlog.BlogAttachedFiles != null && tblBlog.BlogAttachedFiles.Count > 0)
                {
                    foreach (var file in tblBlog.BlogAttachedFiles)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            fileName = fileName + extension;

                            string filePath = "/assets/assets/img/" + fileName;
                            fileName = Path.Combine(Server.MapPath("/assets/assets/img/"), fileName);
                            file.SaveAs(fileName);

                            // Assuming _dbContextContext is your Entity Framework _dbContextContext
                            var attachment = new tblBlogAttachedFile
                            {
                                BlogId = tblBlog.BlogId, // Assuming you have the BlogID available
                                AttachedFiles = filePath,
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
                return RedirectToAction("Index", "Blog");
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
            if(checkUser != null) 
            {
                _dbContext.Entry(checkUser).State = EntityState.Modified;
                int a = _dbContext.SaveChanges();
                if(a > 0) 
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