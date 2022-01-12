using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Service.DtoOutput;

namespace WorkplaceManagement.Service.Service.Interface
{
    public interface IWorkplaceService
    {
        Task<WorkplaceDto> DeleteWorkplace(long id);

        Task<WorkplaceDto> GetWorkplace(long id);

        Task<IEnumerable<WorkplaceDto>> GetWorkplaces();

        Task<WorkplaceDto> PostWorkplace(WorkplaceDto workplace);

        Task<WorkplaceDto> PutWorkplace(long id, WorkplaceDto workplace);
    }
}
