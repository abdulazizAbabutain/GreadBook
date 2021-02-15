using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("CS book");
            book.gradeAdded += OnGradeAdded;

            EnterGrade(book);

            var result = book.GetStatistics();

            Console.WriteLine($"the highest grade {result.High}");
            Console.WriteLine($"the lowest grade {result.Low}");
            Console.WriteLine($"the avarage grade {result.Average}");

        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or q to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.addGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Grade was added");

        }
    }
}
