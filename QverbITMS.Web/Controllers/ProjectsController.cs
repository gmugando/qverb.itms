using QverbITMS.Core;
using QverbITMS.Core.Enums;
using QverbITMS.Core.Infrastructure;
using QverbITMS.Services.Interfaces;
using QverbITMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QverbITMS.Web.Extensions;
using QverbITMS.Core.Domain;

namespace QverbITMS.Web.Controllers
{
    public class ProjectsController : Controller
    {

        #region Fields

        private readonly IProjectManagementService _projectService;
        private readonly IIncidentCategoryService _categoryService;

        #endregion

        #region Constructors

        public ProjectsController(IProjectManagementService projectService, IIncidentCategoryService categoryService)
        {
            var user = EngineContext.Current.Resolve<IWorkContext>().CurrentUser;

            _projectService = projectService;
            _categoryService = categoryService;
        }
        #endregion

        //
        // GET: /Projects/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Projects()
        {
            ViewBag.Header = "Projects";
            ViewBag.SubHeader = "Manage";
            var projects = _projectService.GetProjects().ToList().Select(o => o.ToModel());

            return View(projects);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Header = "Create Project";
            ViewBag.SubHeader = "Manage";
            var projectVM = new ProjectVM();

            return View(projectVM);
        }

        [HttpPost]
        public ActionResult Create(ProjectVM projectVM)
        {

            if (ModelState.IsValid)
            {
                var user = EngineContext.Current.Resolve<IWorkContext>().CurrentUser;

                var project = projectVM.ToEntity();
                //project.ProjectOwner = user.Id.ToString(); ??
                project.DateCreated = DateTime.Now;
                project.CreatedBy = "Grant";
                _projectService.Insert(project);
            }

            return View(projectVM);
        }


        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ViewBag.Header = "Update Project";
            ViewBag.SubHeader = "Manage";
            
            var project = _projectService.GetProjectById(id);
            if (project == null)
                return HttpNotFound();

            var projectVM = project.ToModel();

            return View(projectVM);
        }

        [HttpPost]
        public ActionResult Edit(ProjectVM projectVM)
        {
            if (ModelState.IsValid)
            {
                var project = projectVM.ToEntity();
                _projectService.Update(project);
            }

            return View(projectVM);
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
