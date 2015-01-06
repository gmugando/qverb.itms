using QverbITMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QverbITMS.Core.Domain;
using QverbITMS.Core.Data;

namespace QverbITMS.Services
{
    public class TaskCategoryService : ITaskCategoryService
    {

        #region Fields

        private readonly IRepository<TaskCategory> _repository;

        #endregion

        #region Constructors
        public TaskCategoryService(IRepository<TaskCategory> taskCategoryRepository)
        {
            _repository = taskCategoryRepository;
        }
        #endregion

        public TaskCategory GetIncidentCategoryById(int Id)
        {
            if (Id == 0)
                return null;

            return _repository.GetById(Id);
        }

        public IList<TaskCategory> GetAll()
        {
            return _repository.Table.ToList();
        }

        public IList<TaskCategory> GetAllByStatus(bool active)
        {
            return _repository.GetByFilter(o => o.Active == active).ToList();
        }

        public void Insert(TaskCategory category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _repository.Insert(category);
        }

        public void Update(TaskCategory category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _repository.Update(category);
        }

        public void Delete(TaskCategory category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _repository.Delete(category);
        }
    }
}
