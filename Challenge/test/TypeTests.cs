using System;
using ChallengeApp;
using Xunit;

namespace Challenge.tests
{
    public class TypeTests
    {
        public delegate string WriteMessage(string message);

        int counter =0;

        [Fact]
        public void WriteMessageDelegateCanPointToMethod()
        {
            WriteMessage del = ReturnMessage;
            del += ReturnMessage;
            del += ReturnMessage2;
            var result = del("HELLO!!");
            AssertEqual(3, counter);
        }

        string ReturnMessage(string message)
        {
            counter ++;
            return message;
        }

        string ReturnMessage2(string message)
        {
            counter ++;
            return message.ToUpper();
        }

        [Fact]
        public void GetStudentReturnsDifferentsObjects()
        {
            var stud1 = GetStudent("Dorota");
            var stud2 = GetStudent("Grzegorz");

            Assert.NotSame (stud1, stud2);
            Assert.False(Object.ReferenceEquals(stud1, stud2));
        }

        [Fact]
        public void CSharpCannPassByRef()
        {
            var stud1 = GetStudent("Student 1");
            GetStudentSetName(out stud1, "NewName");
            AssertEqual("NewName", stud1.Name);
        }

        private void GetStudentSetName(out Student stud, string name)
        {
            stud = new Student(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var stud1 = GetStudent("Dorota");
            this.SetName(ref stud1, "New Name");

            Assert.Equal("New Name", stud1.Name);
        }

        private Student GetStudent(string name)
        {
            return new Student(name);
        }
    }
}
