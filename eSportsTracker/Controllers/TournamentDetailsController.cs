using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
            TournamentDetail tournamentDetail = db.TournamentDetails.Find(id);
            if (tournamentDetail == null)
            {
                return HttpNotFound();
            }
            return View(tournamentDetail);
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
        public ActionResult Create([Bind(Include = "Date,Name,Organizer,Location,Game")] TournamentDetail tournamentDetail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //db.TournamentDetails.Add(tournamentDetail);
                    db.insertTournament(tournamentDetail.Date, tournamentDetail.Name, tournamentDetail.Organizer, tournamentDetail.Location, tournamentDetail.Game);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException e) {
                    @ViewBag.error = "Could not create tournament";
                    return View();
                }
            }

            return View(tournamentDetail);
        }

        // GET: TournamentDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentDetail tournamentDetail = db.TournamentDetails.Find(id);
            if (tournamentDetail == null)
            {
                return HttpNotFound();
            }
            return View(tournamentDetail);
        }

        // POST: TournamentDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TournamentID,Date,Name,Organizer,Location,Game")] TournamentDetail tournamentDetail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tournamentDetail).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException e) {
                    @ViewBag.error = "Could not edit tournament";
                    return View();
                }
            }
            return View(tournamentDetail);
        }

        // GET: TournamentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentDetail tournamentDetail = db.TournamentDetails.Find(id);
            if (tournamentDetail == null)
            {
                return HttpNotFound();
            }
            return View(tournamentDetail);
        }

        // POST: TournamentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                TournamentDetail tournamentDetail = db.TournamentDetails.Find(id);
                db.TournamentDetails.Remove(tournamentDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException e) {
                @ViewBag.error = "Could not remove player";
                return View();
            }
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
