using Microsoft.AspNetCore.Identity;

namespace WorkplaceManagement.Domain.Model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
