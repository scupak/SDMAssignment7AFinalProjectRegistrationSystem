using System;
using System.Collections.Generic;
using System.IO;
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
           Repository.Add(s);
       }

       public void Update(Student s)
       {
           if (s.StudentId < 1 || s.Name == null || s.Address == null || s.ZipCode < 1 || s.PostalDistrict == null || s.Email == null )
           {
                throw new InvalidDataException("missing mandatory fields");

           }

           Repository.Update(s);
       }

       public void Remove(Student s)
       {
           throw new NotImplementedException();
       }
   }
}
