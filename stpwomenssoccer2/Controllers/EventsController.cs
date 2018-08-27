using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using stpwomenssoccer2.CustomFilters;
using stpwomenssoccer2.Models;


namespace stpwomenssoccer2.Controllers
{
    public class EventsController : Controller
    {
        ApplicationDbContext db;

        public EventsController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Events
        public ActionResult Index()
        {
            var activeEvents = db.Events.Where(e => e.EventTypeId != 1 && !e.Expired);
            return View(activeEvents);
        }

        // GET: Schedule
        public ActionResult Schedule()
        {
            var activeSchedule = db.Events.Where(e => e.EventTypeId == 1);
            return View(activeSchedule);
        }

        // GET: Events/Details/5
        [AuthLog(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            string EventTypeSelected = (from e in db.Events
                                     join et in db.EventTypes
                                     on e.EventTypeId equals et.EventTypeId
                                     where e.EventId == id
                                     select et.EventTypeName).FirstOrDefault();
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "EventTypeId", "EventTypeName", EventTypeSelected);

            string TeamSelected = (from e in db.Events
                                join t in db.Teams
                                on e.TeamId equals t.TeamId
                                where e.EventId == id
                                select t.TeamName).FirstOrDefault();
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName", TeamSelected);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/CreateEvent
        [AuthLog(Roles = "Administrator")]
        public ActionResult Create()
        {
            EventModel model = new EventModel
            {
                EventTypeList = new SelectList(db.EventTypes, "EventTypeId", "EventTypeName"),
                TeamList = new SelectList(db.Teams, "TeamId", "TeamName")
            };
            
            return View(model);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthLog(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventTypeId,Date,Time,EventName,Location,TeamId,Result,Description,Expired")] EventModel @event)
        {
            //ViewBag.EventTypeId = new SelectList(db.EventTypes, "EventTypeId", "EventTypeName");
            //ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName");

            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                if (@event.EventTypeId != 1)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Schedule");
            }

            return View(@event);
        }

        // GET: Events/CreateGame
        //[AuthLog(Roles = "Administrator")]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Events/CreateGame
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[AuthLog(Roles = "Administrator")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateGame([Bind(Include = "EventId,EventTypeId,Date,Time,EventName,Location,Description,TeamId,TeamName,Result")] EventModel @event)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Events.Add(@event);
        //        db.SaveChanges();
        //        return RedirectToAction("Schedule");
        //    }

        //    return View(@event);
        //}

        // GET: Events/Edit/5
        [AuthLog(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            int EventTypeSelected = (from e in db.Events
                                        join et in db.EventTypes
                                        on e.EventTypeId equals et.EventTypeId
                                        where e.EventId == id
                                        select et.EventTypeId).FirstOrDefault();
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "EventTypeId", "EventTypeName", EventTypeSelected);

            int TeamSelected = (from e in db.Events
                                   join t in db.Teams
                                   on e.TeamId equals t.TeamId
                                   where e.EventId == id
                                   select t.TeamId).FirstOrDefault();
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName", TeamSelected);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthLog(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventTypeId,Date,Time,EventName,Location,Description,TeamId,Result,Expired")] EventModel @event)
        {
            string EventTypeSelected = (from e in db.Events
                                        join et in db.EventTypes
                                        on e.EventTypeId equals et.EventTypeId
                                        where e.EventId == @event.EventId
                                        select et.EventTypeName).First();
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "EventTypeId", "EventTypeName", EventTypeSelected);

            string TeamSelected = (from e in db.Events
                                   join t in db.Teams
                                   on e.TeamId equals t.TeamId
                                   where e.EventId == @event.EventId
                                   select t.TeamName).First();
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName", TeamSelected);

            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                if (@event.EventTypeId != 1)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Schedule");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        [AuthLog(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [AuthLog(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventModel @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            if (@event.EventTypeId != 1)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Schedule");
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
