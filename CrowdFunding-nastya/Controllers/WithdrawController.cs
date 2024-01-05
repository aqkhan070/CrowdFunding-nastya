using CrowdFunding_nastya.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class WithdrawController : Controller
    {
        CrowdfundingnastyaEntities DB = new CrowdfundingnastyaEntities();
        public ActionResult Withdraw(string Success)
        {
            HttpCookie cookieObj = Request.Cookies["User"];
            byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
            string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            int UserId = Int32.Parse(decrypted);
            ViewBag.UserId = UserId;
            ViewBag.Success = Success;
            tblUser User = new tblUser();
            double? UserBalance = 0;
            List<tblWithdraw> Data = new List<tblWithdraw>();
            Data = DB.tblWithdraws.Where(x => x.CreatedBy == UserId).ToList();
            UserBalance = DB.tblUsers.Where(x => x.UserId == UserId).Select(s => s.Balance).FirstOrDefault();
            if (UserBalance == null) { UserBalance = 0; }
            ViewBag.UserBalance = UserBalance;

            return View(Data);
        }
        [HttpPost]
        public ActionResult Withdraw(tblWithdraw Withdraw)
        {
            HttpCookie cookieObj = Request.Cookies["User"];
            byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
            string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            int UserId = Int32.Parse(decrypted);
            ViewBag.UserId = UserId;
            tblUser User = new tblUser();
            double? UserBalance = 0;
            tblWithdraw Data = new tblWithdraw();

            List<tblWithdraw> WithdrawData = new List<tblWithdraw>();
            try
            {
                UserBalance = DB.tblUsers.Where(x => x.UserId == UserId).Select(s => s.Balance).FirstOrDefault();
                if (UserBalance >= Convert.ToDouble(Withdraw.Amount))
                {

                    Data.Amount = Withdraw.Amount;
                    Data.AccountDetail = Withdraw.AccountDetail;
                    Data.AccountTitle = Withdraw.AccountTitle;
                    Data.BankName = Withdraw.BankName;
                    Data.Status = 1;
                    Data.CreatedBy = UserId;
                    Data.CreatedDate = DateTime.Now;
                    DB.tblWithdraws.Add(Data);
                    DB.SaveChanges();
                    ViewBag.Success = "Withdraw request successfull.";
                }
                DB = new CrowdfundingnastyaEntities();
                WithdrawData = DB.tblWithdraws.Where(x => x.CreatedBy == UserId).ToList();

                ViewBag.UserBalance = UserBalance;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(WithdrawData);
        }

        public ActionResult Withdrawals()
        {
            List<tblWithdraw> Data = new List<tblWithdraw>();

            try
            {
                Data = DB.tblWithdraws.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(Data);
        }
        [HttpPost]
        public ActionResult Withdrawals(int Id, string TransactionNo, string Reason, int Status,HttpPostedFileBase Image)
        {
            HttpCookie cookieObj = Request.Cookies["User"];
            byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
            string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            int UserId = Int32.Parse(decrypted);
            ViewBag.UserId = UserId;
            List<tblWithdraw> DataList = new List<tblWithdraw>();
            tblWithdraw Data = new tblWithdraw();
            tblUser Wallet = new tblUser();

            try
            {
                //SessionUser user = Session["User"] as SessionUser;
                Data = DB.tblWithdraws.Where(x => x.WithdrawId == Id).FirstOrDefault();
                Data.Status = Status;
                if (TransactionNo != null)
                {
                    Data.TransactionNo = TransactionNo;
                }
                if (Reason != null)
                {
                    Data.Reason = Reason;
                }
                string folder = Server.MapPath(string.Format("~/{0}/", "Uploading/Slip"));
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string path = null;

                if (Image != null)
                {
                    string FileName = "Slip" + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(Image.FileName);
                    path = Path.Combine(Server.MapPath("~/Uploading/Slip"), FileName);
                    Image.SaveAs(path);
                    path = Path.Combine("\\Uploading\\Slip", FileName);
                    Data.ImagePath = path;
                }
                Data.EditBy = UserId;
                Data.EditDate = DateTime.Now;
                DB.Entry(Data);
                DB.SaveChanges();
                if (Status == 2)
                {
                    Wallet = DB.tblUsers.Where(x => x.UserId == Data.CreatedBy).FirstOrDefault();
                    Wallet.Balance -= Convert.ToDouble(Data.Amount);
                    DB.Entry(Wallet);
                    DB.SaveChanges();
                    ViewBag.Success = "Withdraw request Approved.";
                }
                else
                {
                    ViewBag.Delete = "Withdraw request rejected.";
                }
                DataList = DB.tblWithdraws.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(DataList);
        }

        public ActionResult Transactions()
        {
            HttpCookie cookieObj = Request.Cookies["User"];
            byte[] b = Convert.FromBase64String(cookieObj["UserId"]);
            string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            int UserId = Int32.Parse(decrypted);
            string Role = cookieObj["Role"];
            List<tblTransaction> Data = new List<tblTransaction>();
            ViewBag.Role = Role;
            try
            {
                if(Role.ToLower().Contains("admin"))
                {
                    Data = DB.tblTransactions.ToList();
                }
                else
                {
                    Data = DB.tblTransactions.Where(x=>x.UserId==UserId).ToList();
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(Data);
        }
    }
}