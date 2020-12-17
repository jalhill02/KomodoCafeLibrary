using System;
using System.Collections.Generic;
using System.Text;

namespace JunkYard
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();


        public Badge()
        {

        }

        public Badge(int badgeId, List<string> doorName)
        {
            BadgeId = badgeId;
            DoorNames = doorName;

        }
    }
}
