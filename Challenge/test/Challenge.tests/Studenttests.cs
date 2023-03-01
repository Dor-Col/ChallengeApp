using System;
using ChallengeApp;
using Xunit;

namespace Challenge.tests
{
    public class Studenttests
    {
        [Fact]
        public void Test1()
        {
            //arrage
            var student = new SavedStudent("Grzegorz", "Kowalski");
            student.AddGrade(1);
            student.AddGrade(1.5);
            student.AddGrade(5);   
                  
            //act
            var result = student.GetStatistics();

            //assert
            Assert.Equal(2.5, result.Average);
            Assert.Equal(5, result.High);
            Assert.Equal(1, result.Low);
        }
    }
}
