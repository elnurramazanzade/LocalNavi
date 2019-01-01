using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocalNavi.DAL;
using LocalNavi.Models;
using System.Web.Helpers;
using LocalNavi.Helper;

namespace LocalNavi.Areas.Manage.Controllers
{
    public class AdminController : Controller
    {
        private readonly Navi db = new Navi();

        // GET: Manage/Admin
        public ActionResult Index()
        {
            return View();
        }

        // POST: Manage/Login
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            if (string.IsNullOrEmpty(admin.Login) || string.IsNullOrEmpty(admin.Password))
            {
                Session["LoginError"] = "Login və ya Şifrə boş olmamalıdır!";
                return RedirectToAction("index");
            }

            Admin adm = db.Admins.FirstOrDefault(a => a.Login == admin.Login);
            if (adm != null)
            {
                if (Crypto.VerifyHashedPassword(adm.Password, admin.Password))
                {
                    Session["Admin"] = adm.Name + " " + adm.Surname;
                    Session["AdminLogin"] = true;
                    return RedirectToAction("login", "admin");
                }
            }

            Session["LoginError"] = "Login və ya Şifrə yanlışdır!";
            return RedirectToAction("index");
        }

        // GET: Manage/Login
        [AuthAdmin]
        public ActionResult Login()
        {
            return View();
        }

        // GET: Manage/Logout
        public ActionResult Logout()
        {
            Session["AdminLogin"] = null;
            return RedirectToAction("index");
        }
    }
}