using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class HomeController : Controller
    {
        CrowdfundingnastyaEntities dbEntities = new CrowdfundingnastyaEntities();
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
            tblEditPage sa = dbEntities.tblEditPages.Find(1);
            return View(sa);
        }
        public ActionResult legal()
        {
            tblEditPage sa = dbEntities.tblEditPages.Find(1);
            return View(sa);
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
        public ActionResult case_detail()
        {
            return View();
        }
        public ActionResult preview()
        {
            return View();
        }
        public ActionResult About()
        {
            tblEditPage sa = dbEntities.tblEditPages.Find(1);
            return View(sa);
        }

        public ActionResult Contact()
        {
            tblEditPage sa = dbEntities.tblEditPages.Find(1);
            return View(sa);
        }
        [HttpPost]
        public ActionResult Contact(string email, string name, string subject, string message, string phone)
        {
            try
            {

                tblContact contact = new tblContact();
                contact.Email = email;
                contact.Name = name;
                contact.Message = message;
                contact.Subject = subject;
                contact.Subject = phone;
                dbEntities.tblContacts.Add(contact);
                dbEntities.SaveChanges();
                return Json(new { status = 1 });

                tblSetting sa = dbEntities.tblSettings.Find(1);
                using (MailMessage mm = new MailMessage(sa.Email, sa.AdminEmail))
                {

                    mm.Subject = subject;
                    string body = "Hello,";
                    body += "<br /><br />You received a message from " + name + "(" + email + ")";
                    body += "<br /><br />Phone Number: " + phone + "<br /><br />";
                    body += message;
                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = sa.SMTP;
                    smtp.EnableSsl = Convert.ToBoolean(sa.isActive);
                    NetworkCredential NetworkCred = new NetworkCredential(sa.Email, sa.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = Convert.ToInt32(sa.Port);
                    smtp.Send(mm);
                }
                using (MailMessage mm = new MailMessage(sa.Email, email))
                {
                    mm.Subject = "Thank you";
                    string body1 = "";
                    body1 += "Thank you for contacting us.";
                    body1 += "We will entertain your concern soon.";
                    body1 += "<br /><br />Yours,<br />The Business Shower Team";

                    string body = "";
                    body += "<body  style='background-color:white !important'>";
                    body += " <div>";
                    //body += "<h3>Hello " + sa.ReceiveName + ",</h3>";
                    body += " <table style='background-color: #f2f3f8; max-width:670px;' width='100%' border='0'  cellpadding='0' cellspacing='0'>";
                    body += " <tbody> <tr style='background-color:rgba(40, 58, 90, 0.9);'><td style='padding: 0 35px; background-color:rgba(40, 58, 90, 0.9);'><a><h1 style ='color:white' > 21Drop </h1>   </a></td> </tr>";
                    body += "<tr style='color:#455056; font-size:15px;line-height:35px;text-align: center;'><td style='padding:6px;text-align: center;'> <b>Hello " + name + ",</b></td></tr><tr style='color:#455056; font-size:15px;line-height:35px;'><td style='padding:6px;text-align: center;'>" + body1 + "</td></tr>";
                    body += "  </tbody></table>";
                    body += "</body>";

                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = sa.SMTP;
                    smtp.EnableSsl = Convert.ToBoolean(sa.isActive);
                    NetworkCredential NetworkCred = new NetworkCredential(sa.Email, sa.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = Convert.ToInt32(sa.Port);
                    smtp.Send(mm);
                }
                return Json(new { status = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { status = -1, data = ex.Message });
                throw;
            }

        }


        [HttpPost]
        public ActionResult Subscribe(string email, string name)
        {
            try
            {

                tblSubscriber contact = new tblSubscriber();
                contact.Email = email;
                contact.SubsName = name;
                dbEntities.tblSubscribers.Add(contact);
                dbEntities.SaveChanges();
                return Json(new { status = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { status = -1, data = ex.Message });
                throw;
            }
        } 
    }
}