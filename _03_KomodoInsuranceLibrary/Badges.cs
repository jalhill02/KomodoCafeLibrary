﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _03_KomodoInsuranceLibrary
{
    

    public class Badges
    {
        public int BadgeId { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();


        public Badges()
        {

        }

        public Badges(int badgeId, List<DoorNames> doorName)
        {
            BadgeId = badgeId;
            DoorNames = doorName;

        }
    }
}
