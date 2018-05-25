using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //put everything inside a while(true) loop so that everything appears again n again to the user untill he hits quit option

            Console.WriteLine("Welcome to our School");
            Console.WriteLine("***********************");
            Payments payment = new Payments();

            while (true)
            {


                Console.WriteLine("0: Quit");
                Console.WriteLine("1: Enroll a Student in School");
                Console.WriteLine("2: View Student Information");
                Console.WriteLine("3: Pay Student Tuition Fee");
                Console.WriteLine("4: Add a Teacher");
                Console.WriteLine("5: Pay Teacher Salary");
                Console.WriteLine("Please Select an option from Above..");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0": //quit
                        Console.WriteLine("Thank you for visiting ");
                        return;

                    case "1"://Enroll a student in school
                        Console.Write("Student Name :");
                        var name = Console.ReadLine();

                        Console.Write("Student Age: ");
                        var age = Convert.ToInt32(Console.ReadLine());


                        Console.Write(" Grade: ");
                        School.ShowGradesInfo();
                        Console.Write("Your choice");
                        var grade = (Grades)Enum.Parse(typeof(Grades), Console.ReadLine());


                        Console.WriteLine("Father Name :");
                        var fatherName = Console.ReadLine();

                        Console.WriteLine("Art Subject ?");
                        School.ShowArtSubjects();
                        Console.Write("Your choice");
                        var artSubject = (Arts)Enum.Parse(typeof(Arts), Console.ReadLine());

                        var student = School.EnrollStudent(name, age, grade, fatherName, artSubject);

                        Console.WriteLine($"N Name: {student.Name} Age: {student.Age} Grade : {student.StudentGrade} Father: {student.Father_Name} Art : {student.ArtSubjectTaken}");

                        Console.ReadKey();

                        break;

                    case "2": // view student information
                        GetStudent();

                        break;

                    case "3": // Pay Student Tuition Fee
                        student = GetStudent();
                        Console.WriteLine("Amount :");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        School.CollectStudentFee(student, amount);
                        // payment.

                        break;
                    case "4":
                        break;
                    case "5":
                        Console.Write("Teacher Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Address: ");
                        string address = Console.ReadLine();
                        Console.WriteLine("Contact Number");
                        long contactNumber = Convert.ToInt64(Console.ReadLine());
                        Console.Write("Grade");
                        grade = (Grades)Enum.Parse(typeof(Grades), Console.ReadLine());
                        Console.Write("Total Salary");
                        var salary = Convert.ToDecimal(Console.ReadLine());
                        var teacher = School.AddTeacher(name, address, contactNumber, grade, salary);
                        break;


                }
            }

        }

        public static Student GetStudent()
        {
            Console.Write("Student Name :");
           var name = Console.ReadLine();
           Console.WriteLine("Father Name :");
           var fatherName = Console.ReadLine();
           var student = School.GetStudentInformation(name, fatherName);
            Console.WriteLine($"N Name: {student.Name} Age: {student.Age} Grade : {student.StudentGrade}" +
                $" Father: {student.Father_Name}  FeeTotal: {student.FeeTotal}" +
            $"Art : {student.ArtSubjectTaken}");

            return student;
        }
    }
}
