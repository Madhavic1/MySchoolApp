using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolApp
{
    public enum Arts
    {
        Music,
        Dance,
        Drawing,
        Drama
    }
    public enum Grades
    {
        KinderGarten,
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }
    static class School
    {

        private static MySchoolAppModel db = new MySchoolAppModel();
        private static decimal TotalIncome = 0;
        private static decimal TotalExpenditure = 0;

        //duty is to enroll a student
        /// <summary>
        /// This creates a new student
        /// </summary>
        /// <param name="name">Name of the student</param>
        /// <param name="age">Age of student</param>
        /// <param name="grade">Grdae in which he is studying</param>
        /// <param name="fatherName">Student's Father name</param>
        /// <param name="artSubject">the special art subject taken by a student</param>
        /// <returns></returns>

        
        public static Student EnrollStudent(string name, int age, Grades grade, string fatherName, Arts artSubject)
        {
            var student = new Student(name, age, grade, fatherName, artSubject);
            student.FeeTotal = CalculateStudentTotalFee(student.StudentGrade, student.ArtSubjectTaken);
            db.Students.Add(student);
            db.SaveChanges();

            return student;
        }

        /// <summary>
        /// Displays student's information
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="fatherName"></param>
        /// <returns></returns>
        public static Student GetStudentInformation(string studentName, string fatherName)
        {
            return db.Students.Where(st => st.Name == studentName)
                .Where(st => st.Father_Name == fatherName).FirstOrDefault();
        }

        /// <summary>
        /// Adds a teacher to the school
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="contactNumber"></param>
        /// <param name="grade"></param>
        /// <param name="totalSalary"></param>
        /// <returns></returns>
        public static Teacher AddTeacher(string name, string address, long contactNumber, Grades grade, decimal totalSalary)
        {
            var teacher = new Teacher
            {
                Name = name,
                Address = address,
                ContactNumber = contactNumber,
                Grade = grade,
                Totalsalary = totalSalary
            };
            db.Teachers.Add(teacher);
            db.SaveChanges();

            return teacher;
        }
        /// <summary>
        /// Returns a Teacher object depends on teacher id
        /// </summary>
        /// <returns></returns>
        public static Teacher GetTeacher(int teacherId)
        {
            Console.WriteLine("Teacher Id");
            Teacher teacher = db.Teachers.Where(t => t.Id == teacherId).FirstOrDefault();
            Console.WriteLine("Teacher name = {0}", teacher.Name);
            if(teacher == null)
            {
                               Console.WriteLine("Entered in null condition");
               
                               throw new NullReferenceException("Teacher Not Found");
            }
            return teacher;
            //return Teacher t;
        }

        /// <summary>
        /// Displays the Enum values of Grades
        /// </summary>
        public static void ShowGradesInfo()
        {
            var grades = Enum.GetNames(typeof(Grades));

            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine($"{i}.{grades[i]}");
            }
        }

        /// <summary>
        /// Displays the Enum values of the Art subjects
        /// </summary>
        public static void ShowArtSubjects()
        {
            var artSubjects = Enum.GetNames(typeof(Arts));

            for (int i = 0; i < artSubjects.Length; i++)
            {
                Console.WriteLine($"{i}.{artSubjects[i]}");
            }
        }
        /// <summary>
        /// Does the jobs:
        /// 1.The School income Raises
        /// 2.Student's Paid Money will be Raised(by amount)
        /// </summary>
        /// <param name="st">Student who pays the fee</param>
        /// <param name="amount">The amount that student is paying</param>
        public static void CollectStudentFee(Student st, decimal amount)
        {
            if (amount != 0)
            {
                TotalIncome += amount;
                st.FeesPaid += amount;

                var payment = new Payments
                {
                    Description = "Student tuition Fee",
                    CreatedTime = DateTime.UtcNow,
                    Amount = amount,
                    Student = st
                    
                };
                db.Payments.Add(payment);
                db.SaveChanges();
                

            }
            else
            {
                throw new FormatException();
            }

        }


        /// <summary>
        /// calculates the students total tuition fee depending on his/her grade and art subject taken
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static decimal CalculateStudentTotalFee(Grades grade, Arts subject)
        {
            decimal amount = 0;
            decimal totalFee = 0;
            //int x = (int) Enum.Parse(typeof (CategoriesType), Enum.GetName(typeof (CategoriesType), mycategory));
            var GradeChoice = (int)Enum.Parse(typeof(Grades), Enum.GetName(typeof(Grades), grade));
            var ArtSubject = Enum.GetName(typeof(Arts), subject);

            switch (GradeChoice)
            {
                case 0:
                    amount = 100;
                    break;
                case 1:
                    amount = 200;
                    break;
                case 2:
                    amount = 250;
                    break;
                case 3:
                    amount = 300;
                    break;
                case 4:
                    amount = 350;
                    break;
                case 5:
                    amount = 400;
                    break;
            }

            totalFee = amount + GetArtSubjectFee(ArtSubject);
            return totalFee;
        }

        /// <summary>
        /// Calculates the Fee for the art subject passed
        /// </summary>
        /// <param name="artsubject"></param>
        /// <returns></returns>
        public static decimal GetArtSubjectFee(string artsubject)
        {
            decimal fee = 0;

            if (artsubject == "Music")
                fee = 20;
            else if (artsubject == "Dance")
                fee = 25;
            else
            if (artsubject == "Drawing")
                fee = 30;
            else
            if (artsubject == "Drawing")
                fee = 35;

            return fee;
        }

        public static void PayTeacherSalary(Teacher teacher, int amount)
        {
            if (amount != 0)
            {
                teacher.SalaryEarned += amount;
                TotalExpenditure += amount;
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Salary can not be zero", "Salary");
            }
        }
    }
}
