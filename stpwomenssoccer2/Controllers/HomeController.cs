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

            var upcomingEvents = db.UpcomingEvents.Where(c => !c.Expired).OrderBy(c => c.CardId);
            return View(upcomingEvents);
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

        public ActionResult EventCards()
        {
            var eventCards = db.UpcomingEvents.Where(c => !c.Expired).OrderBy(c => c.CardId);
            return View("EventCards",eventCards);
        }
    }
}