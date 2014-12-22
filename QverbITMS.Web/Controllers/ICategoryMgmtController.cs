using QverbITMS.Core.Domain;
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
    public class ICategoryMgmtController : Controller
    {
        #region Fields

        private readonly IIncidentCategoryService _service;

        #endregion

          #region Constructors

        public ICategoryMgmtController(IIncidentCategoryService categoryService)
        {
            _service = categoryService;
        }

        #endregion

        //
        // GET: /IncidentCategory/
        [Authorize]
        public ActionResult Default()
        {
            ViewBag.Header = "Incident Categories";
            ViewBag.SubHeader = "Manage";

            var categories = _service.GetAll();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Header = "Create Incident Category";
            ViewBag.SubHeader = "Manage";
            var category = new IncidentCategoryVM();
            return View(category);
        }

        [HttpPost]
        public ActionResult Create(IncidentCategoryVM categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var catEntity = new IncidentCategory();
                catEntity.Category = categoryDTO.Category;
                catEntity.Descr = categoryDTO.Descr;
                catEntity.Active = categoryDTO.Active;
                _service.Insert(catEntity);
            }

            return View(categoryDTO);
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ViewBag.Header = "Edit Incident Category";
            ViewBag.SubHeader = "Manage";
            var catEntity = _service.GetIncidentCategoryById(Id);
            var categoryDTO = new IncidentCategoryVM();

            if (catEntity != null)
            {
                categoryDTO.Category = catEntity.Category;
                categoryDTO.Descr = catEntity.Descr;
                categoryDTO.Active = catEntity.Active;
                categoryDTO.Id = catEntity.Id;
            }
            return View(categoryDTO);
        }

        [HttpPost]
        public ActionResult Edit(IncidentCategoryVM categoryDTO)
        {
            ViewBag.Header = "Edit Incident Category";
            ViewBag.SubHeader = "Manage";

            if (ModelState.IsValid)
            {
                var catEntity = new IncidentCategory();
                catEntity.Id = categoryDTO.Id;
                catEntity.Category = categoryDTO.Category;
                catEntity.Descr = categoryDTO.Descr;
                catEntity.Active = categoryDTO.Active;
                _service.Update(catEntity);
            }

            return View(categoryDTO);
        }


        [HttpGet]
        public ActionResult Delete(int Id)
        {
            ViewBag.Header = "Delete Incident Category";
            ViewBag.SubHeader = "Manage";
            var catEntity = _service.GetIncidentCategoryById(Id);
            var categoryDTO = new IncidentCategoryVM();

            if (catEntity != null)
            {
                categoryDTO.Category = catEntity.Category;
                categoryDTO.Descr = catEntity.Descr;
                categoryDTO.Active = catEntity.Active;
                categoryDTO.Id = catEntity.Id;
            }
            return View(categoryDTO);
        }

        [HttpPost]
        public ActionResult Delete(IncidentCategoryVM categoryDTO)
        {
            ViewBag.Header = "Delete Incident Category";
            ViewBag.SubHeader = "Manage";

            if (ModelState.IsValid)
            {
                var catEntity = new IncidentCategory();
                catEntity.Id = categoryDTO.Id;
                catEntity.Category = categoryDTO.Category;
                catEntity.Descr = categoryDTO.Descr;
                catEntity.Active = categoryDTO.Active;
                _service.Delete(catEntity);
            }

            return View(categoryDTO);
        }

    }
}
