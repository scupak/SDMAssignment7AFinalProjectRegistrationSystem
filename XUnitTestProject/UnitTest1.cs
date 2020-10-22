using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Interfaces.ApplicationService;
using Core.Services;
using Moq;
using Xunit;

namespace XUnitTestProject
{
    //Random change. 
    public class UnitTest1
    {
        // Fake store for repository
        private List<Student> dataStore;
        private Mock<IStudentRepository> repoMock;

        public UnitTest1()
        {
            dataStore = new List<Student>();

            repoMock = new Mock<IStudentRepository>();
            repoMock.SetupAllProperties();

            repoMock.Setup(x => x.GetAll()).Returns(() => dataStore.ToArray());
        }

        [Fact]
        public void AddTest()
        {
            // arrange
            IStudentRepository repo = repoMock.Object; 
            IStudentService service = new StudentService(repo);

            Student s = new Student()
            {
                StudentId = 1

            };

            // act
            service.Add(s);

            // asset 
            repoMock.Verify(repo => repo.Add(It.Is<Student>(student =>  student == s)), Times.Once);

        }
    }
}
