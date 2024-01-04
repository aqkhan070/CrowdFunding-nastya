using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdFunding_nastya.Models;

namespace CrowdFunding_nastya.Controllers
{
    [FilterConfig.NoDirectAccess]
    public class ProjectController : Controller
    {
        CrowdfundingnastyaEntities DB = new CrowdfundingnastyaEntities();
        // GET: Project
        public ActionResult Index(string Success, string Update, string Delete, string Error)
        {
            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            ViewBag.Error = Error;
            List<tblProject> Projects = DB.tblProjects.Where(x => x.isDeleted != true).ToList();
            return View(Projects);
        }
        public ActionResult add(int id = 0)
        {
            ViewBag.Status = DB.tblStatus.Where(x => x.isDeleted != true).ToList();
            ViewBag.Categories = DB.tblCategories.Where(x => x.isActive == true).ToList();
            ViewBag.Types = DB.tblTypes.ToList();
            ViewBag.Priorities = DB.tblPriorities.Where(x => x.IsDeleted != true).ToList();
            tblProject Project = DB.tblProjects.Where(x => x.ProjectId == id && x.isDeleted != true).FirstOrDefault();
            if (Project == null)
            {

                Project = new tblProject();
                Project.ImagePath = "/assets/admin/images/faq-img.png";
            }
            return View(Project);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult add(tblProject Project, HttpPostedFileBase Image)
        {
            tblProject Data = new tblProject();
            try
            {
                HttpCookie cookieObj = Request.Cookies["User"];
                byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
                string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                int UserId = Int32.Parse(decrypted);
                if (Project.ProjectId == 0)
                {
                    Data = Project;

                    string folder = Server.MapPath(string.Format("~/{0}/", "Uploading/Project"));
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string path = null;

                    if (Image != null)
                    {
                        string FileName = "Project" + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(Image.FileName);
                        path = Path.Combine(Server.MapPath("~/Uploading/Project"), FileName);
                        Image.SaveAs(path);
                        path = Path.Combine("\\Uploading\\Project", FileName);
                        Data.ImagePath = path;
                    }

                    Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    Data.CreatedBy = UserId;
                    Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    Data.EditBy = UserId;
                    Data.isActive = Project.isActive;
                    Data.isDeleted = false;
                    DB.tblProjects.Add(Data);
                    DB.SaveChanges();

                    tblLog LogData = new tblLog();
                    LogData.UserId = UserId;
                    LogData.Action = "Add Project";
                    LogData.CreatedDate = DateTime.Now;
                    DB.tblLogs.Add(LogData);
                    DB.SaveChanges();
                    string Success = "Project has been added successfully.";
                    return RedirectToAction("Index", new { Success = Success });
                }
                else
                {
                    Data = DB.tblProjects.Select(r => r).Where(x => x.ProjectId == Project.ProjectId).FirstOrDefault();
                    string folder = Server.MapPath(string.Format("~/{0}/", "Uploading/Project"));
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string path = null;

                    if (Image != null)
                    {
                        string FileName = "Project" + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(Image.FileName);
                        path = Path.Combine(Server.MapPath("~/Uploading/Project"), FileName);
                        Image.SaveAs(path);
                        path = Path.Combine("\\Uploading\\Project", FileName);
                        Data.ImagePath = path;
                    }

                    Data.ProjectId = Project.ProjectId;
                    Data.Title = Project.Title;
                    Data.Located = Project.Located;
                    Data.PostCode = Project.PostCode;
                    Data.FundraisingFor = Project.FundraisingFor;
                    Data.Phone = Project.Phone;
                    Data.Description = Project.Description;
                    Data.story = Project.story;
                    Data.Goal = Project.Goal;
                    Data.Deadline = Project.Deadline;
                    Data.Value = Project.Value;
                    Data.Skills = Project.Skills;
                    Data.VerificationCodeTo = Project.VerificationCodeTo;
                    Data.PriorityId = Project.PriorityId;
                    Data.StatusId = Project.StatusId;
                    Data.TypeId = Project.TypeId;
                    Data.CategoryId = Project.CategoryId;
                    Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    Data.EditBy = UserId;
                    Data.isActive = Project.isActive;
                    Data.isDeleted = false;
                    Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    Data.EditBy = UserId;
                    DB.Entry(Data);
                    DB.SaveChanges();

                    tblLog LogData = new tblLog();
                    LogData.UserId = UserId;
                    LogData.Action = "Update Project";
                    LogData.CreatedDate = DateTime.Now;
                    DB.tblLogs.Add(LogData);
                    DB.SaveChanges();
                    string Update = "Project has been Update successfully.";
                    return RedirectToAction("Index", new { Update = Update });

                }
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

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            tblProject Data = new tblProject();
            try
            {
                HttpCookie cookieObj = Request.Cookies["User"];
                byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
                string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                int UserId = Int32.Parse(decrypted);
                Data = DB.tblProjects.Select(r => r).Where(x => x.ProjectId == Id).FirstOrDefault();

                Data.isDeleted = true;
                Data.EditBy = UserId;
                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                DB.Entry(Data);
                DB.SaveChanges();

                tblLog LogData = new tblLog();
                LogData.UserId = UserId;
                LogData.Action = "Delete project";
                LogData.CreatedDate = DateTime.Now;
                DB.tblLogs.Add(LogData);
                DB.SaveChanges();

                string Delete = "Project has been delete successfully.";
                return RedirectToAction("Index", new { Delete = Delete });
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