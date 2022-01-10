using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private ISiteRepository _siteRepository;
        private IFloorRepository _floorRepository;
        private IWorkplaceRepository _workplaceRepository;
        private IEmployeeRepository _employeeRepository;
        private IReservationRepository _reservationRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ISiteRepository Site
        {
            get
            {
                if(_siteRepository == null)
                {
                    _siteRepository = new SiteRepository(_repositoryContext);
                }

                return _siteRepository;
            }
        }






        public IFloorRepository Floor => throw new System.NotImplementedException();

        public IWorkplaceRepository Workplace => throw new System.NotImplementedException();

        public IEmployeeRepository Employee => throw new System.NotImplementedException();

        public IReservationRepository Reservation => throw new System.NotImplementedException();

        public void Save() => _repositoryContext.SaveChanges();
    }
}
