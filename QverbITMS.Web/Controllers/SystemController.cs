using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QverbITMS.Web.Controllers
{
    public class SystemController : Controller
    {
        //
        // GET: /System/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Header = "Users";
            ViewBag.SubHeader = "Manage";
            return View();
        }

        public ActionResult TaskCategories()
        {
            ViewBag.Header = "Task Categories";
            ViewBag.SubHeader = "Manage";
            return View();
        }

        public ActionResult IncidentCategories()
        {
            ViewBag.Header = "Incident Categories";
            ViewBag.SubHeader = "Manage";
            return View();
        }

        public ActionResult Sites()
        {
            ViewBag.Header = "Sites";
            ViewBag.SubHeader = "Manage";
            return View();
        }



    }
}
