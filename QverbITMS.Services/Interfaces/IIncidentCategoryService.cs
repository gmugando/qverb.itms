using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Services.Interfaces
{
    public interface IIncidentCategoryService
    {
        IncidentCategory GetIncidentCategoryById(int Id);

        IList<IncidentCategory> GetAll();

        IList<IncidentCategory> GetAllByStatus(bool active);

        void Insert(IncidentCategory category);

        void Update(IncidentCategory category);

        void Delete(IncidentCategory category);
    }
}
