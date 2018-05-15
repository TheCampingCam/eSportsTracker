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
    public class TeamMatchesController : Controller
    {
        private EsportsTrackerEntities1 db = new EsportsTrackerEntities1();

        // GET: TeamMatches/Create
        public ActionResult Create()
        {
            if (Session["LoggedIn"] != null)
            {
                ViewBag.MatchID = new SelectList(db.Matches, "MatchID", "MatchID");
                ViewBag.Winner = new SelectList(db.Teams, "TeamID", "TeamName");
                return View();
            } else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        // POST: TeamMatches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchID,Winner")] TeamMatch teamMatch)
        {
            if (ModelState.IsValid)
            {
                db.TeamMatches.Add(teamMatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchID = new SelectList(db.Matches, "MatchID", "MatchID", teamMatch.MatchID);
            ViewBag.Winner = new SelectList(db.Teams, "TeamID", "TeamName", teamMatch.Winner);
            return View(teamMatch);
        }

        // GET: TeamMatches/Delete/5
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
            TeamMatch teamMatch = db.TeamMatches.Find(id);
            if (teamMatch == null)
            {
                return HttpNotFound();
            }
            return View(teamMatch);
        }

        // POST: TeamMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamMatch teamMatch = db.TeamMatches.Find(id);
            db.TeamMatches.Remove(teamMatch);
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
