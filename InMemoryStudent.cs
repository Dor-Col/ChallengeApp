using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class InMemoryStudent : StudentBase
    {   
        private List<double> grades;
        public InMemoryStudent(string name, string surname) : base(name, surname)
        { grades = new List<double>(); }


        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 6.5)
            {
                this.grades.Add(grade);
                if (grade < 3)
                {
                    CheckEventLowGrade();
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public override void AddGrade(string input)
        {
            var grade = input switch
            {
                "0+" => 0.5,
                "1-" => 0.75,
                "1+" => 1.5,
                "2-" => 1.75,
                "2+" => 2.5,
                "3-" => 2.75,
                "3+" => 3.5,
                "4-" => 3.75,
                "4+" => 4.5,
                "5-" => 4.75,
                "5+" => 5.5,
                "6-" => 5.75,
                "6+" => 6.5,
                _ => double.Parse(input),
            };

            if (grade >= 0 && grade <= 6.5)
            {
                this.AddGrade(grade);
            }

            else
            {
                throw new ArgumentException($"Invalid value, out of range, only grades from 0 to 6");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);
            }

            return result;
        }
    }
}
