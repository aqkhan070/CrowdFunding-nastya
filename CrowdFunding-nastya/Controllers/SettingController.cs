using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class SettingController : Controller
    {
        CrowdfundingnastyaEntities dbEntities = new CrowdfundingnastyaEntities();
        public ActionResult Index()
        {
            try
            {
                tblSetting sa = dbEntities.tblSettings.Find(1);
                ViewBag.message = null;
                return View(sa);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Index(tblSetting setting)
        {
            try
            {
                dbEntities.Entry(setting).State = EntityState.Modified;
                dbEntities.SaveChanges();
                ViewBag.message = "Record successfully updated.";
                tblSetting sa = dbEntities.tblSettings.Find(2);
                //System.Configuration.Configuration objConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                //PayPal.SDKConfigHandler objAppsettings = (PayPal.SDKConfigHandler)objConfig.GetSection("paypal");
                ////Edit
                //if (objAppsettings != null)
                //{
                //    objAppsettings.Settings["mode"].Value = setting.AccountType.ToString();
                //    objAppsettings.Settings["clientId"].Value = setting.clientId.ToString();
                //    objAppsettings.Settings["clientSecret"].Value = setting.clientSecret.ToString();
                //    objConfig.Save();
                //}

                return View(sa);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }
        public ActionResult Contact(string lng = "en")
        {
            try
            {
                tblEditPage sa = dbEntities.tblEditPages.Find(1);
                ViewBag.message = null;
                ViewBag.lng = lng;
                return View(sa);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Contact(tblEditPage setting)
        {
            try
            {
                tblEditPage page = dbEntities.tblEditPages.Find(1);
                page.Contact = setting.Contact.Replace("'", "");
                

                page.Email = setting.Email.Replace("'", "");
                page.Phone = setting.Phone.Replace("'", "");
                page.Address = setting.Address.Replace("'", "");
                page.Facebook = setting.Facebook.Replace("'", "");
                page.Instagram = setting.Instagram.Replace("'", "");
                page.Twitter = setting.Twitter.Replace("'", "");
                page.Linkdin = setting.Linkdin.Replace("'", "");
                page.Google = setting.Google.Replace("'", "");
                dbEntities.Entry(page).State = EntityState.Modified;
                dbEntities.SaveChanges();
                ViewBag.message = "Record successfully updated.";
                tblEditPage sa = dbEntities.tblEditPages.Find(1);
                return View(sa);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }
        public ActionResult About()
        {
            try
            {
                tblEditPage sa = dbEntities.tblEditPages.Find(1);
                if (sa == null)
                {
                    sa = new tblEditPage();
                }
                ViewBag.message = null;
                return View(sa);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult About(tblEditPage setting)
        {
            try
            {
                tblEditPage page = dbEntities.tblEditPages.Find(1);
                dbEntities.Entry(page).State = EntityState.Modified;
                dbEntities.SaveChanges();
                ViewBag.message = "Record successfully updated.";
                tblEditPage sa = dbEntities.tblEditPages.Find(1);
                return View(sa);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }
        public ActionResult Privacy()
        {
            try
            {
                tblEditPage sa = dbEntities.tblEditPages.Find(1);
                ViewBag.message = null;
                return View(sa);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Privacy(tblEditPage setting)
        {
            try
            {
                tblEditPage page = dbEntities.tblEditPages.Find(1);
                dbEntities.Entry(page).State = EntityState.Modified;
                dbEntities.SaveChanges();
                ViewBag.message = "Record successfully updated.";
                tblEditPage sa = dbEntities.tblEditPages.Find(1);
                return View(sa);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }
        public ActionResult Legal()
        {
            try
            {
                tblEditPage sa = dbEntities.tblEditPages.Find(1);
                ViewBag.message = null;
                return View(sa);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Legal(tblEditPage setting, string lng)
        {
            try
            {
                tblEditPage page = dbEntities.tblEditPages.Find(1);
                dbEntities.Entry(page).State = EntityState.Modified;
                dbEntities.SaveChanges();
                ViewBag.message = "Record successfully updated.";
                tblEditPage sa = dbEntities.tblEditPages.Find(1);
                return View(sa);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }

    }
}