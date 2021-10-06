using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeTest
{
    public class CafeMenuRepository

        //Fields
    {
        List<Menu> _menuItems = new List<Menu>();

        

        //CREATE

        public bool AddItemToMenu(Menu item)
        {
            int startingCount = _menuItems.Count;
            _menuItems.Add(item);

            if(_menuItems.Count > startingCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //READ

        public List<Menu> DisplayMenuItems()
        {
            return _menuItems;
        }


        //DELETE

        public bool DeleteItemFromMenu(Menu existingItem)
        {
            int startingCount = _menuItems.Count;
            _menuItems.Remove(existingItem);

            if (startingCount > _menuItems.Count)
            {
                Console.WriteLine("Successfully deleted.");
                return true;
            }
            else
            {
                Console.WriteLine("There was an error.");
                return false;
            }
        }
    }
}
