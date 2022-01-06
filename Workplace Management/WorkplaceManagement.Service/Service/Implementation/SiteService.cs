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
    public class SiteService : ISiteService
    {
        private ILoggerManager _logger;

        private ISiteRepository _siteRepository;

        private IMapper _mapper;

        public SiteService(ILoggerManager logger, ISiteRepository siteRepository, IMapper mapper)
        {
            _logger = logger;
            _siteRepository = siteRepository;
            _mapper = mapper;
        }

        public async Task<SiteDto> DeleteSite(long id)
        {
            Site toDelete = await _siteRepository.GetAsync(id);
            await _siteRepository.DeleteAsync(toDelete);

            return _mapper.Map<SiteDto>(toDelete);
        }

        public async Task<SiteDto> GetSite(long id)
        {
            Site result = await _siteRepository.GetAsync(id);

            if (result == null)
            {
                throw new Exception("Site not found, implement separate exception later");
            }

            return _mapper.Map<SiteDto>(result);
        }

        public async Task<IEnumerable<SiteDto>> GetSites()
        {
            ICollection<Site> result = await _siteRepository.GetAllAsync();

            return _mapper.Map<List<SiteDto>>(result);
        }

        public async Task<SiteDto> PostSite(SiteDto siteDto)
        {
            Site site = _mapper.Map<Site>(siteDto);

            Site result = await _siteRepository.AddAsync(site);

            return _mapper.Map<SiteDto>(result);
        }

        public async Task<SiteDto> PutSite(long id, SiteDto siteDto)
        {
            Site toUpdate = await _siteRepository.GetAsync(id);
            toUpdate.Name = siteDto.Name;

            Site result = await _siteRepository.UpdateAsync(toUpdate, toUpdate.Id);

            return _mapper.Map<SiteDto>(result);
        }
    }
}
