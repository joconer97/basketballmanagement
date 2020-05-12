using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class Player
    {
        public int playerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthdate { get; set; }
        public short jerseyNO { get; set; }

        public string picture { get; set; }

        public Position position { get; set; }

        public Team team { get; set; }

        public static List<Player> PlayerByTeam(List<Player> player,int teamID)
        {
            List<Player> list = null;

            var data = from xi in player
                       where xi.team.teamID == teamID
                       select xi;
            list = new List<Player>();
            foreach(var dr in data.AsEnumerable())
            {
                list.Add(dr);
            }

            return list;
        }

    }
}
