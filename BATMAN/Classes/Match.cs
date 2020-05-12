using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class Match
    {
        public int matchID { get; set; }
        public int homeTimeOut { get; set; }
        public int guestTimeOut { get; set; }

        public Tournament tournament { get; set; }
        public Venue venue { get; set; }
        public Referee referee1 { get; set; }
        public Referee referee2 { get; set; }

        public Team homeTeam { get; set; }
        public Team guestTeam { get; set; }




        public static List<Match> GenerateMatch(List<Team> listTeam,List<Venue> venue,Tournament tournament)
        {
            List<Match> match = new List<Match>();
            List<Team> tempTeam = Team.ShuffleTeam(listTeam);
            List<Referee> tempOfficial = RefereeHelper.GetReferee(tournament);
            Random randOfficial = new Random();
            Random randVenue = new Random();

            int left, right;
            for (int i = 0; i < tempTeam.Count - 1; i++)
            {
                left = 0;
                right = tempTeam.Count - 1;
                while (left < right)
                {
                    int x1;

                    if (tempOfficial.Count == 0)
                    {
                        tempOfficial = RefereeHelper.GetReferee(tournament);
                    }

                    //REFEFREE 1
                    x1 = randOfficial.Next(0, tempOfficial.Count);
                    Referee referee1 = tempOfficial[x1];
                    tempOfficial.RemoveAt(x1);
                    
                    if(tempOfficial.Count == 0)
                    {
                        tempOfficial = RefereeHelper.GetReferee(tournament);
                    }

                    //REFEREE2
                    x1 = randOfficial.Next(0, tempOfficial.Count);
                    Referee referee2 = tempOfficial[x1];
                    tempOfficial.RemoveAt(x1);

                    Match tempMatch = new Match()
                    {
                        homeTimeOut = 0,
                        guestTimeOut = 0,
                        venue = venue[randVenue.Next(0, venue.Count)],
                        homeTeam = tempTeam[left],
                        guestTeam = tempTeam[right],
                        referee1 = new Referee()
                        {
                            refereeID = referee1.refereeID
                        },
                        referee2 = new Referee()
                        {
                            refereeID = referee2.refereeID,
                        },
                        tournament = new Tournament()
                        {
                            tournamentID = tournament.tournamentID
                        }
                    };
                
                    match.Add(tempMatch);
                    left++;
                    right--;
                }

                Team.RoundRobin(tempTeam);
            }

            return match;

        }

        
        
     
    }
}
