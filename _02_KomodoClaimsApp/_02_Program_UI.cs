using _02_KomodoClaimsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_KomodoClaimsLibrary.Claims;

namespace _02_KomodoClaimsApp
{
    public class _02_Program_UI
    {
        private readonly _02_KomodoClaimsRepository _komodoClaimsRePo = new _02_KomodoClaimsRepository();
        bool hasStarted = true;
        
        public void Run()
        {
            seedMethod();
            Menu();
        }


        //        Show a claims agent a menu:
        //Choose a menu item:
        //1. See all claims
        //2. Take care of next claim
        //3. Enter a new claim

        private void Menu()
        {
            while (hasStarted==true)
            {
                Console.WriteLine("Select a menu option; \n" +
                               "1. See all claims\n" +
                               "2. Take care of next claim\n" +
                               "3. Enter a new claim\n" +
                               "0. Exit\n");

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    case "0":
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

        private void EnterANewClaim()
        {
            Console.Clear();
            Claims claims = new Claims();

            Console.WriteLine("Please input a new claim Id");
            int newclaimId = int.Parse( Console.ReadLine());
            claims.ClaimAmount = newclaimId;

            Console.WriteLine("Please enter the claim type\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            int inputClaimType = int.Parse(Console.ReadLine());
            ClaimType claimType = (ClaimType)inputClaimType;

            switch (claimType)
            {
                case ClaimType.Car:
                    claims.ClaimType = ClaimType.Car;
                    break;
                case ClaimType.Home:
                    claims.ClaimType = ClaimType.Home;
                    break;
                case ClaimType.Theft:
                    claims.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("invalid Choice");
                    break;
            }

            Console.WriteLine("Pleae enter a description");
            string inputdescription = Console.ReadLine();
            claims.Description = inputdescription;

            Console.WriteLine("Please enter the claim amount");
            double inputClaimAmount = double.Parse(Console.ReadLine());
            claims.ClaimAmount = inputClaimAmount;

            claims.DateOfIncident = GetDateTime("Date Of Incident");
            claims.DateOfClaim = GetDateTime("Date Of Claim");

            claims.IsValid = _komodoClaimsRePo.IsValidCalculaiton(claims.DateOfIncident, claims.DateOfClaim);

            if (claims.IsValid)
            {
                Console.WriteLine("Claim is valid");
            }
            else
            {
                Console.WriteLine("Claim is not valid");
            }

            _komodoClaimsRePo.AddClaimToQueue(claims);




        }

        private DateTime GetDateTime(string titleMessage)
        {
            Console.WriteLine($"**{titleMessage}**");

            Console.WriteLine("Please input the Year");
            int inputYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the Month");
            int inputMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the Day");
            int inputDay = int.Parse(Console.ReadLine());

            DateTime dateTime = new DateTime(inputYear, inputMonth, inputDay);
            return dateTime;

        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Claims nextInQueue = _komodoClaimsRePo.SeeNextInQueue();
            ViewClaimData(nextInQueue);

            Console.WriteLine("Do you want to handle this claim? y/n");
            string userinput = Console.ReadLine();

            if (userinput =="y" || userinput =="Y")
            {
                bool isSuccessful = _komodoClaimsRePo.RemoveClaimFromQueue();
                if (isSuccessful)
                {
                    Console.WriteLine("Claim Removed");
                }
                else
                {
                    Console.WriteLine("Claim was not Removed");
                }
            }
            if (userinput == "N" || userinput == "n")
            {
                Menu();
            }


        }

        private void SeeAllClaims()
        {
            Console.Clear();

            Queue<Claims> claims = _komodoClaimsRePo.GetClaims();

            foreach (var claim in claims)
            {
                ViewClaimData(claim);
            }

        }

        private void ViewClaimData(Claims claims)
        {
            Console.WriteLine($"{claims.ClaimId}\n" +
                $"{claims.ClaimType}\n" +
                $"{claims.Description}\n" +
                $"{claims.DateOfIncident}\n" +
                $"{claims.DateOfClaim}\n" +
                $"{claims.IsValid}\n" +
                $"{claims.ClaimAmount}\n" +
                $"");
        }

        private void seedMethod()
        {
            Claims claims1 = new Claims(1,ClaimType.Car,"....",4000.00,new DateTime(2020,11,20),new DateTime(2020,12,25),false);
            Claims claims2 = new Claims(1,ClaimType.Home,"....",4000.00,new DateTime(2020,11,20),new DateTime(2020,12,4),true);
            Claims claims = new Claims(1,ClaimType.Theft,"....",4000.00,new DateTime(2020,11,20),new DateTime(2020,12,25),false);

            _komodoClaimsRePo.AddClaimToQueue(claims1);
            _komodoClaimsRePo.AddClaimToQueue(claims2);
            _komodoClaimsRePo.AddClaimToQueue(claims);
        
        }
    }
}
