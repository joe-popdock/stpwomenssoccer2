using stpwomenssoccer2.CustomFilters;
using stpwomenssoccer2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        // GET: Events/Edit/5
        [AuthLog(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            int CardSelected = (from e in db.UpcomingEvents
                                     where e.CardId == id
                                     select e.CardId).FirstOrDefault();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpcomingEvent card = db.UpcomingEvents.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthLog(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardId,CardDate,CardTitle,Expired")] UpcomingEvent card)
        {
            int CardSelected = (from e in db.UpcomingEvents
                                where e.CardId == card.CardId
                                select e.CardId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                db.Entry(card).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EventCards");
            }
            return View(card);
        }

        // GET: Events/Delete/5
        [AuthLog(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpcomingEvent card = db.UpcomingEvents.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View("EventCards");
        }

        // POST: Events/Delete/5
        [AuthLog(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UpcomingEvent card = db.UpcomingEvents.Find(id);
            db.UpcomingEvents.Remove(card);
            db.SaveChanges();
            return View("EventCards");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}