using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeighted) : base(name, IsWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            float[] Grades = new float[Students.Count];
            int x = 0;

            foreach (var student in Students)
            {
                Grades[x] = (float)student.AverageGrade;
                x++;
            }
            Array.Sort(Grades);
            Array.Reverse(Grades);

            if (Grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (Grades[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (Grades[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (Grades[(threshold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else
                base.CalculateStudentStatistics(name);
        }



    }
}
