using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeLibrary
{
    public enum MealName
    {
        Chili = 1,
        Soup,
        Cake,
        Hamburgr,
        ChickenSandwich,
        MacAndCheese
    }
    public class MealItem
    {
        // Things a meal should have. 
        // Should the, "meals" be contained in a list as well, ingredients
        //MealId is the KEY
        public int MealId { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<Ingredients> Ingredients { get; set; } = new List<Ingredients>();  
        public double Price { get; set; }



        //constructors
        public MealItem()
        {

        }

        public MealItem(int mealId, string mealName, string description, List<Ingredients> ingredients, double price)
        {
            MealId = mealId;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
