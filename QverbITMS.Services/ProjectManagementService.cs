using QverbITMS.Services.Interfaces;
using QverbITMS.Core;
using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QverbITMS.Core.Data;
using QverbITMS.Core.Enums;

namespace QverbITMS.Services
{
    public class ProjectManagementService : IProjectManagementService
    {

        #region Fields

        private readonly IRepository<Project> _projectRepository;

        #endregion

        #region Constructors

        public ProjectManagementService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        #endregion

        public Project GetProjectById(int projectId)
        {
            if (projectId == 0)
                return null;

            return _projectRepository.GetById(projectId);
        }

        public IPagedList<Project> GetProjectsByUser(int userId, DateTime? dateFrom, DateTime? dateTo, int pageIndex, int pageSize, bool showHidden = false)
        {
            var query = _projectRepository.Table;
            if (dateFrom.HasValue)
                query = query.Where(b => dateFrom.Value <= b.StartDate);
            if (dateTo.HasValue)
                query = query.Where(b => dateTo.Value >= b.EndDate);

            query = query.OrderByDescending(b => b.DateCreated);

            var projects = new PagedList<Project>(query, pageIndex, pageSize);
            return projects;
        }

        public IList<Project> GetActiveProjects()
        {
            var query = from ft in _projectRepository.Table
                        select ft;

            query = query.OrderByDescending(b => b.CreatedBy);
            return query.ToList();
        }

        public void Insert(Project project)
        {
            if (project == null)
                throw new ArgumentNullException("project");

            _projectRepository.Insert(project);
        }

        public void Update(Project project)
        {
            if (project == null)
                throw new ArgumentNullException("project");

            _projectRepository.Update(project);
        }

        public IQueryable<Project> GetProjectsByStatus(StatusEnum status)
        {
            return _projectRepository.GetByFilter(o => o.Status == status);
        }

        public IQueryable<Project> GetProjects()
        {
            return _projectRepository.Table;
        }

    }
}
