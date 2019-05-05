using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            this.name = name;
            grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
           grades.Add(grade); 
        }

        internal void ShowStatistics()
        {
            var average = 0.0;
            var hgrade = double.MinValue;
            var lgrade = double.MaxValue;
            foreach(var number in grades)
            {
                hgrade = Math.Max(hgrade, number);
                lgrade = Math.Min(hgrade, number);
                average += number;
            }
            average /= grades.Count;

            Console.WriteLine($"The lowest  grade is {lgrade:N2}");
            Console.WriteLine($"The average grade is {average:N2}");
            Console.WriteLine($"The highest grade is {hgrade:N2}");
        }

        private string name;
        private List<double> grades;

    }
}