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
    public class SoloMatchesController : Controller
    {
        private EsportsTrackerEntities1 db = new EsportsTrackerEntities1();

        // GET: SoloMatches/Create
        public ActionResult Create()
        {
            if (Session["LoggedIn"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            ViewBag.MatchID = new SelectList(db.Matches, "MatchID", "MatchID");
            ViewBag.Winner = new SelectList(db.Players, "PlayerID", "Handle");
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID");
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID");
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID");
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID");
            return View();
        }

        // POST: SoloMatches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchID,Winner,Loser")] SoloMatch soloMatch)
        {
            if (ModelState.IsValid)
            {
                db.SoloMatches.Add(soloMatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchID = new SelectList(db.Matches, "MatchID", "MatchID", soloMatch.MatchID);
            ViewBag.Winner = new SelectList(db.Players, "PlayerID", "Handle", soloMatch.Winner);
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID", soloMatch.MatchID);
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID", soloMatch.MatchID);
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID", soloMatch.MatchID);
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID", soloMatch.MatchID);
            return View(soloMatch);
        }

        // GET: SoloMatches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["LoggedIn"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoloMatch soloMatch = db.SoloMatches.Find(id);
            if (soloMatch == null)
            {
                return HttpNotFound();
            }
            return View(soloMatch);
        }

        // POST: SoloMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.DeleteMatches(id);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                @ViewBag.Error = "Could not remove match record";
                return View();
            }
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
