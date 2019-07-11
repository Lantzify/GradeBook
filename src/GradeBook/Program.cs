using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 12.1, 13.33, 51.33 };
            grades.Add(23.12);

            var result = 0.0;
            foreach(double number in grades){
                result += number;
            }

            result /= grades.Count;
            Console.WriteLine($"The average is {result:N1}");
        }
    }
}
