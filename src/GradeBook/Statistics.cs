
using System;

namespace GradeBook
{

    public class Statistics
    {
        // CONSTRUCTOR
        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        // METHODS
        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            // Math.Max/Min will take two params. the current gradeber/value in List being iterated over, and the current value for their high/low-grade variable.
            // Will retun into that variable the higher or lower of the two.
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
        // FIELDS + PROPERTIES 
        public double Average           // With Average we're going to add a getter to return the Average (Sum/Count)
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter             // As with Average we'll have a property here that computes the Letter grade onthe fly
        {
            get
            {
                // After we've computed the average (and lowest/highest) grades, take that average and 
                // switch-case it to return a letter grade
                switch (Average)
                {   // We're using the 'enhanced' features of switch statements in C# that allow 
                    // assignment of a variable 'd' to the input value (result.Average)
                    // then using the 'when' keyword to evaluate a condition, which if condition returns true
                    // then the code in the case will be executed. In this case we're assigning the letter grade to 
                    // the result object 
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    default:
                        return 'F';

                }
            }
        }
        public double Sum;      // Creating new fields for our constructor - stats methods
        public int Count;       // Created for stats calc & constructor
    }






}