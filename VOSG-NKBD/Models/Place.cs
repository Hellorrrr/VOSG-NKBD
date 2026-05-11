using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
   namespace VOSG_NKBD.Models
   {
       
       public class Place
       {
           [Key]
          public int PlaceID { get; set; }
  
          [Required, MaxLength(100)]
          public string PlaceName { get; set; } = string.Empty;
  
          [Required]
          public string Description { get; set; } = string.Empty;
  
          [Required]
          public decimal Price { get; set; }
  
          
          public int LocationsID { get; set; }
  
          [ForeignKey("LocationsID")]
          public Location? Location { get; set; }
  
          public ICollection<Confirmation>? Confirmations { get; set; }
       }
   }
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