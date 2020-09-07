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
            Console.WriteLine("Enter the name of the gradebook: ");
            var bookName = Console.ReadLine();
            // Instantiate book object from Book (Book.cs) class
            // var book = new InMemoryBook(bookName);               // commenting out to work with DiskBook class
            IBook book = new DiskBook(bookName);
            // Here we want to Handle the GradeAdded Event that we delegated in Book.cs. 
            book.GradeAdded += OnGradeAdded;  // Here you add on (+=) the method OnGradeAdded to the delegate GradeAdded.
                                              // So everytime the Book raises the event GradeAdded, the OnGradeAdded method will be invoked.
                                              // Multicast delegates can addTo(+=) or subFrom(-=) as many methods as you like.
                                              // Create boolean variable to flag when user input is finished
            EnterGrades(book);

            var stats = book.GetStatistics();

            // Console.WriteLine($"The Category constant is: {InMemoryBook.CATEGORY}");
            Console.WriteLine($"The name of this gradebook is: {book.Name}");
            Console.WriteLine($"The lowest grade is: {stats.Low}");
            Console.WriteLine($"The highest grade is: {stats.High}");
            Console.WriteLine($"The average grade is: {stats.Average:N1}");
            Console.WriteLine($"The average letter grade is: {stats.Letter}");

        }

        private static void EnterGrades(IBook book)       // We've changed the paramter type to the BookBase class, because now with the  
                                                          // abstract AddGrade method member of that Base class, it's up to the runtime 
                                                          // instance to determine where (or whatever Polymorphic condition) that gradebook 
                                                          // will be stored (InMemory in this case).
        {
            var isDone = false;
            while (!isDone)
            {
                Console.WriteLine("Enter a grade, or character q to quit: ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    isDone = true;
                    // Using the CONTINUE keyword here we tell the compiler that if the condition is true/met (if input is a "q")
                    // then skip over everything between continue and end of loop body then continue back to the very top
                    // Meaning lines var grade and book.AddGrade are SKIPPED, isDone is set to true and the while loop ends.
                    // Thus no need to worry about "q" being attempted to be passed to AddGrade
                    continue;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                // What we're doing here is declaring a variable ex of Type Exception which will match all of the exceptions
                // in the c# library. It's going to pull our throw-exception out of the AddGrade method in Book.cs
                // then write out that console message we've written there, then gracefully continue back to the start of the 
                // loop. You can also specify which types of exceptions you want to handle in the catch 
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    // Now in some cases you do want the program to catastrophically crash OR you want something even 
                    // higher up to catch the exception. Sometimes though it's safest for the database, etc to crash out
                    // to do so, add another throw statement that will continue to throw up exception even after this is written to console.

                    // throw;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // You can also add a FINALLY block here that will execute no matter whether the loop/input
                // works fine or if an exception is thrown


            }
        }

        // To interact with the static Main method above, you must have another static method
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added (Event Raised)");
        }
    }

}
