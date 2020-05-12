using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class VenueHelper
    {
        public static List<Venue> GetVenue()
        {
            List<Venue> list = null;

            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return null;

                var data = dal.ExecuteQuery("spGetVenue").Tables[0];

                list = new List<Venue>();

                foreach (var dr in data.AsEnumerable())
                {
                    Venue venue = new Venue()
                    {
                        venueID = dr.Field<short>(0),
                        venueName = dr.Field<string>(1)
                    };

                    list.Add(venue);
                }
            }
            return list;
        }
    }
}
