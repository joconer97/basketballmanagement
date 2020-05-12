using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class PlayerHelper
    {
        public static int SavePlayer(Player player)
        {
            using(DAL dal = new DAL())
            {
                if (!dal.IsConnected) return 0;

                SqlParameter[] param =
                {
                    new SqlParameter("@playerID",player.playerID),
                    new SqlParameter("@firstName",player.firstName),
                    new SqlParameter("@lastName",player.lastName),
                    new SqlParameter("@jerseyNO",player.jerseyNO),
                    new SqlParameter("@birthdate",player.birthdate),
                    new SqlParameter("@positionID",player.position.positionID),
                    new SqlParameter("@teamID",player.team.teamID),
                    new SqlParameter("@picture",player.picture)
                };

                dal.ExecuteNonQuery("spSavePlayer", param);

                return 1;
            }
        }

        public static List<Player> GetPlayer(Tournament tournament)
        {
            List<Player> list = null;

            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return null;
                SqlParameter[] param = { new SqlParameter("@tournamentID", tournament.tournamentID) };

                var data = dal.ExecuteQuery("spGetPlayer",param).Tables[0];

                list = new List<Player>();
                
                foreach(var dr in data.AsEnumerable())
                {
                    Player player = new Player()
                    {
                        playerID = dr.Field<int>(0),
                        firstName = dr.Field<string>(1),
                        lastName = dr.Field<string>(2),
                        jerseyNO = dr.Field<short>(3),
                        birthdate = dr.Field<DateTime>(4),
                        picture = dr.Field<string>(7),
                        position = new Position()
                        {
                            positionID = dr.Field<short>(5),
                            positionName = dr.Field<string>(9),
                        },
                        team = new Team()
                        {
                            teamID = dr.Field<int>(6),
                            teamName = dr.Field<string>(8),
                        }

                    };

                    list.Add(player);
                }

            }
                return list;
        }

        public static void DeletePlayer(Player player)
        {
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return;

                SqlParameter[] param =
                {
                    new SqlParameter("@playerID",player.playerID)
                };

                dal.ExecuteNonQuery("spDeletePlayer",param);
            }
        }
    }
}
