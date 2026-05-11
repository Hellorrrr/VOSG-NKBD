using System.ComponentModel.DataAnnotations;

namespace VOSG_NKBD.Models
{
    public class Place
    {
        [Key]
        public int PlaceID { get; set; }

        [Required]
        public string PlaceName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}