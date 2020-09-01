using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Book
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
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        List<double> grades;
        string name;

    }



}