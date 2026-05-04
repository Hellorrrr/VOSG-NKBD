  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using VOSG_NKBD.Models;
 
  namespace VOSG_NKBD.Data
  {
       
       public class Confirmation
       {
           [Key]
          public int ConfirmationID { get; set; }
  
          
          [Required]
          public string MemberId { get; set; } = string.Empty;
  
          
          [Required]
          public int PlaceID { get; set; }
  
          public DateTime ConfirmationDate { get; set; }
          public DateTime StartTime { get; set; }
         public DateTime EndTime { get; set; }
  
          
          public decimal TotalPrice { get; set; }
  
          [ForeignKey("MemberId")]
          public VOSG_NKBDUser? Member { get; set; }
  
          [ForeignKey("PlaceID")]
          public Place? Place { get; set; }
  
          public ICollection<Payment>? Payments { get; set; }
       }
  }