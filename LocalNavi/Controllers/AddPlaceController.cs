using LocalNavi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalNavi.Controllers
{
    public class AddPlaceController : Controller
    {
        // GET: AddPlace
        [AuthUser]
        public ActionResult Index()
        {
            return View();
        }
    }
}