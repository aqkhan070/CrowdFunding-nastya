using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
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