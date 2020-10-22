using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;
using Core.Interfaces.ApplicationService;

namespace Core.Services
{
   public class StudentService : IStudentService
   {
       private IStudentRepository Repository;

       public StudentService(IStudentRepository repository)
       {
           Repository = repository;
       }

       public IEnumerable<Student> GetAll()
       {
           return Repository.GetAll();
       }

       public Student GetById(int id)
       {
           return Repository.GetById(id);
       }

       public void Add(Student s)
       {
           if (s.Name == null || s.Address == null || s.PostalDistrict == null || s.StudentId == 0)
           {
               throw new ArgumentException("Id, ZipCode, name, address and postalDistrict are mandatory fields");
           }

           if (s.StudentId < 0 || s.ZipCode < 0)
           {
               throw new ArgumentException("Id and ZipCode must be positive");
           }

           Repository.Add(s);
       }

       public void Update(Student s)
       {
           throw new NotImplementedException();
       }

       public void Remove(Student s)
       {
           throw new NotImplementedException();
       }
   }
}
