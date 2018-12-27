using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalNavi.Areas.Manage.Controllers
{
    public class AdminController : Controller
    {
        // GET: Manage/Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Manage/Login
        public ActionResult Login()
        {
            return View();
        }
    }
}