using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.Dto;
using WorkplaceManagement.Service.Interface;

namespace WorkplaceManagement.Service.Implementation
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository _floorRepository;

        private readonly IMapper _mapper;

        public FloorService(IFloorRepository floorRepository, IMapper mapper)
        {
            _floorRepository = floorRepository;
            _mapper = mapper;
        }

        public async Task<FloorDto> DeleteFloor(long id)
        {
            Floor toDelete = await _floorRepository.GetAsync(id);
            await _floorRepository.DeleteAsync(toDelete);

            return _mapper.Map<FloorDto>(toDelete);
        }

        public async Task<FloorDto> GetFloor(long id)
        {
            Floor result = await _floorRepository.GetAsync(id);

            if(result == null)
            {
                throw new Exception("Floor not found, implement separate exception later");
            }

            return _mapper.Map<FloorDto>(result);
        }

        public async Task<IEnumerable<FloorDto>> GetFloors()
        {
            ICollection<Floor> result = await _floorRepository.GetAllAsync();

            return _mapper.Map<List<FloorDto>>(result);
        }

        public async Task<FloorDto> PostFloor(FloorDto floorDto)
        {
            Floor floor = _mapper.Map<Floor>(floorDto);

            Floor result = await _floorRepository.AddAsync(floor);

            return _mapper.Map<FloorDto>(result);
        }

        public async Task<FloorDto> PutFloor(long id, FloorDto floorDto)
        {
            Floor toUpdate = await _floorRepository.GetAsync(id);
            toUpdate.Name = floorDto.Name;

            Floor result = await _floorRepository.UpdateAsync(toUpdate, toUpdate.Id);

            return _mapper.Map<FloorDto>(result);
        }
    }
}
