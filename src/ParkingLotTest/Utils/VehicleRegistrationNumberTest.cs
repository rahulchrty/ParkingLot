using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class VehicleRegistrationNumberTest
    {
        private IVehicleRegistrationNumber _vehicleRegistrationNumber;
        [TestInitialize]
        public void SetUp()
        {
            _vehicleRegistrationNumber = new VehicleRegistrationNumber();
        }
        [TestMethod]
        public void Given_Command_With_RegistrationNumber_Then_Get_RegistrationNumber()
        {
            //Given: command as 'slot_number_for_registration_number KA-01-HH-3141'
            string command = "slot_number_for_registration_number KA-01-HH-3141";
            //When: I call VehicleRegistrationNumber object
            string result = _vehicleRegistrationNumber.GetNumber(command);
            //Then: I get 'KA-01-HH-3141'
            string expected = "KA-01-HH-3141";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Given_Command_With_No_RegistrationNumber_Then_Get_EmptyString()
        {
            //Given: command as 'slot_number_for_registration_number'
            string command = "slot_number_for_registration_number";
            //When: I call VehicleRegistrationNumber object
            string result = _vehicleRegistrationNumber.GetNumber(command);
            //Then: I get ''
            string expected = string.Empty;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Given_Provided_No_Command_Then_Get_EmptyString()
        {
            //Given: command as ''
            string command = string.Empty;
            //When: I call VehicleRegistrationNumber object
            string result = _vehicleRegistrationNumber.GetNumber(command);
            //Then: I get ''
            string expected = string.Empty;
            Assert.AreEqual(expected, result);
        }
    }
}
