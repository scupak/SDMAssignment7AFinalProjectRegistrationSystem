using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core.Services;

namespace Core.Interfaces.ApplicationService
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(Student s);
        void Update(Student s);
        void Remove(Student s);
    }
}
