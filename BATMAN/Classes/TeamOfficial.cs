using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class TeamOfficial
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public StaffPosition position {get;set;}

        public Team team { get; set; }

      

        public static List<StaffPosition> listOfPositionAvailable(List<StaffPosition> listPosition, List<TeamOfficial> teamOfficial )
        {


            for(int i = 0; i < teamOfficial.Count;i++)
            {
              for(int j = 0; j < listPosition.Count; j++)
                {
                    if(teamOfficial[i].position.positionID == listPosition[j].positionID)
                    {
                        listPosition.RemoveAt(j);
                        break;
                    }
                }
            }
            return listPosition;
        }


        public static TeamOfficial ShowByTeam(List<TeamOfficial> listOfTeamOfficial, int teamID)
        {
            int ci = teamID;
            TeamOfficial official = new TeamOfficial();
            var data = from st in listOfTeamOfficial
                       where st.team.teamID == ci && st.position.positionDetail == "Coach"
                       select st;

            foreach (var dr in data.AsEnumerable())
            {

                official.id = dr.id;
                official.firstName = dr.firstName;
                official.lastName = dr.lastName;
                official.position = new StaffPosition()
                {
                    positionID = dr.position.positionID,
                    positionDetail = dr.position.positionDetail,
                };
                official.team = new Team()
                {
                    teamID = dr.team.teamID,
                    teamLogo = dr.team.teamName
                };
            }

            return official;

        }
    }
}
