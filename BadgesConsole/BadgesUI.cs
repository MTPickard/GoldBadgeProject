using _03_BadgesTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesConsole
{
    class BadgesUI
    {
        BadgesRepository _badgesRepo = new BadgesRepository();


        public void Run()
        {
            RunMenu();
        }




        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin. What would you like to do?\n" +
                    "1. Add a badge.\n" +
                    "2. Edit a badge.\n" +
                    "3. List all badges.\n" +
                    "4. Exit.");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        EnterValidSelection();
                        break;
                }
            }
        }




        //Add A Badge

        public void AddBadge()                              //NEED TO FINISH
        {
            Badge newBadge = new Badge();

            Console.Clear();
            Console.WriteLine("What is the badge ID:");
            int identity = int.Parse(Console.ReadLine());
            newBadge.BadgeID = identity;


            Console.Clear();
            Console.WriteLine("List a door the badge needs access to.");
            string door = Console.ReadLine();
            newBadge.ListOfDoors.Add(door);

            Console.WriteLine("Any other doors (y/n)\n");
            char response = Console.ReadKey().KeyChar;
            while(response == 'y')
            {
                Console.Clear();
                Console.WriteLine("What is the door the badge needs access to.");
                string answer = Console.ReadLine();
                newBadge.ListOfDoors.Add(answer);

                Console.WriteLine("Any other doors? (y/n)");
                char secondResponse = Console.ReadKey().KeyChar;
                if(secondResponse == 'n')
                {
                    break;
                }
            }

            _badgesRepo.AddBadgeToDictionary(newBadge);
        }




        //Update A Badge

        public void EditBadge()
        {
            Console.WriteLine("What is the badge ID you want to update?");
            int response = int.Parse(Console.ReadLine());

            Badge existingBadgeKey = _badgesRepo.FindBadgeByKey(response);
            if (response != existingBadgeKey.BadgeID)
            {
                Console.WriteLine("Sorry, not able to find that badge ID");
                PressAnyKeyToContinue();
            }

            Console.Clear();
            Console.Write($"Badge ID #{existingBadgeKey.BadgeID} currently has access to: ");
            foreach(string door in existingBadgeKey.ListOfDoors)
            {
                Console.Write($"{door} ");
            }

            Console.WriteLine("\n" +
                "What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n");

            string responseChoice = Console.ReadLine();
            switch(responseChoice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Which door would you like to remove?");
                    ShowAllDoors(existingBadgeKey.BadgeID);
                    Console.WriteLine();
                    string doorRemoved = Console.ReadLine();
                    existingBadgeKey.ListOfDoors.Remove(doorRemoved);

                    if (existingBadgeKey.ListOfDoors.Contains(doorRemoved))
                    {
                        Console.Clear();
                        Console.WriteLine($"ERROR: {doorRemoved} access was NOT successfully removed");
                        PressAnyKeyToContinue();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Access to door {doorRemoved} was successfully removed!");
                        PressAnyKeyToContinue();
                    }
                    break;

                case "2":
                    Console.WriteLine("What door would you like badge to have access to?");
                    string doorResponce = Console.ReadLine();
                    existingBadgeKey.ListOfDoors.Add(doorResponce);
                    _badgesRepo.AddDoorToBadge(doorResponce);
                    break;

                default:
                    EnterValidSelection();
                    break;
            }

        }




        //View All Badges

        public void ListAllBadges()
        {
            Console.Clear();

            Dictionary<int, Badge> listOfBadges = _badgesRepo.ShowAllBadges();

            Console.WriteLine("Badge#\t\t Has access too:");
            foreach (KeyValuePair<int, Badge> badge in listOfBadges)
            {
                Console.Write($"{badge.Key}\t\t ");
                foreach (string door in badge.Value.ListOfDoors)
                {
                    Console.Write($"{door} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            PressAnyKeyToContinue();
        }







        //Helper Methods

        public void EnterValidSelection()
        {
            Console.WriteLine("The option you chose was not a valid selection.");
            PressAnyKeyToContinue();
        }

        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ShowAllDoors(int id)
        {
            Badge listOfDoors = _badgesRepo.FindBadgeByKey(id);

            foreach (string door in listOfDoors.ListOfDoors)
            {
                Console.WriteLine(door);
            }
        }

    }
}
