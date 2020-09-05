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
            this.name = name;

        }
        // METHODS
        public void AddGrade(double grade)
        {
            grades.Add(grade);
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

            foreach (double grade in grades)
            {
                // Math.Max/Min will take two params. the current gradeber/value in List being iterated over, and the current value for their high/low-grade variable.
                // Will retun into that variable the higher or lower of the two.
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            // Now instead of writing/displaying the computed statistics out to the console, or wherever, we've
            // modularized this method to only compute and RETURN the stats. So use return to return the Statistics object (result) here.
            return result;
        }
        // FIELDS 

        // Using the static keyword on these fields would make them inaccessible from any object instantiations (new's) .. and would make them available
        // only on the Class type (Book).. This kind of defeats the purpose of object-oriented programming and should only be used in rare circumstances.
        // Otherwise your fields should be defined as 'instance' occuring like below where a new object has to be instantiated for them to be used. 
        // thus keeping them 'encapsulated' and sealed off from the outside programming world (safer).
        List<double> grades;
        string name;

    }



}