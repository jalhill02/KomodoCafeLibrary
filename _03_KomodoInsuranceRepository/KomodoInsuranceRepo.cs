using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoInsuranceRepository
{
    public class KomodoInsuranceRepo
    {
        private static Dictionary<int, Badges> _dictionaryValues = new Dictionary<int, Badges>();
        private int Count;


        // Create

        public void AddToDictionary(Badges badge)
        {
            Count++;
            _dictionaryValues.Add(Count, badge); // worked with Drew but not sure what the syntax is here
        }

        //Read
        public Dictionary<int, Badges> GetBadges()
        {
            return _dictionaryValues;
        }

        // update

        public bool EditBadgeInfo(int dictkey, Badges newBadge)

        {
            Badges oldBadges = GetBadgeByKey(dictkey);

            if (oldBadges != null)
            {
                newBadge.BadgeId = oldBadges.BadgeId;
                oldBadges.DoorNames = newBadge.DoorNames;

                return true;
            }
            return false;
        }

        //Delete




        //Helper Method
        public Badges GetBadgeByKey(int dictKey)
        {
            foreach (var badge in _dictionaryValues)
            {
                if (badge.Key == dictKey) //  ** the dot accessor does not show "BadgeId"
                {
                    return badge.Value; // **huge problem with code and return
                }
            }
            return null;
        }

        public bool DeleteDoor(int dictkey, string doorName)
        {
            Badges badges = GetBadgeByKey(dictkey);
            if (badges == null)
            {
                return false;
            }
            foreach (var door in badges.DoorNames)
            {
                if (door == doorName)
                {
                    badges.DoorNames.Remove(door);
                    return true;
                }

            }
            return false;
        }

        public bool AddDoor(int dictkey, string doorName)
        {
            Badges badges = GetBadgeByKey(dictkey);
            if (badges != null)
            {
                badges.DoorNames.Add(doorName);

                return true;
            }
            return false;
               
                
        }
    }
}
