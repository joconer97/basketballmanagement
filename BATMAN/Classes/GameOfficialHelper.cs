using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class GameOfficialHelper
    {
        public static void SaveGameOfficial(GameOfficial official)
        {
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return;

                SqlParameter[] spParam = {
                                        new SqlParameter("@officialID", official.officialID),
                                        new SqlParameter("@firstName",official.firstName),
                                        new SqlParameter("@lastName",official.lastName),

                                        };

                try
                {
                    dal.ExecuteNonQuery("spSaveGameOfficial", spParam);
                }
                catch
                {
                    return;
                }
            }
        }

        public static void DeleteGameOfficial(GameOfficial official)
        {
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return;

                SqlParameter[] spParam = {
                                        new SqlParameter("@officialID", official.officialID),
                                        };

                try
                {
                    dal.ExecuteNonQuery("spDeleteGameOfficial", spParam);
                }
                catch
                {
                    return;
                }
            }
        }

        public static List<GameOfficial> GetAllGameOfficial(Tournament tournament)
        {
            List<GameOfficial> list = null;
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return null;

                SqlParameter[] spParam = {
                                        new SqlParameter("tournamentID",tournament.tournamentID)
                                        };


                var datarow = dal.ExecuteQuery("spGetAllOfficial",spParam).Tables[0];
                list = new List<GameOfficial>();
                foreach (var dr in datarow.AsEnumerable())
                {
                    GameOfficial official = new GameOfficial()
                    {
                        officialID = dr.Field<int>(0),
                        firstName = dr.Field<string>(1),
                        lastName = dr.Field<string>(2),
                    };

                    list.Add(official);
                }


            }

            return list;
        }
    }
}
