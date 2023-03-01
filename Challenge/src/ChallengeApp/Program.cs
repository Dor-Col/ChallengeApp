using System;
namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new SavedStudent("Grzegorz", "Kowalski");
            student.LowGradeAdded += LowGradeAdded; 
            EnterGrade(student);
            if (student.HasGrades())
            {
                var stat = student.GetStatistics(); 
                Console.WriteLine($"Grzegorz's lowest grade is: {stat.Low:N2}");
                Console.WriteLine($"Grzegorz's highest grade is: {stat.High:N2}");
                Console.WriteLine($"Grzegorz's average grade is: {stat.Average:N2}");
            }
        }

        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade for {student.Name}");
                Console.WriteLine($"to exit press q");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    Console.WriteLine($"Adding grades was ended.");
                    break;
                }
                try
                {
                    student.AddGrade(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void LowGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Oh no! We should inform student’s parents about this fact");
        }
    }
}