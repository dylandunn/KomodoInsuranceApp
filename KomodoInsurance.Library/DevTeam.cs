using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class DevTeam
    {
        public List<Developer> Devlopers { get; set; } = new List<Developer>();
        public string TeamName { get; set; }
        public int TeamID { get; set; }

        public DevTeam() { }

        public DevTeam(List<Developer> developers, string teamName, int teamID)
        {
            Devlopers = developers;
            TeamName = teamName;
            TeamID = teamID;

        }
    }
}
