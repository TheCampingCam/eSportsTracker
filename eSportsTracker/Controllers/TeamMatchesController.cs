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
    public class TeamMatchesController : Controller
    {
        private EsportsTrackerEntities1 db = new EsportsTrackerEntities1();

        // GET: TeamMatches/Create
        public ActionResult Create()
        {
            if (Session["LoggedIn"] != null)
            {
                ViewBag.Winner = new SelectList(db.Teams, "TeamID", "TeamName");
                ViewBag.Loser = new SelectList(db.Teams, "TeamID", "TeamName");
                ViewBag.TournamentID = new SelectList(db.Tournaments, "TournamentID", "TournamentName");
                ViewBag.GameID = new SelectList(db.VideoGames, "GameID", "GameName");
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
        public ActionResult Create([Bind(Include = "TimePlayed,Winner,Loser,TournamentID,GameID")] MultiMatchMaker teamMatch)
        {
            if (ModelState.IsValid || teamMatch.TournamentID == 0)
            {
                db.MakeTeamMatchEasy(teamMatch.TimePlayed, teamMatch.TournamentID, teamMatch.Winner, teamMatch.Loser, teamMatch.GameID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Winner = new SelectList(db.Teams, "TeamID", "TeamName");
            ViewBag.Loser = new SelectList(db.Teams, "TeamID", "TeamName");
            ViewBag.TournamentID = new SelectList(db.Tournaments, "TournamentID", "TournamentName");
            ViewBag.GameID = new SelectList(db.VideoGames, "GameID", "GameName");
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
