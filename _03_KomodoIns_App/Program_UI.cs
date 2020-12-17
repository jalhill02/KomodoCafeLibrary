
using _03_KomodoInsuranceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoIns_App
{
    public class Program_UI
    {
        private readonly KomodoInsuranceRepo _dictRepo = new KomodoInsuranceRepo();

        bool hasStarted = true;

        public void Run()
        {
            Seed();
            Menu();
        }

        private void Menu()
        {
            while (hasStarted)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                              "1. Add a badge\n" +
                              "2. Edit a badge\n" +
                              "3. List all badges\n" +
                              "0. Exit\n");

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddABadge();
                        break;
                    case 2:
                        EditABadge();
                        break;
                    case 3:
                        ListAllBadges();
                        break;
                    case 0:
                        ExitMenu();
                        break;

                    default:
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            }



        }
        private void ExitMenu()
        {
            hasStarted = false;
        }

        private void ListAllBadges()
        {
            Console.Clear();
            var badges = _dictRepo.GetBadges();
          
            foreach (var pair in badges)
            {
                Console.WriteLine($"DictKey: {pair.Key}");
                GetBadgeInfo(pair.Value);
            }
        }


        private void GetBadgeInfo(Badges badges)
        {
            Console.WriteLine($"BadgeId: {badges.BadgeId}");
            foreach (var door in badges.DoorNames)
            {
                Console.WriteLine($"DoorName: {door}");
            }
            Console.WriteLine("**********************************");
        }


        private void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("Would would you like to do?\n" +
                "1. Remove a door?\n" +
                "2. Add a door?\n" +
                "0. Return to main menu?\n");

            int userinput =int.Parse(Console.ReadLine());

            switch (userinput)
            {
                case 1:
                    RemoveDoor();
                    break;
                case 2:
                    AddADoor();
                    break;
                case 0:
                    Console.Clear();
                   Menu();
                    break;


                default:
                    break;
            }


        }

        private void AddADoor()
        {
            Console.Clear();
            Console.WriteLine("Please input a valid dictionary key.");
            int userInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input a  door name.");
            string userInputName = Console.ReadLine();

            bool IsSuccessful = _dictRepo.AddDoor(userInput, userInputName);

            if (IsSuccessful)
            {
                Console.WriteLine("Door Added");
            }
            else
            {
                Console.WriteLine("Door Not Added");
            }
        }

        private void RemoveDoor()
        {
            Console.Clear();
            Console.WriteLine("Please input a valid dictionary key.");
            int userInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input a valid door name.");
            string userInputName = Console.ReadLine();

            bool IsSuccessful = _dictRepo.DeleteDoor(userInput, userInputName);

            if (IsSuccessful )
            {
                Console.WriteLine("Door Removed");
            }
            else
            {
                Console.WriteLine("Door Not Removed");
            }

        }

        private void AddABadge()
        {
            //clear console
            Console.Clear();
           
            //create A new Badge
            Badges badge = new Badges();
           
            //ask user for badge id
            Console.WriteLine("Please enter the badge Id");
            int userInput = int.Parse(Console.ReadLine());

            //Make an Assignment to badge
            badge.BadgeId = userInput;

            //make a bool that will terminate the upcomming while loop
            bool hasEnteredAllDoors = false;
            while (hasEnteredAllDoors==false)
            {
                //ask user if they want to add a door name
                Console.WriteLine("Would you like to add a door name? y/n");
                string inputAnswer = Console.ReadLine();

                if (inputAnswer == "Y" || inputAnswer =="y")
                {
                    //ask user to input Door name
                    Console.WriteLine("Please enter the door name");
                    string inputDoorName = Console.ReadLine();

                    badge.DoorNames.Add(inputDoorName);
                }
                if (inputAnswer == "N" || inputAnswer == "n")
                {
                    hasEnteredAllDoors = true;

                }
            }
            _dictRepo.AddToDictionary(badge);
           



        }

        private void Seed()
        {
            Badges newBadge1 = new Badges(1, new List<string> { "A1", "B1" });
            Badges newBadge2 = new Badges(100, new List<string> { "A1", "B1", "C1" });
            Badges newBadge3 = new Badges(1000, new List<string> { "A1" });

            _dictRepo.AddToDictionary(newBadge1);
            _dictRepo.AddToDictionary(newBadge2);
            _dictRepo.AddToDictionary(newBadge3);


        }
    }
}
