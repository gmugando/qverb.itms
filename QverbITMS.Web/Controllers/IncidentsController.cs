using QverbITMS.Core.Domain;
using QverbITMS.Services;
using QverbITMS.Services.Interfaces;
using QverbITMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace QverbITMS.Web.Controllers
{
    public class IncidentsController : Controller
    {

        #region Fields

        private readonly IIncidentService _incidentService;

        #endregion

        #region Constructors

        public IncidentsController()
        {
            _incidentService = new IncidentService();
        }

        #endregion
        //
        // GET: /Incidents/

        public ActionResult Index()
        {
            var incidents = _incidentService.GetIncidentsByUser(1, null, null, 1, 10);
            var x = incidents;
            return View();
        }


        public ActionResult Default()
        {
            var incidents = _incidentService.GetActiveIncidents();
            var x = incidents;
            return View(incidents);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var incidentVM = new IncidentVM();
            return View(incidentVM);
        }

        [HttpPost]
        public ActionResult Create(IncidentVM incidentVM)
        {
            if (ModelState.IsValid)
            {
                var incident = new Incident();
                incident.Name = incidentVM.Name;
                incident.Descr = incidentVM.Descr;
                incident.LoggedBy = User.Identity.Name;
                incident.LoggedDate = DateTime.Now;
                incident.PercentageComplete = Convert.ToInt32(incidentVM.PercentageComplete);
                incident.Status = false;

                _incidentService.Insert(incident);
            }

            return View(incidentVM);
        }

        public ActionResult GenerateTemplate()
        {
            var incident = new IncidentVM();
            return View(incident);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

    }
}
