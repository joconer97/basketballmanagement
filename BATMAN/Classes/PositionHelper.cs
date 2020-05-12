using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class PositionHelper
    {
        public static List<Position> GetPosition()
        {
            List<Position> list = null;
            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return null;

                var data = dal.ExecuteQuery("spGetPosition").Tables[0];
                list = new List<Position>();

                foreach(var dr in data.AsEnumerable())
                {
                    Position position = new Position()
                    {
                        positionID = dr.Field<short>(0),
                        positionName = dr.Field<string>(1)
                    };

                    list.Add(position);
                }

                return list;
            }
        }
    }
}
