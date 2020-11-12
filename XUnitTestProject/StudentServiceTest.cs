using System;
using System.Collections.Generic;
using System.IO;
using Core.Interfaces;
using Core.Interfaces.ApplicationService;
using Core.Services;
using Moq;
using Xunit;

namespace XUnitTestProject
{
    //This class tests the student service class in the core. 
    //Random change. 
    //why would you do this??????
    public class StudentServiceTest
    {
        // Fake store for repository
        private List<Student> dataStore;
        private Mock<IStudentRepository> repoMock;

        public StudentServiceTest()
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


        [Fact]
        public void UpdateTest()
        {
            // arrange
            IStudentRepository repo = repoMock.Object; 
            IStudentService service = new StudentService(repo);

            Student s = new Student()
            {
                StudentId = 1, 
                ZipCode = 4356,
                Name = "mike", 
                Address = "stuff 35", 
                PostalDistrict = "NU"





            };



            // act
            service.Update(s);

            // asset 
            repoMock.Verify(repo => repo.Update(It.Is<Student>(student =>  student == s)), Times.Once);

        }

        [Fact]
        public void UpdateArgumentExceptionExeptionTest()
        {
            // arrange
            IStudentRepository repo = repoMock.Object; 
            IStudentService service = new StudentService(repo);

            Student s = new Student()
            {
                StudentId = 1, 
                ZipCode = 4356,
                Address = "stuff 35", 
                PostalDistrict = "NU"




            };



            // act
            var ex = Assert.Throws<InvalidDataException>(() =>
            {
                service.Update(s);
            });


            //assert
            // assert
            Assert.Equal("missing mandatory fields", ex.Message);

            


        }

        [Fact]
        public void RemoveTest()
        {
            // arrange
            IStudentRepository repo = repoMock.Object;
            IStudentService service = new StudentService(repo);

            Student s = new Student()
            {
                StudentId = 1,
                ZipCode = 4356,
                Name = "mike",
                Address = "stuff 35",
                PostalDistrict = "NU"





            };



            // act
            service.Remove(s);

            // asset 
            repoMock.Verify(repo => repo.Remove(It.Is<Student>(student => student == s)), Times.Once);

        }

        [Fact]
        public void RemoveTest2()
        {
            // arrange
            IStudentRepository repo = repoMock.Object;
            IStudentService service = new StudentService(repo);

            Student s = new Student()
            {
                StudentId = 1,
                ZipCode = 4356,
                Name = "mike",
                Address = "stuff 35",
                PostalDistrict = "NU"





            };



            // act
            service.Remove(s);

            // asset 
            repoMock.Verify(repo => repo.Remove(It.Is<Student>(student => student == s)), Times.Once);

        }

    }
}
