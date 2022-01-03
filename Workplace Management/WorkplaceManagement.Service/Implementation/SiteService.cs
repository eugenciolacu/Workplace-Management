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
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;

        private readonly IMapper _mapper;

        public SiteService(ISiteRepository siteRepository, IMapper mapper)
        {
            _siteRepository = siteRepository;
            _mapper = mapper;
        }

        public async Task<SiteDto> DeleteSite(long id)
        {
            Site toDelete = await _siteRepository.GetAsync(id);
            await _siteRepository.DeleteAsyn(toDelete);

            return _mapper.Map<SiteDto>(toDelete);
        }

        public async Task<SiteDto> GetSite(long id)
        {
            var result = await _siteRepository.GetAsync(id);

            if (result == null)
            {
                throw new Exception("Site not found, implement separate exception later");
            }

            return _mapper.Map<SiteDto>(result);
        }

        public async Task<IEnumerable<SiteDto>> GetSites()
        {
            var result = await _siteRepository.GetAllAsyn();

            return _mapper.Map<List<SiteDto>>(result);
        }

        public async Task<SiteDto> PostSite(SiteDto siteDto)
        {
            Site site = _mapper.Map<Site>(siteDto);

            var result = await _siteRepository.AddAsyn(site);

            return _mapper.Map<SiteDto>(result);
        }

        public async Task<SiteDto> PutSite(long id, SiteDto siteDto)
        {
            Site toUpdate = await _siteRepository.GetAsync(id);
            toUpdate.Name = siteDto.Name;

            Site result = await _siteRepository.UpdateAsyn(toUpdate, toUpdate.Id);

            return _mapper.Map<SiteDto>(result);
        }
    }
}
