using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class RefereeHelper
    {

        public static void SaveReferee(Referee referee)
        {
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return;

                SqlParameter[] param =
                {
                    new SqlParameter("@officialID",referee.official.officialID),
                    new SqlParameter("@tournamentID",referee.tournament.tournamentID)
                };

                dal.ExecuteNonQuery("spSaveReferee", param);
            }
        }

        public static List<Referee> GetReferee(Tournament tournament)
        {
            List<Referee> list = null;

            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return null;

                SqlParameter[] param = { new SqlParameter("@tournamentID", tournament.tournamentID) };

                var data = dal.ExecuteQuery("spGetReferee", param).Tables[0];

                list = new List<Referee>();

                foreach(var dr in data.AsEnumerable())
                {
                    Referee referee = new Referee()
                    {
                        refereeID = dr.Field<int>(0),
                        official = new GameOfficial()
                        {
                            officialID = dr.Field<int>(1),
                            firstName = dr.Field<string>(2),
                            lastName = dr.Field<string>(3),
                        },
                    };

                    list.Add(referee);
                }
            }
                return list;
        }
    }
}
