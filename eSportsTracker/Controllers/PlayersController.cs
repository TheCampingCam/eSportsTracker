using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using eSportsTracker.Models;
using PagedList;

namespace eSportsTracker.Controllers
{
    public class PlayersController : Controller
    {
        private EsportsTrackerEntities1 db = new EsportsTrackerEntities1();

        // GET: Players
        public ActionResult Index(string currentFilter, string searchString, string sortOrder, int? page)
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

            ViewBag.CurrentFilter = searchString;

            var players = from m in db.PlayerWithWins
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.Handle.Contains(searchString) || s.FName.Contains(searchString) || s.LName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    players = players.OrderByDescending(s => s.Handle);
                    break;
                default:
                    players = players.OrderBy(s => s.PlayerID);
                    break;
            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(players.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult PlayersByGame(string currentFilter, string searchString, string sortOrder, int? page)
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

            ViewBag.CurrentFilter = searchString;

            var players = (from m in db.PlayersInGames
                          select m).Distinct();

            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.Winner.Contains(searchString) || s.FName.Contains(searchString) || s.LName.Contains(searchString) || s.GameName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    players = players.OrderByDescending(s => s.Winner);
                    break;
                default:
                    players = players.OrderBy(s => s.Winner);
                    break;
            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(players.ToPagedList(pageNumber, pageSize));
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            if (Session["LoggedIn"] == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Handle,DOB,LName,FName,PlayerID")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    @ViewBag.Error = "Could not create player";
                    return View();
                }
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Players/Edit/5
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
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Handle,DOB,LName,FName,PlayerID")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    @ViewBag.Error = "Could not process player change";
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
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
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                @ViewBag.Error = "Could not remove player records";
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
