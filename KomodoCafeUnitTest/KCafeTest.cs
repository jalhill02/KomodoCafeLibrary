using System;
using System.Collections.Generic;
using KomodoCafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafeUnitTest
{
    [TestClass]
    public class KCafeTest
    {
        [TestMethod]
        public void TestMethod_AddMealToList()
        {
            //Arrange -> set things up
            KomodoCafeRepository _kRepo = new KomodoCafeRepository();
            MealItem mealItem = new MealItem(1, "...", "...", new System.Collections.Generic.List<Ingredients> { Ingredients.Beef }, 2.20d);

            //Act -> do some work
            _kRepo.AddMealToList(mealItem);
            MealItem item = _kRepo.GetMealById(1);

            //Assert -> check to see if the work is "working"
            Assert.IsNotNull(item); 
        }

        [TestMethod]
        public void TestMethod_RemoveMealFromList()
        {
            //Arrange
            KomodoCafeRepository _kRepo = new KomodoCafeRepository();
            MealItem mealItem = new MealItem(1, "....", "...", new List<Ingredients> { Ingredients.Beef }, 6.00d);

            //Act
            _kRepo.AddMealToList(mealItem);
            MealItem item = _kRepo.GetMealById(1);
           bool isSuccessful= _kRepo.RemoveMealFromList(item.MealId);

            //Assert
            Assert.IsTrue(isSuccessful);
        }
        [TestMethod]
        public void MyTestMethod_ViewAllItems()
        {
            //Arrange
            KomodoCafeRepository _kRepo = new KomodoCafeRepository();
            MealItem mealItem = new MealItem(1, "....", "...", new List<Ingredients> { Ingredients.Beef }, 6.00d);

            //Act
            _kRepo.AddMealToList(mealItem);
            List<MealItem> items = _kRepo.GetMealList();
            int initialCount = items.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, initialCount);

        }
    }
}
