using QverbITMS.Core;
using QverbITMS.Core.Domain;
using QverbITMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Services.Interfaces
{
   public interface IProjectManagementService
    {

        Project GetProjectById(int projectId);

        IPagedList<Project> GetProjectsByUser(int userId, DateTime? dateFrom, DateTime? dateTo, int pageIndex, int pageSize, bool showHidden = false);

        IList<Project> GetActiveProjects();

        void Insert(Project project);

        void Update(Project project);

        IQueryable<Project> GetProjectsByStatus(StatusEnum status);

        IQueryable<Project> GetProjects();

    }
}
