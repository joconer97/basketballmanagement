using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class TeamOfficialHelper
    {

        public static int SaveTeamOfficial(TeamOfficial official)
        {
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return 0;

                SqlParameter[] param =
                {
                    new SqlParameter("@teamOfficialID",official.id),
                    new SqlParameter("@firstName",official.firstName),
                    new SqlParameter("@lastName",official.lastName),
                    new SqlParameter("@teamID",official.team.teamID),
                    new SqlParameter("@positionID",official.position.positionID)
                };
                try
                {
                    dal.ExecuteNonQuery("spSaveTeamOfficial", param);
                }
                catch
                {
                    return 0;
                }

                return 1;
            }
        }

        public static int DeleteTeamOfficial(TeamOfficial official)
        {
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return 0;

                SqlParameter[] param ={ new SqlParameter("@teamOfficialID",official.id)};
                try
                {
                    dal.ExecuteNonQuery("spDeleteTeamOfficial", param);
                }
                catch
                {
                    return 0;
                }

                return 1;
            }
        }

        public static List<TeamOfficial> GetAllOfficial(Tournament tournament)
        {
            List<TeamOfficial> list = null;
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return null;
                SqlParameter[] param =
                {
                    new SqlParameter("@tournamentID",tournament.tournamentID)
                };
               var data =  dal.ExecuteQuery("spGetAllTeamOfficial",param).Tables[0];


                list = new List<TeamOfficial>();
                foreach(var dr in data.AsEnumerable())
                {
                    TeamOfficial official = new TeamOfficial()
                    {
                        id = dr.Field<int>(0),
                        firstName = dr.Field<string>(1),
                        lastName = dr.Field<string>(2),
                        position = new StaffPosition()
                        {
                            positionID = dr.Field<short>(4),
                            positionDetail = dr.Field<string>(6)
                        },
                        team = new Team()
                        {
                            teamID = dr.Field<int>(3),
                            teamName = dr.Field<string>(5)
                        }

                    };

                    list.Add(official);
                }
                return list;
            }
        }

       
    }
}
