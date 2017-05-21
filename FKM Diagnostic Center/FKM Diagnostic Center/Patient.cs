using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FKM_Diagnostic_Center
{
    public class Patient
    {
        [Key]
        public int PId { get; set; }
         [Required]
        public string PName { get; set; }
         [Required]
        public string PAddress { get; set; }
         [Required]
        public int PAge { get; set; }
         [Required]
        public int PPhone { get; set; }
        public DateTime PDate { get; set; }
         [Required]
        public int PBill { get; set; }
         [Required]
        public int testId { get; set; }
        [ForeignKey("testId")]
        public  Test Test { get; set; }
    }
}