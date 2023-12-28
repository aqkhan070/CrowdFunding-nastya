using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }   
        public ActionResult add()
        {
            return View();
        }
    }
}