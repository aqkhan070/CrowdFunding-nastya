using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult career()
        {
            return View();
        }
        public ActionResult blogs()
        {
            return View();
        }
        public ActionResult blog_detail()
        {
            return View();
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