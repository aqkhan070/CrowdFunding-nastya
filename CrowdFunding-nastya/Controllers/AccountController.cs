using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class AccountController : Controller
    {
        CrowdfundingnastyaEntities DB = new CrowdfundingnastyaEntities();
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
            ViewBag.Roles = DB.tblRoles.Where(x => x.isActive == true && x.isDeleted != true && x.RoleId != 1).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult sign_up(tblUser User)
        {
            tblUser Data = new tblUser();
            try
            {
                if (User.RoleId == 3)
                {
                    if (DB.tblUsers.Select(r => r).Where(x => x.Email == User.Email && x.isDeleted == false).FirstOrDefault() == null)
                    {
                        Data = User;
                        Data.FirstName = User.FirstName;
                        Data.LastName = User.LastName;
                        Data.Email = User.Email;
                        byte[] EncDataBtye = new byte[User.Password.Length];
                        EncDataBtye = System.Text.Encoding.UTF8.GetBytes(User.Password);
                        Data.Password = Convert.ToBase64String(EncDataBtye);
                        Data.RoleId = User.RoleId;

                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        Data.isDeleted = false;
                        DB.tblUsers.Add(Data);
                        DB.SaveChanges();

                        ViewBag.Success = "User has been added successfully.";
                        return View();
                    }
                    else
                    {
                        ViewBag.Error = "User with same email already exsist.";
                        return View();
                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }


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