using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.Dto;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.Service.Service.Implementation
{
    public class WorkplaceService : IWorkplaceService
    {
        private readonly IWorkplaceRepository _workplaceRepository;

        private readonly IMapper _mapper;

        public WorkplaceService(IWorkplaceRepository workplaceRepository, IMapper mapper)
        {
            _workplaceRepository = workplaceRepository;
            _mapper = mapper;
        }

        public async Task<WorkplaceDto> DeleteWorkplace(long id)
        {
            Workplace toDelete = await _workplaceRepository.GetAsync(id);
            await _workplaceRepository.DeleteAsync(toDelete);

            return _mapper.Map<WorkplaceDto>(toDelete);
        }

        public async Task<WorkplaceDto> GetWorkplace(long id)
        {
            Workplace result = await _workplaceRepository.GetAsync(id);

            if (result == null)
            {
                throw new Exception("Workplace not found, implement separate exception later");
            }

            return _mapper.Map<WorkplaceDto>(result);
        }

        public async Task<IEnumerable<WorkplaceDto>> GetWorkplaces()
        {
            ICollection<Workplace> result = await _workplaceRepository.GetAllAsync();

            return _mapper.Map<List<WorkplaceDto>>(result);
        }

        public async Task<WorkplaceDto> PostWorkplace(WorkplaceDto workplaceDto)
        {
            Workplace workplace = _mapper.Map<Workplace>(workplaceDto);

            Workplace result = await _workplaceRepository.AddAsync(workplace);

            return _mapper.Map<WorkplaceDto>(result);
        }

        public async Task<WorkplaceDto> PutWorkplace(long id, WorkplaceDto workplaceDto)
        {
            Workplace toUpdate = await _workplaceRepository.GetAsync(id);
            toUpdate.Name = workplaceDto.Name;

            Workplace result = await _workplaceRepository.UpdateAsync(toUpdate, toUpdate.Id);

            return _mapper.Map<WorkplaceDto>(result);
        }
    }
}
