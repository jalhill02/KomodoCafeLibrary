using System;
using System.Collections.Generic;
using _02_KomodoClaimsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_KomodoClaimsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        _02_KomodoClaimsRepository _kCRepo;
        Claims claims;
        Queue<Claims> _listOfClaims;
        [TestInitialize]
        public void Arrange()
        {
            _kCRepo = new _02_KomodoClaimsRepository();
            claims = new Claims(1, ClaimType.Car, "....", 4000.00, new DateTime(2020, 11, 20), new DateTime(2020, 12, 25), false);
            _kCRepo.AddClaimToQueue(claims);
            _listOfClaims = _kCRepo.GetClaims();

        }
        [TestMethod]
        public void TestMethod_AddClaimsToQueue()
        {
            //Arrange -> Set things up.
            Claims claims2 = new Claims(1, ClaimType.Home, "....", 4000.00, new DateTime(2020, 11, 20), new DateTime(2020, 12, 4), true);
            int expectd = 2;
            //Act - Do some work
            _kCRepo.AddClaimToQueue(claims2);

            //Assert check to see if the work is working
            Assert.AreEqual(expectd, _listOfClaims.Count);
        }



        [TestMethod]
        public void TestMethod_UpdateClaimsInQueue()
        {
            //Arrange -> Set things up.
            int oldClaim = 1;
            //Act - Do some work
            Claims claims2 = new Claims(1, ClaimType.Home, "....", 4000.00, new DateTime(2020, 11, 20), new DateTime(2020, 12, 4), true);

            _kCRepo.UpdateClaimsInQueue(oldClaim, claims2);
            Claims claim = _kCRepo.GetClaimById(oldClaim);
            //Assert check to see if the work is working
            Assert.IsTrue(claim.ClaimType == ClaimType.Home && claim.ClaimAmount==4000.00);
        }



        [TestMethod]
        public void TestMethod_RemoveClaimsFromQueue()
        {
            //Arrange -> Set things up.
            int expected = 0;

            //Act - Do some work
            _kCRepo.RemoveClaimFromQueue();

            //Assert check to see if the work is working
            Assert.AreEqual(expected, _listOfClaims.Count);
        }



        [TestMethod]
        public void TestMethod_GetClaimById()
        {
            //Arrange -> Set things up.
            int oldClaim = 1;
            //Act - Do some work
            Claims claim= _kCRepo.GetClaimById(oldClaim);
            //Assert check to see if the work is working
            Assert.IsTrue(claim.ClaimType == ClaimType.Car);
        }



        [TestMethod]
        public void TestMethod_SeeNextInQueue()
        {
            //Arrange -> Set things up.
            Claims claims = _kCRepo.SeeNextInQueue();
            //Act - Do some work

            //Assert check to see if the work is working
            Assert.IsTrue(claims.ClaimType == ClaimType.Car);
        }



        [TestMethod]
        public void IsValidCalculation()
        {
            //Arrange -> Set things up.
            DateTime dA = new DateTime(2020, 05, 12);
            DateTime dB = new DateTime(2020, 05, 14);
            //Act - Do some work
            bool isSuccessful = _kCRepo.IsValidCalculaiton(dA, dB);
            Console.WriteLine(isSuccessful);
            //Assert check to see if the work is working
            Assert.IsTrue(isSuccessful);
        }

    }
}
