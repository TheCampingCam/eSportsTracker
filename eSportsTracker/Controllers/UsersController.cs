using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using eSportsTracker.Models;

namespace eSportsTracker.Controllers
{
    public class UsersController : Controller
    {
        private EsportsTrackerEntities1 db = new EsportsTrackerEntities1();

        // GET: Users/Create
        public ActionResult Create()
        {
            if (Session["LoggedIn"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(String username, String password)
        {
            if (Session["LoggedIn"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            Models.User user = new Models.User();
            user.Username = username;

            byte[] salt = CreateSalt(16);
            user.PasswordSalt = Convert.ToBase64String(salt);
            user.PasswordHash = Convert.ToBase64String(GenerateSaltedHash(password, salt));

            System.Security.Principal.IIdentity test = User.Identity;

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                Response.Cookies["Username"].Value = username;
                Response.Cookies["Username"].Expires = DateTime.Now.AddMinutes(30);

                Session["LoggedIn"] = "yes";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View(user);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(String username, String password)
        {
            Models.User user = db.Users.Find(username);

            byte[] salt = Convert.FromBase64String(user.PasswordSalt);
            if (user.PasswordHash.Equals(Convert.ToBase64String(GenerateSaltedHash(password, salt))))
            {
                Response.Cookies["Username"].Value = username;
                Response.Cookies["Username"].Expires = DateTime.Now.AddMinutes(60);

                Session["LoggedIn"] = "yes";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return RedirectToAction("Home/Index");
        }

        public ActionResult LogOut()
        {
            Response.Cookies["Username"].Value = null;
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private static byte[] CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[size];
            rng.GetBytes(salt);

            // Return a Base64 string representation of the random number.
            return salt;
        }

        private static byte[] GenerateSaltedHash(string password, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainText = Encoding.UTF8.GetBytes(password);

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

    }
}
