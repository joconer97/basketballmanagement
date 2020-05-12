using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATMAN.Classes
{
    public class GameOfficial
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public int officialID { get; set; }


        public bool isValid()
        {
            if (firstName.Length > 0 || lastName.Length > 0)
                return true;

            return false;
        }

        public static List<GameOfficial> GetOfficial(List<GameOfficial> official)
        {
            List<GameOfficial> list = new List<GameOfficial>();

            foreach (var of in official)
            {
                var temp = new GameOfficial()
                {
                    firstName = of.firstName,
                    lastName = of.lastName,
                    officialID = of.officialID,
                };

                list.Add(temp);
            }

            return list;
        }
    }
}
