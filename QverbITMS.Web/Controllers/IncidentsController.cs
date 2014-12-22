using QverbITMS.Core;
using QverbITMS.Core.Domain;
using QverbITMS.Core.Infrastructure;
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
        private readonly IIncidentCategoryService _categoryService;

        #endregion

        #region Constructors

        public IncidentsController(IIncidentService incidentService, IIncidentCategoryService categoryService)
        {
            var user = EngineContext.Current.Resolve<IWorkContext>().CurrentUser;

            _incidentService = incidentService;
            _categoryService = categoryService;
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
            ViewBag.Header = "Incidents";
            ViewBag.SubHeader = "Manage";

            var incidents = _incidentService.GetActiveIncidents();
            var x = incidents;
            return View(incidents);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Header = "Create Incident";
            ViewBag.SubHeader = "Manage";
            var incidentVM = new IncidentVM();
            // Here we are selecting all the available categories
            // from the database and projecting them to the IEnumerable<SelectListItem>
            incidentVM.Categories = _categoryService.GetAllByStatus(true).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Category
            });
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
                incident.ActionTaken = "-";
                incident.Category = _categoryService.GetIncidentCategoryById(incidentVM.Category_Id);
                incident.IncidentDate = incidentVM.IncidentDate;
                incident.IncidentTime = incidentVM.IncidentTime;
                incident.Location = incidentVM.Location;
                incident.Priority = incidentVM.Priority;

                _incidentService.Insert(incident);
            }

            // Here we are selecting all the available categories
            // from the database and projecting them to the IEnumerable<SelectListItem>
            incidentVM.Categories = _categoryService.GetAllByStatus(true).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Category
            });

            return View(incidentVM);
        }

        public ActionResult GenerateTemplate()
        {
            var incident = new IncidentVM();
            return View(incident);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ViewBag.Header = "Update Incident";
            ViewBag.SubHeader = "Manage";
            var incidentVM = new IncidentVM();
            var incident = _incidentService.GetIncidentById(id);
            if (incident == null)
                return HttpNotFound();

            incidentVM.Id = incident.Id;
            incidentVM.Name = incident.Name;
            incidentVM.Descr = incident.Descr;
            incidentVM.LoggedBy = incident.LoggedBy;
            incidentVM.LoggedDate = incident.LoggedDate;
            incidentVM.PercentageComplete = incident.PercentageComplete;
            incidentVM.Status = incident.Status;
            incidentVM.Location = incident.Location;
            incidentVM.IncidentDate = incident.IncidentDate;
            incidentVM.IncidentTime = incident.IncidentTime;
            incidentVM.Category_Id = incident.Category.Id;
            incidentVM.Category = incident.Category;
            incidentVM.Priority = incident.Priority;

            // Here we are selecting all the available categories
            // from the database and projecting them to the IEnumerable<SelectListItem>
            incidentVM.Categories = _categoryService.GetAllByStatus(true).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Category
            });

            return View(incidentVM);
        }

        [HttpPost]
        public ActionResult Edit(IncidentVM incidentVM)
        {
            if (ModelState.IsValid)
            {
                var incident = new Incident();
                incident.Id = incidentVM.Id;              
                incident.Name = incidentVM.Name;
                incident.Descr = incidentVM.Descr;
                incident.LoggedBy = User.Identity.Name;
                incident.LoggedDate = DateTime.Now;
                incident.PercentageComplete = Convert.ToInt32(incidentVM.PercentageComplete);
                incident.Status = false;
                incident.ActionTaken = "-";
                incident.IncidentDate = incidentVM.IncidentDate;
                incident.IncidentTime = incidentVM.IncidentTime;
                incident.Location = incidentVM.Location;
                incident.Priority = incidentVM.Priority;

                incident.Category = _categoryService.GetIncidentCategoryById(incidentVM.Category_Id);
                incident.Category.Id = incidentVM.Category_Id;
                incident.Category_Id = incidentVM.Category_Id;

                _incidentService.Update(incident);
            }

            // Here we are selecting all the available categories
            // from the database and projecting them to the IEnumerable<SelectListItem>
            incidentVM.Categories = _categoryService.GetAllByStatus(true).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Category
            });

            return View(incidentVM);
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
