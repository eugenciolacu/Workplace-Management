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
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public FloorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<FloorDto> DeleteFloor(long id)
        {
            return null;
        }

        public FloorDto GetFloor(long siteId, long id, bool trackChanges)
        {
            Floor floor = _repository.Floor.GetFloor(siteId, id, trackChanges);

            FloorDto floorDto = _mapper.Map<FloorDto>(floor);

            return floorDto;
        }

        public IEnumerable<FloorDto> GetFloors(long siteId, bool trackChanges)
        {
            IEnumerable<Floor> floors = _repository.Floor.GetFloors(siteId, trackChanges);

            IEnumerable<FloorDto> floorDtos = _mapper.Map<IEnumerable<FloorDto>>(floors);

            return floorDtos;
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
