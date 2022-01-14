using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.DtoInput;
using WorkplaceManagement.Service.DtoOutput;
using WorkplaceManagement.Service.DtoUpdate;

namespace WorkplaceManagement.Service.Profile
{
    public class SiteProfile : AutoMapper.Profile
    {
        public SiteProfile()
        {
            CreateMap<Site, SiteDto>();

            CreateMap<SiteForCreationDto, Site>();

            CreateMap<SiteForUpdateDto, Site>();
        }
    }
}
