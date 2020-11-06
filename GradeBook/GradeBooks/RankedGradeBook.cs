using GradeBook.Enums;
using System;
using System.Collections.Generic;
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
            if(Students.Count < 5 )
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var studentGroup = Students.Count * .2;     // 20% of the total # of students.

            // Get the average grades in order
            var averageGrades = new List<double>();
            foreach(var student in Students)
            {
                averageGrades.Add(student.AverageGrade);
            }
            averageGrades.Sort();
            
            // Calculate the grade.
            for(int i = 0; i < averageGrades.Count; i++)
            {
                if(i < studentGroup)
                {
                    if(averageGrade > averageGrades[i])
                    {
                        return 'A';
                    }
                }
                else if(i < studentGroup * 2)
                {
                    if(averageGrade > averageGrades[i])
                    {
                        return 'B';
                    }
                }
                else if (i < studentGroup * 3)
                {
                    if (averageGrade > averageGrades[i])
                    {
                        return 'C';
                    }
                }
                else if (i < studentGroup * 4)
                {
                    if (averageGrade > averageGrades[i])
                    {
                        return 'D';
                    }
                }
            }

            // The averageGrade was lower than all the other grades.
            return 'F';
        }
    }
}
