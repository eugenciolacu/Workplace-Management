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
            return null;
        }

        public async Task<SiteDto> GetSite(long id)
        {
            return null;
        }

        public async Task<IEnumerable<SiteDto>> GetSites()
        {
            return null;
        }

        public async Task<SiteDto> PostSite(SiteDto siteDto)
        {
            return null;
        }

        public async Task<SiteDto> PutSite(long id, SiteDto siteDto)
        {
            return null;
        }
    }
}
