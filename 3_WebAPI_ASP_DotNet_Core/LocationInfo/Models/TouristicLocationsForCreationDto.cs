using System.ComponentModel.DataAnnotations;

namespace LocationInfo.Models
{
    public class TouristicLocationsForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } 
    }
}
