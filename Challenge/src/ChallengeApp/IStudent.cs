namespace ChallengeApp
{
    public interface IStudent
    {
        string Name {get; set;}
        string Surname {get; set;}
        event LowGradeAddedDelegate LowGradeAdded;
        void AddGrade(double grade);

        void AddGrade(string input);

        Statistics GetStatistics();      
    }
}
