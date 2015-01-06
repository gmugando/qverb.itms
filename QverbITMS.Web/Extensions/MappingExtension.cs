using QverbITMS.Core.Domain;
using QverbITMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QverbITMS.Web.Extensions
{
    public static class MappingExtension
    {
        //project
        public static ProjectVM ToModel(this Project entity)
        {
            if (entity == null)
                return null;

            var model = new ProjectVM()
            {
                Id = entity.Id,
                CreatedBy = entity.CreatedBy,
                DateCreated = entity.DateCreated,
                Descr = entity.Descr,
                EndDate = entity.EndDate,
                Name = entity.Name,
                Priority = entity.Priority,
                ProjectOwner = entity.ProjectOwner,
                StartDate = entity.StartDate,
                Status = entity.Status
            };

            return model;
        }

        //project
        public static Project ToEntity(this ProjectVM projectModel)
        {
            if (projectModel == null)
                return null;

            var model = new Project()
            {
                Id = projectModel.Id,
                CreatedBy = projectModel.CreatedBy,
                DateCreated = projectModel.DateCreated,
                Descr = projectModel.Descr,
                EndDate = projectModel.EndDate,
                Name = projectModel.Name,
                Priority = projectModel.Priority,
                ProjectOwner = projectModel.ProjectOwner,
                StartDate = projectModel.StartDate,
                Status = projectModel.Status
            };

            return model;
        }


        public static void PrepareModel(this DashboardVM dashboardModel)
        {
            if (dashboardModel == null)
                return;


        }

    }
}