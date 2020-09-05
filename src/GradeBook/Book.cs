using System;
using System.Collections.Generic;

namespace GradeBook
{

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

        public void ShowStatistics()
        {

            // We are going to compare all of the grades in the grades List by looping through. To determine the highest and lowest grades we're
            // first going to initialize their variable-holders to the lowest and highest possible double values possible. That way when the loop starts,
            // the first value in the loop will have to be higher or lower respectively and thus stored in the variable, till the next value is compared.
            // this is a more sure and complete method than setting them to just zero.
            double listSum = 0;
            int elems = grades.Count;
            double highGrade = double.MinValue;
            double lowGrade = double.MaxValue;

            foreach (double num in grades)
            {
                // Math.Max/Min will take two params. the current number/value in List being iterated over, and the current value for their high/low-grade variable.
                // Will retun into that variable the higher or lower of the two.
                highGrade = Math.Max(num, highGrade);
                lowGrade = Math.Min(num, lowGrade);
                listSum += num;
            }
            var listResult = listSum / elems;
            Console.WriteLine($"The average grade is: {listResult:N1}");
            Console.WriteLine($"The lowest grade is: {lowGrade}");
            Console.WriteLine($"The highest grade is: {highGrade}");

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