using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
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

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low  = double.MaxValue;
            
            foreach(var grade in grades)
            {
                result.High = Math.Max(result.High, grade);
                result.Low = Math.Min(result.Low, grade);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;
        }

        private string name;
        private List<double> grades;

    }
}