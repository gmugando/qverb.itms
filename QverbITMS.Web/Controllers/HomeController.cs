using QverbITMS.Services;
using QverbITMS.Services.Interfaces;
using QverbITMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QverbITMS.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Fields

        private readonly IIncidentService _incidentService;

        #endregion

         #region Constructors

        public HomeController()
        {
            //todo : use DI
            _incidentService = new IncidentService();
        }

        #endregion


        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Dashboard";
            ViewBag.Header = "Dashboard";
            ViewBag.SubHeader = "Manage";

            DashboardVM dash = new DashboardVM();
            dash.NewIncidents = _incidentService.GetActiveIncidents().Count();
            dash.ResolvedIncidents = _incidentService.GetIncidentsPercentageByStatus(true);
            dash.UserReg = 10;


            return View(dash);
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Qverb.ITMS";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
