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
            book.AddGrade(98.2);
            book.ShowStatistics();






        }
    }

}
