using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolApp
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }
        public string Description { get; set; }
        
        public DateTime CreatedTime { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        public virtual Student Student { get; set; }

        

    }
}
