using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate gradeAdded;
        public abstract void addGrade(double grade);

        public abstract statistics GetStatistics();
    }

    public interface IBook
    {
        void addGrade(double grade);
        statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate gradeAdded;

    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate gradeAdded;

        public override void addGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (gradeAdded != null)
                {
                    gradeAdded(this, new EventArgs());
                }
            }
        }

        public override statistics GetStatistics()
        {
            throw new System.NotImplementedException();
        }
    }

    public class InMemoryBook : Book
    {
        // Felid section 
        private List<double> grades;

        // Method section 
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }

        public InMemoryBook() : base("")
        {
            grades = new List<double>();
        }

        public void addGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    addGrade(90);
                    break;
                case 'B':
                    addGrade(80);
                    break;

                case 'C':
                    addGrade(70);
                    break;

                case 'D':
                    addGrade(60);
                    break;

                default:
                    addGrade(0);
                    break;
            }
        }

        public override void addGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (gradeAdded != null)
                {
                    gradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");

            }

        }

        public override event GradeAddedDelegate gradeAdded;


        public override statistics GetStatistics()
        {
            var result = new statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            var index = 0;
            while (index < grades.Count)
            {
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
                index += 1;
            }
            result.Average /= grades.Count;

            switch (result.Average)
            {
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

            return result;
        }


    }
}