using System;
using System.Collections.Generic;
using System.Text;
using Core.Services;
using Model;

namespace Core.Interfaces.ApplicationService
{
  public interface ITeamService
    {
        public void CreateTeam(int  id);
        public void  RemoveTeam(Team  t);
        public void  AddStudentToTeam(Team  t, Student  s);
        public void  MoveStudentToNewTeam(Team  oldTeam,  Team newTeam, Student  s);
        public void  RemoveStudentFromTeam(Team  t, Student  s);
        public IEnumerable<Team> GetAllTeams(); 
        public Team GetTeamById(int  id); 
       public IEnumerable<Student> GetNonAssignedStudents(); 
    }
}
