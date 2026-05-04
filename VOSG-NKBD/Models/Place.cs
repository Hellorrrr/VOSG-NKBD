  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
using VOSG_NKBD.Data;

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
  
          // FK tới Location
          public int LocationsID { get; set; }
  
          [ForeignKey("LocationsID")]
          public Location? Location { get; set; }

        public ICollection<Confirmation>? Confirmations { get; set; }
       }
  }