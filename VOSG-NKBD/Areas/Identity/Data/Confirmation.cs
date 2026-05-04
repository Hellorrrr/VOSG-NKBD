using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOSG_NKBD.Areas.Identity.Data;
using VOSG_NKBD.Models;

namespace VOSG_NKBD.Areas.Identity.Data
{
    public class Confirmation
    {
        [Key]
        public int ConfirmationID { get; set; }

        [Required]
        public string VOSG_NKBDId { get; set; } = string.Empty;

        [Required]
        public int BookingID { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public string ConfirmationStatus { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateTime ConfirmationDate { get; set; }

        [ForeignKey("VOSG_NKBDId")]
        public VOSG_NKBDUser? User { get; set; }

        [ForeignKey("BookingID")]
        public Booking? Booking { get; set; }

        public ICollection<Payment>? Payments { get; set; }
    }
}