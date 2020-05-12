using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BATMAN.Classes;

namespace BATMAN.Classes
{
    public class UserHelper
    {
        public int login(User user)
        {
            using (DAL dal = new DAL())
            {
                SqlParameter[] spParams = {
                    new SqlParameter("@username", user.username),
                    new SqlParameter("@password", user.password)
                };

                return (int)dal.ExecuteQueryScalar("spLogin", spParams);
            } 
        }
    }
}
