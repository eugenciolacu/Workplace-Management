using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.Dto;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.Service.Service.Implementation
{
    public class FloorService : IFloorService
    {
        private ILoggerManager _logger;

        private IFloorRepository _floorRepository;

        private IMapper _mapper;

        public FloorService(ILoggerManager logger, IFloorRepository floorRepository, IMapper mapper)
        {
            _logger = logger;
            _floorRepository = floorRepository;
            _mapper = mapper;
        }

        public Task<FloorDto> DeleteFloor(long id)
        {
            return null;
        }

        public Task<FloorDto> GetFloor(long id)
        {
            return null;
        }

        public Task<IEnumerable<FloorDto>> GetFloors()
        {
            return null;
        }

        public Task<FloorDto> PostFloor(FloorDto floorDto)
        {
            return null;
        }

        public Task<FloorDto> PutFloor(long id, FloorDto floorDto)
        {
            return null;
        }
    }
}
