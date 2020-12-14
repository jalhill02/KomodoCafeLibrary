using System;
using KomodoCafeLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeApp
{
    class Program_UI
    {
        private readonly KomodoCafeRepository _comodoCafeRpo = new KomodoCafeRepository();
        bool hasStarted = true;
        public void Run()
        {
            SeedMeals();
            Menu();
        }



        public void Menu()
        {

            while (hasStarted)
            {
                Console.WriteLine("Select a menu option;\n" +
                    "1. Create New Meal\n" +
                    "2. View All Meals\n" +
                    "3. View Meals By Meal Name\n" +
                    "4. Delete Meal\n" +
                    "0. Exit Menu ");

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateMeal();
                        break;
                    case "2":
                        ViewAllMeals();
                        break;
                    case "3":
                        ViewallMealsById();
                        break;
                    case "4":
                        DeleteMeals();
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

        private void DeleteMeals()
        {
            Console.Clear();
            //ask for id
            Console.WriteLine("Please input the mealId to be deleted");
            //user input
            int inputmealID = int.Parse(Console.ReadLine());
            //look at our repo -> see that it takes in a int paramerter
            // but it returns a BOOL!!!!

            bool isSuccessful = _comodoCafeRpo.RemoveMealFromList(inputmealID);
            if (isSuccessful)
            {
                Console.WriteLine("Meal has been deleted");

            }
            else
            {
                Console.WriteLine("Meal has not been deleted");
            }


        }

        private void ViewallMealsById()
        {
            Console.Clear();
            Console.WriteLine("Please input a mealId");
            try
            {
                int inputmealId = int.Parse(Console.ReadLine());
                MealItem mealItem = _comodoCafeRpo.GetMealById(inputmealId);

                Console.WriteLine($"{mealItem.MealId}\n" +
                    $"{mealItem.MealName}\n" +
                    $"{mealItem.Description}\n" +
                    $"{mealItem.Price}\n");
                foreach (var ingredient in mealItem.Ingredients)
                {
                    Console.WriteLine(ingredient);
                }
                Console.WriteLine("***************************");
            }
            catch (Exception)
            {

                Console.WriteLine("Meal could not be found");
            }
        }



        private void ViewAllMeals()
        {
            Console.Clear();
            List<MealItem> newMealItems = _comodoCafeRpo.GetMealList();

            foreach (var meal in newMealItems)
            {
                Console.WriteLine($"{meal.MealId}\n" +
                    $"{meal.MealName}\n" +
                    $"{meal.Description}\n" +
                    $"{meal.Price}\n");
                foreach (var ingredient in meal.Ingredients)
                {
                    Console.WriteLine(ingredient);
                }
                Console.WriteLine("***************************");
            }

        }

        private void CreateMeal()
        {
            bool hasFilledIngredients = false;
            MealItem newMeal = new MealItem();
            //ask for meal id
            Console.WriteLine("please input the MealId");
            //store meal id
            int inputNewMealId = int.Parse(Console.ReadLine());
            //assign meal id
            newMeal.MealId = inputNewMealId;


            Console.WriteLine("Please input the MealName");
            string inputMealName = Console.ReadLine();
            newMeal.MealName = inputMealName;

            Console.WriteLine("Please input the description");
            string inputDescription = Console.ReadLine();
            newMeal.Description = inputDescription;


            while (hasFilledIngredients == false)
            {
                Console.WriteLine("Do you want any added ingredients y/n?");
                string userBoolInput = Console.ReadLine();
                if (userBoolInput == "Y" || userBoolInput == "y")
                {

                    //thinking of making this a list using a method
                    //Ingredients ingredients = Addmoreingredients()
                    // Console.WriteLine("would you like to add more ingredients? y/n");
                    Console.WriteLine("Please make a selection \n" +
                        "1. Broth\n" +
                        "2. Carrots\n" +
                        "3. Peppers\n" +
                        "4. Chicken\n" +
                        "5. Beef\n" +
                        "6. Tomato\n" +
                        "7. Salt\n");

                    int inputIngredient = int.Parse(Console.ReadLine());

                    switch (inputIngredient)
                    {
                        case 1:
                            newMeal.Ingredients.Add(Ingredients.Broth);
                            break;
                        case 2:
                            newMeal.Ingredients.Add(Ingredients.Carrots);
                            break;

                        case 3:
                            newMeal.Ingredients.Add(Ingredients.Peppers);
                            break;

                        case 4:
                            newMeal.Ingredients.Add(Ingredients.Chicken);
                            break;

                        case 5:
                            newMeal.Ingredients.Add(Ingredients.Beef);
                            break;

                        case 6:
                            newMeal.Ingredients.Add(Ingredients.Tomato);
                            break;

                        case 7:
                            newMeal.Ingredients.Add(Ingredients.Salt);
                            break;


                        default:
                            break;
                    }
                }
                //This is only to "GET OUT" OF THE WHILE LOOP
                if (userBoolInput == "N" || userBoolInput == "n")
                {
                    hasFilledIngredients = true;

                }
            }




            Console.WriteLine("Please input the price");
            double inputPrice = double.Parse(Console.ReadLine());
            newMeal.Price = inputPrice;

            //add the menuItem to the comodoCafeRepo 
            _comodoCafeRpo.AddMealToList(newMeal);

        }
        private void SeedMeals()
        {

            //set up MealItem objs
            MealItem meal1 = new MealItem(
                1,
                "Chicken",
                "Chicken with sides",
                new List<Ingredients>
                {
                    Ingredients.Chicken,
                    Ingredients.Peppers

                }, 19.45d);

            MealItem meal2 = new MealItem(
                        2,
                         "Beef",
                         "Beef with sides",
                new List<Ingredients>
                {
                    Ingredients.Beef,
                    Ingredients.Peppers

                }, 19.45d);

            MealItem meal3 = new MealItem(
                        3,
                         "Chicken",
                         "Chicken with sides",
                new List<Ingredients>
                {
                      Ingredients.Chicken,
                      Ingredients.Carrots

                }, 19.45d);

            //add meals to the meal repository (look for the readonly KomodoCafeRepo obj at top)

            _comodoCafeRpo.AddMealToList(meal1);
            _comodoCafeRpo.AddMealToList(meal2);
            _comodoCafeRpo.AddMealToList(meal3);
        }
    }
}
