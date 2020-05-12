using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class StaffPositionHelper
    {

        public static List<StaffPosition> GetAllPosition()
         {
             List<StaffPosition> list = null;

             using (DAL dal = new DAL())
             {
                 if (!dal.IsConnected) return null;

  
                var data = dal.ExecuteQuery("spGetStaffPosition").Tables[0];

                list = new List<StaffPosition>();

                 foreach(var dr in data.AsEnumerable())
                 {
                    StaffPosition position = new StaffPosition()
                    {
                        positionID = dr.Field<short>(0),
                        positionDetail = dr.Field<string>(1)
                    };
                    list.Add(position);
                 }

                return list;
             }

         }
             
    }
}
