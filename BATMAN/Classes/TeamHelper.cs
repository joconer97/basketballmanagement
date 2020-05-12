using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class TeamHelper
    {
        public static int SaveTeam(Team team)
        {
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return 0;

                SqlParameter[] spParams = {
                                new SqlParameter("@teamID",team.teamID),
                                new SqlParameter("@teamName",team.teamName),
                                new SqlParameter("@teamSlogan",team.teamSlogan),
                                new SqlParameter("@teamLogo",team.teamLogo),
                                new SqlParameter("@barangayID",team.barangay.id),
                                new SqlParameter("@tournamentID",team.tournament.tournamentID)
                                };
               
                dal.ExecuteNonQuery("spSaveTeam",spParams);


            }

            return 1;
        }

        public static List<Team> GetTeam(Tournament tournament = null)
        {
            List<Team> list = null;
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return null;

                SqlParameter[] param = { new SqlParameter("@tournamentID", tournament.tournamentID) };
               var data =  dal.ExecuteQuery("spGetTeam",param).Tables[0];
               list = new List<Team>();

                foreach(var dr in data.AsEnumerable())
                {
                    Team team = new Team()
                    {
                        teamID = dr.Field<int>(0),
                        teamName = dr.Field<string>(1),
                        teamSlogan = dr.Field<string>(2),
                        teamLogo = dr.Field<string>(3),
                        barangay = new Baranggay()
                        {
                            id = dr.Field<int>(4),
                            name = dr.Field<string>(6),
                        },
                        tournament = new Tournament()
                        {
                            tournamentID = dr.Field<int>(5)
                        }

                    };

                    list.Add(team);
                }

                return list;

            }
        }
        public static bool DeleteTeam(Team team)
        {
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return false;

                SqlParameter[] param = { new SqlParameter("@teamID", team.teamID) };

                dal.ExecuteNonQuery("spDeleteTeam", param);
            }
                return true;
        }
       
    }
}
