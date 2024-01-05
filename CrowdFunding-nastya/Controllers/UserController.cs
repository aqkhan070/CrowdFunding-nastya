using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    [FilterConfig.NoDirectAccess]
    public class UserController : Controller
    {
        CrowdfundingnastyaEntities DB = new CrowdfundingnastyaEntities();
        // GET: User
        public ActionResult Index(string Success, string Update, string Delete, string Error)
        {
            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            ViewBag.Error = Error;
            List<tblUser> Users = DB.tblUsers.Where(x => x.isDeleted != true).ToList();
            return View(Users);
        }
        public ActionResult lenders(string Success, string Update, string Delete, string Error)
        {
            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            ViewBag.Error = Error;
            List<tblUser> Users = DB.tblUsers.Where(x => x.isDeleted != true && x.RoleId == 3).ToList();
            return View(Users);
        }
        public ActionResult borrowers(string Success, string Update, string Delete, string Error)
        {
            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            ViewBag.Error = Error;
            List<tblUser> Users = DB.tblUsers.Where(x => x.isDeleted != true && x.RoleId == 2).ToList();
            return View(Users);
        }
        public ActionResult business()
        {
            return View();
        }

        public ActionResult add(int id = 0, int RoleId = 0, string message="")
        {
            ViewBag.Roles = DB.tblRoles.Where(x => x.isActive == true && x.isDeleted != true).ToList();
            tblUser User = DB.tblUsers.Where(x => x.UserId == id && x.isDeleted != true).FirstOrDefault();
            if (User == null)
            {
                User = new tblUser();
                User.RoleId = RoleId;
                User.ImagePath = "/assets/assets/img/logo.png";
            }
            ViewBag.message = message;
            return View(User);
        }
        [HttpPost]
        public ActionResult add(tblUser User, HttpPostedFileBase Image)
        {
            tblUser Data = new tblUser();
            try
            {
                HttpCookie cookieObj = Request.Cookies["User"];
                byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
                string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                int UserId = Int32.Parse(decrypted);
                if (User.UserId == 0)
                {
                    if (DB.tblUsers.Select(r => r).Where(x => x.Email == User.Email).FirstOrDefault() == null)
                    {
                        Data = User;
                        byte[] EncDataBtye = new byte[User.Password.Length];
                        EncDataBtye = System.Text.Encoding.UTF8.GetBytes(User.Password);
                        Data.Password = Convert.ToBase64String(EncDataBtye);

                        string folder = Server.MapPath(string.Format("~/{0}/", "Uploading/User"));
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                        string path = null;

                        if (Image != null)
                        {
                            string FileName = "User" + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(Image.FileName);
                            path = Path.Combine(Server.MapPath("~/Uploading/User"), FileName);
                            Image.SaveAs(path);
                            path = Path.Combine("\\Uploading\\User", FileName);
                            Data.ImagePath = path;
                        }

                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        Data.CreatedBy = UserId;
                        Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        Data.EditBy = UserId;
                        Data.isActive = true;
                        Data.isDeleted = false;
                        DB.tblUsers.Add(Data);
                        DB.SaveChanges();

                        tblLog LogData = new tblLog();
                        LogData.UserId = UserId;
                        LogData.Action = "Add User";
                        LogData.CreatedDate = DateTime.Now;
                        DB.tblLogs.Add(LogData);
                        DB.SaveChanges();
                        if (Data.RoleId == 1)
                        {
                            string Success = "User has been added successfully.";
                            return RedirectToAction("Index", new { Success = Success });
                        }
                        else if (Data.RoleId == 2)
                        {
                            string Success = "Donee has been added successfully.";
                            return RedirectToAction("borrowers", new { Success = Success });
                        }
                        else
                        {
                            string Success = "Donner has been added successfully.";
                            return RedirectToAction("lenders", new { Success = Success });
                        }
                    }
                    else
                    {
                        string Error = "User with same email already exsist!";
                        return RedirectToAction("Index", new { Error = Error });
                    }
                }
                else
                {
                    var check = DB.tblUsers.Select(r => r).Where(x => x.Email == User.Email).FirstOrDefault();
                    if (check == null || check.UserId == User.UserId)
                    {
                        Data = DB.tblUsers.Select(r => r).Where(x => x.UserId == User.UserId).FirstOrDefault();
                        string folder = Server.MapPath(string.Format("~/{0}/", "Uploading/User"));
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                        string path = null;

                        if (Image != null)
                        {
                            string FileName = "User" + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(Image.FileName);
                            path = Path.Combine(Server.MapPath("~/Uploading/User"), FileName);
                            Image.SaveAs(path);
                            path = Path.Combine("\\Uploading\\User", FileName);
                            Data.ImagePath = path;
                        }

                        Data.UserId = User.UserId;
                        Data.FirstName = User.FirstName;
                        Data.LastName = User.LastName;
                        Data.Email = User.Email;
                        Data.Description = User.Description;
                        Data.Phone = User.Phone;
                        Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        Data.EditBy = UserId;
                        Data.isActive = true;
                        Data.isDeleted = false;
                        Data.RoleId = User.RoleId;
                        if (User.Password != null)
                        {
                            byte[] EncDataBtye = new byte[User.Password.Length];
                            EncDataBtye = System.Text.Encoding.UTF8.GetBytes(User.Password);
                            Data.Password = Convert.ToBase64String(EncDataBtye);
                        }
                        else
                        {
                            Data.Password = Data.Password;
                        }
                        Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        Data.EditBy = UserId;
                        DB.Entry(Data);
                        DB.SaveChanges();

                        tblLog LogData = new tblLog();
                        LogData.UserId = UserId;
                        LogData.Action = "Update User";
                        LogData.CreatedDate = DateTime.Now;
                        DB.tblLogs.Add(LogData);
                        DB.SaveChanges();
                        if (Data.UserId == UserId)
                        {
                            string Update = "Record has been updated successfully.";
                            return RedirectToAction("add", new {id=Data.UserId, message = Update });
                        }
                        else
                        {
                            if (Data.RoleId == 1)
                            {
                                string Update = "User has been Update successfully.";
                                return RedirectToAction("Index", new { Update = Update });
                            }
                            else if (Data.RoleId == 2)
                            {
                                string Update = "Donee has been Update successfully.";
                                return RedirectToAction("borrowers", new { Update = Update });
                            }
                            else
                            {
                                string Update = "Donner has been Update successfully.";
                                return RedirectToAction("lenders", new { Update = Update });
                            }
                        }
                    }
                    else
                    {
                        string Error = "User with same email already exsist!";
                        return RedirectToAction("Index", new { Error = Error });
                    }

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

                if (User.RoleId == 1)
                {
                    return RedirectToAction("Index", new { Error = ErrorString });
                }
                else if (User.RoleId == 2)
                {
                    return RedirectToAction("borrowers", new { Error = ErrorString });
                }
                else
                {
                    return RedirectToAction("lenders", new { Error = ErrorString });
                }
            }
            catch (Exception ex)
            {
                string Error = ex.InnerException != null && ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : ex.Message;
                if (User.RoleId == 1)
                {
                    return RedirectToAction("Index", new { Error = Error });
                }
                else if (User.RoleId == 2)
                {
                    return RedirectToAction("borrowers", new { Error = Error });
                }
                else
                {
                    return RedirectToAction("lenders", new { Error = Error });
                }
            }
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            tblUser Data = new tblUser();
            try
            {
                HttpCookie cookieObj = Request.Cookies["User"];
                byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
                string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                int UserId = Int32.Parse(decrypted);
                Data = DB.tblUsers.Select(r => r).Where(x => x.UserId == Id).FirstOrDefault();

                Data.isDeleted = true;
                Data.EditBy = UserId;
                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                DB.Entry(Data);
                DB.SaveChanges();

                tblLog LogData = new tblLog();
                LogData.UserId = UserId;
                LogData.Action = "Delete user";
                LogData.CreatedDate = DateTime.Now;
                DB.tblLogs.Add(LogData);
                DB.SaveChanges();

                if (Data.RoleId == 1)
                {
                    string Delete = "User has been delete successfully.";
                    return RedirectToAction("Index", new { Delete = Delete });
                }
                else if (Data.RoleId == 2)
                {
                    string Delete = "Donee has been delete successfully.";
                    return RedirectToAction("borrowers", new { Delete = Delete });
                }
                else
                {
                    string Delete = "Donner has been delete successfully.";
                    return RedirectToAction("lenders", new { Delete = Delete });
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

                if (Data.RoleId == 1)
                {
                    return RedirectToAction("Index", new { Error = ErrorString });
                }
                else if (Data.RoleId == 2)
                {
                    return RedirectToAction("borrowers", new { Error = ErrorString });
                }
                else
                {
                    return RedirectToAction("lenders", new { Error = ErrorString });
                }
            }
            catch (Exception ex)
            {
                string Error = ex.InnerException != null && ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : ex.Message;
                if (Data.RoleId == 1)
                {
                    return RedirectToAction("Index", new { Error = Error });
                }
                else if (Data.RoleId == 2)
                {
                    return RedirectToAction("borrowers", new { Error = Error });
                }
                else
                {
                    return RedirectToAction("lenders", new { Error = Error });
                }
            }
        }

        [HttpPost]
        public ActionResult CheckPassword(string OldPassword, string Email)
        {
            string pass = null;
            try
            {
                byte[] EncDataBtye = new byte[OldPassword.Length];
                EncDataBtye = System.Text.Encoding.UTF8.GetBytes(OldPassword);
                pass = Convert.ToBase64String(EncDataBtye);
                tblUser Data = new tblUser();
                Data = DB.tblUsers.Select(r => r).Where(x => x.Email == Email && x.Password == pass).FirstOrDefault();
                if (Data != null)
                {
                    return Json(1);
                }
                else
                {
                    return Json(0);
                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(int id, string OldPassword, string NewPassword, string ConfirmPassword, string Email)
        {
            string pass = null;
            try
            {

                //HttpCookie cookieObj = Request.Cookies["User"];
                //int UserId = Int32.Parse(cookieObj["UserId"]);
                int UserId = 1;
                byte[] EncDataBtye = new byte[OldPassword.Length];
                EncDataBtye = System.Text.Encoding.UTF8.GetBytes(OldPassword);
                pass = Convert.ToBase64String(EncDataBtye);
                tblUser Data = new tblUser();
                Data = DB.tblUsers.Select(r => r).Where(x => x.Email == Email && x.Password == pass).FirstOrDefault();
                if (Data != null)
                {

                    if (NewPassword == ConfirmPassword)
                    {
                        EncDataBtye = new byte[NewPassword.Length];
                        EncDataBtye = System.Text.Encoding.UTF8.GetBytes(NewPassword);
                        pass = Convert.ToBase64String(EncDataBtye);
                    }
                    else
                    {
                        ViewBag.Error = "New Password and Confirm Password not Matched!!!";
                        return RedirectToAction("Index", "User", new { Error = "New Password and Confirm Password not Matched!" });
                    }

                    Data.Password = pass;
                    Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    Data.EditBy = UserId;
                    DB.Entry(Data);
                    DB.SaveChanges();
                    ViewBag.Success = "Password has been change successfully!!!";

                    tblLog LogData = new tblLog();
                    LogData.UserId = UserId;
                    LogData.Action = "Change Password";
                    LogData.CreatedDate = DateTime.Now;
                    DB.tblLogs.Add(LogData);
                    DB.SaveChanges();
                    string Update = "Password has been changed successfully!";
                    if (Data.UserId == UserId)
                    {
                        return RedirectToAction("add", new { id = Data.UserId, message = Update });
                    }
                    else
                    {
                        if (Data.RoleId == 1)
                        {
                            return RedirectToAction("Index", new { Update = Update });
                        }
                        else if (Data.RoleId == 2)
                        {
                            return RedirectToAction("borrowers", new { Update = Update });
                        }
                        else
                        {
                            return RedirectToAction("lenders", new { Update = Update });
                        }
                    }
                }
                else
                {
                    ViewBag.Error = "Old password is not Correct!!!";
                    return RedirectToAction("Index", "User", new { Error = "Old password is not Correct!!!" });
                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return View();
        }
    }
}