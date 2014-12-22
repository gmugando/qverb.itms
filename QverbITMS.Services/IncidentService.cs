using QverbITMS.Core;
using QverbITMS.Core.Data;
using QverbITMS.Core.Domain;
using QverbITMS.Data;
using QverbITMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace QverbITMS.Services
{
    public class IncidentService : IIncidentService
    {

        #region Fields
        
        private readonly IRepository<Incident> _incidentRepository;

        #endregion

        #region Fields

        #region Constructors

        public IncidentService(IRepository<Incident> incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        #endregion

        public Incident GetIncidentById(int incidentId)
        {
            if (incidentId == 0)
                return null;

            return _incidentRepository.GetById(incidentId, "Category");
        }

        public virtual IPagedList<Incident> GetIncidentsByUser(int userId, DateTime? dateFrom, DateTime? dateTo, int pageIndex, int pageSize, bool showHidden)
        {
            var query = _incidentRepository.Table;
            if (dateFrom.HasValue)
                query = query.Where(b => dateFrom.Value <= b.LoggedDate);
            if (dateTo.HasValue)
                query = query.Where(b => dateTo.Value >= b.LoggedDate);

            query = query.OrderByDescending(b => b.LoggedDate);

            var incidents = new PagedList<Incident>(query, pageIndex, pageSize);
            return incidents;
        }

        public IList<Incident> GetActiveIncidents()
        {
            //var query = _incidentRepository.Table;

            var query = from ft in _incidentRepository.Table
                         select ft;
            //query = query.Where(o => o.Status == true);
            query = query.OrderByDescending(b => b.LoggedDate);
            var incidents = new PagedList<Incident>(query, 1 , 1000);
            return query.ToList();
        }

        /// <summary>
        /// Inserts an incident
        /// </summary>
        /// <param name="incident"></param>
        public void Insert(Incident incident) 
        {
            if (incident == null)
                throw new ArgumentNullException("incident");

            _incidentRepository.Insert(incident);

            //event notification
            //_eventPublisher.EntityInserted(incident);
        }

        public void Update(Incident incident) 
        {
            if (incident == null)
                throw new ArgumentNullException("incident");

            _incidentRepository.Update(incident);

            //event notification
            //_eventPublisher.EntityUpdated(incident);
        }


        public IQueryable<Incident> GetIncidentsByStatus(bool status)
        {
            return _incidentRepository.GetByFilter(o => o.Status == status);
        }


        public Int32 GetIncidentsPercentageByStatus(bool status)
        {
            var statusCount = _incidentRepository.GetByFilter(o => o.Status == status).Count();
            var all = _incidentRepository.Table.Count();
            if (statusCount == 0)
            {
                return 0;
            }
            else
            {
                return (statusCount * 100) / all ;
            }


        }

        #endregion
    }
}
