using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0) 
            {
                Console.WriteLine($"Hello, {args[0]} !");
            }
            else
            {
                Console.WriteLine("Hello!");
            }
            float x = 32.55f;
            float y = 45.65f;
            float result = x + y;
            //Console.WriteLine("Float Result: " + result);
            
            // Looping through array to sum elements
            double[] numbers = new double[] {14.44, 21.66, 40.24, 58.23830230, 62.10301377};
            double sum = 0;
            foreach (double num in numbers) 
            {
                sum+=num;
            }
            Console.WriteLine("Sum of numbers array: " + sum);

            // Lists
            List<double> grades = new List<double>() {21.45, 36.33, 58.72, 63.71, 72.97, 88.39};
            double listSum = 0;
            int elems = grades.Count;

            foreach (double num in grades)
            {
                listSum += num;
            }
                    var listResult = listSum / elems;
                    Console.WriteLine("Average of grades List: " + listResult);

            
        }
    }
}
