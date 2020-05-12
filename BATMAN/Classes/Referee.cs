using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class Referee
    {
        public int refereeID { get; set; }

        public GameOfficial official { get; set; }

        public Tournament tournament { get; set; }

    }
}
