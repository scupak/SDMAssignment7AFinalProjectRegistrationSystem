using System;
using System.Collections.Generic;
using Core.Interfaces;
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
        public void Test1()
        {

        }
    }
}
