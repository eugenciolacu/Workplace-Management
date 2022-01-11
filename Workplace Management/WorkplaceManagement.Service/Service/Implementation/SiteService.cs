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

        public Task<SiteDto> GetSite(long id)
        {
            return null;
        }

        public IEnumerable<SiteDto> GetAllSites(bool trackChanges)
        {
            IEnumerable<Site> sites = _repository.Site.GetAllSites(trackChanges: false);

            IEnumerable<SiteDto> sitesDto = _mapper.Map<IEnumerable<SiteDto>>(sites);

            return sitesDto;
        }

        public Task<SiteDto> PostSite(SiteDto siteDto)
        {
            return null;
        }

        public Task<SiteDto> PutSite(long id, SiteDto siteDto)
        {
            return null;
        }
    }
}
