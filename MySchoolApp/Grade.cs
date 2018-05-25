using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolApp
{
    class Grade
    {

        public Grades Grade_Number { get; set; }
        public int Student_Strength { get; set; }
        public string Assigned_Teacher { get; set; }
        // public List<Student> Students { get; set; }
        public int AnnualFee { get; set; }
        public int Year { get; set; }
        //private static int NoOfStudents = 0;




        public Grade(Grades gradeNumber, int studentStrength, string teacher, int annualFee)
        {
            Console.WriteLine("Grade Constructor");
            Grade_Number = gradeNumber;
            Student_Strength = studentStrength;
            Assigned_Teacher = teacher;
            AnnualFee = annualFee;
        }

        public void addStudent(Student st)
        {
            Console.WriteLine("in Grade class addStudent method---{0}", st.StudentId);
            if (st.StudentGrade == Grade_Number)
            {
                // Students.Add(st);
                // NoOfStudents += 1;
            }
            else Console.WriteLine("This student {0} does not belong to this Grade --", st.StudentId);
        }



    }
}
