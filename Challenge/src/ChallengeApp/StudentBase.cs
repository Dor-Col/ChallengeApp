using System;
namespace ChallengeApp
{
    public delegate void LowGradeAddedDelegate(object sender, EventArgs args);

    public abstract class StudentBase : NamedObject, IStudent
    {
        public StudentBase(string name, string surname) : base(name, surname)
    {        
    }
        public event LowGradeAddedDelegate LowGradeAdded;

        public abstract void AddGrade(double grade);

        public abstract void AddGrade(string input);

        public abstract Statistics GetStatistics();

        protected void CheckEventLowGrade()
        {
            if (LowGradeAdded != null)
            {
                LowGradeAdded(this, new EventArgs());
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
    }
}
