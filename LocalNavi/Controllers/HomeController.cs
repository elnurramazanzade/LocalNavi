using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using LocalNavi.DAL;
using LocalNavi.Models;

namespace LocalNavi.Controllers
{
    public class HomeController : Controller
    {
        private readonly Navi db = new Navi();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                Session["LoginError"] = "E-mail və ya Şifrə boş olmamalıdır!";
                return RedirectToAction("index");
            }

            User usr = db.Users.FirstOrDefault(u => u.Email == user.Email);
            if (usr != null)
            {
                if (Crypto.VerifyHashedPassword(usr.Password, user.Password))
                {
                    Session["UserLogin"] = true;
                    Session["UserId"] = usr.Id;
                    return RedirectToAction("index", "home");
                }
            }

            Session["LoginError"] = "Login və ya Şifrə yanlışdır!";
            return RedirectToAction("index");
        }

        public ActionResult Logout()
        {
            Session["UserLogin"] = null;
            Session["UserId"] = null;
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Surname) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                Session["RegisterError"] = "Məlumatlar boş olmamalıdır!";
                return RedirectToAction("index");
            }

            if (db.Users.FirstOrDefault(u => u.Email == user.Email) != null)
            {
                Session["RegisterError"] = "Bu e-mail artıq qeydiyyata alınıb!";
                return RedirectToAction("index");
            }

            User usr = new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Password = Crypto.HashPassword(user.Password),
                Status = true
            };
            db.Users.Add(usr);
            db.SaveChanges();

            Session["UserLogin"] = true;
            Session["UserId"] = usr.Id;
            Session["RegisterSuccess"] = "Qeydiyyat tamamlandı!";
            return RedirectToAction("index");
        }
    }
}