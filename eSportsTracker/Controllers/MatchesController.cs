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
using PagedList;

namespace eSportsTracker.Controllers
{
    public class MatchesController : Controller
    {
        private EsportsTrackerEntities1 db = new EsportsTrackerEntities1();

        // GET MATCHES
        public ActionResult Index(string searchString, string currentFilter, string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var matches = from m in db.MatchesViews
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                matches = matches.Where(s => s.Winner.Contains(searchString) || s.Loser.Contains(searchString) || s.TournamentName.Contains(searchString) || s.GameName.Contains(searchString));

                //matches = matches.Where(s => s.Handle.Contains(searchString)); 
            }

            matches = matches.OrderBy(s => s.MatchID);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(matches.ToPagedList(pageNumber, pageSize));
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            if (Session["LoggedIn"] == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID");
            ViewBag.MatchID = new SelectList(db.TeamMatches, "MatchID", "MatchID");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimePlayed,Winner,Loser,TournamentID,GameID")] MatchMaker match)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                    db.MakeMatchEasy(match.TimePlayed, match.TournamentID, match.Winner, match.Loser, match.GameID);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    @ViewBag.Error = "Could not process match";
                    return View();
                }
                return RedirectToAction("Index");
            }
            
            return View(match);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["LoggedIn"] == null)
            {
                return RedirectToAction("Index");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID", match.MatchID);
            ViewBag.MatchID = new SelectList(db.TeamMatches, "MatchID", "MatchID", match.MatchID);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchID,TimePlayed")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    @ViewBag.Error = "Could not process match change";
                    return View();
                }
                return RedirectToAction("Index");
            }
            ViewBag.MatchID = new SelectList(db.SoloMatches, "MatchID", "MatchID", match.MatchID);
            ViewBag.MatchID = new SelectList(db.TeamMatches, "MatchID", "MatchID", match.MatchID);
            return View(match);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["LoggedIn"] == null)
            {
                return RedirectToAction("Index");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
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
