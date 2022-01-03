using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.Dto;

namespace WorkplaceManagement.Service.Profile
{
    public class SiteProfile : AutoMapper.Profile
    {
        public SiteProfile()
        {
            CreateMap<SiteDto, Site>();
            CreateMap<Site, SiteDto>();
        }
    }
}
