using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces.ApplicationService;
using Model;

namespace Core.Services
{
    class TeamService : ITeamService
    {
        public void CreateTeam(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveTeam(Team t)
        {
            throw new NotImplementedException();
        }

        public void AddStudentToTeam(Team t, Student s)
        {
            throw new NotImplementedException();
        }

        public void MoveStudentToNewTeam(Team oldTeam, Team newTeam, Student s)
        {
            throw new NotImplementedException();
        }

        public void RemoveStudentFromTeam(Team t, Student s)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public Team GetTeamById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetNonAssignedStudents()
        {
            throw new NotImplementedException();
        }
    }
}
