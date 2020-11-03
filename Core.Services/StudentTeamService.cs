using Model;
using System;
using Core.Interfaces;
using Core.Interfaces.DomainService;
using Core.Services;

namespace Services
{
    public class StudentTeamService
    {
        public const int MAX_STUDENTS = 4;

        private readonly IStudentRepository StudentsRepo;
        private readonly ITeamRepository TeamsRepo;

        public StudentTeamService(IStudentRepository studentRepository, ITeamRepository teamRepository)
        {
            this.StudentsRepo = studentRepository ?? throw new ArgumentException("StudentRepository is missing");
            this.TeamsRepo = teamRepository ?? throw new ArgumentException("TeamRepository is missing");
        }

        public void AddStudentToTeam(Team team, Student student)
        {
            if (team == null)
            {
                throw new ArgumentException("Team is missing");
            }
            
            if (student == null)
            {
                throw new ArgumentException("Student is missing");
            }

            var fetchedTeam = TeamsRepo.GetById(team.Id);
            
            if (fetchedTeam == null)
            {
                throw new ArgumentException("Team not found");
            }

            if (fetchedTeam.Students.Count == MAX_STUDENTS)
            {
                throw new InvalidOperationException("Team is full");
            }
            
            if (IsAssignedToTeam(student))
            {
                throw new InvalidOperationException("Student is already assigned to a team");
            }
            
            var fetchedStudent = StudentsRepo.GetById(student.StudentId);
            
            if (fetchedStudent == null)
            {
                throw new ArgumentException("Student not found");
            }

            fetchedTeam.Students.Add(fetchedStudent);
            TeamsRepo.Update(fetchedTeam);
        }

        private bool IsAssignedToTeam(Student student)
        {
            foreach (var team in TeamsRepo.GetAll())
            {
                if (team.Students.Contains(student))
                    return true;
            }
            return false;
        }
    }
}
