using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott");
            book.AddGrade(12.7);
            book.AddGrade(10.3);
            book.AddGrade(6.11);
            book.AddGrade(4.1);
            
            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest  grade is {stats.Low:N2}");
            Console.WriteLine($"The average grade is {stats.Average:N2}");
            Console.WriteLine($"The highest grade is {stats.High:N2}");
        }
    }
}
