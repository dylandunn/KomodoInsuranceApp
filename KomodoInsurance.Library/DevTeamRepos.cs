using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class DevTeamRepos
    {
        private List<DevTeam> _listofDevTeams = new List<DevTeam>();
        
        public bool AddDevloperToDevTeam(string teamName, Developer devlopers)
        {
            DevTeam devTeam = GetDevTeamByTeamName(teamName);

            int initalNumber = devTeam.Devlopers.Count;

            if(devlopers == null)
            {
                return false;
            }
            
           devTeam.Devlopers.Add(devlopers);


            if (initalNumber < devTeam.Devlopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Create
        public void AddDevTeamToList(DevTeam devTeam)
        {
            _listofDevTeams.Add(devTeam);
        }

       
        //Read
        public List<DevTeam> GetDevTeamList()
       
        {
            return _listofDevTeams;
        }
        //Update
        public bool UpdateExistingDevTeamByTeamName(string originalTeamName, DevTeam newdevTeam)
        {
            DevTeam oldDevTeam = GetDevTeamByTeamName(originalTeamName);
            if(oldDevTeam != null)
            {
                oldDevTeam.Devlopers = newdevTeam.Devlopers;
                oldDevTeam.TeamName = newdevTeam.TeamName;
                oldDevTeam.TeamID = newdevTeam.TeamID;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveDevTeamFromListByTeamName(string teamName)
        {
            DevTeam devTeam = GetDevTeamByTeamName(teamName);
            if (devTeam == null)
            {
                return false;
            }
            int intialCount = _listofDevTeams.Count;
            _listofDevTeams.Remove(devTeam);
            if(intialCount > _listofDevTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        private DevTeam GetDevTeamByTeamName(string teamName)
        {
            foreach(DevTeam devTeam in _listofDevTeams)
            {
                if(devTeam.TeamName == teamName)
                {
                    return devTeam;
                }
            }
            return null;
        }
    }
}
