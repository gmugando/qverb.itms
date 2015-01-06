using QverbITMS.Core.Domain;
using QverbITMS.Services;
using QverbITMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QverbITMS.Web.Controllers
{
    public class TaskCategoryController : Controller
    {
        #region Fields

        private readonly ITaskCategoryService _service;

        #endregion

        #region Constructors

        public TaskCategoryController(ITaskCategoryService categoryService)
        {
            _service = categoryService;
        }

        #endregion


        [Authorize]
        public ActionResult Default()
        {
            ViewBag.Header = "Task Categories";
            ViewBag.SubHeader = "Manage";

            var categories = _service.GetAll();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Header = "Create Task Category";
            ViewBag.SubHeader = "Manage";
            var category = new TaskCategory();
            return View(category);
        }

        [HttpPost]
        public ActionResult Create(TaskCategory category)
        {
            if (ModelState.IsValid)
            {
                _service.Insert(category);
            }

            return View(category);
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ViewBag.Header = "Edit Task Category";
            ViewBag.SubHeader = "Manage";
            var catEntity = _service.GetIncidentCategoryById(Id);
            //var categoryDTO = new IncidentCategoryVM();

            //if (catEntity != null)
            //{
            //    categoryDTO.Category = catEntity.Category;
            //    categoryDTO.Descr = catEntity.Descr;
            //    categoryDTO.Active = catEntity.Active;
            //    categoryDTO.Id = catEntity.Id;
            //}
            return View(catEntity);
        }

        [HttpPost]
        public ActionResult Edit(TaskCategory category)
        {
            ViewBag.Header = "Edit Task Category";
            ViewBag.SubHeader = "Manage";

            if (ModelState.IsValid)
            {
                //var catEntity = new IncidentCategory();
                //catEntity.Id = categoryDTO.Id;
                //catEntity.Category = categoryDTO.Category;
                //catEntity.Descr = categoryDTO.Descr;
                //catEntity.Active = categoryDTO.Active;
                _service.Update(category);
            }

            return View(category);
        }


        [HttpGet]
        public ActionResult Delete(int Id)
        {
            ViewBag.Header = "Delete Task Category";
            ViewBag.SubHeader = "Manage";
            var catEntity = _service.GetIncidentCategoryById(Id);
            //var categoryDTO = new IncidentCategoryVM();

            //if (catEntity != null)
            //{
            //    categoryDTO.Category = catEntity.Category;
            //    categoryDTO.Descr = catEntity.Descr;
            //    categoryDTO.Active = catEntity.Active;
            //    categoryDTO.Id = catEntity.Id;
            //}
            return View(catEntity);
        }

        [HttpPost]
        public ActionResult Delete(TaskCategory category)
        {
            ViewBag.Header = "Delete Task Category";
            ViewBag.SubHeader = "Manage";

            if (ModelState.IsValid)
            {
                //var catEntity = new IncidentCategory();
                //catEntity.Id = categoryDTO.Id;
                //catEntity.Category = categoryDTO.Category;
                //catEntity.Descr = categoryDTO.Descr;
                //catEntity.Active = categoryDTO.Active;
                _service.Delete(category);
            }

            return View(category);
        }

    }
}
