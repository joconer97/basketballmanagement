using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class MatchHelper
    {
        public static void SaveMatch(Match match)
        {
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return;

                SqlParameter[] param =
                { 
                    new SqlParameter("@matchID",match.matchID),
                    new SqlParameter("@homeTimeOut",match.homeTimeOut),
                    new SqlParameter("@guestTimeOut",match.guestTimeOut),
                    new SqlParameter("@tournamentID",match.tournament.tournamentID),
                    new SqlParameter("@venueID",match.venue.venueID),
                    new SqlParameter("@referee1ID",match.referee1.refereeID),
                    new SqlParameter("@referee2ID",match.referee2.refereeID),
                    new SqlParameter("@homeTeamID",match.homeTeam.teamID),
                    new SqlParameter("@guestTeamID",match.guestTeam.teamID),
                };

                dal.ExecuteNonQuery("spSaveMatch", param);
            }
        }


        public static List<Match> GetMatch(Tournament tournament)
        {
            List<Match> list = null;

            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return null;

                SqlParameter[] param = { new SqlParameter("@tournamentID", tournament.tournamentID) };

               var data = dal.ExecuteQuery("spGetMatch", param).Tables[0];

                list = new List<Match>();

                foreach(var dr in data.AsEnumerable())
                {
                    Match match = new Match()
                    {
                        matchID = dr.Field<int>(0),
                        homeTimeOut = dr.Field<short>(1),
                        guestTimeOut = dr.Field<short>(2),
                        tournament = new Tournament()
                        {
                            tournamentID = dr.Field<int>(3),
                        },
                        venue = new Venue()
                        {
                            venueID = dr.Field<short>(4),
                            venueName = dr.Field<string>(9),
                        },
                        
                        referee1 = new Referee()
                        {
                            refereeID = dr.Field<int>(5),
                            official = new GameOfficial() 
                            {
                                firstName =  dr.Field<string>(10),
                                lastName = dr.Field<string>(11),
                            },
                          
                        },
                        
                        referee2 = new Referee()
                        {
                            refereeID = dr.Field<int>(6),
                            official = new GameOfficial()
                            {
                                firstName = dr.Field<string>(12),
                                lastName = dr.Field<string>(13),
                            }
                        },
                        
                        homeTeam = new Team()
                        {
                            teamID = dr.Field<int>(7),
                            teamName = dr.Field<string>(15),
                            teamLogo = dr.Field<string>(17),
                            teamSlogan = dr.Field<string>(16),
                            barangay = new Baranggay()
                            {
                                id = dr.Field<int>(18),
                                name = dr.Field<string>(26)
                            },
                        },

                        guestTeam = new Team()
                        {
                            teamID = dr.Field<int>(20),
                            teamName = dr.Field<string>(21),
                            teamLogo = dr.Field<string>(23),
                            teamSlogan = dr.Field<string>(22),
                            barangay = new Baranggay()
                            {
                                id = dr.Field<int>(24),
                                name = dr.Field<string>(27)
                            },
                        }

                    };
                    list.Add(match);
                }

                return list;
            }
        }
    }
}
