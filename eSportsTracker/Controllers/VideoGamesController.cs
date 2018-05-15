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
    public class VideoGamesController : Controller
    {
        private EsportsTrackerEntities1 db = new EsportsTrackerEntities1();

        // GET: VideoGames
        public ActionResult Index(int? page)
        {
            var games = from m in db.VideoGames
                        orderby m.GameName
                        select m;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(games.ToPagedList(pageNumber, pageSize));
        }

        // GET: VideoGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // GET: VideoGames/Create
        public ActionResult Create()
        {
            if (Session["LoggedIn"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameName,Released,Genre,Developer,Publisher,GameID")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.VideoGames.Add(videoGame);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e) {
                    @ViewBag.Error = "Could not process game";
                    return View();
                }
                return RedirectToAction("Index");
            }

            return View(videoGame);
        }

        // GET: VideoGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["LoggedIn"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameName,Released,Genre,Developer,Publisher,GameID")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoGame).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    @ViewBag.Error = "Could not process game changes";
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
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
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            db.VideoGames.Remove(videoGame);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                @ViewBag.Error = "Could not remove game record";
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
