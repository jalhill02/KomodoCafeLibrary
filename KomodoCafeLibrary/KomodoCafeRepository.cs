using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeLibrary
{
    public class KomodoCafeRepository
    {
        // New up a list for comodoCafe database
        private List<MealItem> _listOfMeals = new List<MealItem>();

        //Create
        public void AddMealToList(MealItem newMeal)
        {
            _listOfMeals.Add(newMeal);
        }

        //Read
        public List<MealItem> GetMealList()
        {
            return _listOfMeals;
        }

        //Update -> This is not required for the challenge

        //Delete
        public bool RemoveMealFromList(int mealId)
        {
            MealItem meal = GetMealById(mealId);
            if (meal == null)
            {
                return false;
            }
            int initialcount = _listOfMeals.Count();
            _listOfMeals.Remove(meal);

            if (initialcount > _listOfMeals.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        //Helper Method
        public MealItem GetMealById(int mealId)
        {
            foreach (MealItem meal in _listOfMeals)
            {
                if (meal.MealId  == mealId)
                {
                    return meal;
                }
            }
           
                return null;
            
        }

    }
}
