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

        // GET: Services
        public JsonResult ServicesJson(int id)
        {
            Category category = db.Categories.Find(id);

            if (category == null)
            {
                return Json(new { Status = 404 }, JsonRequestBehavior.AllowGet);
            }

            var services = db.CategoryServices.Where(cs => cs.CategoryID == id).Select(cs => new { cs.ServiceID, cs.Service.Name }).ToList();
            return Json(services, JsonRequestBehavior.AllowGet);
        }

        // GET: CheckPlace
        public JsonResult CheckPlace(string Name)
        {
            if (db.Places.FirstOrDefault(p => p.Name == Name) != null)
            {
                return Json(new
                {
                    valid = false,
                    message = "Bu adda məkan qeydiyyata alınıb"
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                valid = true
            }, JsonRequestBehavior.AllowGet);
        }

        // POST: Add New Place
        public JsonResult AddNewPlace(Place place)
        {
            if(string.IsNullOrEmpty(place.Name)|| string.IsNullOrEmpty(place.Slogan) || string.IsNullOrEmpty(place.Desc) || string.IsNullOrEmpty(place.Address) || string.IsNullOrEmpty(place.Phone) || string.IsNullOrEmpty(place.Website) || string.IsNullOrEmpty(place.Name))
            {
                return Json(new
                {
                    status = 401,
                    message = "* ilə işarələnmiş məlumatlar boş ola bilməz"
                }, JsonRequestBehavior.AllowGet);
            }

            if(place.CategoryID==0|| place.CityID == 0|| place.UserID == 0)
            {
                return Json(new
                {
                    status = 402,
                    message = "Seçim qutularından seçim edilməlidir"
                }, JsonRequestBehavior.AllowGet);
            }

            if (db.Places.FirstOrDefault(p => p.Name == place.Name) != null)
            {
                return Json(new
                {
                    status = 414,
                    message = "Bu adda məkan qeydiyyata alınıb"
                }, JsonRequestBehavior.AllowGet);
            }

            db.Places.Add(place);
            db.SaveChanges();

            return Json(new
            {
                status = 200,
                message = "Məkan qeydiyyata alındı"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}