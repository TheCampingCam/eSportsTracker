using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eSportsTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "CSSE 333 Database Project: eSportsTracker";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Email:";

            return View();
        }
    }
}