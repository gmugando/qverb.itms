using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Services.Interfaces
{
    public interface ITaskCategoryService
    {
        TaskCategory GetIncidentCategoryById(int Id);

        IList<TaskCategory> GetAll();

        IList<TaskCategory> GetAllByStatus(bool active);

        void Insert(TaskCategory category);

        void Update(TaskCategory category);

        void Delete(TaskCategory category);
    }
}
