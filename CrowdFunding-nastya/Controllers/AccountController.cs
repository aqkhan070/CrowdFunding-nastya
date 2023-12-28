using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult sign_in()
        {
            return View();
        }
        public ActionResult sign_up()
        {
            return View();
        }
        public ActionResult forget_password()
        {
            return View();
        }
        
        public ActionResult admin()
        {
            return View();
        }
        public ActionResult forgetpassword()
        {
            return View();
        }

        public ActionResult changepassword()
        {
            return View();
        }
    }
}