using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.DomainService
{
   public interface ITeamRepository
    {

         void Add(Team t);
         void Update(Team t); 
         void Remove(Team t);
         IEnumerable<Team> GetAll();
         Team GetById(int id); 
    }
}
