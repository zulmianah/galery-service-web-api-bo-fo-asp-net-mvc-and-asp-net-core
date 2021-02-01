using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bo.Controllers
{
    public class HouseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Galery by Anah.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Anah's contact page.";

            return View();
        }
    }
}