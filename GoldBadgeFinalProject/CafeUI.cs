using _01_CafeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeFinalProject
{
    class CafeProgramUI
    {
        CafeMenuRepository _menuRepository = new CafeMenuRepository();



        public void Run()
        {
            ItemsSeed();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "Enter the number for your seletion:\n" +
                    "\n" +
                    "1. View all menu items.\n" +
                    "2. Add item to menu\n" +
                    "3. Delete item from menu.\n" +
                    "\n");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        DisplayAllMenuItems();
                        break;
                    case "2":
                        AddItemToMenu();
                        break;
                    case "3":
                        DeleteItemFromMenu();
                        break;

                    default:
                        InvalidSelection();
                        break;
                }
            }

        }


        public void DisplayAllMenuItems()
        {
            Console.Clear();
            List<Menu> listOfItems = _menuRepository.DisplayMenuItems();

            foreach (Menu item in listOfItems)
            {
                Console.WriteLine($"#{item.MealNumber}. {item.MealName} - ${item.Price}\n" +
                    $"\n" +
                    $"Description:\n" +
                    $"{item.Description}.");
                Console.WriteLine("Ingredients:");
                foreach (string ingredient in item.Ingredients)
                {
                    Console.Write($"{ingredient}, ");
                }
                Console.WriteLine("\n");
            }
            PressAnyKeyToContinue();
        }


        public void AddItemToMenu()
        {
            Menu item = new Menu();

            Console.Clear();

            Console.WriteLine("\n" +
                "Please enter the name of the item you want to add:");
            item.MealName = Console.ReadLine();

            Console.WriteLine("\n" +
                "Please enter the description of the item:");
            item.Description = Console.ReadLine();

            Console.WriteLine("\n" +
                "Please enter the price of the item:");
            item.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("\n" +
                "Please enter the ingredients used:");
            item.Ingredients.Add(Console.ReadLine());


            Console.WriteLine("\n" +
                "Please enter the menu item number:\n");
            item.MealNumber = int.Parse(Console.ReadLine());

            _menuRepository.AddItemToMenu(item);


        }


        public void DeleteItemFromMenu()
        {
            Console.Clear();
            int index = 1;
            List<Menu> mealList = _menuRepository.DisplayMenuItems();

            Console.WriteLine("Select the number for which item you want to remove.\n");

            foreach (Menu meal in mealList)
            {
                Console.WriteLine($"{index}. {meal.MealName}");
                index++;
            }

            int response = int.Parse(Console.ReadLine());
            int targetMeal = response - 1;

            if (targetMeal >= 0 && targetMeal < mealList.Count)
            {
                Menu mealSelected = mealList[targetMeal];

                if (_menuRepository.DeleteItemFromMenu(mealSelected))
                {
                    Console.WriteLine($"{mealSelected.MealName} was removed.");
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                }
            }
            else
            {
                Console.WriteLine("Not a valid selection.");
            }
            PressAnyKeyToContinue();
        }






        //Seeder
        public void ItemsSeed()
        {
            Menu cheeseBurger = new Menu();
            cheeseBurger.MealNumber = 1;
            cheeseBurger.MealName = "Bacon Angus Burger";
            cheeseBurger.Price = 11.99;
            cheeseBurger.Description = "Try our half pound angus burger, topped with bacon and all the fixins";
            cheeseBurger.Ingredients.Add("Sweet-bun");
            cheeseBurger.Ingredients.Add("Angus Beef");
            cheeseBurger.Ingredients.Add("Hickory-Smoked Bacon");
            cheeseBurger.Ingredients.Add("Pepper-Jack Cheese");
            cheeseBurger.Ingredients.Add("Lettuce");
            cheeseBurger.Ingredients.Add("Onions");
            cheeseBurger.Ingredients.Add("Tomatoe");
            cheeseBurger.Ingredients.Add("Mayo");

            _menuRepository.AddItemToMenu(cheeseBurger);

            Menu tenderloin = new Menu();
            tenderloin.MealNumber = 2;
            tenderloin.MealName = "Hand breaded tenderloin";
            tenderloin.Price = 10.99;
            tenderloin.Description = "Hand breaded and fried to perfection. Our giant tenderloin get you right where you want to be.";
            tenderloin.Ingredients.Add("Sweet-Bun");
            tenderloin.Ingredients.Add("Premium Tenderloin");
            tenderloin.Ingredients.Add("Lettuce");
            tenderloin.Ingredients.Add("Tomatoe");
            tenderloin.Ingredients.Add("Red Onion");
            tenderloin.Ingredients.Add("Mayo");

            _menuRepository.AddItemToMenu(tenderloin);
        }

        //Helper Methods
        public void InvalidSelection()
        {
            Console.WriteLine("The number you entered was not a valid selection.");
            PressAnyKeyToContinue();
        }

        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        
    }
}
