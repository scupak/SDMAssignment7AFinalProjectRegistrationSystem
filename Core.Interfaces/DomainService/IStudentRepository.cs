using System;
using System.Collections.Generic;
using System.Text;
using Core.Services;

namespace Core.Interfaces
{
    public interface IStudentRepository
    {
        //lol
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(Student s);
        void Update(Student s);
        void Remove(Student s);
    }
}
