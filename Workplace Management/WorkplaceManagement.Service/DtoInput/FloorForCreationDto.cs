using System.ComponentModel.DataAnnotations;

namespace WorkplaceManagement.Service.DtoInput
{
    public class FloorForCreationDto
    {
        [Required(ErrorMessage = "Floor name is a required field")]
        [MaxLength(64, ErrorMessage = "Maximum length for the Name is 64 characters")]
        public string Name { get; set; }
    }
}
