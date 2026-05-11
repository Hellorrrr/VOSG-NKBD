using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VOSG_NKBD.Areas.Identity.Data;
using VOSG_NKBD.Data;
using VOSG_NKBD.Models;

namespace VOSG_NKBD.Areas.Identity.Data
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int ConfirmationID { get; set; }

        [Required]
        public string VOSG_NKBDId { get; set; } = string.Empty;

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentStatus { get; set; } = string.Empty;

        [ForeignKey("ConfirmationID")]
        public Confirmation? Confirmation { get; set; }

        [ForeignKey("VOSG_NKBDId")]
        public VOSG_NKBDUser? User { get; set; }
    }
}
using VOSG_NKBD.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 
   namespace VOSG_NKBD.Data
   {
       
       public class Payment
       {
          [Key]
          public int PaymentID { get; set; }
  
          
          [Required]
          public int ConfirmationID { get; set; }
  
          [Required]
          public string VOSG_NKBDId { get; set; } = string.Empty;
  
          [Required]
          public decimal PaymentAmount { get; set; }
  
          [Required, DataType(DataType.Date)]
          public DateTime PaymentDate { get; set; }
  
          [Required]
          public string PaymentStatus { get; set; } = string.Empty;
            
          [ForeignKey("ConfirmationID")]
          public Confirmation? Confirmation { get; set; }
  
          [ForeignKey("VOSG_NKBDId")]
          public VOSG_NKBDUser? User { get; set; }
       }
   }