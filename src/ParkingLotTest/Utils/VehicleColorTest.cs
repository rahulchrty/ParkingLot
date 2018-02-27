using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.BusinessInterfaces;
using ParkingLot.Business;

namespace ParkingLotTest.Utils
{
    [TestClass]
    public class VehicleColorTest
    {
        private IVehicleColor _vehicleColor;
        [TestInitialize]
        public void SetUp()
        {
            _vehicleColor = new VehicleColor();
        }
        [TestMethod]
        public void Given_color_With_command_as_black()
        {
            //Given: command as 'registration_numbers_for_cars_with_colour black'
            string command = "registration_numbers_for_cars_with_colour black";
            //When: I call VehicleColor object
            string result = _vehicleColor.GetColor(command);
            //Then: I get 'black'
            string expected = "black";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Given_No_car_color()
        {
            //Given: command as 'registration_numbers_for_cars_with_colour'
            string command = "registration_numbers_for_cars_with_colour";
            //When: I call VehicleColor object
            string result = _vehicleColor.GetColor(command);
            //Then: I get empty string
            Assert.AreEqual(string.Empty, result);
        }
        [TestMethod]
        public void Given_Command_as_EmptyString()
        {
            //Given: command as ''
            string command = string.Empty;
            //When: I call VehicleColor object
            string result = _vehicleColor.GetColor(command);
            //Then: I get empty string
            Assert.AreEqual(string.Empty, result);
        }
        [TestMethod]
        public void Given_Command_With_PrifixAndPotFix_Spaces_And_No_Color()
        {
            //Given: command as '  registration_numbers_for_cars_with_colour  '
            string command = string.Empty;
            //When: I call VehicleColor object
            string result = _vehicleColor.GetColor(command);
            //Then: I get empty string
            Assert.AreEqual(string.Empty, result);
        }
    }
}
