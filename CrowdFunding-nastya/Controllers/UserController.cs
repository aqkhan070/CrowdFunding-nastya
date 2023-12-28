using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }    
        public ActionResult lenders()
        {
            return View();
        }    
        public ActionResult borrowers()
        {
            return View();
        } 
        public ActionResult business()
        {
            return View();
        }


        public ActionResult add()
        {
            return View();
        }
    }
}