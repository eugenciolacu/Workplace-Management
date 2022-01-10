using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Context;
using WorkplaceManagement.Domain.Model;

namespace WorkplaceManagement.Dal.Repository.Implementation
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository // GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
