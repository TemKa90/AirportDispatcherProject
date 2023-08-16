using AirportDispatcherLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AirportDispatcherLibraryTests
{
    [TestClass]
    public class FlightMethodsTests
    {
        AirportDispatcherLibrary.FlightMethods newObject = new AirportDispatcherLibrary.FlightMethods();

        [TestMethod]
        public void FlightNumberGenerate_DigitsTest1_NextNumberExpected()
        {
            //Arrange
            string str = "AAA-000";
            string exp = "AAA-001";
            //Act
            string result = newObject.FlightNumberGenerate(str);
            //Assert
            Assert.AreEqual(result, exp);
        }

        [TestMethod]
        public void FlightNumberGenerate_DigitsTest2_NextNumberExpected()
        {
            //Arrange
            string str = "AAA-009";
            string exp = "AAA-010";
            //Act
            string result = newObject.FlightNumberGenerate(str);
            //Assert
            Assert.AreEqual(result, exp);
        }

        [TestMethod]
        public void FlightNumberGenerate_DigitsTest3_NextNumberExpected()
        {
            //Arrange
            string str = "AAA-499";
            string exp = "AAA-500";
            //Act
            string result = newObject.FlightNumberGenerate(str);
            //Assert
            Assert.AreEqual(result, exp);
        }

        [TestMethod]
        public void FlightNumberGenerate_LettersAndDigitsTest1_NextNumberExpected()
        {
            //Arrange
            string str = "AAA-999";
            string exp = "AAB-000";
            //Act
            string result = newObject.FlightNumberGenerate(str);
            //Assert
            Assert.AreEqual(result, exp);
        }


        [TestMethod]
        public void FlightNumberGenerate_LettersAndDigitsTest2_NextNumberExpected()
        {
            //Arrange
            string str = "AZZ-999";
            string exp = "BAA-000";
            //Act
            string result = newObject.FlightNumberGenerate(str);
            //Assert
            Assert.AreEqual(result, exp);
        }

        [TestMethod]
        public void FlightNumberGenerate_LettersAndDigitsTest3_NextNumberExpected()
        {
            //Arrange
            string str = "BAA-000";
            string exp = "BAA-001";
            //Act
            string result = newObject.FlightNumberGenerate(str);
            //Assert
            Assert.AreEqual(result, exp);
        }
    }
}