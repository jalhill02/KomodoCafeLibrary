using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoInsuranceLibrary
{
    class KomodoInsuranceRepository
    {
        private static Dictionary<int, Badges> _dictionaryValues = new Dictionary<int, Badges>();


        // Create

        public void AddToDictionary(Badges badge)
        {
            _dictionaryValues.Add(badge badgeId); 
        }

        //Read
        public Dictionary<int, Badges> GetBadges()
        {
            return _dictionaryValues;
        }

        // update

        //Delete

        //Helper Method
        public Badges GetBadgeById(int badgeId)
        {
            foreach (var badge in _dictionaryValues)
            {
                if (badge.Key == badgeId)
                {
                    return badgeId;
                }
            }
            return null;
        }


    }
}
