using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QverbITMS.Web.Controllers
{
    public class ProjectsController : Controller
    {
        //
        // GET: /Projects/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Tasks()
        {
            ViewBag.Header = "Tasks";
            ViewBag.SubHeader = "Manage";
            return View();
        }


        public ActionResult Calendar()
        {
            ViewBag.Header = "Calendar";
            ViewBag.SubHeader = "Manage";
            return View();
        }

    }
}
