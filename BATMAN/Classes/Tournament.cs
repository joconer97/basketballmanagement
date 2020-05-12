using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BATMAN.Classes
{
    public class Tournament
    {
        public string tournamentTitle { get; set; }
        public int tournamentID { get; set; }
        public string tournamentMotto { get; set; }
        public DateTime tournamentStart { get; set; }
        public DateTime tournamentEnd { get; set; }

        public int tournamentStatus { get; set; }

  


        public bool isValid()
        {
            if(Convert.ToDateTime(tournamentStart) < Convert.ToDateTime(tournamentEnd) && tournamentTitle.Length > 0 && tournamentMotto.Length > 0)
            {
                return true;

            }
            return false;
        }

        public bool ValidationOfActivation(List<Team> team,List<GameOfficial> gameofficial,List<Player> player)
        {
            bool valid = true;
            List < Player > temp = null;
            if(team.Count >= 2 && gameofficial.Count >= 2)
            {
                foreach (var t in team)
                {
                    temp = Player.PlayerByTeam(player,t.teamID);
                    if (temp.Count < 5)
                        return false;
                }

            }
            else
            {
                valid = false;
            }

            return valid;
        }
        
    }
}
