using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class Team
    {
        public int teamID { get; set; }
        public string teamName { get; set; }
        public string teamSlogan { get; set; }

        public string teamLogo { get; set; }

        public Baranggay barangay{get;set;}
        public Tournament tournament { get; set; }

        //METHODS
        public static Team GetTeam(List<Team> listTeam, int id)
        {
            Team team = null;

            var data = from st in listTeam
                       where st.teamID == id
                       select st;

            foreach (var dr in data.AsEnumerable())
            {
                team = dr;
            }

            return team;
        }

        public static Team GetTeamByName(Tournament tournament,string name)
        {
            List<Team> listTeam = TeamHelper.GetTeam(tournament);
            Team team = null;

            var data = from st in listTeam
                       where string.Equals(st.teamName.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase)
                       select st;

            foreach (var dr in data.AsEnumerable())
            {
                team = dr;
            }

            return team;
        }

        //Validation

        public static bool isValid(List<Team> list,Team updateTeam,Team team)
        {
            foreach(Team t in list)
            {
                if (updateTeam.teamID == 0)
                {
                    if (string.Equals(t.teamName, updateTeam.teamName, StringComparison.OrdinalIgnoreCase) || t.barangay.id == updateTeam.barangay.id && t.tournament.tournamentID == updateTeam.tournament.tournamentID)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!string.Equals(team.teamName, updateTeam.teamName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (string.Equals(t.teamName, updateTeam.teamName, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }

                    if(!(team.barangay.id == updateTeam.barangay.id))
                    {
                        if(t.barangay.id == updateTeam.barangay.id)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public static List<Team> ShuffleTeam(List<Team> list)
        {
            Random rand = new Random();
            int total = list.Count;
            int totalOfTeam = list.Count;
            List<Team> tempTeam = new List<Team>();
            //FOR SHUFFLING TEAM
            for (int i = 0; i < total; i++)
            {
                int r = rand.Next(0, totalOfTeam);
                tempTeam.Add(list[r]);
                list.RemoveAt(r);
                totalOfTeam--;
            }

            return tempTeam;
        }
        public static List<Team> RoundRobin(List<Team> team)
        {
            Team temp = team[team.Count - 1];
            for (int j = team.Count - 1; j >= 1; j--)
            {
                team[j] = team[j - 1];
            }
            team[1] = temp;

            return team;
        }
    }
}
