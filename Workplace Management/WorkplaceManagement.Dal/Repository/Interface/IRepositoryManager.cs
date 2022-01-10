namespace WorkplaceManagement.Dal.Repository.Interface
{
    public interface IRepositoryManager
    {
        ISiteRepository Site { get; }
        IFloorRepository Floor { get; }
        IWorkplaceRepository Workplace { get; }
        IEmployeeRepository Employee { get; }
        IReservationRepository Reservation { get; }
        void Save();
    }
}
