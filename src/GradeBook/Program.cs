using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {



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
