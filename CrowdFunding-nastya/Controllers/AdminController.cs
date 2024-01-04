using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    [FilterConfig.NoDirectAccess]
    public class AdminController : Controller
    {
        CrowdfundingnastyaEntities _dbContext = new CrowdfundingnastyaEntities();
        public ActionResult Index()
        {
            HttpCookie cookieObj = Request.Cookies["User"];
              string  Role = cookieObj["Role"];
            ViewBag.Name = cookieObj["FirstName"];
            ViewBag.Donners = _dbContext.tblUsers.Where(x => x.isActive == true && x.isDeleted != true && x.RoleId==3).Take(5).ToList();
            ViewBag.DonnersCount = _dbContext.tblUsers.Where(x => x.isActive == true && x.isDeleted != true && x.RoleId==3).Count();
            ViewBag.Donees = _dbContext.tblUsers.Where(x => x.isActive == true && x.isDeleted != true && x.RoleId==2).Take(5).ToList();
            ViewBag.DoneesCount = _dbContext.tblUsers.Where(x => x.isActive == true && x.isDeleted != true && x.RoleId==2).Count();
            ViewBag.ProjectCount = _dbContext.tblProjects.Where(x => x.isActive == true && x.isDeleted != true).Count();
            


            return View();
        }  
        public ActionResult settings()
        {
            return View();
        }
        public ActionResult Contact()
        {
            var Contact = _dbContext.tblContacts.ToList().OrderByDescending(x=>x.Contact_ID);
            return View(Contact);
        }
        public ActionResult Subscriber()
        {
            var Subscribe = _dbContext.tblSubscribers.ToList().OrderByDescending(x => x.SubscriberID);
            return View(Subscribe);
        }
    }
}