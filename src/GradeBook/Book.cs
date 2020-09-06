using System;
using System.Collections.Generic;

namespace GradeBook
{

    // You must specify 'public' access modifier on the class or it will only be available 'internal' within the project 
    public class Book
    {
        // Explicit Constructor
        // Constructor must have same name as class 
        public Book(string name)
        {   // This ensures every time you instantiate a Book class into an object,
            // The state-holding-field grades will also be instantiated to prevent the null-ref-error
            // If you want to have a field named the same name as a parameter, as in the case of 'name' here
            // You'll have to use the 'this' keyword to tell the compiler you mean this object's field
            grades = new List<double>();
            this.Name = name;

        }
        // METHODS

        public void AddGrade(char letter)
        {       // We have multiple 'AddGrade' methods in this class. This is fine in C#, the compiler
                // Will realize the method signatures are different (The parameters are different types dbl/char)
                // And will determine at runtime based on the input parameter which 'overload' to use.
            switch (letter)
            {
                case 'A':
                    AddGrade(90.0);
                    break;
                case 'B':
                    AddGrade(80.0);
                    break;
                case 'C':
                    AddGrade(70.0);
                    break;
                case 'D':
                    AddGrade(60.0);
                    break;
                case 'F':
                    AddGrade(50.0);
                    break;
                default:
                    AddGrade(0.0);
                    break;
            }
        }
        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {   // Formally handling errors requires more than just a hardcoded console log.
                // we want to throw and catch the exception to handle it gracefully. dotnet comes with
                // a lot of Exception objects, like the Argument one below (if parameters are bad input)
                // nameof stringifys the field or parameter that in this instance is being mis-inputted
                // IF you fail to CATCH a thrown exception, it will crash the program catastrophically
                // It's important to remember the runtime will look in the current method for a CATCH statement
                // to handle, if one isn't found it will go up a level to the calling piece of code (Program.cs in this case)
                // And will look there for a catch before crashing. so lets add the try-catch statement above in 
                // Program 
                throw new ArgumentException($"The grade input is an invalid: {nameof(grade)}");
            }
        }
        // We have changed the original 'showstatistics' method to 'getstatistics' that now instead of returning void
        // with display, now it will more specifically return an object of type Statistics (which we've defined in Statistics.cs)
        // This way we have separated responsibilities, minified and modularized our method so that it's not
        // trying to 'do too much'
        public Statistics GetStatistics()
        {

            // We are going to compare all of the grades in the grades List by looping through. To determine the highest and lowest grades we're
            // first going to initialize their variable-holders to the lowest and highest possible double values possible. That way when the loop starts,
            // the first value in the loop will have to be higher or lower respectively and thus stored in the variable, till the next value is compared.
            // this is a more sure and complete method than setting them to just zero.
            var result = new Statistics();
            // result here instantiates (for return from method) an object of Type Statistics (Statistics.cs)
            // this allows us to save the soon-to-be computed values into the specific fields on the Statistics class
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            for (var i = 0; i < grades.Count; i++)
            {
                // Math.Max/Min will take two params. the current gradeber/value in List being iterated over, and the current value for their high/low-grade variable.
                // Will retun into that variable the higher or lower of the two.
                result.Low = Math.Min(grades[i], result.Low);
                result.High = Math.Max(grades[i], result.High);
                result.Average += grades[i];

            }
            result.Average /= grades.Count;
            // After we've computed the average (and lowest/highest) grades, take that average and 
            // switch-case it to return a letter grade
            switch (result.Average)
            {   // We're using the 'enhanced' features of switch statements in C# that allow 
                // assignment of a variable 'd' to the input value (result.Average)
                // then using the 'when' keyword to evaluate a condition, which if condition returns true
                // then the code in the case will be executed. In this case we're assigning the letter grade to 
                // the result object 
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
            // Now instead of writing/displaying the computed statistics out to the console, or wherever, we've
            // modularized this method to only compute and RETURN the stats. So use return to return the Statistics object (result) here.
            return result;
        }
        // FIELDS 

        // Using the static keyword on these fields would make them inaccessible from any object instantiations (new's) .. and would make them available
        // only on the Class type (Book).. This kind of defeats the purpose of object-oriented programming and should only be used in rare circumstances.
        // Otherwise your fields should be defined as 'instance' occuring like below where a new object has to be instantiated for them to be used. 
        // thus keeping them 'encapsulated' and sealed off from the outside programming world (safer).
        public List<double> grades;
        public string Name;

    }



}