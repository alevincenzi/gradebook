using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book
    {
        public Book(string name)
        {
            Name = name;
            grades = new List<double>();
        }

        public void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <=100 && grade >= 0)
            {
                grades.Add(grade); 
                if (GradeAdded != null)
                    GradeAdded(this, new EventArgs());
            }
            else
                throw new ArgumentException($"Invalid {nameof(grade)}");
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

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            
            return result;
        }
        public string Name
        {
            get; set;
        }

        public event GradeAddedDelegate GradeAdded;

        private List<double> grades;

    }
}