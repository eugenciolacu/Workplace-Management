using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.DtoOutput;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.Service.Service.Implementation
{
    public class WorkplaceService : IWorkplaceService
    {
        private ILoggerManager _logger;

        private IWorkplaceRepository _workplaceRepository;

        private IMapper _mapper;

        public WorkplaceService(ILoggerManager logger, IWorkplaceRepository workplaceRepository, IMapper mapper)
        {
            _logger = logger;
            _workplaceRepository = workplaceRepository;
            _mapper = mapper;
        }

        public Task<WorkplaceDto> DeleteWorkplace(long id)
        {
            return null;
        }

        public Task<WorkplaceDto> GetWorkplace(long id)
        {
            return null;
        }

        public Task<IEnumerable<WorkplaceDto>> GetWorkplaces()
        {
            return null;
        }

        public Task<WorkplaceDto> PostWorkplace(WorkplaceDto workplaceDto)
        {
            return null;
        }

        public Task<WorkplaceDto> PutWorkplace(long id, WorkplaceDto workplaceDto)
        {
            return null;
        }
    }
}
