using System.ComponentModel.DataAnnotations;
using VOSG_NKBD.Models;

namespace VOSG_NKBD.Models
{
    public class Location
    {
        [Key]
        public int CountryID { get; set; }

        [Required, MinLength(2), MaxLength(30), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Country name must only contain letters.")]
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        [Required, MinLength(2), MaxLength(40), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Address must only contain letters, numbers or spaces.")]
        [Display(Name = "Address")]
        public string Addresss { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Suburb must only contain letters, numbers or spaces.")]
        [Display(Name = "Suburb")]
        public string Suburb { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "City must only contain letters, numbers or spaces.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[0-9]+$", ErrorMessage = "Postal code must only contain numbers.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required, RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Invalid phone number format (please include your country code)")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public ICollection<VOSG_NKBDUser>? VOSG_NKBDUser { get; set; }

    }
}

