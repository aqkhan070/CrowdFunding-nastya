using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class AdminController : Controller
    {
        CrowdfundingnastyaEntities _dbContext = new CrowdfundingnastyaEntities();
        public ActionResult Index()
        {
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