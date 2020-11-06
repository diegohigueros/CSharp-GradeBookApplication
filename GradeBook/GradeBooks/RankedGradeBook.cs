using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        // This constructor calls the base class constructor.
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        // This method overrides the base class method.
        public override char GetLetterGrade(double averageGrade)
        {
            // Validate the amount of students. 
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            int threshold = (int)Math.Ceiling(Students.Count * .2);     // 20% of the total # of students.

            // Get the average grades in order
            var averageGrades = Students.OrderByDescending(x => x.AverageGrade).ToList();

            // Calculate the grade.
            for (int i = 0; i < averageGrades.Count; i++)
            {
                if (i < threshold)
                {
                    if (averageGrade >= averageGrades[i].AverageGrade)
                    {
                        return 'A';
                    }
                }
                else if (i < threshold * 2)
                {
                    if (averageGrade >= averageGrades[i].AverageGrade)
                    {
                        return 'B';
                    }
                }
                else if (i < threshold * 3)
                {
                    if (averageGrade >= averageGrades[i].AverageGrade)
                    {
                        return 'C';
                    }
                }
                else if (i < threshold * 4)
                {
                    if (averageGrade >= averageGrades[i].AverageGrade)
                    {
                        return 'D';
                    }
                }
                else
                {
                    break;
                }
            }

            // The averageGrade was lower than all the other grades.
            return 'F';
        }

        // This method overrides the base CalculateStatistics method.
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        // This method overrides the base CalculateStudentStatistics method.
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }


    }
}
