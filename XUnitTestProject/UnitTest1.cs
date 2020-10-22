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
        public void AddNegativeIDandZipcodeExceptionTest()
        {
            // arrange
            IStudentRepository repo = repoMock.Object;
            IStudentService service = new StudentService(repo);

            Student s = new Student()
            {
                PostalDistrict = "København f",
                Name = "Gork",
                Email = "Gork@gork.dk",
                Address = "Gorkvej 12",
                ZipCode = -6790,
                StudentId = -1

            };

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                service.Add(s);
            });

            Assert.Equal("Id and ZipCode must be positive", ex.Message);
        }

        [Fact]
        public void AddWithoutFieldsExceptionTest()
        {
            // arrange
            IStudentRepository repo = repoMock.Object;
            IStudentService service = new StudentService(repo);

            Student s = new Student()
            {
                Email = "Gork@gork.dk"

            };

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                service.Add(s);
            });

            Assert.Equal("Id, ZipCode, name, address and postalDistrict are mandatory fields", ex.Message);
        }

        [Fact]
        public void AddTest()
        {
            // arrange
            IStudentRepository repo = repoMock.Object; 
            IStudentService service = new StudentService(repo);

            Student s = new Student()
            {
                PostalDistrict = "København f",
                Name  = "Gork",
                Email = "Gork@gork.dk",
                Address = "Gorkvej 12",
                ZipCode = 6790,
                StudentId = 1
                
            };

            // act
            service.Add(s);

            // asset 
            repoMock.Verify(repo => repo.Add(It.Is<Student>(student =>  student == s)), Times.Once);

        }

        [Fact]
        public void GetByIdTest()
        {
            // arrange
            IStudentRepository repo = repoMock.Object;
            IStudentService service = new StudentService(repo);

            

            // act
            service.GetById(1);

            // asset 
            repoMock.Verify(repo => repo.GetById(It.Is<int>(id => id == 1)), Times.Once);

        }

        [Fact]
        public void GetAllTest()
        {
            // arrange
            IStudentRepository repo = repoMock.Object; 
            IStudentService service = new StudentService(repo);

            Student s = new Student()
            {
                StudentId = 1

            };

            Student s2 = new Student()
            {
                StudentId = 2

            };

            dataStore = new List<Student>
            {
                s,
                s2

            };


            // act
            service.GetAll();

            // asset 
            repoMock.Verify(repo => repo.GetAll(), Times.Once);

        }

        
    }
}
