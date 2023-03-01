using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class InMemoryStudent : StudentBase
    {   
        private List<double> grades;

        public InMemoryStudent(string name, string surname) : base(name, surname)

        {grades = new List<double>();}

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
