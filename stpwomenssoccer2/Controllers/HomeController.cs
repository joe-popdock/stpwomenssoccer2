using stpwomenssoccer2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace stpwomenssoccer2.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            string countdownDate = (from ec in db.Clock
                                   where !ec.Expired
                                   select ec.Date).FirstOrDefault();
            ViewBag.clockDate = countdownDate;

            string countdownTitle = (from ec in db.Clock
                                    where !ec.Expired
                                    select ec.EventTitle).FirstOrDefault();
            ViewBag.clockTitle = countdownTitle;

            return View();
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult Coaches()
        {
            return View("Coaches");
        }

        public ActionResult Varsity()
        {
            return View("Varsity");
        }

        public ActionResult JV()
        {
            return View("JV");
        }

        public ActionResult Photos()
        {
            return View("Photos");
        }

        //[HttpPost]
        //public ActionResult Subscribe(Subscriber subscriber)
        //{
        //    bool emailSub;
        //    bool smsSub;

        //    if (subscriber.Email != null)
        //    {
        //        string emailRegex = @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$";
        //        Regex re = new Regex(emailRegex);

        //        if (!re.IsMatch(subscriber.Email))
        //        {
        //            ModelState.AddModelError("Email", "Please enter a valid email address.");
        //            emailSub = false;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                Amazon.SimpleNotificationService.AmazonSimpleNotificationServiceClient _client = new Amazon.SimpleNotificationService.AmazonSimpleNotificationServiceClient();
        //                _client.SubscribeAsync(_iconfiguration["TopicARN"], "email", subscriber.Email);
        //                emailSub = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                emailSub = false;
        //            }
        //        }

        //    }
        //    else
        //        emailSub = false;

        //    if (subscriber.Phone != null)
        //    {
        //        string phoneRegex = @"^([0-9]{10})+$";
        //        Regex re = new Regex(phoneRegex);

        //        if (!re.IsMatch(subscriber.Phone))
        //        {
        //            ModelState.AddModelError("Phone", "Please enter a 10-digit US phone number.");
        //            smsSub = false;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                Amazon.SimpleNotificationService.AmazonSimpleNotificationServiceClient _client = new Amazon.SimpleNotificationService.AmazonSimpleNotificationServiceClient();
        //                _client.SubscribeAsync(_iconfiguration["TopicARN"], "sms", "+1" + subscriber.Phone);
        //                smsSub = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                smsSub = false;
        //            }
        //        }

        //    }
        //    else
        //        smsSub = false;

        //    if (ModelState.IsValid)
        //    {
        //        return Redirect("/Home/Index?email=" + emailSub + "&sms=" + smsSub);
        //    }
        //    else
        //    {
        //        return View("Index");
        //    }

        //}

    }
}