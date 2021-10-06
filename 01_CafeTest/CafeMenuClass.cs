using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeTest
{
    public class Menu
    {
        

        public Menu() { }

        public Menu(int mealNumber, string mealName, string description, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Price = price;
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public List<string> Ingredients = new List<string>();
    }
}
