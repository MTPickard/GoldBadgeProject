using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesTest
{
    public class BadgesRepository
    {
        Dictionary<int, Badge> _badgesDictionary = new Dictionary<int, Badge>();
        public List<Badge> _badges = new List<Badge>();



        public bool AddBadgeToDictionary(Badge badge)
        {
            int startingCount = _badgesDictionary.Count;
            _badgesDictionary.Add(badge.BadgeID, badge);
            if (_badgesDictionary.Count > startingCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        
        public void AddDoorToBadge(string door)
        {
            Badge badge = new Badge();
            badge.ListOfDoors.Add(door);
        }



        public Dictionary<int, Badge> ShowAllBadges()
        {
            return _badgesDictionary;

        }



        public List<string> ShowAllDoors(int id)
        {            
            Badge listOfDoors = FindBadgeByKey(id);
            foreach (string door in listOfDoors.ListOfDoors)
            {
                ;
            }
            return null;
        }
        


        public Badge FindBadgeByKey(int id)
        {
            foreach (KeyValuePair<int, Badge> entry in _badgesDictionary)
            {
                if (entry.Key == id)
                {
                    return entry.Value;
                }
            }
            return null;
        }



        
        public bool DeleteDoorFromBadge(string existingDoor)
        {
            Badge badge = new Badge();
            bool result = badge.ListOfDoors.Remove(existingDoor);
            return result;
        }
    }
}
