using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FKM_Diagnostic_Center
{
    public class Test
    {
        [Key]
        public int testId { get; set; }
         [Required]
        public string testName { get; set; }
        public int testQuantity { get; set; }
         [Required]
        public int testBill { get; set; }
        public DateTime testDate { get; set; }
        public List<Patient> Patients { get; set; }
    }
}