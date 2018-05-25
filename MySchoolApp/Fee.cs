using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolApp
{
    class Fees
    {

        /// <summary>
        /// Calculates the fee that should be paid by a student
        /// </summary>
        public decimal CalculateStudentTotalFee(Grades grade, Arts subject)
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

        public decimal GetArtSubjectFee(string artsubject)
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
    }
}
