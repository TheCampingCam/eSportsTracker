using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eSportsTracker.Models;

namespace eSportsTracker.Controllers
{
    public class TournamentDetailsController : Controller
    {
        private EsportsTrackerEntities1 db = new EsportsTrackerEntities1();

        // GET: TournamentDetails
        public ActionResult Index()
        {
            return View(db.TournamentDetails.ToList());
        }

        // GET: TournamentDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentDetails tournamentDetails = db.TournamentDetails.Find(id);
            if (tournamentDetails == null)
            {
                return HttpNotFound();
            }
            return View(tournamentDetails);
        }

        // GET: TournamentDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TournamentDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TournamentID,Date,Name,Organizer,Location,Game,Participant")] TournamentDetails tournamentDetails)
        {
            if (ModelState.IsValid)
            {
                db.TournamentDetails.Add(tournamentDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tournamentDetails);
        }

        // GET: TournamentDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentDetails tournamentDetails = db.TournamentDetails.Find(id);
            if (tournamentDetails == null)
            {
                return HttpNotFound();
            }
            return View(tournamentDetails);
        }

        // POST: TournamentDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TournamentID,Date,Name,Organizer,Location,Game,Participant")] TournamentDetails tournamentDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournamentDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tournamentDetails);
        }

        // GET: TournamentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentDetails tournamentDetails = db.TournamentDetails.Find(id);
            if (tournamentDetails == null)
            {
                return HttpNotFound();
            }
            return View(tournamentDetails);
        }

        // POST: TournamentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TournamentDetails tournamentDetails = db.TournamentDetails.Find(id);
            db.TournamentDetails.Remove(tournamentDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
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
