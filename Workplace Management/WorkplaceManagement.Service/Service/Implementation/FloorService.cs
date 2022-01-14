using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;
using WorkplaceManagement.Service.DtoUpdate;
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

        public void DeleteFloor(long siteId, long id, bool trackChanges)
        {
            Floor floorForSite = _repository.Floor.GetFloor(siteId, id, trackChanges);

            _repository.Floor.DeleteFloor(floorForSite);

            _repository.Save();
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

        public FloorDto CreateFloor(long siteId, FloorForCreationDto floor)
        {
            var floorEntity = _mapper.Map<Floor>(floor);

            _repository.Floor.CreateFloor(siteId, floorEntity);

            _repository.Save();

            return _mapper.Map<FloorDto>(floorEntity);
        }

        public FloorDto UpdateFloorForSite(long siteId, long id, FloorForUpdateDto floor, bool trackChanges)
        {
            Floor floorEntity = _repository.Floor.GetFloor(siteId, id, trackChanges);

            _mapper.Map(floor, floorEntity);

            _repository.Save();

            return _mapper.Map<FloorDto>(floorEntity);
        }

        public FloorDto PartiallyUpdateFloorForSite(long siteId, long id, JsonPatchDocument<FloorForUpdateDto> patchDoc, bool trackChanges)
        {
            Floor floorEntity = _repository.Floor.GetFloor(siteId, id, trackChanges);

            FloorForUpdateDto floorToPatch = _mapper.Map<FloorForUpdateDto>(floorEntity);
            patchDoc.ApplyTo(floorToPatch);
            _mapper.Map(floorToPatch, floorEntity);

            _repository.Save();

            return _mapper.Map<FloorDto>(floorEntity);
        }
    }
}
