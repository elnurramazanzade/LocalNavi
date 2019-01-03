using LocalNavi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocalNavi.DAL;
using LocalNavi.Models;

namespace LocalNavi.Controllers
{
    public class AddPlaceController : Controller
    {
        private readonly Navi db = new Navi();
        public ViewPlace model = new ViewPlace();
        public string[] Weekdays ={ "Bazar ertəsi",
                                    "Çərşənbə axşamı",
                                    "Çərşənbə",
                                    "Cümə axşamı",
                                    "Cümə",
                                    "Şənbə",
                                    "Bazar" };

        // GET: AddPlace
        [AuthUser]
        public ActionResult Index()
        {
            model.Categories = db.Categories.ToList();
            model.Cities = db.Cities.ToList();

            ViewBag.Weekdays = Weekdays;

            return View(model);
        }

        public ActionResult Services(int id)
        {
            Category category = db.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            string serv = "";
            foreach(var item in db.CategoryServices.Where(cs => cs.CategoryID == id).ToList())
            {
                serv += "<option value='" + item.ServiceID + "'>" + item.Service.Name + "</option>";
            }

            return Content(serv);
        }

        public JsonResult ServicesJson(int id)
        {
            Category category = db.Categories.Find(id);

            if (category == null)
            {
                return Json(new { Status = 404 }, JsonRequestBehavior.AllowGet);
            }

            var response = db.CategoryServices.Where(cs => cs.CategoryID == id).Select(cs => new { cs.ServiceID, cs.Service.Name }).ToList();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}