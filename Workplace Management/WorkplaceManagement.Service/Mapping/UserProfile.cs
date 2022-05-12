using WorkplaceManagement.Domain.Model;
using WorkplaceManagement.Service.DtoInput;

namespace WorkplaceManagement.Service.Mapping
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
