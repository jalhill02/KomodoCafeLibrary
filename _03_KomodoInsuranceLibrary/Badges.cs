using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _03_KomodoInsuranceLibrary
{
    

    public class Badges
    {
        public int BadgeId { get; set; }
        public List<DoorNames> DoorName { get; set; } = new List<DoorNames>();


        public Badges()
        {

        }

        public Badges(int badgeId, List<DoorNames> doorName)
        {
            BadgeId = badgeId;
            DoorName = doorName;

        }
    }
}
