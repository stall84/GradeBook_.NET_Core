using System;
using System.Collections.Generic;


namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiating new object of class Book (Book.cs). A (required) input parameter is the
            // name of the book 
            var book = new Book("Michael's Gradebook");
            book.AddGrade(80.2);
            book.AddGrade(82.3);
            book.AddGrade(98.2);

            var stats = book.GetStatistics();


            Console.WriteLine($"The lowest grade is: {stats.Low}");
            Console.WriteLine($"The highest grade is: {stats.High}");
            Console.WriteLine($"The average grade is: {stats.Average:N1}");






        }
    }

}
