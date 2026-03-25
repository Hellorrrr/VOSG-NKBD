using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOSG_NKBD.Models;

namespace VOSG_NKBD.Models
{
    public class Payments
    {
        [Key]
        public int PaymentID { get; set; }

        [ForeignKey("MemberID"), Required]
        public int MemberID { get; set; }

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required(ErrorMessage = "Enter your date")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentStatus { get; set; }

        public Payments? Payment { get; set; }
    }
}