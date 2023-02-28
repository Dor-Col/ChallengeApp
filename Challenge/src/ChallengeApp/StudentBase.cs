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
       
    }
}
