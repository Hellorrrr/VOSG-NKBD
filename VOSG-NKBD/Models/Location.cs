using System.ComponentModel.DataAnnotations;
 
namespace VOSG_NKBD.Models
{
       public class Location
       {
           
          [Key]
          public int LocationsID { get; set; }
  
          [Required, MinLength(2), MaxLength(30)]
          [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Location name must only contain letters, numbers or spaces.")]
          [Display(Name = "Location Name")]
          public string LocationName { get; set; } = string.Empty;
  
          [Required, MinLength(2), MaxLength(40)]
          [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Address must only contain letters, numbers or spaces.")]
          [Display(Name = "Address")]
          public string Addresss { get; set; } = string.Empty;
  
          [Required, MinLength(2), MaxLength(20)]
          [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Suburb must only contain letters or spaces.")]
          [Display(Name = "Suburb")]
          public string Suburb { get; set; } = string.Empty;
  
          [Required, MinLength(2), MaxLength(20)]
          [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "City must only contain letters or spaces.")]
          [Display(Name = "City")]
          public string City { get; set; } = string.Empty;
  
          
          [Required, MaxLength(30)]
          public string Country { get; set; } = string.Empty;
  
          [Required, MinLength(2), MaxLength(20)]
          [RegularExpression(@"^[0-9]+$", ErrorMessage = "Postal code must only contain numbers.")]
          [Display(Name = "Postal Code")]
          public string PostalCode { get; set; } = string.Empty;
  
          [Required]
          [RegularExpression(@"^\+?\d[\d\-]{6,14}$", ErrorMessage = "Invalid phone number format.")]
          [Display(Name = "Phone Number")]
          public string PhoneNumber { get; set; } = string.Empty;
  
          
          public ICollection<Place>? Places { get; set; }
       }
}

