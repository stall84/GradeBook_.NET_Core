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
            book.AddGrade(90.2);
            book.AddGrade(95.3);

            // Lists
            List<double> grades = new List<double>() { 21.45, 36.33, 58.72, 63.71, 72.97, 88.39 };
            double listSum = 0;
            int elems = grades.Count;

            foreach (double num in grades)
            {
                listSum += num;
            }
            var listResult = listSum / elems;
            Console.WriteLine($"The average grade is: {listResult:N2}");


        }
    }

}
