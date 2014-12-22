using QverbITMS.Core.Data;
using QverbITMS.Core.Domain;
using QverbITMS.Data;
using QverbITMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Services
{
    public class IncidentCategoryService : IIncidentCategoryService
    {
        #region Fields

        private readonly IRepository<IncidentCategory> _repository;

        #endregion

         #region Constructors

        public IncidentCategoryService(IRepository<IncidentCategory> incidentCategoryRepository)
        {
            _repository = incidentCategoryRepository;
        }

        #endregion

        public IncidentCategory GetIncidentCategoryById(int Id)
        {
            if (Id == 0)
                return null;

            return _repository.GetById(Id);
        }

        public IList<IncidentCategory> GetAll()
        {
            return _repository.Table.ToList();
        }

        public IList<IncidentCategory> GetAllByStatus(bool active)
        {
            return _repository.GetByFilter(o => o.Active == active).ToList();
        }

        public void Insert(IncidentCategory category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _repository.Insert(category);

        }

        public void Update(IncidentCategory category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _repository.Update(category);
        }


        public void Delete(IncidentCategory category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _repository.Delete(category);
        }
    }
}
