using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QverbITMS.Web.Controllers
{
    public class ChartsController : Controller
    {
        //
        // GET: /Charts/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incidents()
        {
            ViewBag.Header = "Incidents";
            ViewBag.SubHeader = "Manage";
            return View();
        }

        public ActionResult Accidents()
        {
            ViewBag.Header = "Accidents";
            ViewBag.SubHeader = "Manage";
            return View();
        }

        public ActionResult Tasks()
        {
            ViewBag.Header = "Tasks";
            ViewBag.SubHeader = "Manage";
            return View();
        }




    }
}
