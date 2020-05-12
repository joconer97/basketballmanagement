using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BATMAN.Classes
{
    class TournamentHelper
    {
        public static int SaveTournament(Tournament tournament)
        {
            using (DAL dal = new DAL())
            {
                SqlParameter[] spParams = {
                    new SqlParameter("@tournamentTitle",tournament.tournamentTitle),
                    new SqlParameter("@tournamentStart",tournament.tournamentStart),
                    new SqlParameter("@tournamentEnd",tournament.tournamentEnd),
                    new SqlParameter("@tournamentMotto",tournament.tournamentMotto),
                    new SqlParameter("@tournamentID",tournament.tournamentID),
                    new SqlParameter("@tournamentStatus",1),
                };

                    if (validateTournament(tournament) > 0 && tournament.tournamentID == 0)
                        return 0;
                try
                {
                    dal.ExecuteNonQuery("spSaveTournament", spParams);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static int DeleteTournament(int id)
        {
            using (DAL dal = new DAL())
            {
                SqlParameter[] spParams = {
                         new SqlParameter("@tournamentID",id),
                   
                };

                try
                {
                    dal.ExecuteNonQuery("spDeleteTournament", spParams);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static int UpdateTournamentStatus(Tournament tournament)
        {
            using (DAL dal = new DAL())
            {
                SqlParameter[] spParams = {
                         new SqlParameter("@tournamentID",tournament.tournamentID),
                         new SqlParameter("@tournamentStatus",tournament.tournamentStatus),

                };


                try
                {
                    dal.ExecuteNonQuery("spUpdateStatus", spParams);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        private static int validateTournament(Tournament tournament)
        {
            using (DAL dal = new DAL())
            {
                SqlParameter[] spParams = {
                    new SqlParameter("@tournamentStart",tournament.tournamentStart),
                };
                return (int)dal.ExecuteQueryScalar("spValidateTournament",spParams);
            }
        }


        public static List<Tournament> GetTournament()
        {
            List<Tournament> list = null;

            using (DAL dal = new DAL())
            {
                list = new List<Tournament>();

                var data = dal.ExecuteQuery("spGetTournament").Tables[0];

                foreach(DataRow dr in data.AsEnumerable())
                {
                    Tournament tournament = new Tournament()
                    {
                        tournamentID = dr.Field<int>(0),
                        tournamentMotto = dr.Field<string>(1),
                        tournamentTitle = dr.Field<string>(2),
                        tournamentStart = dr.Field<DateTime>(3),
                        tournamentEnd = dr.Field<DateTime>(4),
                        tournamentStatus = dr.Field<short>(5)
                    };

                    

                    list.Add(tournament);
                }
                return list;
            }
        }
    }
}
