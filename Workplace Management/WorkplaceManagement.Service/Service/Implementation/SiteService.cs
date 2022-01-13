using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkplaceManagement.Dal.Repository.Interface;
using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.LoggerService;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;
using WorkplaceManagement.Service.Service.Interface;

namespace WorkplaceManagement.Service.Service.Implementation
{
    public class SiteService : ISiteService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public SiteService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<SiteDto> DeleteSite(long id)
        {
            return null;
        }

        public SiteDto GetSite(long id, bool trackChanges)
        {
            Site site = _repository.Site.GetSite(id, trackChanges);

            SiteDto siteDto = _mapper.Map<SiteDto>(site);

            return siteDto;
        }

        public IEnumerable<SiteDto> GetSites(bool trackChanges)
        {
            IEnumerable<Site> sites = _repository.Site.GetSites(trackChanges);

            IEnumerable<SiteDto> sitesDtos = _mapper.Map<IEnumerable<SiteDto>>(sites);

            return sitesDtos;
        }

        public IEnumerable<SiteDto> GetSiteCollection(IEnumerable<long> ids, bool trackChanges)
        {
            IEnumerable<Site> siteEntities = _repository.Site.GetByIds(ids, trackChanges);

            IEnumerable<SiteDto> sitesDtos = _mapper.Map<IEnumerable<SiteDto>>(siteEntities);

            return sitesDtos;
        }

        public SiteDto CreateSite(SiteForCreationDto site)
        {
            Site siteEntity = _mapper.Map<Site>(site);

            _repository.Site.CreateSite(siteEntity);

            _repository.Save();

            return _mapper.Map<SiteDto>(siteEntity);
        }

        public IEnumerable<SiteDto> CreateSiteCollection(IEnumerable<SiteForCreationDto> siteCollection)
        {
            IEnumerable<Site> siteEntities = _mapper.Map<IEnumerable<Site>>(siteCollection);

            foreach (Site site in siteEntities)
            {
                _repository.Site.CreateSite(site);
            }

            _repository.Save();

            return _mapper.Map<IEnumerable<SiteDto>>(siteEntities);
        }

        public Task<SiteDto> PutSite(long id, SiteDto siteDto)
        {
            return null;
        }
    }
}
