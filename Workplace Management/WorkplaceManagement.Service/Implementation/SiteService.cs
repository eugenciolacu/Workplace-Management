using AutoMapper;
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


        public async Task<SiteDto> PostSite(SiteDto siteDto)
        {
            Site site = _mapper.Map<Site>(siteDto);

            await _siteRepository.AddAsyn(site);
            await _siteRepository.SaveAsync();

            return siteDto;
        }
    }
}
