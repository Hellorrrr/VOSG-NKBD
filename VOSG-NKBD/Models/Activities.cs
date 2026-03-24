using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using VOSG_NKBD.Areas.Identity.Data;

namespace VOSG_NKBD.Models
{
    public class Activities
    {
        [Key]
        public int MemberID { get; set; }

        [ForeignKey("UserID"), Required]
        public string VOSGNKBDUserId { get; set; }

        [Required(ErrorMessage = "Select your activity")]
  

        public int? PlaceID { get; set; }


        [Required(ErrorMessage = "Enter your place")]
        [DataType(DataType.Date)]
        public Time Date { get; set; }

        [Required(ErrorMessage = "Enter your time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Enter your end time")]
        [DataType(DataType.Time)]
        public StartTime EndTime { get; set; }

        [Required(ErrorMessage = "End time must be later than start time.")]
        public decimal TotalPrice { get; set; }

        public ICollection<Payments>? Payments
        { get; set; }
        public Member? Member { get; set; }
        public Place? Place { get; set; }
        public VOSG_NKBDUser? VoSG_NKBDUser { get; set; }


    }

}
