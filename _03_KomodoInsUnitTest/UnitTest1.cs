using _03_KomodoInsuranceRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_KomodoInsUnitTest
{


    [TestClass]
    public class UnitTest1
    {
        KomodoInsuranceRepo _kIRepo;
        List<string> doorName;
        Badges badges;

        [TestInitialize]
        public void Arrange()
        {
            //Arrange -> Set things up.
            //Check with Terry to be sure I am using the right Ref. of _o3_KomodoInsuranceRepo of 
            _kIRepo = new KomodoInsuranceRepo();
            doorName = new List<string> { "A1", "A2","333" };
            badges = new Badges(1, doorName); // need to fill in parameters
            _kIRepo.AddToDictionary(badges);
        }

        [TestMethod]
        public void TestMethod_AddToDitctionary()
        {
            //Arrange -> Set things up.
            int expected = 1;
            //Check with Terry to be sure I am using the right Ref. of _o3_KomodoInsuranceRepo of 

            //Act - Do some work
            var database = _kIRepo.GetBadges();
            Console.WriteLine(database.Count);

            //Assert check to see if the work is working
            Assert.AreEqual(expected, database.Count);
        }


        [TestMethod]
        public void TestMethod_GetBadges()
        {
            //Arrange -> Set things up.
            List<string> doorName1 = new List<string> { "A1", "A2", "J1" };
            Badges badges1 = new Badges(2, doorName1); // need to fill in parameters

            List<string> doorName2 = new List<string> { "A1", "A2", "T1" };
            Badges badges2 = new Badges(3, doorName2); // need to fill in parameters
            int expected = 3;
            //Act - Do some work
            _kIRepo.AddToDictionary(badges2);
            _kIRepo.AddToDictionary(badges1);
            //Assert check to see if the work is working
            Assert.AreEqual(expected, _kIRepo.GetBadges().Count);
        }

        [TestMethod]
        public void TestMethod_EditBadgeInfo()
        {
            //Arrange -> Set things up.

            //we need dictKey
            int dictKey = 1;
            //need new form of a badge
            List<string> doorName1 = new List<string> { "A1", "A2", "J1" };
            Badges badges1 = new Badges(2, doorName1); // need to fill in parameters

            //Act - Do some work
            _kIRepo.EditBadgeInfo(dictKey, badges1);

            //store what I updated in badges variable
            Badges badges = _kIRepo.GetBadgeByKey(1);

            //Assert check to see if the work is working
            Assert.IsTrue(badges.DoorNames.Contains("J1"));

        }

        [TestMethod]
        public void TestMethod_GetBadgeByKey()
        {
            //Arrange -> Set things up.


            //Act - Do some work
            Badges badges = _kIRepo.GetBadgeByKey(1);
            //Assert check to see if the work is working
            Assert.IsTrue(badges.DoorNames.Contains("333"));
        }


        [TestMethod]
        public void TestMethod_DeleteDoor()
        {
            //Arrange -> Set things up.

            //Act - Do some work
            _kIRepo.DeleteDoor(1, "333");
            //Assert check to see if the work is working
            Assert.IsTrue(badges.DoorNames.Contains("A2"));

        }

        [TestMethod]
        public void TestMethod_AddDoor()
        {
            //Arrange -> Set things up.

            //Act - Do some work
            _kIRepo.AddDoor(1, "A34");
            //Assert check to see if the work is working
            Assert.IsTrue(badges.DoorNames.Contains("A34"));
        }

    }
}
