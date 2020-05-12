using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace BATMAN.Classes
{
    public class BarangayHelper
    {
        public static List<Baranggay> GetAllBarangay()
        {
            List<Baranggay> list = null;

            using (DAL dal = new DAL())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("spShowBarangay").Tables[0];

                list = new List<Baranggay>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    //get the individual columns of the DataRow
                    int id = dr.Field<int>(0);
                    string name = dr.Field<string>(1);

                    //create an instance of Barangay and add it onto the list
                    Baranggay brgy = new Baranggay() { id = id, name = name };
                    list.Add(brgy);

                }

            }

            return list;
        }

    }
}
