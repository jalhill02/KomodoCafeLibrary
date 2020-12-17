using System;
using System.Collections.Generic;

namespace JunkYard
{
    class Program
    {
        static void Main(string[] args)
        {
            Badge badgeA = new Badge(1, new List<string> { "A1", "A2" });
            Badge badgeB = new Badge(100, new List<string> { "A1", "A2", "B1" });
            Badge badgeC = new Badge(10000, new List<string> { "A1", "A2", "0001" });

            //dictionary is a key/value pair
            //key apple <string>
            //value definition <string>  Dictionary<string,string>

            Dictionary<int, Badge> badges = new Dictionary<int, Badge>();
            badges.Add(1, badgeA);
            badges.Add(2, badgeB);
            badges.Add(3, badgeC);

            foreach (var pair in badges)  // access both key and value
            {
                Console.WriteLine($"badge Key:{pair.Key}");
                Console.WriteLine($"BadgeIds:{pair.Value.BadgeId}");
            }

            //only can loop threw the keys in the situation access only key
            foreach (var key in badges.Keys)
            {
                if (key == 2)
                {
                    Console.WriteLine(key);

                }
            }


            foreach (var value in badges.Values) // only access value
            {
               
                    DisplayBadgeInfo(value);
                
            }

            //helper method
            void DisplayBadgeInfo(Badge badge)
            {
                Console.WriteLine($"Badge Id: {badge.BadgeId}");
                foreach (var door in badge.DoorNames)
                {
                    Console.WriteLine($"Door Name:{door}");
                }
                    Console.WriteLine("*****************");
            }
            Console.ReadKey();
        }
    }
}
