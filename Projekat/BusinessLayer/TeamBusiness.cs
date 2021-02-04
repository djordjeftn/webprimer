using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TeamBusiness
    {
        private readonly TeamRepository teamRepository;
        public TeamBusiness()
        {
            this.teamRepository = new TeamRepository();
        }

        public List<Team> GetAllTeams()
        {
            return this.teamRepository.GetAllTeams();
        }
        public List<Team> GetTeamsSort()
        {
            List<Team> team = this.teamRepository.GetAllTeams();
            for(int i= 0; i < team.Count-1; i++)
            {
                for (int j = i+1 ; j < team.Count; j++)
                {
                    if(team.ElementAt(i).Points > team.ElementAt(j).Points)
                    {
                        Team pom = team.ElementAt(i);
                        team[i] = team[j];
                        team[j] = pom;
                    }
                }
            }
            return team;
            //return team.OrderBy(t => t.Points).ToList(); 
        }
        public bool InsertAllTeams(Team t)
        {
            if (this.teamRepository.InsertAllTeams(t) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
