using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BATMAN.Classes
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }


        public bool validate()
        {
            if (!(username.Length > 0 && password.Length > 0 )|| !(username == "Username" && password == "Password"))
                return true;

            return false;
        }
    }
}
