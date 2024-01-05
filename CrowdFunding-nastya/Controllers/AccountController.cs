using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies["User"];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult sign_in(string Success, string Update, string Error)
        {
            ViewBag.Success = Success;
            ViewBag.Error = Error;
            return View();
        }

        [HttpPost]
        public ActionResult sign_in(string Email, string Password)
        {
            string pass = null;
            tblLog LogData = new tblLog();
            try
            {
                if (Password != null)
                {
                    byte[] EncDataBtye = new byte[Password.Length];
                    EncDataBtye = System.Text.Encoding.UTF8.GetBytes(Password);
                    pass = Convert.ToBase64String(EncDataBtye);
                }
                var User = DB.tblUsers.Select(r => r).Where(x => x.Email == Email && x.Password == pass && x.isActive == true && x.isDeleted == false).FirstOrDefault();
                if (User != null)
                {


                    //Session["User"] = DB.tblUsers.Select(r => r).Where(x => x.Email == Email).FirstOrDefault();
                    Session["Access"] = DB.tblAccessLevels.Select(r => r).Where(x => x.RoleId == User.RoleId && x.isActive == true).OrderBy(x => x.tblMenu.OrderBy).ToList();
                    //Session["Settings"] = DB.tblSettings.Select(r => r).FirstOrDefault();

                    string UserIdString = User.UserId.ToString();
                    byte[] EncDataBtye = new byte[UserIdString.Length];
                    EncDataBtye = System.Text.Encoding.UTF8.GetBytes(UserIdString);
                    string UserIdEnc = Convert.ToBase64String(EncDataBtye);
                    HttpCookie cookie = new HttpCookie("User");

                    cookie["RoleId"] = User.RoleId.ToString();
                    cookie["Role"] = User.tblRole.Role;
                    cookie["UserId"] = UserIdEnc.ToString();
                    cookie["Email"] = User.Email;
                    cookie["FirstName"] = User.FirstName;
                    cookie["ImagePath"] = User.ImagePath;
                    cookie.Expires = DateTime.Now.AddHours(3);
                    Response.Cookies.Add(cookie);

                    FormsAuthentication.SetAuthCookie(Email, false);

                    User.LastLogin = DateTime.Now;
                    DB.Entry(User);
                    DB.SaveChanges();

                    LogData.UserId = User.UserId;
                    LogData.Action = "Login";
                    LogData.CreatedDate = DateTime.Now;
                    DB.tblLogs.Add(LogData);
                    DB.SaveChanges();

                    if (User.RoleId == 1)
                    {
                        return RedirectToAction("Index", "admin");
                    }

                    if (User.RoleId == 3)
                    {
                        return RedirectToAction("Withdraw", "Withdraw");
                    }
                    if (User.RoleId == 2)
                    {
                        return RedirectToAction("Transactions", "Withdraw");
                    }
                }
                else
                {
                    var UserCheck = DB.tblUsers.Select(r => r).Where(x => x.Email == Email && x.Password == pass).FirstOrDefault();
                    if (UserCheck != null && (UserCheck.isActive == false || UserCheck.isActive == null))
                    {
                        ViewBag.Error = "Your account is in-active";
                    }
                    else
                    {
                        ViewBag.Error = "Invalid email or password";
                    }

                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult sign_up()
        {
            ViewBag.EditPage = DB.tblEditPages.FirstOrDefault();
            ViewBag.Roles = DB.tblRoles.Where(x => x.isActive == true && x.isDeleted != true && x.RoleId != 1).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult sign_up(tblUser User, tblProject Project, HttpPostedFileBase ProjectImage)
        {
            tblUser Data = new tblUser();
            tblProject ProjectData = new tblProject();
            try
            {
                ViewBag.Roles = DB.tblRoles.Where(x => x.isActive == true && x.isDeleted != true && x.RoleId != 1).ToList();
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

                        ViewBag.Success = "User has been register successfully.";
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

                        ProjectData = Project;
                        string folder = Server.MapPath(string.Format("~/{0}/", "Uploading/Project"));
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                        string path = null;

                        if (ProjectImage != null)
                        {
                            path = Path.Combine(Server.MapPath("~/Uploading/Project"), Path.GetFileName("Project" + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(ProjectImage.FileName)));
                            ProjectImage.SaveAs(path);
                            path = Path.Combine("\\Uploading\\Project", Path.GetFileName("Project" + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(ProjectImage.FileName)));
                            ProjectData.ImagePath = path;
                        }
                        ProjectData.StatusId = 5;
                        ProjectData.CreatedBy = Data.UserId;
                        ProjectData.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        ProjectData.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        ProjectData.isActive = true;
                        ProjectData.isDeleted = false;
                        DB.tblProjects.Add(ProjectData);
                        DB.SaveChanges();

                        ViewBag.Success = "User has been register successfully.";
                        return View();
                    }
                    else
                    {
                        ViewBag.Error = "User with same email already exsist.";
                        return View();
                    }

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

        [HttpPost]
        public ActionResult forget_password(string Email)
        {
            try
            {
                if (DB.tblUsers.Where(x => x.Email == Email).FirstOrDefault() != null)
                {


                    tblSetting setting = DB.tblSettings.Find(1);
                    //string SenderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                    string SenderEmail = setting.Email;
                    //string SenderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
                    string SenderPassword = setting.Password;
                    //SmtpClient Client = new SmtpClient("yehtohoga.com", 25);
                    SmtpClient Client = new SmtpClient(setting.SMTP, Convert.ToInt32(setting.Port));
                    //Client.EnableSsl = false;
                    Client.EnableSsl = Convert.ToBoolean(setting.isActive);
                    Client.Timeout = 100000;
                    Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    Client.UseDefaultCredentials = false;
                    Client.Credentials = new System.Net.NetworkCredential(SenderEmail, SenderPassword);

                    string link = Request.Url.ToString();
                    link = link.Replace("forget_password", "ChangeForgetPassword");

                    byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(Email);
                    string encrypted = Convert.ToBase64String(b);

                    byte[] t = System.Text.ASCIIEncoding.ASCII.GetBytes(DateTime.Now.ToString());
                    string encryptedTime = Convert.ToBase64String(t);


                    string body1 = "";
                    body1 += "Welcome to My Business Shower!";
                    body1 += "<br />To Change your password, please click on the button below: ";
                    body1 += "<br /> <button style='padding: 10px 28px 11px 28px;color: #fff;background:#333333;'><a style='color:white !important' href = '" + link + "?Email=" + encrypted + "&&Expire=" + encryptedTime + "'>Change Account Password</a></button>";
                    body1 += "<br /><br />Yours,<br />The My Business Shower Team";

                    string body = "";
                    body += "<body  style='background-color:white !important'>";
                    body += " <div>";
                    //body += "<h3>Hello " + sa.ReceiveName + ",</h3>";
                    body += " <table style='background-color: #f2f3f8; max-width:670px;' width='100%' border='0'  cellpadding='0' cellspacing='0'>";
                    body += " <tbody> <tr style='background-color:#333333;'><td style='padding: 0 35px; background-color:#333333;text-align: center;'><a><img style='width:15%;padding: 1%;' src='https://startupbusiness.yehtohoga.com/assets/assets/img/Logo.png' style='padding-top: 1%;' alt='Alternate Text' />  </a></td> </tr>";
                    body += "<tr style='color:#455056; font-size:15px;line-height:35px;text-align: center;'><td style='padding:6px;text-align: center;'></td></tr><tr style='color:#455056; font-size:15px;line-height:35px;text-align: center;'><td style='padding:6px;text-align: center;'>" + body1 + "</td></tr>";
                    body += "  </tbody></table>";
                    body += "</body>";


                    MailMessage mailMessage = new MailMessage(SenderEmail, Email, "Forget Password Email", body);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.BodyEncoding = System.Text.UTF8Encoding.UTF8;

                    Client.Send(mailMessage);

                    //mailMessage = new MailMessage(SenderEmail, Email, "Thank You Email", "Thank You for Contacting Us!!!");
                    //mailMessage.IsBodyHtml = true;
                    //mailMessage.BodyEncoding = System.Text.UTF8Encoding.UTF8;

                    //Client.Send(mailMessage);

                    ViewBag.Success = "Email has been sent successfully.";
                    return View();
                }
                else
                {
                    ViewBag.Error = "User not register";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult changepassword()
        {
            HttpCookie cookieObj = Request.Cookies["User"];
            byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
            string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            int UserId = Int32.Parse(decrypted);
            string Email = cookieObj["Email"];
            ViewBag.Email = Email;
            ViewBag.UserId = UserId;
            return View();
        }
        [HttpPost]
        public ActionResult changepassword(int id, string OldPassword, string NewPassword, string ConfirmPassword, string Email)
        {
            string pass = null;
            try
            {

                HttpCookie cookieObj = Request.Cookies["User"];
                byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
                string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                int UserId = Int32.Parse(decrypted);

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
                        return View();
                    }

                    Data.Password = pass;
                    Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    Data.EditBy = UserId;
                    DB.Entry(Data);
                    DB.SaveChanges();

                    tblLog LogData = new tblLog();
                    LogData.UserId = UserId;
                    LogData.Action = "Change Password";
                    LogData.CreatedDate = DateTime.Now;
                    DB.tblLogs.Add(LogData);
                    DB.SaveChanges();
                    ViewBag.Update = "Password has been change successfully!";
                    return View();
                }
                else
                {
                    ViewBag.Error = "Old password is not Correct!!!";
                    return View();
                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return View();
        }

        public ActionResult ChangeForgetPassword(string Email, string Expire)
        {
            try
            {
                byte[] b = Convert.FromBase64String(Email);
                string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);

                ViewBag.Email = decrypted;

                b = Convert.FromBase64String(Expire);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);

                ViewBag.Expire = DateTime.Parse(decrypted);
                DateTime Date = (DateTime)ViewBag.Expire;
                if (DateTime.Now > Date.AddMinutes(60))
                {
                    return RedirectToAction("sign_in", "Account", new { Error = "Link is expired." });
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
        public ActionResult ChangeForgetPassword(string NewPassword, string ConfirmPassword, string Email)
        {
            string pass = null;
            try
            {


                byte[] EncDataBtye = null;
                tblUser Data = new tblUser();
                Data = DB.tblUsers.Select(r => r).Where(x => x.Email == Email).FirstOrDefault();
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
                        ViewBag.Error = "New Password and Confirm Password are not matched!!!";
                        return View();
                    }

                    Data.Password = pass;
                    Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    DB.Entry(Data);
                    DB.SaveChanges();
                    return RedirectToAction("sign_in", "Account", new { Success = "Password has been change successfully." });
                }
                else
                {
                    ViewBag.Error = "Email is not correct.";
                    return View();
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