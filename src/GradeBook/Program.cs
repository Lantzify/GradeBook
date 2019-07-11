using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(98.1);
            book.AddGrade(77.4);
            book.ShowStatistics();
        }
    }
}
