using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MySchoolApp
{
    public class Teacher
    {
        //properties

        //Teacher ID  id
        //Teacher Name name


        //Teacher salary    salary
        //Salary Earned by Teacher
        [Key]
        public int Id { get; set; } //shld be unique
        [Required]
        public string Name { get; set; }
        public decimal Totalsalary { get; set; }
        public int SalaryEarned { get; set; }
        [Required]
        public long ContactNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public Grades Grade { get; set; }





    }
}
