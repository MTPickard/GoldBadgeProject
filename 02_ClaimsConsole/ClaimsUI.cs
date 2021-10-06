using _02_UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsConsole
{
    class ClaimsUI
    {
        ClaimsRepository _claimsRepo = new ClaimsRepository();


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
                Console.WriteLine("Choose a menu item\n" +
                    "1. See all claims.\n" +
                    "2. Take care of next claim.\n" +
                    "3. Enter a new claim.\n" +
                    "4. Exit");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        EnterValidChoice();
                        break;
                }
            }
        }

        public void SeeAllClaims()
        {
            Queue<ClaimsClass> queueOfClaims = _claimsRepo.DisplayClaims();

            Console.Clear();
            Console.WriteLine("Claim ID  Type\t Description\t Amount\t DateOfAccident\t\t DateOfClaim\t\t IsValid\n");
            foreach (ClaimsClass claim in queueOfClaims)
            {
                Console.WriteLine($"{claim.ClaimID}\t {claim.TypeOfClaim}\t {claim.Description}\t {claim.ClaimAmount}\t {claim.DateOfIncident}\t {claim.DateOfClaim}\t {claim.IsValid}\n");
            }
            PressAnyKeyToContinue();
        }


        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            Queue<ClaimsClass> queueOfClaims = _claimsRepo.DisplayClaims();
            if (queueOfClaims.Count > 0)
            {
                Console.WriteLine("Do you want to complete the next claim? (y/n):\n" +
                    "Press y for 'yes'\n" +
                    "Press n for 'no'\n");
                char response = Console.ReadKey().KeyChar;
                if (response == 'y')
                {
                    Console.Clear();
                    queueOfClaims.Dequeue();
                    Console.WriteLine("Claim case has been closed.\n");
                    PressAnyKeyToContinue();
                }
                else if (response == 'n')
                {
                    RunMenu();
                }
                else
                {
                    EnterValidChoice();
                }
            }
            else
            {
                Console.WriteLine("Sorry, new claims in queue!\n");
                PressAnyKeyToContinue();
            }
        }



        public void EnterNewClaim()
        {
            ClaimsClass newClaim = new ClaimsClass();

            Console.Clear();
            Console.WriteLine("Enter the Claim ID:");
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Enter the type of claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    newClaim.TypeOfClaim = ClaimType.Car;
                    break;
                case "2":
                    newClaim.TypeOfClaim = ClaimType.Home;
                    break;
                case "3":
                    newClaim.TypeOfClaim = ClaimType.Theft;
                    break;
                default:
                    EnterValidChoice();
                    break;
            }

            Console.Clear();
            Console.WriteLine("Enter the description of the claim:");
            newClaim.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter the amount of the claim:");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Enter the date of the accident (mm/dd/yyyy):");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Enter the date of the claim (mm/dd/yyyy):");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"This claim is valid: {newClaim.IsValid}");
            PressAnyKeyToContinue();

            _claimsRepo.AddClaim(newClaim);
        }



        //HelperMethods
        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void EnterValidChoice()
        {
            Console.WriteLine("You did not enter a valid option");
            PressAnyKeyToContinue();
        }
    }
}
