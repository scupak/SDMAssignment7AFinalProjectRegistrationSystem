﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces.ApplicationService;
using Core.Interfaces.DomainService;
using Model;

namespace Core.Services
{
  public class TeamService 
    {
       
        private ITeamRepository repo;

        public TeamService(ITeamRepository repo)
        {
            this.repo = repo ?? throw new ArgumentException("Team Repository is missing");
        }

        public void AddTeam(Team t)
        {
            if (t == null)
            {
                throw new ArgumentException("Team is missing");
            }
            if (repo.GetById(t.Id) != null)
            {
                throw new InvalidOperationException("Team already in Repository");
            }

            ValidateTeam(t);
            repo.Add(t);
        }

        private void ValidateTeam(Team t)
        {
            if (t.Id <= 0)
            {
                throw new ArgumentException("Invalid Team Id");
            }
            if (t.Students == null)
            {
                throw new ArgumentException("Invalid Students property");
            }
        }

        public void UpdateTeam(Team team)
        {
            if (team == null)
            {
                throw new ArgumentException("Team is missing");
            }

            ValidateTeam(team);

            if (repo.GetById(team.Id) == null)
            {
                throw new InvalidOperationException("Team does not exist in the Team Repository");
            }

            repo.Update(team);
        }
        public void RemoveTeam(Team team)
        {
            if (team == null)
            {
                throw new ArgumentException("Team is missing");
            }
            if (repo.GetById(team.Id) == null)
            {
                throw new InvalidOperationException("Team does not exist");
            }
            repo.Remove(team);
        }

        public object GetTeamById(int teamId)
        {
            return repo.GetById(teamId);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return repo.GetAll();
        }
    }
}
