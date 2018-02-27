using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class VehicleByColorSuccessMessageTest
    {
        private IVehicleByColorSuccessMessage _vehicleByColorSuccessMessage;
        [TestInitialize]
        public void SetUp()
        {
            _vehicleByColorSuccessMessage = new VehicleByColorSuccessMessage();
        }
        [TestMethod]
        public void Given_1_RegistrationNumber()
        {
            //given: registration number as 'ka-01-hh-1111' in string array
            string[] registrationNumbers = { "ka-01-hh-1111" };
            //When: I call VehicleByColorSuccessMessage object
            string result = _vehicleByColorSuccessMessage.BuildMessage(registrationNumbers);
            //Then: I get 'ka-01-hh-1111'
            string expected = "ka-01-hh-1111";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Given_2_RegistrationNumber()
        {
            //given: registration number as 'ka-01-hh-1111' in string array
            string[] registrationNumbers = { "ka-01-hh-1111", "ka-01-hh-1112" };
            //When: I call VehicleByColorSuccessMessage object
            string result = _vehicleByColorSuccessMessage.BuildMessage(registrationNumbers);
            //Then: I get 'ka-01-hh-1111, ka-01-hh-1112'
            string expected = "ka-01-hh-1111, ka-01-hh-1112";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Given_No_RegistrationNumber()
        {
            //given: registration number as 'ka-01-hh-1111' in string array
            string[] registrationNumbers = new string[0];
            //When: I call VehicleByColorSuccessMessage object
            string result = _vehicleByColorSuccessMessage.BuildMessage(registrationNumbers);
            //Then: I get empty string
            string expected = string.Empty;
            Assert.AreEqual(expected, result);
        }
    }
}
