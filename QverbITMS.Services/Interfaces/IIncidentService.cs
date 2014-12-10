using QverbITMS.Core;
using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QverbITMS.Services.Interfaces
{
    public interface IIncidentService
    {
        Incident GetIncidentById(int incidentId);

        IPagedList<Incident> GetIncidentsByUser(int userId, DateTime? dateFrom, DateTime? dateTo, int pageIndex, int pageSize, bool showHidden = false);

        IList<Incident> GetActiveIncidents();

        void Insert(Incident incident);

        void Update(Incident incident);
    }
}
