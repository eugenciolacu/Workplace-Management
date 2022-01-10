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

        public IFloorRepository Floor
        {
            get
            {
                if (_floorRepository == null)
                {
                    _floorRepository = new FloorRepository(_repositoryContext);
                }

                return _floorRepository;
            }
        }

        public IWorkplaceRepository Workplace
        {
            get
            {
                if(_workplaceRepository == null)
                {
                    _workplaceRepository = new WorkplaceRepository(_repositoryContext);
                }

                return _workplaceRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if(_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                }

                return _employeeRepository;
            }
        }

        public IReservationRepository Reservation
        {
            get
            {
                if(_reservationRepository == null)
                {
                    _reservationRepository = new ReservationRepository(_repositoryContext);
                }

                return _reservationRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
