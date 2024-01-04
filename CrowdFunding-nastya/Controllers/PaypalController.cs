using CrowdFunding_nastya.Models;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding_nastya.Controllers
{
    public class PaypalController : Controller
    {
        static int UserID;
        static int ProjectID;
        static int Amount;
        static string UserFirstName;
        static string UserLastName;
        static string UserEmail;
        static string Comment;
        CrowdfundingnastyaEntities DB = new CrowdfundingnastyaEntities();
        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            if (Cancel != null)
            {
                return RedirectToAction("Orders", new { Error = "Your have canceled your request, please pay your payment." });
            }
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                if(ProjectID > 0)
                { Session["ProjectID"] = ProjectID; }
                if (UserID > 0)
                { Session["UserID"] = UserID; }
                string payerId = Request.Params["PayerID"];
                tblUser UserData = null;
                if (UserID!=null && UserID!=0)
                {
                    int UserNu = UserID;
                    UserData = DB.tblUsers.Find(UserNu);
                }
                
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Paypal/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    tblSetting SettingData = DB.tblSettings.FirstOrDefault();
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    tblTransaction Data = new tblTransaction();
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        Data.PaymentDateTime = DateTime.Now;
                        Data.UserId = Convert.ToInt32(Session["UserID"]);
                        if (Data.UserId == 0)
                        {
                            Data.UserId = null;
                        }

                        Data.Amount =Convert.ToDouble(executedPayment.transactions[0].amount.total);
                        Data.PayerEmail = executedPayment.payer.payer_info.email;
                        Data.PayerFirstName = executedPayment.payer.payer_info.first_name;
                        Data.PayerLastName = executedPayment.payer.payer_info.last_name;
                        Data.PaypalPaymentId = executedPayment.id;
                        Data.PayerId = payerId;
                        Data.Status = "Failed";
                        DB.tblTransactions.Add(Data);
                        DB.SaveChanges();
                        return RedirectToAction("case_detail", "Home", new { Error = "Donation transaction failed.", id = ProjectID });
                    }
                    string FeeType = SettingData.Feetype;
                    Data.PaymentDateTime = DateTime.Now;
                    Data.UserId = Convert.ToInt32(Session["UserID"]);
                    if (Data.UserId == 0)
                    {
                        Data.UserId = null;
                    }
                    else
                    {

                        Data.UserFirstName = UserData.FirstName;
                        Data.UserLastName = UserData.LastName;
                        Data.UserEmail = UserData.Email;
                    }
                    Data.Amount = Convert.ToDouble(executedPayment.transactions[0].amount.total);
                    if (FeeType.ToLower().Contains("fix"))
                    {
                        Data.ComissionType = FeeType;
                        Data.ComissionAmount = SettingData.FeeAmount;
                        Data.Comission = SettingData.FeeAmount;
                        Data.PaidAmount = Data.Amount - SettingData.FeeAmount;
                    }
                    else
                    {
                        Data.ComissionType = FeeType;
                        Data.ComissionAmount = SettingData.FeeAmount;
                        Data.Comission = (Data.Amount * SettingData.FeeAmount) / 100;
                        Data.PaidAmount = Data.Amount - ((Data.Amount * SettingData.FeeAmount) / 100);
                    }
                    if(Session["UserFirstName"]!=null)
                    {
                        Data.UserFirstName = Session["UserFirstName"].ToString();
                    }
                    if(Session["UserLastName"] !=null)
                    {
                        Data.UserLastName = Session["UserLastName"].ToString();
                    }
                    if(Session["UserEmail"] !=null)
                    {
                        Data.UserEmail = Session["UserEmail"].ToString();
                    }
                    if(Session["Comment"] !=null)
                    {
                        Data.Comment = Session["Comment"].ToString();
                    }
                    
                    Data.PayerEmail = executedPayment.payer.payer_info.email;
                    Data.PayerFirstName = executedPayment.payer.payer_info.first_name;
                    Data.PayerLastName = executedPayment.payer.payer_info.last_name;
                    Data.PaypalPaymentId = executedPayment.id;
                    Data.ProjectId = ProjectID;
                    Data.PayerId = payerId;
                    Data.Status = "Successfull";
                    DB.tblTransactions.Add(Data);

                    int ProjectNu = Convert.ToInt32(Session["ProjectID"]);
                    tblProject project = DB.tblProjects.Find(ProjectNu);
                    if (project.RaisedAmount == null)
                    {
                        project.RaisedAmount = 0;
                    }
                    project.RaisedAmount = project.RaisedAmount + Data.PaidAmount;
                    DB.Entry(project);
                    DB.SaveChanges();
                    int UserNu = Convert.ToInt32(project.CreatedBy);
                    UserData = DB.tblUsers.Find(UserNu);
                    if (UserData.Balance == null)
                    {
                        UserData.Balance = 0;
                    }
                    UserData.Balance = UserData.Balance + Data.PaidAmount;
                    DB.Entry(UserData);
                    DB.SaveChanges();
                    UserNu = 1;
                    UserData = DB.tblUsers.Find(UserNu);
                    if (UserData.Balance == null)
                    {
                        UserData.Balance = 0;
                    }
                    UserData.Balance = UserData.Balance + Data.Comission;
                    DB.Entry(UserData);
                    DB.SaveChanges();

                }
                ProjectID = Convert.ToInt32(Session["ProjectID"]);
                return RedirectToAction("case_detail", "Home", new { Success = "Donation transaction successfull.", id= ProjectID });
            }
            catch (Exception ex)
            {
                tblLog ErrorData = new tblLog();
                ErrorData.Action = ex.Message;
                ErrorData.CreatedDate = DateTime.Now;
                ProjectID = Convert.ToInt32(Session["ProjectID"]);
                return RedirectToAction("case_detail", "Home", new { Error = ex.Message, id = ProjectID });
            }

            //return RedirectToAction("Transactions", "Customer", new { Success = "Payment Successfull" });
        }
        private PayPal.Api.Payment payment;



        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {



            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {

            UserID = Convert.ToInt32(Request.Params["UserId"]);
            ProjectID = Convert.ToInt32(Request.Params["ProjectID"]);
            UserFirstName = Request.Params["UserFirstName"];
            UserLastName = Request.Params["UserLastName"];
            UserEmail = Request.Params["UserEmail"];
            Comment = Request.Params["Comment"];

            Session["UserId"] = UserID;
            Session["ProjectID"] = ProjectID;
            Session["UserFirstName"] = UserFirstName;
            Session["UserLastName"] = UserLastName;
            Session["UserEmail"] = UserEmail;
            Session["Comment"] = Comment;

            string FixAmount = Request.Params["FixAmount"];
            string Amount = Request.Params["Amount"];
            if(Amount!=null && Amount!="")
            {
                Amount = Convert.ToDouble(Amount).ToString("0.00");
            }
            else
            {
                Amount = Convert.ToDouble(FixAmount).ToString("0.00");
            }
            var guid = Convert.ToString((new Random()).Next(100000));
            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = "My Business Shower",
                currency = "USD",
                price = Amount,
                quantity = "1",
                sku = "sku"
            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = Amount
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = Amount, // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Transaction description",
                invoice_number = "CF-" + guid, //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }
    }
}