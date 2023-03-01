using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
        public class SavedStudent : StudentBase
    {
        private const string fileName = "_grades.txt";

        public SavedStudent(string name, string surname) : base(name, surname)
        {
        }
        public bool HasGrades()
        {
            if (this.grades.Count > 0)
                return true;
            return false;
        }
        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 6.5)
            {
                this.grades.Add(grade);
                Console.WriteLine($"Grade {grade} has been added");
                using (var writer = File.AppendText($"{Name} {fileName}"))
                using (var writer2 = File.AppendText($"audit.txt"))
                {
                    writer.WriteLine(grade);
                    writer2.WriteLine($"{Name} {Surname} {DateTime.Now}");
                }
                if (grade < 3)
                {
                    CheckEventLowGrade();
                }
            }
            else
            {
                throw new ArgumentException($"Invalid value, out of range, only grades from 0 to 6");

            }
        }
        
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name} {fileName}"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
            }
    }
}
